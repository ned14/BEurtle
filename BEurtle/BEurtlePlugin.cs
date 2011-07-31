using System;
using System.Runtime.InteropServices;
using Interop.BugTraqProvider;
using System.Windows.Forms;

namespace BEurtle
{
    public class BEIssue
    {
        public string uuid { get; set; }
        public string shortname { get; set; }
        public string summary { get; set; }
        public string severity { get; set; }
        public string status { get; set; }
        public BEIssue(string shortname)
        {
            this.shortname = shortname;
        }
    }

    [ComVisible(true), ClassInterface(ClassInterfaceType.None), Guid("233c8c6b-00ac-4e21-89fd-a66a9c10cedb"), ProgId("BEurtle")]
    public sealed class BEurtlePlugin : IBugTraqProvider
    {
        public string BEcmdpath="be.bat";
        public bool ValidateParameters(IntPtr hParentWnd, string parameters)
        {
            return true;
        }
        public string GetLinkText(IntPtr hParentWnd, string parameters)
        {
            return "Bugs, Bugs, Bugs!";
        }
        public string GetCommitMessage(IntPtr hParentWnd, string parameters, string commonRoot, string[] pathList, string originalMessage)
        {
            try
            {
                var form = new IssuesForm(this, commonRoot, originalMessage);
                if (form.ShowDialog() != DialogResult.OK)
                    return originalMessage;
                var issues = form.selectedIssues();
                if (issues.Count == 0)
                    return originalMessage;
                string result = originalMessage+"\n\n";
                foreach (var issue in issues)
                    result += "* Issue " + issue.shortname + " (" + issue.summary + ") fixed.\n";
                return result;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                throw;
            }
        }
    }
}
