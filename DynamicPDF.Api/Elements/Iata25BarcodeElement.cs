using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace DynamicPDF.Api.Elements
{
    /// <summary>
    /// Represents an IATA 2 of 5 barcode element.
    /// </summary>
    /// <remarks>This class can be used to place an IATA 2 of 5 barcode on a page.</remarks>
    public class Iata25BarcodeElement : TextBarcodeElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Iata25BarcodeElement"/> class.
        /// </summary>
        /// <param name="value">The value of the barcode.</param>
        /// <param name="placement">The placement of the barcode on the page.</param>
        /// <param name="height">The height of the barcode.</param>
        /// <param name="xOffset">The X coordinate of the barcode.</param>
        /// <param name="yOffset">The Y coordinate of the barcode.</param>
        public Iata25BarcodeElement(string value, ElementPlacement placement, float height, float xOffset = 0, float yOffset = 0) : base(value, placement, xOffset, yOffset) { Height = height; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Iata25BarcodeElement"/> class.
        /// </summary>
        /// <param name="value">The value of the barcode.</param>
        /// <param name="height">The height of the barcode.</param>
        /// <param name="placement">The placement of the barcode on the page.</param>
        /// <param name="xOffset">The X coordinate of the barcode.</param>
        /// <param name="yOffset">The Y coordinate of the barcode.</param>
        public Iata25BarcodeElement(string value, float height, ElementPlacement placement = ElementPlacement.TopLeft, float xOffset = 0, float yOffset = 0) : base(value, placement, xOffset, yOffset) { Height = height; }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal override ElementType Type { get; } = ElementType.Iata25Barcode;

        /// <summary>
        /// Gets or sets a value indicating if the check digit should be added to the value.
        /// </summary>
        public bool? IncludeCheckDigit { get; set; }

        /// <summary>
        /// Gets or sets the height of the barcode.
        /// </summary>
        public float? Height { get; set; }
    }
}
