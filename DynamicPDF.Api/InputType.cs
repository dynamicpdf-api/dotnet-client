
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Specifies input type.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum InputType
    {
        /// <summary>
        /// Pdf.
        /// </summary>
        Pdf,
        /// <summary>
        /// Image.
        /// </summary>
        Image,
        /// <summary>
        /// Dlex.
        /// </summary>
        Dlex,
        /// <summary>
        /// Page.
        /// </summary>
        Page
    }
}
