using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents a pdf resource.
    /// </summary>
    public class HtmlResource : Resource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlResource"/> class.
        /// </summary>
        /// <param name="filePath">The pdf file path.</param>
        public HtmlResource(string filePath)
        {
            if (File.Exists(filePath))
            {
                Data = Resource.GetFileData(filePath);
                FilePath = filePath;
                ResourceName = "htmlinput.html";
            }
            else
                throw new EndpointException("File does not exist.");
        }


        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal override ResourceType Type { get; } = ResourceType.Html;

        internal override string FileExtension { get; } = ".html";

        internal override string MimeType { get; set; } = "text/html";
    }
}
