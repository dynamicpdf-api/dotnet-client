using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace DynamicPDF.Api.Elements
{
    /// <summary>
    /// Represents Pdf417 barcode element.
    /// </summary>
    /// <remarks>
    /// This class can be used to generate Pdf417 barcode symbol.
    ///	</remarks>
    public class Pdf417BarcodeElement : Dim2BarcodeElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Pdf417BarcodeElement"/> class.
        /// </summary>
        /// <param name="value">String to be encoded.</param>
        /// <param name="placement">The placement of the barcode on the page.</param>
        /// <param name="columns">Columns of the PDF417 barcode.</param>
        /// <param name="xOffset">The X coordinate of the PDF417 barcode.</param>
        /// <param name="yOffset">The Y coordinate of the PDF417 barcode.</param>
        public Pdf417BarcodeElement(string value, ElementPlacement placement, int columns, float xOffset = 0, float yOffset = 0) : base(value, placement, xOffset, yOffset) { Columns = columns; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Pdf417BarcodeElement"/> class.
        /// </summary>
        /// <param name="value">String to be encoded.</param>
        /// <param name="columns">Columns of the PDF417 barcode.</param>
        /// <param name="placement">The placement of the barcode on the page.</param>
        /// <param name="xOffset">The X coordinate of the PDF417 barcode.</param>
        /// <param name="yOffset">The Y coordinate of the PDF417 barcode.</param>
        public Pdf417BarcodeElement(string value, int columns, ElementPlacement placement = ElementPlacement.TopLeft, float xOffset = 0, float yOffset = 0) : base(value, placement, xOffset, yOffset) { Columns = columns; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Pdf417BarcodeElement"/> class.
        /// </summary>
        /// <param name="value">String to be encoded.</param>
        /// <param name="placement">The placement of the barcode on the page.</param>
        /// <param name="columns">Columns of the PDF417 barcode.</param>
        /// <param name="xOffset">The X coordinate of the PDF417 barcode.</param>
        /// <param name="yOffset">The Y coordinate of the PDF417 barcode.</param>
        public Pdf417BarcodeElement(byte[] value, ElementPlacement placement, int columns, float xOffset = 0, float yOffset = 0) : base(value, placement, xOffset, yOffset) { Columns = columns; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Pdf417BarcodeElement"/> class.
        /// </summary>
        /// <param name="value">String to be encoded.</param>
        /// <param name="columns">Columns of the PDF417 barcode.</param>
        /// <param name="placement">The placement of the barcode on the page.</param>
        /// <param name="xOffset">The X coordinate of the PDF417 barcode.</param>
        /// <param name="yOffset">The Y coordinate of the PDF417 barcode.</param>
        public Pdf417BarcodeElement(byte[] value, int columns, ElementPlacement placement = ElementPlacement.TopLeft, float xOffset = 0, float yOffset = 0) : base(value, placement, xOffset, yOffset) { Columns = columns; }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal override ElementType Type { get; } = ElementType.Pdf417Barcode;

        /// <summary>
        /// Gets or sets the columns of the barcode.
        /// </summary>
        public int Columns { get; set; }

        /// <summary>
        /// Gets or sets the YDimension of the barcode.
        /// </summary>
        public float YDimension { get; set; }

        /// <summary>
        /// Gets or Sets a boolean indicating whether to process the tilde character.
        /// </summary>
        public bool ProcessTilde { get; set; }

        /// <summary>
        /// Gets or sets the Compact Pdf417.
        /// </summary>
        public bool CompactPdf417 { get; set; }

        /// <summary>
        /// Gets or sets the error correction level for the PDF417 barcode.
        /// </summary>
        /// <returns>Returns a <see cref="ErrorCorrection"/> object.</returns>
        [JsonProperty("errorCorrection")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        public ErrorCorrection? ErrorCorrection { get; set; }

        /// <summary>
        /// Gets or sets the type of compaction.
        /// </summary>
        /// <returns>Returns a <see cref="Compaction"/> object.</returns>
        [JsonProperty("compaction")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        public Compaction? Compaction { get; set; }
    }
}
