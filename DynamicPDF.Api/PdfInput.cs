using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents a pdf input.
    /// </summary>
    public class PdfInput : Input
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PdfInput"/> class.
        /// </summary>
        /// <param name="resource">The resource of type <see cref="PdfResource"/>.</param>
        /// <param name="options">The merge options for the pdf.</param>
        public PdfInput(PdfResource resource, MergeOptions options = null) : base(resource) 
        {
            MergeOptions = options;
        }

        /// <summary>
        /// Returns a <see cref="PdfInput"/> object containing the input pdf.
        /// </summary>
        /// <param name="cloudResourcePath">The resource path in cloud resource manager.</param>
        /// <param name="options">The merge options for the pdf.</param>
        public PdfInput(string cloudResourcePath, MergeOptions options = null) : base(cloudResourcePath)
        {
            MergeOptions = options;
        }
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal override InputType Type { get { return InputType.Pdf; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfInput"/> class.
        /// </summary>
        /// <param name="resourceName">The name of the resource present in cloud resource manager.</param>
        public PdfInput(string resourceName) : base(resourceName) { }

        /// <summary>
        /// Gets or sets the merge options <see cref="MergeOptions"/>.
        /// </summary>
        public MergeOptions MergeOptions { get; set; } = null;

        /// <summary>
        /// Gets or sets the start page.
        /// </summary>
        public int? StartPage { get; set; }

        /// <summary>
        /// Gets or sets the page count.
        /// </summary>
        public int? PageCount { get; set; }

    }
}
