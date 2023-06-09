using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace DynamicPDF.Api.Elements
{
    /// <summary>
    /// Represents a Code 3 of 9 barcode element.
    /// </summary>
    /// <remarks>This class can be used to place a Code 3 of 9 barcode on a page.</remarks>
    public class Code39BarcodeElement : TextBarcodeElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Code39BarcodeElement"/> class.
        /// </summary>
        /// <param name="value">The value of the barcode.</param>
        /// <param name="placement">The placement of the barcode on the page.</param>
        /// <param name="height">The height of the barcode.</param>
        /// <param name="xOffset">The X coordinate of the barcode.</param>
        /// <param name="yOffset">The Y coordinate of the barcode.</param>
        public Code39BarcodeElement(string value, ElementPlacement placement, float height, float xOffset = 0, float yOffset = 0) : base(value, placement, xOffset, yOffset) { Height = height; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Code39BarcodeElement"/> class.
        /// </summary>
        /// <param name="value">The value of the barcode.</param>
        /// <param name="height">The height of the barcode.</param>
        /// <param name="placement">The placement of the barcode on the page.</param>
        /// <param name="xOffset">The X coordinate of the barcode.</param>
        /// <param name="yOffset">The Y coordinate of the barcode.</param>
        public Code39BarcodeElement(string value, float height, ElementPlacement placement = ElementPlacement.TopLeft, float xOffset = 0, float yOffset = 0) : base(value, placement, xOffset, yOffset) { Height = height; }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal override ElementType Type { get; } = ElementType.Code39Barcode;

        /// <summary>
        /// Gets or sets the height of the barcode.
        /// </summary>
        public float? Height { get; set; }
    }
}