using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

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
        public WordResource(string filePath, string resourceName = null) : base(filePath, resourceName)
        {
            if (string.IsNullOrWhiteSpace(ResourceName) == true || Path.HasExtension(ResourceName.Trim()) == false)
                throw new EndpointException("Invalid filePath or resourceName.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WordResource"/> class.
        /// </summary>
        /// <param name="value">The byte array of the Word file.</param>
        /// <param name="resourceName">The name of the resource.</param>
        public WordResource(byte[] value, string resourceName) : base(value, resourceName) 
        {
            if (string.IsNullOrWhiteSpace(ResourceName) == true || Path.HasExtension(ResourceName.Trim()) == false)
                throw new EndpointException("Invalid filePath or resourceName.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WordResource"/> class.
        /// </summary>
        /// <param name="data">The stream of the Word file.</param>
        /// <param name="resourceName">The name of the resource.</param>
        public WordResource(Stream data, string resourceName ) : base(data, resourceName)
        {
            if (string.IsNullOrWhiteSpace(ResourceName) == true || Path.HasExtension(ResourceName.Trim()) == false)
                throw new EndpointException("Invalid filePath or resourceName.");
        }

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
                              
                string inputFileExtension = "";
                if (string.IsNullOrWhiteSpace(FilePath) == false && Path.HasExtension(FilePath.Trim()) == true)
                    inputFileExtension = Path.GetExtension(FilePath.Trim()).ToLower();
                else if (string.IsNullOrWhiteSpace(ResourceName) == false && Path.HasExtension(ResourceName.Trim()) == true)
                    inputFileExtension = Path.GetExtension(ResourceName).ToLower();
                else
                    throw new EndpointException("Invalid filePath or resourceName.");


                if (inputFileExtension == ".doc" && IsDoc(fileHeader))
                {
                    MimeType = "application/msword";
                    return ".doc";
                }
                else if (inputFileExtension == ".docx" && IsDocxOrOdt(fileHeader))
                {
                    MimeType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                    return ".docx";
                }
                else if (inputFileExtension == ".odt" && IsDocxOrOdt(fileHeader))
                {
                    MimeType = "application/vnd.oasis.opendocument.text";
                    return ".odt";
                }
                else
                {
                    throw new EndpointException("Unsupported file type or invalid file extension.");
                }
            }
        }


        internal static bool IsDoc(char[] header)
        {
            //d0 cf 11 e0 a1 b1 1a e1 doc
            return (header[0] == 0xd0 && header[1] == 0xcf && header[2] == 0x11 && header[3] == 0xe0 && header[4] == 0xa1 &&
                header[5] == 0xb1 && (header[6] == 0x1a)) ;
        }
        internal static bool IsDocxOrOdt(char[] header)
        {
            // 50 4B 03 04
            // 50 4B 05 06(empty archive)
            // 50 4B 07 08(spanned archive)

            return (header[0] == 0x50 && 
                header[1] == 0x4b && 
                (header[2] == 0x03 || header[2] == 0x05 || header[2] == 0x07 ) && 
                (header[3] == 0x04 || header[3] == 0x06 || header[3] == 0x08)  );
        }


    }
}
