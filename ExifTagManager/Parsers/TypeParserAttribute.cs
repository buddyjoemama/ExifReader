using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExifTagManager.Parsers
{
    abstract class TypeParserAttribute : Attribute
    {
        public abstract object ParseValue(PropertyItem item);
    }
}
