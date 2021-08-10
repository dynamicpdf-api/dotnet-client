using Newtonsoft.Json;

namespace DynamicPDF.Api.Elements
{
    /// <summary>
    /// Base class from which barcode page elements are derived.
    /// </summary>
    public abstract class BarcodeElement : Element
    {
        private Color color;

        internal BarcodeElement() { }

        internal BarcodeElement(string value, ElementPlacement placement, float xOffset, float yOffset) : base(value, placement, xOffset, yOffset) { }

        [JsonProperty("color")]
        internal string ColorName { get; set; }

        /// <summary>
        /// Gets or sets the Color of the barcode.
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
        /// Gets or sets the XDimension of the barcode.
        /// </summary>
        public float? XDimension { get; set; }

        /// <summary>
        /// Gets or sets the value of the barcode.
        /// </summary>
        public string Value
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
    }
}