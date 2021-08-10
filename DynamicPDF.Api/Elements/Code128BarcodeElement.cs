using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace DynamicPDF.Api.Elements
{
    /// <summary>
    /// Represents a Code 128 barcode element.
    /// </summary>
    /// <remarks>This class can be used to place a Code 128 barcode on a page.</remarks>
    public class Code128BarcodeElement : TextBarcodeElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Code128BarcodeElement"/> class.
        /// </summary>
        /// <param name="value">The value of the barcode.</param>
        /// <param name="placement">The placement of the barcode on the page.</param>
        /// <param name="height">The height of the barcode.</param>
        /// <param name="xOffset">The X coordinate of the barcode.</param>
        /// <param name="yOffset">The Y coordinate of the barcode.</param>        
        /// <remarks>Code sets can be specified along with data, in order to do this <see cref="ProcessTilde"/> property needs to be set to <b>true</b>.
        /// Example value: "~BHello ~AWORLD 1~C2345", where ~A, ~B and ~C representing code sets A, B and C respectively.
        /// However if any inline code set has invalid characters it will be shifted to an appropriate code set.</remarks>
        public Code128BarcodeElement(string value, ElementPlacement placement, float height, float xOffset = 0, float yOffset = 0) : base(value, placement, xOffset, yOffset) { Height = height; }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal override ElementType Type { get; } = ElementType.Code128Barcode;

        /// <summary>
        /// Gets or sets the height of the barcode.
        /// </summary>
        public float? Height { get; set; }

        /// <summary>
        /// Gets or sets a boolean representing if the barcode is a UCC / EAN Code 128 barcode.
        /// </summary>
        /// <remarks>If <b>true</b> an FNC1 code will be the first character in the barcode.</remarks>
        public bool? UccEan128 { get; set; }

        /// <summary>
        /// Gets or Sets a boolean indicating whether to process the tilde character.
        /// </summary>
        /// <remarks>If <b>true</b> checks for fnc1 (~1) character in the barcode Value and checks for the inline code sets if present in the data to process.
        /// Example value: "~BHello ~AWORLD 1~C2345", where ~A, ~B and ~C representing code sets A, B and C respectively.
        /// However if any inline code set has invalid characters it will be shifted to an appropriate code set.
        /// "\" is used as an escape character to add ~.</remarks>
        public bool? ProcessTilde { get; set; }
    }
}