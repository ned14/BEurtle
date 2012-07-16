using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace nedprod
{
    class LastModifiedInDirs
    {
        public static List<FileSystemInfo> FindLastModifiedSince(DirectoryInfo path, DateTime dt, List<FileSystemInfo> ret=null)
        {
            if(ret==null) ret = new List<FileSystemInfo>();
            foreach (var entry in path.GetFileSystemInfos())
            {
                if (entry.LastWriteTimeUtc > dt) ret.Add(entry);
                if ((entry.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
                    FindLastModifiedSince((DirectoryInfo)entry, dt, ret);
            }
            return ret;
        }
    }
}
