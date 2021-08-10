using Newtonsoft.Json;

namespace DynamicPDF.Api.Elements
{
    /// <summary>
    /// Base class from which barcode page elements that display text are derived.
    /// </summary>
    public abstract class TextBarcodeElement : BarcodeElement
    {
        private Font font;
        private Color textColor;

        internal TextBarcodeElement(string value, ElementPlacement placement, float xOffset = 0, float yOffset = 0) : base(value, placement, xOffset, yOffset) { }

        [JsonProperty("font")]
        internal string FontName { get; set; }

        internal override Font TextFont { get { return Font; } }

        internal override Resource Resource { get; set; }

        [JsonProperty("textColor")]
        internal string TextColorName { get; set; }

        /// <summary>
        /// Gets or set the color of the text.
        /// </summary>
        [JsonIgnore]
        public Color TextColor
        {
            get
            {
                return textColor;
            }
            set
            {
                textColor = value;
                TextColorName = textColor.ColorString;
            }
        }

        /// <summary>
        /// Gets or sets the font to use when displaying the text.
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
        /// Gets or sets the font size to use when displaying the text.
        /// </summary>
        public float? FontSize { get; set; }

        /// <summary>
        /// Gets or sets a value indicating if the value should be placed as text below the barcode.
        /// </summary>
        public bool? ShowText { get; set; }
    }
}
