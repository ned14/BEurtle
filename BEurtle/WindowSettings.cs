using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;
using System.ComponentModel;
using System.Security.Cryptography;

namespace nedprod
{
    abstract public class WindowSettings
    {
        private Form form;

        public FormWindowState state;
        public Point location;
        public Size size;

        public WindowSettings(Form _form)
        {
            this.form = _form;
        }
        internal class MD5Sum
        {
            static MD5CryptoServiceProvider engine = new MD5CryptoServiceProvider();
            private byte[] sum = engine.ComputeHash(BitConverter.GetBytes(0));
            public MD5Sum() { }
            public MD5Sum(string s)
            {
                for (var i = 0; i < sum.Length; i++)
                    sum[i] = byte.Parse(s.Substring(i * 2, 2), System.Globalization.NumberStyles.HexNumber);
            }
            public void Add(byte[] data)
            {
                byte[] temp = new byte[sum.Length + data.Length];
                var i=0;
                for (; i < sum.Length; i++)
                    temp[i] = sum[i];
                for (; i < temp.Length; i++)
                    temp[i] = data[i - sum.Length];
                sum=engine.ComputeHash(temp);
            }
            public void Add(int data)
            {
                Add(BitConverter.GetBytes(data));
            }
            public void Add(string data)
            {
                Add(Encoding.UTF8.GetBytes(data));
            }
            public static bool operator ==(MD5Sum a, MD5Sum b)
            {
                if (a.sum == b.sum) return true;
                if (a.sum.Length != b.sum.Length) return false;
                for (var i = 0; i < a.sum.Length; i++)
                    if (a.sum[i] != b.sum[i]) return false;
                return true;
            }
            public static bool operator !=(MD5Sum a, MD5Sum b)
            {
                return !(a == b);
            }
            public override bool Equals(object obj)
            {
                try
                {
                    return (bool)(this == (MD5Sum)obj);
                }
                catch
                {
                    return false;
                }
            }
            public override int GetHashCode()
            {
                return ToString().GetHashCode();
            }
            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                for (var i = 0; i < sum.Length; i++)
                    sb.Append(sum[i].ToString("x2"));
                return sb.ToString();
            }
        }
        private MD5Sum screenconfig()
        {
            MD5Sum md5=new MD5Sum();
            md5.Add(Screen.AllScreens.Length); // Hash the number of screens
            for(var i=0; i<Screen.AllScreens.Length; i++)
            {
                md5.Add(Screen.AllScreens[i].Bounds.ToString()); // Hash the dimensions of this screen
            }
            return md5;
        }
        public void load()
        {
            using (RegistryKey r = Registry.CurrentUser.OpenSubKey(@"Software\" + CompanyId() + @"\" + AppId() + @"\Window State\" + form.Name))
            {
                if (r != null)
                {
                    try
                    {
                        string _location = (string)r.GetValue("location"), _size = (string)r.GetValue("size");
                        state = (FormWindowState)r.GetValue("state");
                        location = (Point)TypeDescriptor.GetConverter(typeof(Point)).ConvertFromInvariantString(_location);
                        size = (Size)TypeDescriptor.GetConverter(typeof(Size)).ConvertFromInvariantString(_size);

                        // Don't do anything if the screen config has since changed (otherwise windows vanish off the side)
                        if (screenconfig() == new MD5Sum((string) r.GetValue("screenconfig")))
                        {
                            form.Location = location;
                            form.Size = size;
                            // Don't restore if miminised (it's unhelpful as the user misses the fact it's opened)
                            if (state != FormWindowState.Minimized)
                                form.WindowState = state;
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }
        public void save()
        {
            state = form.WindowState;
            if (form.WindowState == FormWindowState.Normal)
            {
                size = form.Size;
                location = form.Location;
            }
            else
            {
                size = form.RestoreBounds.Size;
                location = form.RestoreBounds.Location;
            }
            using (RegistryKey r = Registry.CurrentUser.CreateSubKey(@"Software\" + CompanyId()+@"\"+AppId() + @"\Window State\" + form.Name, RegistryKeyPermissionCheck.ReadWriteSubTree))
            {
                r.SetValue("state", (int) state, RegistryValueKind.DWord);
                r.SetValue("location", location.X.ToString() + "," + location.Y.ToString(), RegistryValueKind.String);
                r.SetValue("size", size.Width.ToString()+","+size.Height.ToString(), RegistryValueKind.String);
                r.SetValue("screenconfig", screenconfig().ToString(), RegistryValueKind.String);
            }
        }
        abstract protected string CompanyId();
        abstract protected string AppId();
    }
}
