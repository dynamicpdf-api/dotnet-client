using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.IO;

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
        public WordResource(Stream data, string resourceName) : base(data, resourceName)
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
                string inputFileExtension = "";
                if (string.IsNullOrWhiteSpace(FilePath) == false && Path.HasExtension(FilePath.Trim()) == true)
                    inputFileExtension = Path.GetExtension(FilePath.Trim()).ToLower();
                else if (string.IsNullOrWhiteSpace(ResourceName) == false && Path.HasExtension(ResourceName.Trim()) == true)
                    inputFileExtension = Path.GetExtension(ResourceName).ToLower();
                else
                    throw new EndpointException("Invalid filePath or resourceName.");

                if (inputFileExtension == ".doc")
                {
                    MimeType = "application/msword";
                    return ".doc";
                }
                else if (inputFileExtension == ".docx" && Data[0] == 0x50 && Data[1] == 0x4b)
                {
                    MimeType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                    return ".docx";
                }
                else if (inputFileExtension == ".odt" && Data[0] == 0x50 && Data[1] == 0x4b)
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
    }
}
