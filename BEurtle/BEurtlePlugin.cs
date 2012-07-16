using System;
using System.Runtime.InteropServices;
using Interop.BugTraqProvider;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Xml.XPath;
using System.Diagnostics;
using System.Xml;
using System.Collections.Specialized;
using System.Text;

namespace BEurtle
{
    public class WindowSettings : nedprod.WindowSettings
    {
        public WindowSettings(Form form) : base(form) { }
        protected override string CompanyId() { return "ned Productions Limited"; }
        protected override string AppId() { return "BEurtle"; }
    }
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

    public enum ShowCommentCountType { DontShow, ShowEasy, ShowAll };
    public class ParseParameters
    {
        private BEurtlePlugin plugin;
        public string BEPath="", DefaultAuthor="";
        public bool DumpHTML=true;
        public string DumpHTMLPath="";
        public bool AddCommitAsComment = true, FilterOutClosedIssues=false;
        public bool UseBEXML = false, CacheBEXML = true;
        public ShowCommentCountType ShowCommentCount=ShowCommentCountType.ShowEasy;
        public ParseParameters(BEurtlePlugin plugin, IWin32Window hwnd, string parameters, bool fillindefaults=true)
        {
            this.plugin = plugin;
            string[] pars = parameters.Split('&');
            foreach (var par in pars)
            {
                if (par.StartsWith("BEPath="))
                    BEPath = par.Substring(7);
                else if (par.StartsWith("DefaultAuthor="))
                    DefaultAuthor = par.Substring(14);
                else if (par.StartsWith("DumpHTML="))
                    DumpHTML = bool.Parse(par.Substring(9));
                else if (par.StartsWith("DumpHTMLPath="))
                    DumpHTMLPath = par.Substring(13);
                else if (par.StartsWith("AddCommitAsComment="))
                    AddCommitAsComment = bool.Parse(par.Substring(19));
                else if (par.StartsWith("FilterOutClosedIssues="))
                    FilterOutClosedIssues = bool.Parse(par.Substring(22));
                else if (par.StartsWith("UseBEXML="))
                    UseBEXML = bool.Parse(par.Substring(9));
                else if(par.StartsWith("ShowCommentCount="))
                    switch (par.Substring(17))
                    {
                        case "DontShow":
                            ShowCommentCount = ShowCommentCountType.DontShow;
                            break;
                        case "ShowEasy":
                            ShowCommentCount = ShowCommentCountType.ShowEasy;
                            break;
                        case "ShowAll":
                            ShowCommentCount = ShowCommentCountType.ShowAll;
                            break;
                    }
                else if (par.StartsWith("CacheBEXML="))
                    CacheBEXML = bool.Parse(par.Substring(11));
            }
            if (fillindefaults) FillInDefaults(hwnd);
        }
        public void FillInDefaults(IWin32Window hwnd)
        {
            if (BEPath.Length == 0)
            {
                // Try the embedded copy first, then python
                string mylocation;
                using (RegistryKey r=Registry.ClassesRoot.OpenSubKey(@"CLSID\{233C8C6B-00AC-4E21-89FD-A66A9C10CEDB}\InprocServer32"))
                    mylocation=r.GetValue("CodeBase").ToString().Substring(8);
                mylocation=Path.GetDirectoryName(mylocation);
                while(mylocation.Length>0 && !Directory.Exists(mylocation+@"\dist"))
                    mylocation = Path.GetDirectoryName(mylocation);
                if (mylocation.Length > 0)
                {
                    if (File.Exists(mylocation + @"\dist\be.exe"))
                        BEPath = mylocation + @"\dist\be.exe";
                }
                // Still haven't found a BE, so try python
                if(BEPath.Length==0)
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
                        MessageBox.Show(hwnd, "Failed to find a copy of BE and failed to read what executes Python files. Is Python installed?\nError was: " + ex.Message);
                    }
                }
            }
            if (DefaultAuthor.Length == 0)
            {
                if (plugin.VCSAuthor != null && plugin.VCSAuthor.Length > 0)
                {
                    DefaultAuthor = plugin.VCSAuthor;
                }
                else
                {
                    StringBuilder fullname_ = new StringBuilder(1024);
                    string fullname, login, machine;
                    uint l = (uint)fullname_.Capacity;
                    int code = Win32.GetUserNameEx((int)Win32.EXTENDED_NAME_FORMAT.NameDisplay, fullname_, ref l);
                    fullname = fullname_.ToString();
                    if (fullname == "") fullname = "<set full name in user account settings>";
                    login = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\')[1];
                    machine = System.Net.Dns.GetHostEntry("").HostName;
                    DefaultAuthor = "\"" + fullname + "\" <" + login + "@" + machine + ">";
                }
            }
            if (DumpHTMLPath.Length == 0)
                DumpHTMLPath = "BEBugsAsHTML";
        }
    }

    [ComVisible(true), ClassInterface(ClassInterfaceType.None), Guid("233c8c6b-00ac-4e21-89fd-a66a9c10cedb"), ProgId("BEurtle")]
    public sealed class BEurtlePlugin : IBugTraqProvider2
    {
        public string rootpath="";
        public ParseParameters parameters;
        public XPathDocument issues;
        public string VCSInfo="", VCSAuthor=null;
        // Keep a list of these for autocomplete
        public AutoCompleteStringCollection creators, reporters, assigneds, authors;

        public string[] callBEcmd(string BErepopath, string[] arguments, string[] inputs = null)
        {
            string[] outputs = new string[arguments.Length];
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                for (var i = 0; i < arguments.Length; i++)
                {
                    string arguments_ = arguments[i];
                    if (BErepopath.StartsWith("http://"))
                        arguments_ = "--repo " + BErepopath + " " + arguments_;
                    var process = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            CreateNoWindow = true,
                            FileName = parameters.BEPath,
                            Arguments = arguments_,
                            RedirectStandardInput = true,
                            RedirectStandardOutput = true,
                            RedirectStandardError = true,
                            StandardErrorEncoding=Encoding.UTF8,
                            StandardOutputEncoding=Encoding.UTF8,
                            UseShellExecute = false,
                            WorkingDirectory = BErepopath.StartsWith("http://") ? rootpath : BErepopath
                        }
                    };
                    process.StartInfo.EnvironmentVariables.Add("BE_ENCODING", "UTF-8");
                    process.StartInfo.EnvironmentVariables.Add("BE_INPUT_ENCODING", "UTF-8");
                    process.StartInfo.EnvironmentVariables.Add("BE_OUTPUT_ENCODING", "UTF-8");
                    try
                    {
                        string output = "", error = "";
                        process.OutputDataReceived += new DataReceivedEventHandler((sender, e) => output += e.Data);
                        process.ErrorDataReceived += new DataReceivedEventHandler((sender, e) => error += e.Data);
                        if (!process.Start()) throw new Exception(parameters.BEPath + " not found");
                        process.BeginOutputReadLine();
                        process.BeginErrorReadLine();
                        if (inputs != null && inputs[i].Length > 0)
                            process.StandardInput.Write(inputs[i]);
                        process.StandardInput.Close();
                        process.WaitForExit();
                        outputs[i] = output + error;
                    }
                    catch (Exception e)
                    {
                        outputs[i] = e.Message;
                    }
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            return outputs;
        }

        public bool loadIssues(IWin32Window hwnd, string rootdir = null)
        {
            string arguments = "list --status=all --xml";
            if (rootdir == null) rootdir = rootpath;
            issues = null;
            creators = new AutoCompleteStringCollection();
            reporters = new AutoCompleteStringCollection();
            assigneds=new AutoCompleteStringCollection();
            authors = new AutoCompleteStringCollection();
            string xml = "unknown error";
            if (rootdir.EndsWith(".xml"))
            {   // This is a raw BE XML dump
                using (var fs = new StreamReader(rootdir))
                    xml = fs.ReadToEnd();
                VCSInfo = "Direct load of XML database";
            }
            else
            {
                FileInfo idcache=new FileInfo(rootdir + "\\.be\\id-cache"), bexmlcache=new FileInfo(rootdir + "\\.be\\bexml.xml");
                if (parameters.CacheBEXML && bexmlcache.Exists && (!idcache.Exists || bexmlcache.LastWriteTimeUtc > idcache.LastWriteTimeUtc) && nedprod.LastModifiedInDirs.FindLastModifiedSince(new DirectoryInfo(rootdir+"\\.be"), bexmlcache.LastWriteTimeUtc).Count==0)
                {   // There is a bexml.xml cache which isn't older than the id-cache nor BE repo contents, so we can use that
                    using (var fs = new StreamReader(rootdir + "\\.be\\bexml.xml"))
                        xml = fs.ReadToEnd();
                    VCSInfo = "Used up-to-date XML cache in .be\\bexml.xml";
                }
                else
                {
                    xml = callBEcmd(rootdir, new string[1] { arguments })[0];
                    string VCSVersion = callBEcmd(rootdir, new string[1] { "vcs version" })[0];
                    if (-1 == VCSVersion.IndexOf("RESULT:"))
                        VCSInfo = "VCS: Error reading VCS version";
                    else
                        VCSInfo = "VCS: " + VCSVersion.Substring(VCSVersion.IndexOf("RESULT:") + 8);
                    if (parameters.CacheBEXML && xml.StartsWith("<?xml version=\"1.0\" "))
                        using (var fs = new StreamWriter(rootdir + "\\.be\\bexml.xml"))
                            fs.Write(xml);
                }
            }
            if (!xml.StartsWith("<?xml version=\"1.0\" "))
            {
                VCSInfo = xml;
                if (xml.IndexOf("Connection Error") >= 0 && !rootdir.StartsWith("http://"))
                {
                    if (DialogResult.Yes == MessageBox.Show(hwnd, "BE repository not found at " + rootdir + ". Would you like me to create it there for you?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        xml = callBEcmd(rootdir, new string[1] { "init" })[0];
                        MessageBox.Show(hwnd, xml);
                        return loadIssues(hwnd);
                    }
                }
                else
                    MessageBox.Show(hwnd, xml);
            }
            else
            {
                issues = new XPathDocument(new XmlTextReader(new StringReader(xml)));
                creators.AddRange(XMLitems(issues, "creator", true, true).ToArray());
                reporters.AddRange(XMLitems(issues, "reporter", true, true).ToArray());
                assigneds.AddRange(XMLitems(issues, "assigned", true, true).ToArray());
                authors.AddRange(XMLitems(issues, "author", true, true).ToArray());
                return true;
            }
            return false;
        }

        public List<BEIssue> findIssues(string[] shortnames)
        {
            var ret = new List<BEIssue>();
            if (shortnames.Length > 0)
            {
                foreach (var shortname in shortnames)
                {
                    var item = new BEIssue(shortname);
                    var node = issues.CreateNavigator().SelectSingleNode("/be-xml/bug[string(short-name)='" + shortname + "']");
                    if (node != null)
                    {
                        item.uuid = node.SelectSingleNode("uuid").ToString();
                        item.summary = node.SelectSingleNode("summary").ToString();
                        item.severity = node.SelectSingleNode("severity").ToString();
                        item.status = node.SelectSingleNode("status").ToString();
                    }
                    ret.Add(item);
                }
            }
            return ret;
        }

        public List<string> XMLitems(XPathDocument xml, string item, bool unique = false, bool sorted=false)
        {
            List<string> ret = new List<string>();
            Dictionary<string, int> uniqueness = new Dictionary<string, int>();
            var nodes_iter = xml.CreateNavigator().SelectDescendants(item, "", true);
            while(nodes_iter.MoveNext())
            {
                if (unique)
                {
                    if (uniqueness.ContainsKey(nodes_iter.Current.Value))
                        continue;
                    uniqueness.Add(nodes_iter.Current.Value, 0);
                }
                ret.Add(nodes_iter.Current.Value);
            }
            if (sorted)
                ret.Sort();
            return ret;
        }

        public List<string> walkDirectoryTree(DirectoryInfo root, string[] filters)
        {
            var ret = new List<string>();
            foreach (var filter in filters)
            {
                try
                {
                    FileInfo[] files = root.GetFiles(filter);
                    foreach (var file in files)
                        ret.Add(file.FullName);
                }
                catch (UnauthorizedAccessException)
                {
                }
            }
            var dirs = root.GetDirectories();
            foreach(var dir in dirs)
                ret.AddRange(walkDirectoryTree(dir, filters));
            return ret;
        }

        public void writeHTML(Win32Window hwnd, string rootdir)
        {
            try
            {
                if (parameters.DumpHTML)
                {
                    if (parameters.DumpHTMLPath.Length < 3) throw new Exception("DumpHTMLPath has no length. This would delete your entire repo!");
                    try
                    {
                        Directory.Delete(rootdir + "\\" + parameters.DumpHTMLPath, true);
                    }
                    catch (Exception)
                    {
                    }
                    string result = callBEcmd(rootdir, new string[1] { "html -o \"" + parameters.DumpHTMLPath + "\"" })[0];
                    if (Directory.Exists(rootdir + "\\" + parameters.DumpHTMLPath))
                    {
                        // Strip out the generated date
                        var htmlfiles = walkDirectoryTree(new DirectoryInfo(rootdir + "\\" + parameters.DumpHTMLPath), new string[1] { "*.html" });
                        foreach (var htmlfile in htmlfiles)
                        {
                            var fh = new StreamReader(htmlfile);
                            var f = fh.ReadToEnd();
                            fh.Close();
                            int idx = f.LastIndexOf("<p>Generated by <a href=\"http://www.bugseverywhere.org/\">");
                            if (idx >= 0)
                            {
                                idx = f.IndexOf("</a>", idx);
                                var eidx = f.IndexOf("</p>", idx);
                                f = f.Remove(idx + 4, eidx - idx - 4);
                                var fo = new StreamWriter(htmlfile);
                                fo.Write(f);
                                fo.Close();
                            }
                        }
                        // Add any new HTML files
                        result = callBEcmd(rootdir, new string[1] { "vcs add \"" + parameters.DumpHTMLPath + "\"" })[0];
                        if (result.Contains("ERROR:"))
                            throw new Exception(result);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(hwnd, "Error when writing HTML: " + e.ToString(), "Error from BEurtle", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool ValidateParameters(IntPtr hParentWnd, string parameters)
        {
            var hwnd = hParentWnd != IntPtr.Zero ? new Win32Window(hParentWnd) : null;
            this.parameters = new ParseParameters(this, hwnd, parameters);
            return true;
        }
        public string GetLinkText(IntPtr hParentWnd, string parameters)
        {
            var hwnd = hParentWnd != IntPtr.Zero ? new Win32Window(hParentWnd) : null;
            this.parameters = new ParseParameters(this, hwnd, parameters);
            return "Bugs, Bugs, Bugs!";
        }
        public string GetCommitMessage(IntPtr hParentWnd, string parameters, string commonRoot, string[] pathList, string originalMessage)
        {
            var hwnd=hParentWnd != IntPtr.Zero ? new Win32Window(hParentWnd) : null;
            try
            {
                rootpath = commonRoot;
                this.parameters = new ParseParameters(this, hwnd, parameters);
                if (VCSAuthor == null)
                {
                    string VCSUser_ = callBEcmd(rootpath, new string[1] { "vcs get_user_id" })[0];
                    if (-1 != VCSUser_.IndexOf("RESULT:"))
                        this.parameters.DefaultAuthor = VCSAuthor = VCSUser_.Substring(VCSUser_.IndexOf("RESULT:") + 8);
                }
                var form = new IssuesForm(this, commonRoot, originalMessage);
                if (form.ShowDialog(hwnd) != DialogResult.OK)
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
                MessageBox.Show(hwnd, e.ToString());
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
            var hwnd = hParentWnd != IntPtr.Zero ? new Win32Window(hParentWnd) : null;
            rootpath = commonRoot;
            this.parameters = new ParseParameters(this, hwnd, parameters);
            return null;
        }
        public string OnCommitFinished(IntPtr hParentWnd, string commonRoot, string[] pathList, string logMessage, int revision)
        {
            var hwnd = hParentWnd != IntPtr.Zero ? new Win32Window(hParentWnd) : null;
            rootpath = commonRoot;
            if (logMessage.ToLower().IndexOf("fixed") >= 0)
            {
                var regexObj = new Regex(@"[\s;,.]([0-9a-f]{3}/[0-9a-f]{3})[\s;,.]", RegexOptions.IgnoreCase);
                var matches = regexObj.Matches(logMessage);

                if (matches.Count > 0)
                {
                    bool modified = false;
                    if(parameters==null) parameters = new ParseParameters(this, hwnd, "");
                    if (VCSAuthor == null)
                    {
                        string VCSUser_ = callBEcmd(rootpath, new string[1] { "vcs get_user_id" })[0];
                        if (-1 != VCSUser_.IndexOf("RESULT:"))
                            this.parameters.DefaultAuthor = VCSAuthor = VCSUser_.Substring(VCSUser_.IndexOf("RESULT:") + 8);
                    }
                    if (issues == null && !loadIssues(hwnd))
                        throw new Exception("Failed to load BE issues for checking commit message against");
                    var openstatuses=new List<string>() { "unconfirmed", "open", "assigned", "test" };
                    var itemsdone = new List<string>();
                    foreach (Match match in matches)
                    {
                        string shortname = match.Groups[1].ToString();
                        if (!itemsdone.Contains(shortname))
                        {
                            BEIssue issue = findIssues(new string[1] { shortname })[0];
                            if (openstatuses.Contains(issue.status))
                            {
                                var result = MessageBox.Show(hwnd, "Commit message implies issue " + shortname + " (" + issue.summary + ")\nwith status " + issue.status + " is now fixed. Shall I mark it as fixed for you?", "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                                if (DialogResult.Cancel == result)
                                    break;
                                else if (DialogResult.Yes == result)
                                {
                                    string[] outputs;
                                    if(parameters.AddCommitAsComment)
                                        outputs = callBEcmd(rootpath, new string[1] { "comment -a \"BEurtle auto issue closer\" " + shortname + " -" }, new string[1] { "Fixed in commit "+revision.ToString("x")+" (decimal "+revision.ToString()+")" });
                                    outputs = callBEcmd(rootpath, new string[1] { "status fixed " + shortname });
                                    if (outputs[0].Length > 0) MessageBox.Show(hwnd, "Command output: " + outputs[0]);
                                    else
                                    {
                                        itemsdone.Add(shortname);
                                        modified = true;
                                    }
                                }
                            }
                        }
                    }
                    if (modified)
                        writeHTML(hwnd, rootpath);
                }
            }
            return null;
        }
        public bool HasOptions()
        {
            return true;
        }
        public string ShowOptionsDialog(IntPtr hParentWnd, string parameters)
        {
            var dialog = new OptionsDialog(this, parameters);

            return dialog.ShowDialog(hParentWnd!=IntPtr.Zero ? new Win32Window(hParentWnd) : null) == DialogResult.OK ? dialog.parameters : parameters;
        }
    }
    public class Win32Window : IWin32Window
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
