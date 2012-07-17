using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BEgui
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var dir = args.Length>0 ? args[0] : Directory.GetCurrentDirectory();
            var plugin = new BEurtle.BEurtlePlugin();
            var result = plugin.GetCommitMessage((IntPtr)null, "", dir, null, "");
        }
    }
}
