using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace DynamicPDF.Api.Elements
{
    /// <summary>
    /// Represents a MSI Barcode element (also known as Modified Plessey).
    /// </summary>
    public class MsiBarcodeElement : TextBarcodeElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MsiBarcodeElement"/> class.
        /// </summary>
        /// <param name="value">The value of the barcode.</param>
        /// <param name="placement">The placement of the barcode on the page.</param>
        /// <param name="height">The height of the barcode.</param>
        /// <param name="xOffset">The X coordinate of the barcode.</param>
        /// <param name="yOffset">The Y coordinate of the barcode.</param>
        public MsiBarcodeElement(string value, ElementPlacement placement, float height, float xOffset = 0, float yOffset = 0) : base(value, placement, xOffset, yOffset) { Height = height; }
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal override ElementType Type { get; } = ElementType.MsiBarcode;

        /// <summary>
        /// Gets or sets a value specifying if the check digit should calculated.
        /// </summary>
        [JsonProperty("appendCheckDigit")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        public MsiBarcodeCheckDigitMode? AppendCheckDigit { get; set; }

        /// <summary>
        /// Gets or sets the height of the barcode.
        /// </summary>
        public float? Height { get; set; }
    }
}
