using System;
using System.Collections.Generic;
using System.Text;

namespace AmitBytesBlog.Entity.Extensions
{
    public static class StringExtensions
    {
        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static Int32 ToInt32(this string value)
        {
            var result = default(Int32);
            try
            {
                result = int.Parse(value);
            }
            catch { }
            return result;
        }
    }
}
