using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace DynamicPDF.Api.Elements
{
    /// <summary>
    /// Represents a line page element.
    /// </summary>
    /// <remarks>This class can be used to place lines of different length, width, color and patterns on a page.</remarks>
    public class LineElement : Element
    {
        private Color color;
        private LineStyle lineStyle;

        /// <summary>
		/// Initializes a new instance of the <see cref="LineElement"/> class.
		/// </summary>
        /// <param name="placement">The placement of the line on the page.</param>
		/// <param name="x2Offset">X2 coordinate of the line.</param>
		/// <param name="y2Offset">Y2 coordinate of the line.</param>
        public LineElement(ElementPlacement placement, float x2Offset, float y2Offset)
        {
            Placement = placement;
            X2Offset = x2Offset;
            Y2Offset = y2Offset;
        }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal override ElementType Type { get; } = ElementType.Line;

        [JsonProperty("color")]
        internal string ColorName { get; set; }

        [JsonProperty("lineStyle")]
        internal string LineStyleName { get; set; }

        /// <summary>
		/// Gets or sets the <see cref="Color"/> object to use for the line.
		/// </summary>
        [JsonIgnore]
        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
                ColorName = color.ColorString;
            }
        }

        /// <summary>
		/// Gets or sets the X2 coordinate of the line.
		/// </summary>
        public float X2Offset { get; set; }

        /// <summary>
		/// Gets or sets the Y2 coordinate of the line.
		/// </summary>
        public float Y2Offset { get; set; }

        /// <summary>
		/// Gets or sets the width of the line.
		/// </summary>
        public float? Width { get; set; }

        /// <summary>
		/// Gets or sets the <see cref="LineStyle"/> object to use for the style of the line.
		/// </summary>
        [JsonIgnore]
        public LineStyle LineStyle
        {
            get
            {
                return lineStyle;
            }
            set
            {
                lineStyle = value;
                LineStyleName = lineStyle.LineStyleString;
            }
        }

    }
}
