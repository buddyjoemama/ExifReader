using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ExifTagManager;

namespace ExifTagManager.Parsers
{
    public class DateTimeAttribute : TypeParserAttribute
    {
        public override object ParseValue(PropertyItem item)
        {
            String str = item.GetString();

            if (item.Len == 10)
            {
                return DateTime.ParseExact(str, "yyyy:MM:dd", CultureInfo.InvariantCulture);
            }

            return DateTime.ParseExact(str, "yyyy:MM:dd HH:mm:ss", CultureInfo.InvariantCulture);
        }
    }
}
