using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.XPath;
using System.Xml;
using System.Runtime.InteropServices;
using System.Security.Principal;
using mshtml;
using System.IO;
using System.Collections.Specialized;

namespace BEurtle
{
    public partial class IssueDetail : Form
    {
        private XPathNavigator issue;
        internal class uuid_xpath
        {
            public string Item1;
            public XPathNavigator Item2;
            public uuid_xpath(string Item1, XPathNavigator Item2)
            {
                this.Item1 = Item1;
                this.Item2 = Item2;
            }
        }
        private Dictionary<TreeNode, uuid_xpath> commentToUUID = new Dictionary<TreeNode, uuid_xpath>();
        public bool changed { get; set; }
        private IHTMLDocument2 doc;

        public IssueDetail(XPathNavigator issue, AutoCompleteStringCollection creators, AutoCompleteStringCollection reporters, AutoCompleteStringCollection assigneds, AutoCompleteStringCollection authors)
        {
            this.issue = issue;
            InitializeComponent();
            CommentBody.DocumentText = "<!DOCTYPE html><html><body></body></html>";

            BoxCreator.AutoCompleteCustomSource = creators;
            BoxReporter.AutoCompleteCustomSource = reporters;
            BoxAssigned.AutoCompleteCustomSource = assigneds;
            CommentAuthor.AutoCompleteCustomSource = authors;
            if (issue == null)
            {
                StringBuilder fullname_=new StringBuilder(1024);
                string fullname, login, machine;
                uint l=(uint) fullname_.Capacity;
                int code=Win32.GetUserNameEx((int) Win32.EXTENDED_NAME_FORMAT.NameDisplay, fullname_, ref l);
                fullname = fullname_.ToString();
                if (fullname == "") fullname = "<set full name in user account settings>";
                login = WindowsIdentity.GetCurrent().Name.Split('\\')[1];
                machine = System.Net.Dns.GetHostEntry("").HostName;
                BoxCreator.Text = BoxReporter.Text = "\"" + fullname + "\" <" + login + "@" + machine + ">";
            }
        }

        private void setEditable(bool v)
        {
            BoxCreator.ReadOnly = !v;
            BoxReporter.ReadOnly = !v;
            BoxAssigned.ReadOnly = !v;
            BoxSeverity.Enabled = v;
            BoxStatus.Enabled = v;
            BoxSummary.ReadOnly = !v;
            ButtonEdit.Enabled = !v;
            ButtonOK.Enabled = !v || (BoxSummary.Text.Length > 0);
            if (v) ButtonCancel.Show();
            else ButtonCancel.Hide();
        }

        private string fixUp(string text)
        {
            text = text.Replace("<", "&lt;");
            text = text.Replace(">", "&gt;");
            text = text.Replace("\n", "\n<br />\n");
            return text+"<br />";
        }

        public string toXML()
        {
            XmlDocument document = new XmlDocument();
            var root = document.CreateElement("bug");
            document.AppendChild(root);
            XmlNode node;
            if (BoxUUID.Text.Length > 0)
            {
                root.AppendChild((node = document.CreateElement("uuid")));
                node.AppendChild(document.CreateTextNode(BoxUUID.Text));
            }
            if (BoxShortName.Text.Length > 0)
            {
                root.AppendChild((node = document.CreateElement("short-name")));
                node.AppendChild(document.CreateTextNode(BoxShortName.Text));
            }
            /*if (BoxCreated.Text.Length > 0)
            {
                root.AppendChild((node = document.CreateElement("created")));
                node.AppendChild(document.CreateTextNode(BoxCreated.Text));
            }*/
            if (BoxCreator.Text.Length > 0)
            {
                root.AppendChild((node = document.CreateElement("creator")));
                node.AppendChild(document.CreateTextNode(BoxCreator.Text));
            }
            if (BoxReporter.Text.Length > 0)
            {
                root.AppendChild((node = document.CreateElement("reporter")));
                node.AppendChild(document.CreateTextNode(BoxReporter.Text));
            }
            if (BoxAssigned.Text.Length > 0)
            {
                root.AppendChild((node = document.CreateElement("assigned")));
                node.AppendChild(document.CreateTextNode(BoxAssigned.Text));
            }
            if (BoxSeverity.SelectedIndex >= 0)
            {
                root.AppendChild((node = document.CreateElement("severity")));
                node.AppendChild(document.CreateTextNode(BoxSeverity.Text));
            }
            if (BoxStatus.SelectedIndex >= 0)
            {
                root.AppendChild((node = document.CreateElement("status")));
                node.AppendChild(document.CreateTextNode(BoxStatus.Text));
            }
            if (BoxSummary.Text.Length > 0)
            {
                root.AppendChild((node = document.CreateElement("summary")));
                node.AppendChild(document.CreateTextNode(BoxSummary.Text));
            }
            return document.OuterXml;
        }

