using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TestContainer
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var plugin = new BEurtle.BEurtlePlugin();
            plugin.OnCommitFinished((IntPtr) null, @"G:\BEurtle", null, "Fixed issue 4\nFixed issue 701/ae8, 785/bad,111/def\nIssue b79/abc\nIssue efa/123 fixed\n", 0);

            //var result = plugin.GetCommitMessage((IntPtr)null, "", @"G:\BEurtle\BEurtle\testlist.xml", null, "An original commit message");
            //var result = plugin.GetCommitMessage((IntPtr)null, "", @"G:\Oxyderkeia", null, "An original commit message");
            //MessageBox.Show("Result was: " + result);
        }
    }
}
