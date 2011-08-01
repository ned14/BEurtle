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
        public string parameters;
        bool initialising = false;
        bool BEPathChanged = false, DumpHTMLPathChanged = false;
        public OptionsDialog(string parameters)
        {
            this.parameters = parameters;
            InitializeComponent();
        }

        private void OptionsDialog_Shown(object sender, EventArgs e)
        {
            try
            {
                initialising = true;
                BEPathChanged = false;
                BoxBEPath.Text = "";
                BoxBEPath.ForeColor = Color.FromArgb(0, 0, 0);
                DumpHTMLPathChanged = false;
                BoxDumpHTMLPath.Text = "";
                BoxDumpHTMLPath.ForeColor = Color.FromArgb(0, 0, 0);
                ParseParameters parsed = new ParseParameters(parameters, false);
                if(parsed.BEPath.Length>0)
                    BEPathChanged = true;
                else
                    BoxBEPath.ForeColor = Color.FromArgb(192, 192, 192);
                if(parsed.DumpHTMLPath.Length>0)
                    DumpHTMLPathChanged = true;
                else
                    BoxDumpHTMLPath.ForeColor = Color.FromArgb(192, 192, 192);
                parsed.FillInDefaults();

                BoxBEPath.Text = parsed.BEPath;
                CheckDumpHTML.Checked = parsed.DumpHTML;
                BoxDumpHTMLPath.Text = parsed.DumpHTMLPath;
            }
            finally
            {
                initialising = false;
            }
        }

        private void OptionsDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            parameters = "";
            if (BEPathChanged) parameters += "&BEPath=" + BoxBEPath.Text;
            parameters += "&DumpHTML=" + CheckDumpHTML.Checked.ToString();
            if (DumpHTMLPathChanged) parameters += "&DumpHTMLPath=" + BoxDumpHTMLPath.Text;
        }

        private void BoxBEPath_TextChanged(object sender, EventArgs e)
        {
            if (!initialising)
            {
                BEPathChanged = true;
                BoxBEPath.ForeColor = Color.FromArgb(0, 0, 0);
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
