using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExifTagManager
{
    public static class Extensions
    {
        public static EXIFTags EXIFTags(this Bitmap image)
        {
            return TagParser.Parse<EXIFTags>(image.PropertyItems.ToList());
        }

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
    }
}
