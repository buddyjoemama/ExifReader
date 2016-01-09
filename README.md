# ExifReader

Exif spec: http://www.exiv2.org/Exif2-2.PDF

ExifTagManager can be used to read exif tags from an image. It's basically a wrapper around .Net's Bitmap PropertyItems property 
with some added functionality. .Net does not have a native Exif object but it does have the ability to enumerate the exif properties. 
This software allows a developer to add custom properties and map them to specific exif tags, allowing for typed exif parsing..

ex:

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
        [DateTime]
        public DateTime? FileChangeDateTime { get; set; }
    }
    
    In the example above, ExifTags is a simple class with decorated properties. The attribute (tagid) informs the parser which 
    exif tag to handle (272 is the model name of the camera, for example). There are also some helper methods used during the parsing process...
    Implementing ITagParsable is not required...
    
    This software also allows for custom parsing. In the example above [DateTime] informs the parser to use the DateTimeAttribute class, which 
    is a parser type. When the parser comes across this property decorated with this attribute, the DateTimeAttribute.ParseValue() is called
    and the result from which is set on the decorated property.
    
    ----------------------------------------------------------
    
    Adding a custom parser: Create a subclass of TypeParserAttribute and implement ParseValue(..).
    
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
    
    
    TODO: 
      - Rational parser
      - Type inferencing (int, datetime)
    
    
