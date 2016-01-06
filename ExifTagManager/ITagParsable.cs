using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExifTagManager
{
    public interface ITagParsable
    {
        void BeginParse(int tagId, PropertyInfo property, PropertyItem item);

        void ParseFailed(PropertyInfo property, PropertyItem item, Exception exc);

        void BeforeSetProperty(PropertyInfo prop, object parsedValue);

        void AfterSetProperty(PropertyInfo prop, object parsedValue);
    }
}
