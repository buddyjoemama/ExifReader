using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExifTagManager
{
    public static class Extensions
    {
        public static T MatchAs<T>(this Match match, String name, String @default = null)
        {
            String value = match.Groups[name].Value;

            try
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch
            {
                return default(T);
            }
        }

        public static String GetString(this PropertyItem item)
        {
            return Encoding.ASCII.GetString(item.Value.Take(item.Len - 1).ToArray());
        }
    }
}
