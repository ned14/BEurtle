using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BEurtle
{
    public partial class OptionsDialog : Form
    {
        private BEurtlePlugin plugin;
        public string parameters, BEPath="";
        bool initialising = false;
        bool DefaultAuthorChanged = false, DumpHTMLPathChanged = false;
        public OptionsDialog(BEurtlePlugin plugin, string parameters)
        {
            this.plugin = plugin;
            this.parameters = parameters;
            InitializeComponent();
            BoxDefaultAuthor.AutoCompleteCustomSource = plugin.authors;
            CheckUseBEXML.Enabled = false;
        }

        private void OptionsDialog_Shown(object sender, EventArgs e)
        {
            try
            {
                initialising = true;
                DefaultAuthorChanged = false;
                BoxDefaultAuthor.Text = "";
                BoxDefaultAuthor.ForeColor = Color.FromArgb(0, 0, 0);
                DumpHTMLPathChanged = false;
                BoxDumpHTMLPath.Text = "";
                BoxDumpHTMLPath.ForeColor = Color.FromArgb(0, 0, 0);
                if (parameters != null)
                {
                    ParseParameters parsed = new ParseParameters(plugin, this, parameters, false);
                    if (parsed.DefaultAuthor.Length > 0)
                        DefaultAuthorChanged = true;
                    else
                        BoxDefaultAuthor.ForeColor = Color.FromArgb(192, 192, 192);
                    if (parsed.DumpHTMLPath.Length > 0)
                        DumpHTMLPathChanged = true;
                    else
                        BoxDumpHTMLPath.ForeColor = Color.FromArgb(192, 192, 192);
                    parsed.FillInDefaults(this);

                    BEPath = parsed.BEPath;
                    BoxDefaultAuthor.Text = parsed.DefaultAuthor;
                    CheckDumpHTML.Checked = parsed.DumpHTML;
                    BoxDumpHTMLPath.Text = parsed.DumpHTMLPath;
                    CheckAddCommitAsComment.Checked = parsed.AddCommitAsComment;
                    CheckFilterOutClosedIssues.Checked = parsed.FilterOutClosedIssues;
                    CheckBEXMLCache.Checked = parsed.CacheBEXML;
                    switch(parsed.ShowCommentCount)
                    {
                        case ShowCommentCountType.DontShow:
                            CheckShowCommentCount.CheckState = CheckState.Unchecked;
                            break;
                        case ShowCommentCountType.ShowEasy:
                            CheckShowCommentCount.CheckState = CheckState.Indeterminate;
                            break;
                        case ShowCommentCountType.ShowAll:
                            CheckShowCommentCount.CheckState = CheckState.Checked;
                            break;
                    }
                    CheckUseBEXML.Checked = parsed.UseBEXML;
                }
                else
                {
                    this.Text = "About BEurtle";
                    OptionsGroupBox.Enabled = false;
                    ButtonReset.Visible = false;
                    ButtonCancel.Visible = false;
                }
            }
            finally
            {
                initialising = false;
            }
        }

        private void OptionsDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            parameters = "";
            if (BEPath.Length > 0) parameters += "&BEPath=" + BEPath;
            if (DefaultAuthorChanged) parameters += "&DefaultAuthor=" + BoxDefaultAuthor.Text;
            parameters += "&DumpHTML=" + CheckDumpHTML.Checked.ToString();
            if (DumpHTMLPathChanged) parameters += "&DumpHTMLPath=" + BoxDumpHTMLPath.Text;
            parameters += "&AddCommitAsComment=" + CheckAddCommitAsComment.Checked.ToString();
            parameters += "&FilterOutClosedIssues=" + CheckFilterOutClosedIssues.Checked.ToString();
            parameters += "&CacheBEXML=" + CheckBEXMLCache.Checked.ToString();
            switch (CheckShowCommentCount.CheckState)
            {
                case CheckState.Unchecked:
                    parameters += "&ShowCommentCount=DontShow";
                    break;
                case CheckState.Indeterminate:
                    parameters += "&ShowCommentCount=ShowEasy";
                    break;
                case CheckState.Checked:
                    parameters += "&ShowCommentCount=ShowAll";
                    break;
            }
            parameters += "&UseBEXML=" + CheckUseBEXML.Checked.ToString();
        }

        private void BoxBEPath_TextChanged(object sender, EventArgs e)
        {
            if (!initialising)
            {
                DefaultAuthorChanged = true;
                BoxDefaultAuthor.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }

        private void BoxDumpHTMLPath_TextChanged(object sender, EventArgs e)
        {
            if (!initialising)
            {
                DumpHTMLPathChanged = true;
                BoxDumpHTMLPath.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }

        private void Link_nedproductions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.nedproductions.biz/");
        }

        private void LinkGithubIssues_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://github.com/ned14/BEurtle/issues");
        }

        private void LinkHomepage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.nedprod.com/programs/Win32/BEurtle/");
        }

        private void LinkDonate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.nedprod.com/index.html#donate");
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            parameters = "";
            OptionsDialog_Shown(null, null);
        }
    }
}
