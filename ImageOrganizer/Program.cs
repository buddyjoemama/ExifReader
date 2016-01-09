using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ExifTagManager;
using System.Resources;
using System.IO;
using ExifTagManager.Parsers;

namespace ImageOrganizer
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = TagParser.Parse<ExifTags>(Resource.Sample.PropertyItems.ToList());
        }
    }

    public class ExifTags
    {
        [TagId(306)]
        [MyParser]
        public DateTime? FileChangeDateTime { get; set; }
    }

    public class MyParser : TypeParserAttribute
    {
        public override object ParseValue(PropertyItem item)
        {
            return null;
            //throw new NotImplementedException();
        }
    }
}
