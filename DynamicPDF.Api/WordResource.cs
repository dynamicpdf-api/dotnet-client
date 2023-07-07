using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
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
        /// <param name="resourceName">The The resource name with file extension.</param>
        public WordResource(string filePath, string resourceName = null) : base(filePath, resourceName)
        {
            if (string.IsNullOrWhiteSpace(resourceName) == false)
            {
                SetMimeType();
            }
            else if (resourceName != null)
            {
                throw new EndpointException("Unsupported file type or invalid file extension.");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WordResource"/> class.
        /// </summary>
        /// <param name="value">The byte array of the Word file.</param>
        /// <param name="resourceName">The The resource name with file extension.</param>
        public WordResource(byte[] value, string resourceName) : base(value, resourceName)
        {
            if (string.IsNullOrWhiteSpace(resourceName) == false)
            {
                SetMimeType();
            }
            else if (resourceName != null)
            {
                throw new EndpointException("Unsupported file type or invalid file extension.");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WordResource"/> class.
        /// </summary>
        /// <param name="data">The stream of the Word file.</param>
        /// <param name="resourceName">The The resource name with file extension.</param>
        public WordResource(Stream data, string resourceName) : base(data, resourceName)
        {
            if (string.IsNullOrWhiteSpace(resourceName) == false)
            {
                SetMimeType();
            }
            else if (resourceName != null)
            {
                throw new EndpointException("Unsupported file type or invalid file extension.");
            }
        }

        /// <summary>
        /// Sets the resource name.
        /// </summary>
        /// <remarks>The resource name should be specified with a file extension.</remarks>
        public override string ResourceName
        {
            set
            {
                if (string.IsNullOrWhiteSpace(value) == true || Path.HasExtension(value) == false)
                    throw new EndpointException("Invalid resource name.");

                base.ResourceName = value;
                SetMimeType();
            }
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
                if (string.IsNullOrWhiteSpace(ResourceName) == false)
                {
                    if (Path.HasExtension(ResourceName.Trim()) == true)
                        inputFileExtension = Path.GetExtension(ResourceName).ToLower();
                    else
                        throw new EndpointException("Invalid resource name.");
                }
                else if (string.IsNullOrWhiteSpace(FilePath) == false)
                {
                    if (Path.HasExtension(FilePath.Trim()) == true)
                        inputFileExtension = Path.GetExtension(FilePath).ToLower();
                    else
                        throw new EndpointException("Invalid file path specified.");
                }
                else
                    throw new EndpointException("Invalid file path or resource name.");

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

        private void SetMimeType()
        {
            _ = FileExtension;
        }

      
    }
}
