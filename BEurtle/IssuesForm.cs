using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Xml;
using System.Xml.XPath;
using System.Runtime.InteropServices;

namespace BEurtle
{
    public partial class IssuesForm : Form
    {
        private BEurtlePlugin plugin;
        private string BEroot, baseComment;

        public IssuesForm(BEurtlePlugin plugin, string commonRoot, string baseComment)
        {
            this.plugin = plugin;
            this.BEroot=commonRoot;
            this.baseComment = baseComment;
            /*if (!BEroot.StartsWith("http://") && !BEroot.EndsWith(".xml"))
            {
                while (!Directory.Exists(BEroot + Path.DirectorySeparatorChar + ".be"))
                {
                    BEroot = Path.GetDirectoryName(BEroot);
                    if (BEroot == null) throw new Exception("Couldn't find a BE issues repository in this directory hierarchy");
                }
            }*/
            InitializeComponent();
            BERepoLocation.Text = BEroot;
            IssuesList.Sort(IssuesList.Columns[1], ListSortDirection.Ascending);
        }

        private void IssuesList_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Index == 1)
            {
                var order = new List<string>() { "unconfirmed", "open", "assigned", "test", "fixed", "closed", "wontfix" };
                e.SortResult = order.FindIndex(x => x == (string) e.CellValue1)-order.FindIndex(x => x== (string) e.CellValue2);
                e.Handled = true;
            }
            else if (e.Column.Index == 2)
            {
                var order = new List<string>() { "target", "wishlist", "minor", "serious", "critical", "fatal" };
                e.SortResult = order.FindIndex(x => x == (string)e.CellValue1) - order.FindIndex(x => x == (string)e.CellValue2);
                e.Handled = true;
            }
        }

        private void loadIssues()
        {
            string focuseditem=null;
            if (IssuesList.SelectedRows.Count > 0)
                focuseditem = IssuesList.SelectedRows[0].Cells[0].ToString();
            try
            {
                Win32.SendMessage(this.Handle, Win32.WM_SETREDRAW, false, 0);
                IssuesList.Rows.Clear();
                ButtonOk.Enabled = false;
                NewIssue.Enabled = false;
                DeleteIssue.Enabled = false;
                BoxStatus.Enabled = false;

                if (plugin.loadIssues())
                {
                    var issues_nav = plugin.issues.CreateNavigator();
                    XPathNodeIterator iter = (XPathNodeIterator)issues_nav.Select("/be-xml/bug");
                    foreach (XPathNavigator issue in iter)
                    {
                        //MessageBox.Show(issue.OuterXml);
                        var row = new DataGridViewRow();
                        row.Cells.Add(new DataGridViewTextBoxCell());
                        row.Cells[0].Value = issue.Evaluate("string(short-name)");

                        row.Cells.Add(new DataGridViewTextBoxCell());
                        string status = (string)(row.Cells[1].Value = issue.Evaluate("string(status)"));
                        if (status == "closed" || status == "fixed" || status == "wontfix")
                            row.Cells[1].Style.BackColor = Color.FromArgb(128, 255, 128);
                        else if (status == "unconfirmed")
                            row.Cells[1].Style.BackColor = Color.FromArgb(255, 255, 128);
                        else if (status == "open" || status == "assigned")
                            row.Cells[1].Style.BackColor = Color.FromArgb(255, 128, 128);

                        row.Cells.Add(new DataGridViewTextBoxCell());
                        string severity = (string)(row.Cells[2].Value = issue.Evaluate("string(severity)"));
                        if (severity == "target")
                            row.Cells[2].Style.BackColor = Color.FromArgb(128, 255, 128);
                        else if (severity == "serious")
                            row.Cells[2].Style.BackColor = Color.FromArgb(255, 255, 128);
                        else if (severity == "critical" || severity == "fatal")
                            row.Cells[2].Style.BackColor = Color.FromArgb(255, 128, 128);

                        row.Cells.Add(new DataGridViewTextBoxCell());
                        string created = (string)issue.Evaluate("string(created)");
                        if (created == "")
                            row.Cells[3].Value = "unknown";
                        else
                        {
                            try
                            {
                                row.Cells[3].Value = DateTime.Parse(created).ToString("u");
                            }
                            catch (Exception)
                            {
                                row.Cells[3].Value = "BAD";
                            }
                        }

                        row.Cells.Add(new DataGridViewTextBoxCell());
                        row.Cells[4].Value = issue.Evaluate("string(summary)");

                        IssuesList.Rows.Add(row);
                    }
                    NewIssue.Enabled = true;
                    ButtonOk.Enabled = true;
                    if (IssuesList.Rows.Count > 0)
                    {
                        DeleteIssue.Enabled = true;
                        BoxStatus.Enabled = true;
                        if (focuseditem != null)
                        {
                            foreach (DataGridViewRow item in IssuesList.Rows)
                            {
                                if (item.Cells[0].ToString() == focuseditem)
                                {
                                    IssuesList.Rows[0].Selected = false;
                                    item.Selected = true;
                                    IssuesList_SelectionChanged(null, null);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                Win32.SendMessage(this.Handle, Win32.WM_SETREDRAW, true, 0);
                this.Refresh();
            }
        }

        private void changesMade()
        {
            if (!BERepoLocation.Text.StartsWith("http://")) plugin.writeHTML(BERepoLocation.Text);
            loadIssues();
        }

        private void IssuesForm_Shown(object sender, EventArgs e)
        {
            loadIssues();
        }

        private XPathNodeIterator shortnamesToXML(string[] shortnames)
        {
            string query="";
            foreach(var shortname in shortnames)
            {
                if(query!="") query+=" or ";
                query+="string(short-name)='"+shortname+"'";
            }
            var issues_nav = plugin.issues.CreateNavigator();
            return (XPathNodeIterator)issues_nav.Select("/be-xml/bug[" + query + "]");
        }

        private void writeOutIssue(IssueDetail issue)
        {
            string[] arguments = new string[1], inputs = new string[1], outputs;
            arguments[0] = "import_xml -";
            inputs[0] = "<be-xml>\n";
            inputs[0] += issue.toXML();
            inputs[0] += "</be-xml>";
            //MessageBox.Show("Would call: " + arguments[0] + "\nwith: " + inputs[0]);
            outputs = plugin.callBEcmd(BERepoLocation.Text, arguments, inputs);
            if (outputs[0].Length > 0) MessageBox.Show("Command output: " + outputs[0]);
            changesMade();
        }

        private void editIssue(string shortname)
        {
            var iter = shortnamesToXML(new string[1] { shortname });
            iter.MoveNext();
            var detail = new IssueDetail(iter.Current);
            if (DialogResult.OK == detail.ShowDialog() && detail.changed)
                writeOutIssue(detail);
        }

        private void IssuesList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(IssuesList.Rows.Count>0 && e.RowIndex>=0 && e.RowIndex<IssuesList.Rows.Count)
            {
                string shortname = (string) IssuesList.Rows[e.RowIndex].Cells[0].Value;
                if (shortname != null)
                    editIssue(shortname);
            }
        }

        private void IssuesList_KeyDown(object sender, KeyEventArgs e)
        {
            if (IssuesList.Rows.Count > 0 && e.KeyCode==Keys.Enter)
            {
                string shortname=(string) IssuesList.SelectedRows[0].Cells[0].Value;
                e.Handled = true;
                if (shortname != null)
                    editIssue(shortname);
            }
        }

        private void NewIssue_Click(object sender, EventArgs e)
        {
            var detail = new IssueDetail(null);
            if (DialogResult.OK == detail.ShowDialog())
                writeOutIssue(detail);
        }

        private void DeleteIssue_Click(object sender, EventArgs e)
        {
            string[] arguments=selectedIssuesAsShortnames(), outputs;
            for (var i = 0; i < arguments.Length; i++)
                arguments[i] = "remove " + arguments[i];
            string l="";
            foreach(string s in arguments)
                l+=s+"\n";
            //MessageBox.Show("Would do: "+l);
            outputs = plugin.callBEcmd(BERepoLocation.Text, arguments);
            if (outputs[0].Length > 0) MessageBox.Show("Command output: " + outputs[0]);
            changesMade();
        }

        private void BERepoLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                loadIssues();
            }
        }

        private void BERepoLocationBrowse_Click(object sender, EventArgs e)
        {
            var open = new FolderBrowserDialog();
            open.SelectedPath = BERepoLocation.Text;
            if (DialogResult.OK == open.ShowDialog())
            {
                BERepoLocation.Text = open.SelectedPath;
                loadIssues();
            }
        }

        public string[] selectedIssuesAsShortnames()
        {
            if (IssuesList.Rows.Count > 0)
            {
                string[] shortnames = new string[IssuesList.SelectedRows.Count];
                for (var i = 0; i < IssuesList.SelectedRows.Count; i++)
                    shortnames[i] = (string)IssuesList.SelectedRows[i].Cells[0].Value;
                return shortnames;
            }
            return new string[0];
        }

        public List<BEIssue> selectedIssues()
        {
            string[] shortnames = selectedIssuesAsShortnames();
            return plugin.findIssues(shortnames);
        }

        private bool setting_selection = false;
        private void IssuesList_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                setting_selection = true;
                if (IssuesList.SelectedRows.Count > 0)
                {
                    DeleteIssue.Enabled = true;
                    BoxStatus.SelectedItem = "";
                    BoxStatus.Enabled = true;
                    for (var i = 0; i < IssuesList.SelectedRows.Count; i++)
                    {
                        if (i == 0)
                            BoxStatus.SelectedItem = IssuesList.SelectedRows[i].Cells[1].Value;
                        else if ((string) BoxStatus.SelectedItem != (string) IssuesList.SelectedRows[i].Cells[1].Value)
                            BoxStatus.SelectedItem = "";
                    }
                }
                else
                {
                    DeleteIssue.Enabled = false;
                    BoxStatus.SelectedItem = "";
                    BoxStatus.Enabled = false;
                }
            }
            finally
            {
                setting_selection = false;
            }
        }

        private void BoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!setting_selection)
            {
                string[] arguments=selectedIssuesAsShortnames(), outputs;
                for (var i = 0; i < arguments.Length; i++)
                    arguments[i] = "status " + BoxStatus.SelectedItem + " " + arguments[i];
                string l="";
                foreach(string s in arguments)
                    l+=s+"\n";
                //MessageBox.Show("Would do: "+l);
                outputs = plugin.callBEcmd(BERepoLocation.Text, arguments);
                if(outputs[0].Length>0) MessageBox.Show("Command output: " + outputs[0]);
                changesMade();
            }
        }

    }

}
