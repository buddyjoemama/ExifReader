using ExifTagManager.Parsers;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExifTagManager
{
    public static class TagParser
    {
        public static T Parse<T>(List<PropertyItem> props)
        {
            T t = Activator.CreateInstance<T>();
            ITagParsable parsable = t as ITagParsable;

            foreach (var prop in t.GetType()
                .GetProperties()
                .Where(s => s.CustomAttributes.Count() > 0))
            {
                var tagId = prop.GetCustomAttributes(typeof(TagIdAttribute), true).FirstOrDefault() as TagIdAttribute;

                // Get the value from the property
                PropertyItem item = props.SingleOrDefault(s => s.Id == tagId.TagId);
                if (item != null)
                {
                    if(parsable != null)
                        parsable.BeginParse(tagId.TagId, prop, item);

                    try
                    {
                        object parsedValue = ParseValue(prop, item);

                        if (parsable != null)
                            parsable.BeforeSetProperty(prop, parsedValue);

                        prop.SetValue(t, parsedValue);

                        if (parsable != null)
                            parsable.AfterSetProperty(prop, parsedValue);
                    }
                    catch(Exception e)
                    {
                        if (parsable != null)
                            parsable.ParseFailed(prop, item, e);
                    }
                }
            }

            return t;
        }

        private static object ParseValue(PropertyInfo prop, PropertyItem item)
        {
            switch (prop.PropertyType.Name)
            {
                case "String":
                    return Encoding.Default.GetString(item.Value);
                case "Int32":
                    return BitConverter.ToInt16(item.Value, 0);
            }

            // Any parser attributes?
            TypeParserAttribute parser = prop.GetCustomAttribute<TypeParserAttribute>();
            if (parser != null)
                return parser.ParseValue(item);

            return null;
        }
    }
}
