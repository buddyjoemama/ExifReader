# ExifReader

Exif spec: http://www.exiv2.org/Exif2-2.PDF

ExifTagManager can be used to read exif tags from an image. It's basically a wrapper around .Net's Bitmap PropertyItems property 
with some added functionality. .Net does not have a native Exif object but it does have the ability to enumerate the exif properties. 
This software allows a developer to add custom properties and map them to specific exif tags, allowing for typed exif parsing..

ex:

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
    
    In the example above, ExifTags is a simple class with decorated properties. The attribute (tagid) informs the parser which 
    exif tag to handle (272 is the model name of the camera, for example). There are also some helper methods used during the parsing process...
    Implementing ITagParsable is not required...
    
    This software also allows for custom parsing. In the example above [DateTime] informs the parser to use the DateTimeAttribute class, which 
    is a parser type. When the parser comes across this property decorated with this attribute, the DateTimeAttribute.ParseValue() is called
    and the result from which is set on the decorated property.
    
    So to add a new parser, create a subclass of TypeParserAttribute and implement ParseValue(..).
    
    The available built-in parsers are:
    -DateTime
    -String
    -Rational (see exif spec)
    
    To use the parser:
    
    using ExifTagManager;
    
        static void Main(string[] args)
        {
            // Read a bitmap and use the EXIFTags() extension method to parse the exif data.
            EXIFTags data = Resource.Sample.EXIFTags();
        }
        
