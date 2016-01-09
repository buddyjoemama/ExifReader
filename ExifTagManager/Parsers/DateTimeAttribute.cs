using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExifTagManager.Parsers
{
    public class DateTimeAttribute : TypeParserAttribute
    {
        public override object ParseValue(PropertyItem item)
        {
            String str = Encoding.ASCII.GetString(item.Value);
            var date = Regex.Match(str, @"^(?<year>\d+):(?<month>\d+):(?<day>\d+)\s?(?<hour>\d+):(?<min>\d+):");

            return new DateTime(date.MatchAs<int>("year"), date.MatchAs<int>("month"), date.MatchAs<int>("day"),
                date.MatchAs<int>("hour"), date.MatchAs<int>("min"), 0);
        }
    }
}
