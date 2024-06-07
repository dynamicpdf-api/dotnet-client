using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using api = DynamicPDF.Api;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents a Excel input.
    /// </summary>
    public class ExcelInput : ConverterInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelInput"/> class.
        /// </summary>
        /// <param name="resource">The resource of type <see cref="ExcelResource"/>.</param>
        /// <param name="size">The page size of the output PDF.</param>
        /// <param name="orientation">The page orientation of the output PDF.</param>
        /// <param name="margins">The page margins of the output PDF.</param>
        public ExcelInput(ExcelResource resource, api.PageSize? size = null, api.PageOrientation? orientation = null, float? margins = null) : base(resource, size, orientation, margins)
        { }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal override InputType Type { get { return InputType.Excel; } }
    }
}
