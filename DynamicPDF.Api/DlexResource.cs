using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.IO;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents a Dlex resource.
    /// </summary>
    public class DlexResource : Resource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DlexResource"/> class.
        /// </summary>
        /// <param name="dlexPath">The dlex file path.</param>
        /// <param name="resourceName">The name of the resource.</param>
        public DlexResource(string dlexPath, string  resourceName = null) : base(dlexPath, resourceName) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DlexResource"/> class.
        /// </summary>
        /// <param name="value">The byte array of the dlex file.</param>
        /// <param name="resourceName">The name of the resource.</param>
        public DlexResource(byte[] value, string resourceName = null) : base(value, resourceName) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DlexResource"/> class.
        /// </summary>
        /// <param name="data">The stream of the dlex file.</param>
        /// <param name="resourceName">The name of the resource.</param>
        public DlexResource(Stream data, string resourceName = null) : base(data, resourceName) { }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal override ResourceType Type { get; } = ResourceType.Dlex;
        internal override string FileExtension { get; } = ".dlex";
        internal override string MimeType { get; set; } = "application/xml";

        /// <summary>
        /// Gets or sets name for layout data resource.
        /// </summary>
        public string LayoutDataResourceName { get; set; }
    }
}
