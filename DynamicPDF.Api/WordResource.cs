using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents a Word resource.
    /// </summary>
    public class WordResource : Resource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WordResource"/> class.
        /// </summary>
        /// <param name="filePath">The Word file path.</param>
        /// <param name="resourceName">The name of the resource.</param>
        public WordResource(string filePath, string resourceName = null) : base(filePath, resourceName) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WordResource"/> class.
        /// </summary>
        /// <param name="value">The byte array of the Word file.</param>
        /// <param name="resourceName">The name of the resource.</param>
        public WordResource(byte[] value, string resourceName = null) : base(value, resourceName) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="WordResource"/> class.
        /// </summary>
        /// <param name="data">The stream of the Word file.</param>
        /// <param name="resourceName">The name of the resource.</param>
        public WordResource(Stream data, string resourceName = null) : base(data, resourceName) { }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal override ResourceType Type { get; } = ResourceType.Word;

        internal override string MimeType { get; set; }


        internal override string FileExtension
        {
            get
            {
                char[] fileHeader = new char[16];
                Array.Copy(Data, fileHeader, 16);
                 
                if (IsDoc(fileHeader))
                {
                    MimeType = "application/msword";
                    return ".doc";
                }
                else if (IsDocx(fileHeader))
                {
                    MimeType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                    return ".docx";
                }
                else if (IsOdt(fileHeader))
                {
                    MimeType = "application/vnd.oasis.opendocument.text";
                    return ".odt";
                }
                else if (IsRtf(fileHeader))
                {
                    MimeType = "text/rtf";
                    return ".rtf";
                }
                else
                    throw new EndpointException("Unsupported file type or invalid file.");
            }
        }


        internal static bool IsDoc(char[] header)
        {
            //d0 cf 11 e0 a1 b1 1a e1 doc
            return (header[0] == 0xd0 && header[1] == 0xcf && header[2] == 0x11 && header[3] == 0xe0 && header[4] == 0xa1 &&
                header[5] == 0xb1 && (header[6] == 0x1a)) ;
        }
        internal static bool IsDocx(char[] header)
        {
            //50 4b 03 04 14 00 06 00 docx
            return (header[0] == 0x50 && header[1] == 0x4b && header[2] == 0x03 && header[3] == 0x04 && header[4] == 0x14 &&
                header[5] == 0x00 && (header[6] == 0x06));
        }
        internal static bool IsOdt(char[] header)
        {
           // 50 4b 03 04 0a 00 00

            //50 4b 03 04 14 00 00 08 odt
            return (header[0] == 0x50 && header[1] == 0x4b && header[2] == 0x03 && header[3] == 0x04 && (header[4] == 0x14 || header[4] == 0x0a) &&
                header[5] == 0x00 && (header[6] == 0x00) );
        }
        internal static bool IsRtf(char[] header)
        {
            //7b 5c 72 74 66 31 5c rtf
            return (header[0] == 0x7b && header[1] == 0x5c && header[2] == 0x72 && header[3] == 0x74 && header[4] == 0x66 &&
               header[5] == 0x31 && (header[6] == 0x5c));
        }

    }
}
