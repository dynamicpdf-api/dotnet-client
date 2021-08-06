using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace DynamicPDF.Api.Elements
{
    /// <summary>
    /// Represents a rectangle page element.
    /// </summary>
    /// <remarks>This class can be used to place rectangles of any size or color on a page.</remarks>
    public class RectangleElement : Element
    {
        private Color fillColor;
        private Color borderColor;
        private LineStyle borderStyle;

        /// <summary>
        /// Initializes a new instance of the <see cref="RectangleElement"/> class.
        /// </summary>
        /// <param name="placement">The placement of the rectangle on the page.</param>
        /// <param name="width">Width of the rectangle.</param>
        /// <param name="height">Height of the rectangle.</param>
        public RectangleElement(ElementPlacement placement, float width, float height)
        {
            Placement = placement;
            Width = width;
            Height = height;
        }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal override ElementType Type { get; } = ElementType.Rectangle;

        /// <summary>
		/// Gets or sets the width of the rectangle.
		/// </summary>
        public float Width { get; set; }

        /// <summary>
		/// Gets or sets the height of the rectangle.
		/// </summary>
        public float Height { get; set; }

        /// <summary>
		/// Gets or sets the border width of the rectangle.
		/// </summary>
		/// <remarks>To force the borders not to appear set the border width to any value 0 or less.</remarks>
        public float? BorderWidth { get; set; } = null;

        /// <summary>
		/// Gets or sets the corner radius of the rectangle.
		/// </summary>
        public float? CornerRadius { get; set; }

        [JsonProperty("fillColor")]
        internal string FillColorName { get; set; }

        [JsonProperty("borderColor")]
        internal string BorderColorName { get; set; }

        [JsonProperty("borderStyle")]
        internal string BorderStyleName { get; set; }

        /// <summary>
		/// Gets or sets the <see cref="Color"/> object to use for the fill of the rectangle.
		/// </summary>
		/// <remarks>To force no color to appear in the rectangle (only borders) set the fill color to null (Nothing in Visual Basic).</remarks>
        [JsonIgnore]
        public Color FillColor
        {
            get
            {
                return fillColor;
            }
            set
            {
                fillColor = value;
                FillColorName = fillColor.ColorString;
            }
        }

        /// <summary>
		/// Gets or sets the <see cref="Color"/> object to use for the border of the rectangle.
		/// </summary>
        [JsonIgnore]
        public Color BorderColor
        {
            get
            {
                return borderColor;
            }
            set
            {
                borderColor = value;
                BorderColorName = borderColor.ColorString;
            }
        }

        /// <summary>
		/// Gets or sets the <see cref="LineStyle"/> object used to specify the border style of the rectangle.
		/// </summary>
        [JsonIgnore]
        public LineStyle BorderStyle
        {
            get
            {
                return borderStyle;
            }
            set
            {
                borderStyle = value;
                BorderStyleName = borderStyle.LineStyleString;
            }
        }
    }
}
