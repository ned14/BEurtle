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
        private List<string> status_filters=new List<string>();
        private List<string> severity_filters = new List<string>();
        private List<string> created_filters = new List<string>();
        private List<string> summary_filters = new List<string>();

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
            this.KeyPreview = true;
            BERepoLocation.Text = BEroot;
            IssuesList.Sort(IssuesList.Columns[1], ListSortDirection.Ascending);
            if (plugin.parameters.FilterOutClosedIssues)
            {
                if (!status_filters.Contains("closed")) status_filters.Add("closed");
                if (!status_filters.Contains("fixed")) status_filters.Add("fixed");
                if (!status_filters.Contains("wontfix")) status_filters.Add("wontfix");
            }
        }

        private static List<string> status_order = new List<string>() { "unconfirmed", "open", "assigned", "test", "fixed", "closed", "wontfix" };
        private static List<string> severity_order = new List<string>() { "target", "wishlist", "minor", "serious", "critical", "fatal" };
        private void IssuesList_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            string status1   = (string) IssuesList.Rows[e.RowIndex1].Cells[1].Value;
            string severity1 = (string) IssuesList.Rows[e.RowIndex1].Cells[2].Value;
            string status2   = (string) IssuesList.Rows[e.RowIndex2].Cells[1].Value;
            string severity2 = (string) IssuesList.Rows[e.RowIndex2].Cells[2].Value;
            int status_result = status_order.FindIndex(x => x == status1) - status_order.FindIndex(x => x == status2);
            int severity_result = severity_order.FindIndex(x => x == severity1) - severity_order.FindIndex(x => x == severity2);
            if (e.Column.Index == 1)
            {
                if (status_result != 0)
                    e.SortResult = status_result;
                else if (severity_result != 0)
                    e.SortResult = severity_result;
                else
                    e.SortResult = ((string) IssuesList.Rows[e.RowIndex1].Cells[3].Value).CompareTo((string) IssuesList.Rows[e.RowIndex2].Cells[3].Value);
                e.Handled = true;
            }
            else if (e.Column.Index == 2)
            {
                if (severity_result != 0)
                    e.SortResult = severity_result;
                else if (status_result != 0)
                    e.SortResult = status_result;
                else
                    e.SortResult = ((string)IssuesList.Rows[e.RowIndex1].Cells[3].Value).CompareTo((string)IssuesList.Rows[e.RowIndex2].Cells[3].Value);
                e.Handled = true;
            }
        }

        private void loadIssues(bool refreshData=true)
        {
            string focuseditem=null;
            if (IssuesList.SelectedRows.Count > 0)
                focuseditem = IssuesList.SelectedRows[0].Cells[0].ToString();
            bool doredraw = (!refreshData || plugin.loadIssues(this, BERepoLocation.Text));
            try
            {
                Win32.SendMessage(this.Handle, Win32.WM_SETREDRAW, false, 0);
                SuspendLayout();
                IssuesList.Rows.Clear();
                ButtonOk.Enabled = false;
                NewIssue.Enabled = false;
                DeleteIssue.Enabled = false;
                VCSInfo.Text = plugin.VCSInfo;

                if(doredraw)
                {
                    var issues_nav = plugin.issues.CreateNavigator();
                    XPathNodeIterator iter = (XPathNodeIterator)issues_nav.Select("/be-xml/bug");
                    foreach (XPathNavigator issue in iter)
                    {
                        //MessageBox.Show(this, issue.OuterXml);
                        string shortname=(string) issue.Evaluate("string(short-name)"), status=(string) issue.Evaluate("string(status)"), severity=(string) issue.Evaluate("string(severity)"), created, summary=(string) issue.Evaluate("string(summary)");
                        created=(string) issue.Evaluate("string(created)");
                        if (created == "")
                            created = "unknown";
                        else
                        {
                            try
                            {
                                created = DateTime.Parse(created).ToString("u");
                            }
                            catch (Exception)
                            {
                                created = "BAD";
                            }
                        }
                        if (status_filters.Count > 0)
                        {
                            bool filter = false;
                            foreach (var f in status_filters)
                                if (status.Contains(f)) { filter = true; break; }
                            if (filter) continue;
                        }
                        if (severity_filters.Count > 0)
                        {
                            bool filter = false;
                            foreach (var f in severity_filters)
                                if (severity.Contains(f)) { filter = true; break; }
                            if (filter) continue;
                        }
                        if (status_filters.Count > 0)
                        {
                            bool filter = false;
                            foreach (var f in status_filters)
                                if (status.Contains(f)) { filter = true; break; }
                            if (filter) continue;
                        }
                        if (created_filters.Count > 0)
                        {
                            bool filter = false;
                            foreach (var f in created_filters)
                                if (created.Contains(f)) { filter = true; break; }
                            if (filter) continue;
                        }
                        if (summary_filters.Count > 0)
                        {
                            bool filter = false;
                            foreach (var f in summary_filters)
                                if (summary.Contains(f)) { filter = true; break; }
                            if (filter) continue;
                        }
                        var row = new DataGridViewRow();
                        row.Cells.Add(new DataGridViewTextBoxCell());
                        row.Cells[0].Value = shortname;

                        row.Cells.Add(new DataGridViewTextBoxCell());
                        row.Cells[1].Value = status;
                        if (status == "closed" || status == "fixed" || status == "wontfix")
                            row.Cells[1].Style.BackColor = Color.FromArgb(128, 255, 128);
                        else if (status == "unconfirmed")
                            row.Cells[1].Style.BackColor = Color.FromArgb(255, 255, 128);
                        else if (status == "open" || status == "assigned")
                            row.Cells[1].Style.BackColor = Color.FromArgb(255, 128, 128);

                        row.Cells.Add(new DataGridViewTextBoxCell());
                        row.Cells[2].Value = severity;
                        if (severity == "target")
                            row.Cells[2].Style.BackColor = Color.FromArgb(128, 255, 128);
                        else if (severity == "serious")
                            row.Cells[2].Style.BackColor = Color.FromArgb(255, 255, 128);
                        else if (severity == "critical" || severity == "fatal")
                            row.Cells[2].Style.BackColor = Color.FromArgb(255, 128, 128);

                        row.Cells.Add(new DataGridViewTextBoxCell());
                        row.Cells[3].Value = created;

                        row.Cells.Add(new DataGridViewTextBoxCell());
                        row.Cells[4].Value = summary;

                        IssuesList.Rows.Add(row);
                    }
                    NewIssue.Enabled = true;
                    ButtonOk.Enabled = true;
                    if (IssuesList.Rows.Count > 0)
                    {
                        DeleteIssue.Enabled = true;
                        if (focuseditem != null)
                        {
                            foreach (DataGridViewRow item in IssuesList.Rows)
                            {
                                if (item.Cells[0].ToString() == focuseditem)
                                {
                                    IssuesList.Rows[0].Selected = false;
                                    item.Selected = true;
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
                this.ResumeLayout();
                Refresh();
            }
        }

        private void changesMade()
        {
            if (!BERepoLocation.Text.StartsWith("http://")) plugin.writeHTML(new Win32Window(this.Handle), BERepoLocation.Text);
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
            //MessageBox.Show(this, "Would call: " + arguments[0] + "\nwith: " + inputs[0]);
            outputs = plugin.callBEcmd(BERepoLocation.Text, arguments, inputs);
            if (outputs[0].Length > 0) MessageBox.Show(this, "Command output: " + outputs[0]);
            changesMade();
        }

        private void editIssue(string shortname)
        {
            var iter = shortnamesToXML(new string[1] { shortname });
            iter.MoveNext();
            var detail = new IssueDetail(iter.Current, plugin.creators, plugin.reporters, plugin.assigneds, plugin.authors);
            if (DialogResult.OK == detail.ShowDialog(this) && detail.changed)
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
            var detail = new IssueDetail(null, plugin.creators, plugin.reporters, plugin.assigneds, plugin.authors);
            if (DialogResult.OK == detail.ShowDialog(this))
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
            //MessageBox.Show(this, "Would do: "+l);
            outputs = plugin.callBEcmd(BERepoLocation.Text, arguments);
            if (outputs[0].Length > 0) MessageBox.Show(this, "Command output: " + outputs[0]);
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
            if (DialogResult.OK == open.ShowDialog(this))
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

        private void IssuesList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && !IssuesList.Rows[e.RowIndex].Selected)
            {
                while (IssuesList.SelectedRows.Count > 0)
                    IssuesList.SelectedRows[0].Selected = false;
                IssuesList.Rows[e.RowIndex].Selected = true;
            }
        }

        private void fillInMenuItems(ToolStripMenuItem menu, List<string> items, EventHandler changedhandler, KeyPressEventHandler enterhandler)
        {
            while(menu.DropDownItems.Count>3)
                menu.DropDownItems.RemoveAt(3);
            foreach (var item in items)
            {
                var tb = new ToolStripTextBox();
                tb.Text = item;
                tb.TextChanged += changedhandler;
                tb.KeyPress += enterhandler;
                menu.DropDownItems.Add(tb);
            }
        }
        bool contextmenu_initialising = false;
        bool contextmenu_fixupclosing = false;
        private void contextMenu_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                contextmenu_initialising = true;
                contextMenu.SuspendLayout();

                FromStatusTextBox.Text = "";
                fillInMenuItems(fromStatusToolStripMenuItem, status_filters, new EventHandler(FromStatusTextBox_TextChanged), new KeyPressEventHandler(FromStatusTextBox_KeyPress));
                FromSeverityTextBox.Text = "";
                fillInMenuItems(fromSeverityToolStripMenuItem, severity_filters, new EventHandler(FromSeverityTextBox_TextChanged), new KeyPressEventHandler(FromSeverityTextBox_KeyPress));
                FromCreatedTextBox.Text = "";
                fillInMenuItems(fromCreatedToolStripMenuItem, created_filters, new EventHandler(FromCreatedTextBox_TextChanged), new KeyPressEventHandler(FromCreatedTextBox_KeyPress));
                FromSummaryTextBox.Text = "";
                fillInMenuItems(fromSummaryToolStripMenuItem, summary_filters, new EventHandler(FromSummaryTextBox_TextChanged), new KeyPressEventHandler(FromSummaryTextBox_KeyPress));

                filterOutToolStripMenuItem.Checked = (status_filters.Count > 0 || severity_filters.Count > 0 || created_filters.Count > 0 || summary_filters.Count > 0);
                allClosedItemsToolStripMenuItem.Checked = (status_filters.Contains("closed") && status_filters.Contains("fixed") && status_filters.Contains("wontfix"));
                allNotSeriousToolStripMenuItem.Checked = (severity_filters.Contains("target") && severity_filters.Contains("wishlist") && severity_filters.Contains("minor"));

                if (!contextmenu_fixupclosing)
                {   // Hack in such that any attempts to auto-close the filter menu are prevented
                    filterOutToolStripMenuItem.DropDown.Closing += new ToolStripDropDownClosingEventHandler(filterOutToolStripMenuItem_Closing);
                    fromStatusToolStripMenuItem.DropDown.Closing += new ToolStripDropDownClosingEventHandler(filterOutToolStripMenuItem_Closing);
                    fromSeverityToolStripMenuItem.DropDown.Closing += new ToolStripDropDownClosingEventHandler(filterOutToolStripMenuItem_Closing);
                    fromCreatedToolStripMenuItem.DropDown.Closing += new ToolStripDropDownClosingEventHandler(filterOutToolStripMenuItem_Closing);
                    fromSummaryToolStripMenuItem.DropDown.Closing += new ToolStripDropDownClosingEventHandler(filterOutToolStripMenuItem_Closing);
                    contextmenu_fixupclosing = true;
                }
            }
            finally
            {
                contextMenu.ResumeLayout();
                contextmenu_initialising = false;
            }
        }
        private void filterOutToolStripMenuItem_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked)
            {
                e.Cancel = true;
            }
        }

        private void changeStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] arguments = selectedIssuesAsShortnames(), outputs;
            for (var i = 0; i < arguments.Length; i++)
                arguments[i] = "status " + ((ToolStripMenuItem) sender).Text + " " + arguments[i];
            //string l = "";
            //foreach (string s in arguments)
            //    l += s + "\n";
            //MessageBox.Show(this, "Would do: "+l);
            outputs = plugin.callBEcmd(BERepoLocation.Text, arguments);
            if (outputs[0].Length > 0) MessageBox.Show(this, "Command output: " + outputs[0]);
            changesMade();
        }

        private void changeSeverityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] arguments = selectedIssuesAsShortnames(), outputs;
            for (var i = 0; i < arguments.Length; i++)
                arguments[i] = "severity " + ((ToolStripMenuItem)sender).Text + " " + arguments[i];
            //string l = "";
            //foreach (string s in arguments)
            //    l += s + "\n";
            //MessageBox.Show(this, "Would do: "+l);
            outputs = plugin.callBEcmd(BERepoLocation.Text, arguments);
            if (outputs[0].Length > 0) MessageBox.Show(this, "Command output: " + outputs[0]);
            changesMade();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            status_filters.Clear();
            severity_filters.Clear();
            created_filters.Clear();
            summary_filters.Clear();
            loadIssues(false);
            contextMenu_Opening(sender, null);
        }

        private void allClosedItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (allClosedItemsToolStripMenuItem.Checked)
            {
                status_filters.RemoveAll(x => x == "closed");
                status_filters.RemoveAll(x => x == "fixed");
                status_filters.RemoveAll(x => x == "wontfix");
            }
            else
            {
                if (!status_filters.Contains("closed")) status_filters.Add("closed");
                if (!status_filters.Contains("fixed")) status_filters.Add("fixed");
                if (!status_filters.Contains("wontfix")) status_filters.Add("wontfix");
            }
            loadIssues(false);
            contextMenu_Opening(sender, null);
        }

        private void allNotSeriousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (allNotSeriousToolStripMenuItem.Checked)
            {
                severity_filters.RemoveAll(x => x == "target");
                severity_filters.RemoveAll(x => x == "wishlist");
                severity_filters.RemoveAll(x => x == "minor");
            }
            else
            {
                if (!severity_filters.Contains("target")) severity_filters.Add("target");
                if (!severity_filters.Contains("wishlist")) severity_filters.Add("wishlist");
                if (!severity_filters.Contains("minor")) severity_filters.Add("minor");
            }
            loadIssues(false);
            contextMenu_Opening(sender, null);
        }

        private void FromStatusClear_Click(object sender, EventArgs e)
        {
            status_filters.Clear();
            loadIssues(false);
            contextMenu_Opening(sender, null);
        }

        private void FromSeverityClear_Click(object sender, EventArgs e)
        {
            severity_filters.Clear();
            loadIssues(false);
            contextMenu_Opening(sender, null);
        }

        private void FromCreatedClear_Click(object sender, EventArgs e)
        {
            created_filters.Clear();
            loadIssues(false);
            contextMenu_Opening(sender, null);
        }

        private void FromSummaryClear_Click(object sender, EventArgs e)
        {
            summary_filters.Clear();
            loadIssues(false);
            contextMenu_Opening(sender, null);
        }

        private void setFilters(ToolStripMenuItem menuitem, List<string> filters)
        {
            if (!contextmenu_initialising)
            {
                var j = 0;
                for (var i = 2; i < menuitem.DropDownItems.Count; i++)
                {
                    var v = menuitem.DropDownItems[i].Text;
                    if (v.Length > 0)
                    {
                        if (filters.Count == j)
                            filters.Add(v);
                        else
                            filters[j] = v;
                        j++;
                    }
                }
                if (filters.Count > j) filters.RemoveRange(j, filters.Count - j);
                loadIssues(false);
            }
        }
        private void FromStatusTextBox_TextChanged(object sender, EventArgs e)
        {
            setFilters(fromStatusToolStripMenuItem, status_filters);
        }
        private void FromStatusTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 127)
                FromStatusTextBox_TextChanged(sender, e);
            else if (e.KeyChar == 13)
                contextMenu_Opening(sender, null);
        }

        private void FromSeverityTextBox_TextChanged(object sender, EventArgs e)
        {
            setFilters(fromSeverityToolStripMenuItem, severity_filters);
        }
        private void FromSeverityTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 127)
                FromSeverityTextBox_TextChanged(sender, e);
            else if (e.KeyChar == 13)
                contextMenu_Opening(sender, null);
        }

        private void FromCreatedTextBox_TextChanged(object sender, EventArgs e)
        {
            setFilters(fromCreatedToolStripMenuItem, created_filters);
        }
        private void FromCreatedTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 127)
                FromCreatedTextBox_TextChanged(sender, e);
            else if (e.KeyChar == 13)
                contextMenu_Opening(sender, null);
        }

        private void FromSummaryTextBox_TextChanged(object sender, EventArgs e)
        {
            setFilters(fromSummaryToolStripMenuItem, summary_filters);
        }
        private void FromSummaryTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 127)
                FromSummaryTextBox_TextChanged(sender, e);
            else if (e.KeyChar == 13)
                contextMenu_Opening(sender, null);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new OptionsDialog(null).ShowDialog(this);
        }

        private void IssuesForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                loadIssues();
                e.Handled = true;
            }
        }

        private void IssuesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            new WindowSettings(this).save();
        }

        private void IssuesForm_Load(object sender, EventArgs e)
        {
            new WindowSettings(this).load();
        }


    }

}
