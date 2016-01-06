using ExifTagManager.Parsers;
using System;
using System.Drawing.Imaging;
using System.Reflection;

namespace ExifTagManager
{
    public class EXIFTags : ITagParsable
    {
        [TagId(306)]
        [DateTime]
        public DateTime FileChangeDateTime { get; set; }

        [TagId(270)]
        public String ImageTitle { get; set; }

        [TagId(271)]
        public String Manufacturer { get; set; }

        [TagId(272)]
        public String Model { get; set; }

        public void BeginParse(int tagId, PropertyInfo property, PropertyItem item)
        {

        }

        public void ParseFailed(PropertyInfo property, PropertyItem item, Exception exc)
        {

        }

        public void BeforeSetProperty(PropertyInfo prop, object parsedValue)
        {

        }

        public void AfterSetProperty(PropertyInfo prop, object parsedValue)
        {

        }
    }
}