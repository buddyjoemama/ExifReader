using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExifTagManager.Parsers
{
    public class RationalAttribute : TypeParserAttribute
    {
        public override object ParseValue(PropertyItem item)
        {
            return 0;
        }
    }
}
