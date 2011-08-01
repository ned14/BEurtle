using System;
using System.Runtime.InteropServices;
using Interop.BugTraqProvider;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;

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

    public class ParseParameters
    {
        public string BEPath="";
        public bool DumpHTML=true;
        public string DumpHTMLPath="";
        public ParseParameters(string parameters, bool fillindefaults=true)
        {
            string[] pars = parameters.Split('&');
            foreach (var par in pars)
            {
                if (par.StartsWith("BEPath="))
                    BEPath = par.Substring(7);
                else if (par.StartsWith("DumpHTML="))
                    DumpHTML = bool.Parse(par.Substring(9));
                else if (par.StartsWith("DumpHTMLPath="))
                    DumpHTMLPath = par.Substring(13);
            }
            if (fillindefaults) FillInDefaults();
        }
        public void FillInDefaults()
        {
            if (BEPath.Length == 0)
            {
                try
                {
                    RegistryKey r = Registry.ClassesRoot.OpenSubKey(@"Python.File\shell\open\command");
                    string pythonexe = r.GetValue("").ToString();
                    r.Close();
                    pythonexe = pythonexe.Substring(1, pythonexe.IndexOf('"', 1) - 1);
                    BEPath = Path.GetDirectoryName(pythonexe) + "\\Scripts\\be.bat";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to read what executes Python files. Is Python installed?\nError was: " + ex.Message);
                }
            }
            if (DumpHTMLPath.Length == 0)
                DumpHTMLPath = "BEBugsAsHTML";
        }
    }

    [ComVisible(true), ClassInterface(ClassInterfaceType.None), Guid("233c8c6b-00ac-4e21-89fd-a66a9c10cedb"), ProgId("BEurtle")]
    public sealed class BEurtlePlugin : IBugTraqProvider2
    {
        public string BEcmdpath="be.bat";
        public ParseParameters parameters;
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
                this.parameters = new ParseParameters(parameters);
                var form = new IssuesForm(this, commonRoot, originalMessage);
                if (form.ShowDialog(hParentWnd != IntPtr.Zero ? new Win32Window(hParentWnd) : null) != DialogResult.OK)
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
                MessageBox.Show(hParentWnd != IntPtr.Zero ? new Win32Window(hParentWnd) : null, e.ToString());
                throw;
            }
        }
        public string GetCommitMessage2(IntPtr hParentWnd, string parameters, string commonUrl, string commonRoot, string[] pathList, string originalMessage, string bugID, out string bugIDOut, out string[] revPropNames, out string[] revPropValues)
        {
            bugIDOut = bugID;

            // If no revision properties are to be set, 
            // the plug-in MUST return empty arrays. 
            revPropNames = new string[0];
            revPropValues = new string[0];

            return GetCommitMessage(hParentWnd, parameters, commonRoot, pathList, originalMessage);
        }
        public string CheckCommit(IntPtr hParentWnd, string parameters, string commonUrl, string commonRoot, string[] pathList, string commitMessage)
        {
            this.parameters = new ParseParameters(parameters);
            return null;
        }
        public string OnCommitFinished(IntPtr hParentWnd, string commonRoot, string[] pathList, string logMessage, int revision)
        {
            return null;
        }
        public bool HasOptions()
        {
            return true;
        }
        public string ShowOptionsDialog(IntPtr hParentWnd, string parameters)
        {
            var dialog = new OptionsDialog(parameters);

            return dialog.ShowDialog(hParentWnd!=IntPtr.Zero ? new Win32Window(hParentWnd) : null) == DialogResult.OK ? dialog.parameters : parameters;
        }
    }
    internal class Win32Window : IWin32Window
    {
        IntPtr hwnd;
        public Win32Window(IntPtr hwnd)
        {
            this.hwnd = hwnd;
        }

        public IntPtr Handle
        {
            get { return hwnd; }
        }
    }
}
