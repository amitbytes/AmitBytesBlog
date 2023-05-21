using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AmitBytesBlog.Entity.FileSystem
{
    public static class FileSystemHelper
    {
        #region File Helper
        public static string FileExtension(this string filePath)
        {
            return Path.GetExtension(filePath);
        }
        #endregion
    }
}
