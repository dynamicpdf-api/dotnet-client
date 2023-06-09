using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace DynamicPDF.Api.Elements
{
    /// <summary>
    /// Represents a GS1DataBar barcode element.
    /// </summary>
    /// <remarks>This class can be used to place a GS1DataBar barcode on a page.</remarks>
    public class Gs1DataBarBarcodeElement : TextBarcodeElement
    {
        private Gs1DataBarType type;

        /// <summary>
        /// Initializes a new instance of the <see cref="Gs1DataBarBarcodeElement"/> class.
        /// </summary>
        /// <param name="value">The value of the barcode.</param>
        /// <param name="placement">The placement of the barcode on the page.</param>
        /// <param name="height">The height of the barcode.</param>
        /// <param name="type">The GS1DataBarType of the barcode.</param>
        /// <param name="xOffset">The X coordinate of the barcode.</param>
        /// <param name="yOffset">The Y coordinate of the barcode.</param>
        public Gs1DataBarBarcodeElement(string value, ElementPlacement placement, float height, Gs1DataBarType type, float xOffset = 0, float yOffset = 0) : base(value, placement, xOffset, yOffset) { this.type = type; Height = height; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Gs1DataBarBarcodeElement"/> class.
        /// </summary>
        /// <param name="value">The value of the barcode.</param>
        /// <param name="height">The height of the barcode.</param>
        /// <param name="type">The GS1DataBarType of the barcode.</param>
        /// <param name="placement">The placement of the barcode on the page.</param>
        /// <param name="xOffset">The X coordinate of the barcode.</param>
        /// <param name="yOffset">The Y coordinate of the barcode.</param>
        public Gs1DataBarBarcodeElement(string value, float height, Gs1DataBarType type, ElementPlacement placement = ElementPlacement.TopLeft, float xOffset = 0, float yOffset = 0) : base(value, placement, xOffset, yOffset) { this.type = type; Height = height; }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal override ElementType Type { get; } = ElementType.Gs1DataBarBarcode;

        [JsonProperty("gs1DataBarType")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal Gs1DataBarType Gs1DataBarType { get { return type; } }

        /// <summary>
        /// Gets or sets the height of the barcode.
        /// </summary>
        public float? Height { get; set; }
    }
}