        private void IssueDetail_Shown(object sender, EventArgs e)
        {
            if (issue != null)
            {
                BoxUUID.Text = issue.Evaluate("string(uuid)").ToString();
                BoxShortName.Text = issue.Evaluate("string(short-name)").ToString();
                BoxCreated.Text = issue.Evaluate("string(created)").ToString();
                BoxCreator.Text = issue.Evaluate("string(creator)").ToString();
                BoxReporter.Text = issue.Evaluate("string(reporter)").ToString();
                BoxAssigned.Text = issue.Evaluate("string(assigned)").ToString();
                BoxSeverity.SelectedItem = issue.Evaluate("string(severity)").ToString();
                BoxStatus.SelectedItem = issue.Evaluate("string(status)").ToString();
                BoxSummary.Text = issue.Evaluate("string(summary)").ToString();

                // Iterate all root comments and append
                Comments.Nodes.Clear();
                commentToUUID.Clear();
                var UUIDtoComment = new Dictionary<string, TreeNode>();
                XPathNodeIterator comments = (XPathNodeIterator)issue.Select("comment[not(in-reply-to)]");
                foreach (XPathNavigator comment in comments)
                {
                    var node=new TreeNode(comment.SelectSingleNode("short-name").ToString()+" "+comment.SelectSingleNode("author").ToString()+" "+comment.SelectSingleNode("date").ToString());
                    var uuid=new uuid_xpath(comment.Evaluate("string(uuid)").ToString(), comment);
                    UUIDtoComment.Add(uuid.Item1, node);
                    commentToUUID.Add(node, uuid);
                    Comments.Nodes.Add(node);
                }
                // Recursively apply replies to comments
                XPathNodeIterator replies_ = (XPathNodeIterator)issue.Select("comment[in-reply-to]");
                var replies = new List<uuid_xpath>();
                foreach (XPathNavigator reply in replies_)
                    replies.Add(new uuid_xpath(reply.Evaluate("string(in-reply-to)").ToString(), reply));
                while (replies.Count > 0)
                {
                    var oldcount = replies.Count;
                    for(var i=0; i<replies.Count; )
                    {
                        uuid_xpath reply = replies[i];
                        TreeNode commentnode = UUIDtoComment[reply.Item1];
                        if (commentnode !=null)
                        {
                            var node = new TreeNode(reply.Item2.SelectSingleNode("short-name").ToString() + " " + reply.Item2.SelectSingleNode("author").ToString() + " " + reply.Item2.SelectSingleNode("date").ToString());
                            var uuid=new uuid_xpath(reply.Item2.Evaluate("string(uuid)").ToString(), reply.Item2);
                            UUIDtoComment.Add(uuid.Item1, node);
                            commentToUUID.Add(node, uuid);
                            commentnode.Nodes.Add(node);
                            replies.Remove(reply);
                        }
                        else i++;
                    }
                    if (oldcount == replies.Count)
                    {
                        // BE repo is corrupt, so just add as root items and exit
                        foreach (uuid_xpath reply in replies)
                        {
                            var node = new TreeNode("Corrupted BE repo in-reply-to-unknown(" + reply.Item1 + ") " + reply.Item2.SelectSingleNode("short-name").ToString() + " " + reply.Item2.SelectSingleNode("author").ToString() + " " + reply.Item2.SelectSingleNode("date").ToString());
                            var uuid = new uuid_xpath(reply.Item2.Evaluate("string(uuid)").ToString(), reply.Item2);
                            commentToUUID.Add(node, uuid);
                            Comments.Nodes.Add(node);
                        }
                        break;
                    }
                }
            }
            setEditable(issue == null);
            CommentAdd.Enabled = true;
            if (Comments.Nodes.Count > 0)
            {
                Commentary.Panel2.Enabled = true;
                Comments.SelectedNode = Comments.Nodes[0];
                CommentDelete.Enabled = CommentEdit.Enabled = true;
            }
        }

        private void IssueDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (doc != null)
                SaveComment();
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            setEditable(true);
            changed = true;
        }

