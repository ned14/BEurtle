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

namespace BEurtle
{
    public partial class IssueDetail : Form
    {
        private XPathNavigator issue;
        public bool changed { get; set; }
        public IssueDetail(XPathNavigator issue)
        {
            this.issue = issue;
            InitializeComponent();
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
            text = text.Replace("\n", "<br />");
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

                XmlDocument document = new XmlDocument();
                var root_ul = document.CreateElement("ul");
                document.AppendChild(root_ul);
                XPathNodeIterator comments = (XPathNodeIterator)issue.Select("comment[not(in-reply-to)]");
                foreach (XPathNavigator comment in comments)
                {
                    var li = document.CreateElement("li");
                    var li_uuid = document.CreateAttribute("uuid");
                    li_uuid.Value = comment.Evaluate("string(uuid)").ToString();
                    li.Attributes.Append(li_uuid);
                    li.InnerXml = fixUp(comment.InnerXml);
                    root_ul.AppendChild(li);
                }
                XPathNodeIterator replies_ = (XPathNodeIterator)issue.Select("comment[in-reply-to]");

                var replies = new List<uuid_xpath>();
                foreach (XPathNavigator reply in replies_)
                    replies.Add(new uuid_xpath(reply.Evaluate("string(in-reply-to)").ToString(), reply));
                while (replies.Count > 0)
                {
                    var lis = document.SelectNodes("//li[@uuid]");
                    foreach (XmlNode parent_li in lis)
                    {
                        string parent_li_uuid = parent_li.Attributes.GetNamedItem("uuid").Value;
                        XPathNavigator reply = null;
                        foreach (var item in replies)
                        {
                            if (item.Item1 == parent_li_uuid)
                            {
                                reply = item.Item2;
                                break;
                            }
                        }
                        if (reply != null)
                        {
                            XmlNode ul = parent_li.SelectSingleNode("ul");
                            if (ul==null)
                            {
                                ul = document.CreateElement("ul");
                                parent_li.AppendChild(ul);
                            }
                            var li = document.CreateElement("li");
                            var li_uuid = document.CreateAttribute("uuid");
                            li_uuid.Value = reply.Evaluate("string(uuid)").ToString();
                            li.Attributes.Append(li_uuid);
                            li.InnerXml = fixUp(reply.InnerXml);
                            ul.AppendChild(li);
                            foreach (var item in replies)
                            {
                                if (item.Item1 == parent_li_uuid)
                                {
                                    replies.Remove(item);
                                    break;
                                }
                            }
                        }
                    }
                }
                Commentary.DocumentText = document.OuterXml;
            }
            setEditable(issue==null);
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
    }

}
