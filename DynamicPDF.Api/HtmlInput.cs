using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using api = DynamicPDF.Api;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents a html input.
    /// </summary>
    public class HtmlInput : ConverterInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlInput"/> class.
        /// </summary>
        /// <param name="resource">The resource of type <see cref="HtmlResource"/>.</param>
        /// <param name="basepath">The basepath options for the url.</param>
        /// <param name="size">The page size of the output PDF.</param>
        /// <param name="orientation">The page orientation of the output PDF.</param>
        /// <param name="margins">The page margins of the output PDF.</param>
        public HtmlInput(HtmlResource resource, string basepath = null, api.PageSize size = api.PageSize.Letter, api.PageOrientation orientation = api.PageOrientation.Portrait, float? margins = null) : base(resource, size, orientation, margins)
        {
            if (basepath != null)
            {
                BasePath = basepath;
            }
        }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal override InputType Type { get { return InputType.Html; } }

        /// <summary>
        /// Gets or sets the base path option.
        /// </summary>
        public string BasePath { get; set; } = null;
    }
}
