using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.IO;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents a pdf resource.
    /// </summary>
    public class PdfResource : Resource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PdfResource"/> class.
        /// </summary>
        /// <param name="filePath">The pdf file path.</param>
        /// <param name="resourceName">The name of the resource.</param>
        public PdfResource(string filePath, string resourceName = null) : base(filePath, resourceName) {  }

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfResource"/> class.
        /// </summary>
        /// <param name="value">The byte array of the pdf file.</param>
        /// <param name="resourceName">The name of the resource.</param>
        public PdfResource(byte[] value, string resourceName = null) : base(value, resourceName) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfResource"/> class.
        /// </summary>
        /// <param name="data">The stream of the pdf file.</param>
        /// <param name="resourceName">The name of the resource.</param>
        public PdfResource(Stream data, string resourceName = null) : base(data, resourceName) { }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal override ResourceType Type { get; } = ResourceType.Pdf;
        internal override string FileExtension { get; } = ".pdf";
        internal override string MimeType { get; set; } = "application/pdf";

    }
}
