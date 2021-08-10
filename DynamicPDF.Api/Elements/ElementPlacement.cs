using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DynamicPDF.Api.Elements
{
    /// <summary>
    /// Represents the placement of a page element.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ElementPlacement
    {
        /// <summary>
        /// Represents top left placement.
        /// </summary>
        TopLeft,

        /// <summary>
        /// Represents top center placement.
        /// </summary>
        TopCenter,

        /// <summary>
        /// Represents top right placement.
        /// </summary>
        TopRight,

        /// <summary>
        /// Represents bottom left placement.
        /// </summary>
        BottomLeft,

        /// <summary>
        /// Represents bottom center placement.
        /// </summary>
        BottomCenter,

        /// <summary>
        /// Represents bottom right placement.
        /// </summary>
        BottomRight
    }
}
