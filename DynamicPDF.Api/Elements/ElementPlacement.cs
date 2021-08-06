using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DynamicPDF.Api.Elements
{
    /// <summary>
    /// Represents a page element's placement.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ElementPlacement
    {
        /// <summary>
        /// Represents a top left.
        /// </summary>
        TopLeft,

        /// <summary>
        /// Represents a top center.
        /// </summary>
        TopCenter,

        /// <summary>
        /// Represents a top right.
        /// </summary>
        TopRight,

        /// <summary>
        /// Represents a bottom left.
        /// </summary>
        BottomLeft,

        /// <summary>
        /// Represents a bottom center.
        /// </summary>
        BottomCenter,

        /// <summary>
        /// Represents a bottom right.
        /// </summary>
        BottomRight
    }
}