        private void BoxSummary_TextChanged(object sender, EventArgs e)
        {
            ButtonOK.Enabled = (BoxSummary.Text.Length > 0);
        }

        private void Comments_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (doc != null)
                SaveComment();
            XPathNavigator comment = commentToUUID[Comments.SelectedNode].Item2;
            CommentAuthor.Text = comment.SelectSingleNode("author").ToString();
            CommentDate.Text = comment.SelectSingleNode("date").ToString();
            var commentbody = comment.SelectSingleNode("body").ToString();
            var commenttype = comment.SelectSingleNode("content-type").ToString();
            if (commenttype.StartsWith("text/"))
            {
                if (CommentBodyView.TabPages[0] != CommentBodyViewHTML)
                {
                    CommentBodyView.TabPages.Insert(0, CommentBodyViewRaw);
                    CommentBodyView.TabPages.Insert(0, CommentBodyViewHTML);
                    CommentBodyView.SelectedIndex = 0;
                    CommentEdit.Enabled = true;
                }
            }
            DraggableIcon.Items[0].Text = commenttype;
            DraggableIcon.Items[0].ImageIndex = 0;
            switch (commenttype)
            {
                case "text/plain":
                    // Hack the text into HTML
                    commentbody = fixUp(commentbody);
                    break;
                case "text/html":
                    break;
                default:
                    if (CommentBodyView.TabPages[0] == CommentBodyViewHTML)
                    {
                        CommentBodyView.TabPages.Remove(CommentBodyViewHTML);
                        CommentBodyView.TabPages.Remove(CommentBodyViewRaw);
                        CommentEdit.Enabled = false;
                    }
                    if(commenttype.StartsWith("image"))
                        DraggableIcon.Items[0].ImageIndex = 1;
                    else if(commenttype.StartsWith("application/zip"))
                        DraggableIcon.Items[0].ImageIndex = 2;
                    break;
            }
            CommentBody.Document.Body.InnerHtml = commentbody;
        }
        [DllImport(@"urlmon.dll", CharSet = CharSet.Auto)]
        private extern static System.UInt32 FindMimeFromData(
            System.UInt32 pBC,
            [MarshalAs(UnmanagedType.LPStr)] System.String pwzUrl,
            [MarshalAs(UnmanagedType.LPArray)] byte[] pBuffer,
            System.UInt32 cbSize,
            [MarshalAs(UnmanagedType.LPStr)] System.String pwzMimeProposed,
            System.UInt32 dwMimeFlags,
            out System.UInt32 ppwzMimeOut,
            System.UInt32 dwReserverd
        );
        private void LoadFromFile(Stream s)
        {
            byte[] buffer = new byte[s.Length];
            s.Read(buffer, 0, buffer.Length);
            UInt32 mimetype_;
            FindMimeFromData(0, null, buffer, 256, null, 0, out mimetype_, 0);
            IntPtr mimetypeptr = new IntPtr(mimetype_);
            string mimetype = Marshal.PtrToStringUni(mimetypeptr);
            Marshal.FreeCoTaskMem(mimetypeptr);
            if (mimetype.StartsWith("text/"))
            {
                var textreader = new StreamReader(new MemoryStream(buffer));
                var text = textreader.ReadToEnd();
                if (mimetype == "text/plain") text = fixUp(text);
                CommentBodyRaw.Text = CommentBody.Document.Body.InnerHtml = text;
            }
            else
            {
                var text = Convert.ToBase64String(buffer);
                CommentBodyRaw.Text = CommentBody.Document.Body.InnerHtml = text;
            }
            DraggableIcon.Items[0].Text = mimetype;
            DraggableIcon.Items[0].ImageIndex = 0;
            if (mimetype.StartsWith("image/"))
                DraggableIcon.Items[0].ImageIndex = 1;
            else if (mimetype.StartsWith("application/zip"))
                DraggableIcon.Items[0].ImageIndex = 2;
        }
        private void SaveAsFile(Stream s)
        {
            XPathNavigator comment = commentToUUID[Comments.SelectedNode].Item2;
            var commentbody = comment.SelectSingleNode("body").ToString();
            var commenttype = comment.SelectSingleNode("content-type").ToString();
            if (commenttype.StartsWith("text/"))
            {
                byte[] towrite = Encoding.UTF8.GetBytes(commentbody);
                s.Write(towrite, 0, towrite.Length);
            }
            else
            {
                byte[] towrite = Convert.FromBase64String(commentbody);
                s.Write(towrite, 0, towrite.Length);
            }
        }

        private void CommentBodyView_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == CommentBodyViewRaw)
            {
                CommentBodyRaw.Text = CommentBody.Document.Body.InnerHtml;
            }
            else if(e.TabPage!=CommentBodyViewFile)
            {
                CommentBody.Document.Body.InnerHtml = CommentBodyRaw.Text;
            }
        }

        private void CommentEdit_Click(object sender, EventArgs e)
        {
            // Bind the MSHTML COM control and turn on editing
            doc = CommentBody.Document.DomDocument as IHTMLDocument2;
            doc.designMode = "On";

            HTMLEditorControls.Enabled = true;
            CommentBodyRaw.Enabled = true;
            LoadAttachment.Enabled = true;
            CommentAuthor.ReadOnly = false;
            CommentAdd.Visible = CommentDelete.Visible = CommentEdit.Visible = false;
            Application.DoEvents(); // Let MSHTML get around to binding
            Comments_AfterSelect(null, null);
            DraggableIcon.Items[0].Text = "text/html";
        }
        private void CommentEditCancel_Click(object sender, EventArgs e)
        {
            doc.designMode = "Off";
            doc = null;

            HTMLEditorControls.Enabled = false;
            CommentBodyRaw.Enabled = false;
            LoadAttachment.Enabled = false;
            CommentAuthor.ReadOnly = true;
            CommentAdd.Visible = CommentDelete.Visible = CommentEdit.Visible = true;
            Application.DoEvents(); // Let MSHTML get around to unbinding
            Comments_AfterSelect(null, null);
        }

        // List of commands is available at http://msdn.microsoft.com/en-us/library/ms533049(v=vs.85).aspx
        private void ApplyBold_Click(object sender, EventArgs e)
        {
            CommentBody.Document.ExecCommand("Bold", false, null);
            CommentBody.Focus();
            CommentBody.Document.ActiveElement.Focus();
        }

        private void ApplyItalics_Click(object sender, EventArgs e)
        {
            CommentBody.Document.ExecCommand("Italic", false, null);
            CommentBody.Focus();
            CommentBody.Document.ActiveElement.Focus();
        }

        private void ApplyAlignLeft_Click(object sender, EventArgs e)
        {
            CommentBody.Document.ExecCommand("JustifyLeft", false, null);
            CommentBody.Focus();
            CommentBody.Document.ActiveElement.Focus();
        }

        private void ApplyAlignMiddle_Click(object sender, EventArgs e)
        {
            CommentBody.Document.ExecCommand("JustifyCenter", false, null);
            CommentBody.Focus();
            CommentBody.Document.ActiveElement.Focus();
        }

        private void ApplyAlignRight_Click(object sender, EventArgs e)
        {
            CommentBody.Document.ExecCommand("JustifyRight", false, null);
            CommentBody.Focus();
            CommentBody.Document.ActiveElement.Focus();
        }

        private void ApplyAlignJustify_Click(object sender, EventArgs e)
        {
            CommentBody.Document.ExecCommand("JustifyFull", false, null);
            CommentBody.Focus();
            CommentBody.Document.ActiveElement.Focus();
        }

        private void ApplyUnorderedList_Click(object sender, EventArgs e)
        {
            CommentBody.Document.ExecCommand("InsertUnorderedList", false, null);
            CommentBody.Focus();
            CommentBody.Document.ActiveElement.Focus();
        }

        private void ApplyOrderedList_Click(object sender, EventArgs e)
        {
            CommentBody.Document.ExecCommand("InsertOrderedList", false, null);
            CommentBody.Focus();
            CommentBody.Document.ActiveElement.Focus();
        }

        private void ApplyIndent_Click(object sender, EventArgs e)
        {
            CommentBody.Document.ExecCommand("Indent", false, null);
            CommentBody.Focus();
            CommentBody.Document.ActiveElement.Focus();
        }

        private void ApplyOutdent_Click(object sender, EventArgs e)
        {
            CommentBody.Document.ExecCommand("Outdent", false, null);
            CommentBody.Focus();
            CommentBody.Document.ActiveElement.Focus();
        }

        private void LoadAttachment_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == openFileDialog.ShowDialog())
            {
                using (var s = openFileDialog.OpenFile())
                {
                    LoadFromFile(s);
                }
            }
        }

        private static readonly Dictionary<string, string> MIMETypesDictionary = new Dictionary<string, string>
          {
            {"application/atom+xml", "atom"},
            {"application/octet-stream", "bin"},
            {"application/mac-compactpro", "cpt"},
            {"application/msword", "doc"},
            {"application/xml-dtd", "dtd"},
            {"application/andrew-inset", "ez"},
            {"application/srgs", "gram"},
            {"application/srgs+xml", "grxml"},
            {"application/mac-binhex40", "hqx"},
            {"application/mathml+xml", "mathml"},
            {"application/oda", "oda"},
            {"application/ogg", "ogg"},
            {"application/vnd.mif", "mif"},
            {"application/pdf", "pdf"},
            {"application/vnd.ms-powerpoint", "ppt"},
            {"application/postscript", "ps"},
            {"application/vnd.rn-realmedia", "rm"},
            {"application/smil", "smil"},
            {"application/voicexml+xml", "vxml"},
            {"application/vnd.wap.wbxml", "wbmxl"},
            {"application/vnd.wap.wmlc", "wmlc"},
            {"application/vnd.wap.wmlscriptc", "wmlsc"},
            {"application/xhtml+xml", "xhtml"},
            {"application/vnd.ms-excel", "xls"},                        
            {"application/xslt+xml", "xslt"},
            {"application/vnd.mozilla.xul+xml", "xul"},
            {"application/xml", "xml"},
            {"application/zip", "zip"},
            {"application/rdf+xml", "rdf"},

            {"application/x-bcpio", "bcpio"},
            {"application/x-cdlink", "vcd"},
            {"application/x-cpio", "cpio"},
            {"application/x-csh", "csh"},
            {"application/x-netcdf", "cdf"},
            {"application/x-dvi", "dvi"},
            {"application/x-director", "dxr"},
            {"application/x-chess-pgn", "pgn"},
            {"application/x-gtar", "gtar"},
            {"application/x-hdf", "hdf"},
            {"application/x-java-jnlp-file", "jnlp"},
            {"application/x-javascript", "js"},
            {"application/x-latex", "latex"},
            {"application/x-sh", "sh"},
            {"application/x-shar", "shar"},
            {"application/x-stuffit", "sit"},
            {"application/x-futuresplash", "spl"},
            {"application/x-wais-source", "src"},
            {"application/x-sv4cpio", "sv4cpio"},
            {"application/x-sv4crc", "sv4crc"},
            {"application/x-shockwave-flash", "swf"},
            {"application/x-tar", "tar"},
            {"application/x-tcl", "tcl"},
            {"application/x-tex", "tex"},
            {"application/x-texinfo", "texinfo"},
            {"application/x-troff", "tr"},
            {"application/x-troff-man", "man"},
            {"application/x-troff-me", "me"},
            {"application/x-troff-ms", "ms"},
            {"application/x-ustar", "ustar"},

            {"audio/x-aiff", "aiff"},
            {"audio/basic", "au"},
            {"audio/x-mpegurl", "m3u"},
            {"audio/mp4a-latm", "m4a"},
            {"audio/midi", "midi"},
            {"audio/mpeg", "mp3"},
            {"audio/x-pn-realaudio", "ram"},
            {"audio/x-wav", "wav"},

            {"image/bmp", "bmp"},
            {"image/cgm", "cgm"},
            {"image/vnd.djvu", "djvu"},
            {"image/gif", "gif"},
            {"image/x-icon", "ico"},
            {"image/ief", "ief"},
            {"image/jp2", "jp2"},
            {"image/jpeg", "jpg"},
            {"image/x-macpaint", "mac"},
            {"image/x-portable-bitmap", "pbm"},
            {"image/x-portable-graymap", "pgm"},
            {"image/pict", "pict"},
            {"image/png", "png"}, 
            {"image/x-portable-anymap", "pnm"},
            {"image/x-portable-pixmap", "ppm"},
            {"image/x-quicktime", "qtif"},
            {"image/x-cmu-raster", "ras"},
            {"image/x-rgb", "rgb"},
            {"image/svg+xml", "svg"},
            {"image/tiff", "tiff"},
            {"image/vnd.wap.wbmp", "wbmp"},
            {"image/x-xbitmap", "xbm"},
            {"image/x-xpixmap", "xpm"},
            {"image/x-xwindowdump", "xwd"},

            {"text/css", "css"},
            {"text/x-setext", "etx"},
            {"text/html", "html"},
            {"text/calendar", "ics"},
            {"text/rtf", "rtf"},
            {"text/richtext", "rtx"},
            {"text/sgml", "sgml"},
            {"text/tab-separated-values", "tsv"},
            {"text/plain", "txt"},
            {"text/vnd.wap.wml", "wml"},
            {"text/vnd.wap.wmlscript", "wmls"},

            {"video/x-msvideo", "avi"},
            {"video/x-dv", "dv"},
            {"video/vnd.mpegurl", "m4u"},
            {"video/x-m4v", "m4v"},
            {"video/quicktime", "mov"},
            {"video/x-sgi-movie", "movie"},
            {"video/mp4", "mp4"},
            {"video/mpeg", "mpg"},

            {"x-conference/x-cooltalk", "ice"},
            {"model/iges", "iges"},
            {"model/mesh", "mesh"},
            {"chemical/x-pdb", "pdb"},
            {"model/vrml", "vrml"},
            {"chemical/x-xyz", "xyz"}
          };
        private void SaveAttachment_Click(object sender, EventArgs e)
        {
            var ext = MIMETypesDictionary.ContainsKey(DraggableIcon.Items[0].Text) ? MIMETypesDictionary[DraggableIcon.Items[0].Text] : "bin";
            saveFileDialog.DefaultExt=ext;
            saveFileDialog.FileName = "comment." + ext;
            saveFileDialog.Filter = DraggableIcon.Items[0].Text + " (*." + ext + ")|" + ext;
            if (DialogResult.OK == saveFileDialog.ShowDialog())
            {
                using (var s = saveFileDialog.OpenFile())
                    SaveAsFile(s);
            }
        }

        private void DraggableIcon_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("TODO: Save out to a temporary file and launch");
        }

        private void DraggableIcon_ItemDrag(object sender, ItemDragEventArgs e)
        {
            var comment = commentToUUID[Comments.SelectedNode];
            var ext = MIMETypesDictionary.ContainsKey(DraggableIcon.Items[0].Text) ? MIMETypesDictionary[DraggableIcon.Items[0].Text] : "bin";
            DataObject obj = new DataObject();
            string tempfilepath = Path.GetTempPath() + "BEurtle";
            string tempfilename = tempfilepath+@"\comment-"+comment.Item1+"." +ext;
            if (!Directory.Exists(tempfilepath)) Directory.CreateDirectory(tempfilepath);
            FileStream data = new FileStream(tempfilename, FileMode.Create, FileAccess.ReadWrite, FileShare.Delete|FileShare.ReadWrite);
            try
            {
                SaveAsFile(data);
                data.Seek(0, SeekOrigin.Begin);
                if (DraggableIcon.Items[0].Text.StartsWith("text/"))
                {
                    string data_ = new StreamReader(data).ReadToEnd();
                    obj.SetText(data_, DraggableIcon.Items[0].Text == "text/html" ? TextDataFormat.Html : TextDataFormat.UnicodeText);
                }
                else if (DraggableIcon.Items[0].Text.StartsWith("image/"))
                {
                    var data_ = new Bitmap(data);
                    obj.SetImage(data_);
                }
                else
                    obj.SetData(data);
                data.Close();
                obj.SetData(DataFormats.FileDrop, true, new String[] {tempfilename} );
                DraggableIcon.DoDragDrop(obj, DragDropEffects.All);
            }
            finally
            {
                if (data.CanRead)
                    data.Close();
                try
                {
                    File.Delete(tempfilename);
                }
                catch (Exception)
                {
                }
            }
        }

        private void CommentAdd_Click(object sender, EventArgs e)
        {
            // Bind the MSHTML COM control and turn on editing
            doc = CommentBody.Document.DomDocument as IHTMLDocument2;
            doc.designMode = "On";

            HTMLEditorControls.Enabled = true;
            CommentBodyRaw.Enabled = true;
            LoadAttachment.Enabled = true;
            CommentEdit.Enabled = false;

            CommentBodyRaw.Text = "";
            CommentAuthor.Text = "";
            CommentDate.Text = "";
        }

        private void CommentDelete_Click(object sender, EventArgs e)
        {
            XPathNavigator comment = commentToUUID[Comments.SelectedNode].Item2;
            string shortname = comment.SelectSingleNode("short-name").ToString();
            MessageBox.Show("TODO: Delete Comment "+shortname);
        }

        private void SaveComment()
        {
            MessageBox.Show("TODO: Save Comment");
        }

    }

}
