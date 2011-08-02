using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace BEurtle
{
    public sealed class Win32
    {
        public enum EXTENDED_NAME_FORMAT : int
        {
            NameUnknown = 0,
            NameFullyQualifiedDN = 1,
            NameSamCompatible = 2,
            NameDisplay = 3,
            NameUniqueId = 6,
            NameCanonical = 7,
            NameUserPrincipal = 8,
            NameCanonicalEx = 9,
            NameServicePrincipal = 10,
            NameDnsDomain = 12
        };

        [DllImport("secur32.dll", CharSet = CharSet.Auto)]
        public static extern int GetUserNameEx(int NameFormat, StringBuilder namebuffer, ref uint size);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        public const int WM_SETREDRAW = 11;
    }
}
