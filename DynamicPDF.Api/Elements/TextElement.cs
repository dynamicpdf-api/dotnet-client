using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace DynamicPDF.Api.Elements
{
    /// <summary>
    /// Represents a text element.
    /// </summary>
    /// <remarks>This class can be used to place text on a page.</remarks>
    public class TextElement : Element
    {
        private Font font;
        private Color color;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextElement"/> class.
        /// </summary>
        /// <param name="value">Text to display in the text element.</param>
        /// <param name="placement">The placement of the text element on the page.</param>
        /// <param name="xOffset">X coordinate of the text element.</param>
        /// <param name="yOffset">Y coordinate of the text element.</param>
        public TextElement(string value, ElementPlacement placement, float xOffset = 0, float yOffset = 0) : base(value, placement, xOffset, yOffset) { }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal override ElementType Type { get; } = ElementType.Text;

        [JsonProperty("font")]
        internal string FontName { get; set; }

        [JsonProperty("color")]
        internal string ColorName { get; set; }

        internal override Resource Resource { get; set; }

        internal override Font TextFont { get { return font; } }

        /// <summary>
        /// Gets or sets the text to display in the text element.
        /// </summary>
        public string Text
        {
            get
            {
                return InputValue;
            }
            set
            {
                InputValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="Color"/> object to use for the text of the text element.
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
        /// Gets or sets the <see cref="Font"/> object used to specify the font of the text for the text element.
        /// </summary>
        [JsonIgnore]
        public Font Font
        {
            get
            {
                return font;
            }
            set
            {
                font = value;
                FontName = font.Name;
                Resource = font.Resource;
            }
        }

        /// <summary>
        /// Gets or sets the font size for the text of the text element.
        /// </summary>
        public float? FontSize { get; set; }
    }
}
