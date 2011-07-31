using System;
using System.Collections.Generic;
using System.Linq;
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
            var result = plugin.GetCommitMessage((IntPtr)null, "", @"G:\BEurtle\BEurtle\testlist.xml", null, "An original commit message");
            //var result = plugin.GetCommitMessage((IntPtr)null, "", @"G:\Oxyderkeia", null, "An original commit message");
            MessageBox.Show("Result was: " + result);
        }
    }
}
