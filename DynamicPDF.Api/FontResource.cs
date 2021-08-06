using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.IO;

namespace DynamicPDF.Api
{
    internal class FontResource : Resource
    {
        internal FontResource(string filePath, string resourceName = null) : base(filePath, resourceName) {  }
        internal FontResource(Stream stream, string resourceName = null) : base(stream, resourceName) { }
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal override ResourceType Type { get; } = ResourceType.Font;
        internal override string MimeType { get; set; }

        internal override string FileExtension
        {
            get
            {

                if (Data[0] == 0x4f && Data[1] == 0x54 && Data[2] == 0x54 && Data[3] == 0x4f)
                {
                    MimeType = "font/otf";
                    return ".otf";
                }
                else if (Data[0] == 0x00 && Data[1] == 0x01 && Data[2] == 0x00 && Data[3] == 0x00)
                {
                    MimeType = "font/ttf";
                    return ".ttf";
                }
                else
                {
                    throw new EndpointException("Unsupported font");
                }

            }
        }
    }
}
