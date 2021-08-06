using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace DynamicPDF.Api.Elements
{
    /// <summary>
    /// Represents an Aztec barcode element.
    /// </summary>
    /// <remarks>
    /// With some of the .Net runtimes (example: .Net Core 2.0) the ECI values 20, 28, 29 and 30 will give the error "No data is available 
    /// for encoding 'code page number'. For information on defining a custom encoding, see the documentation for the Encoding.RegisterProvider method.".
    /// </remarks>
    public class AztecBarcodeElement : Dim2BarcodeElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AztecBarcodeElement"/> class.
        /// </summary>
        /// <param name="value">The value of the barcode.</param>
        /// <param name="placement">The placement of the barcode on the page.</param>
        /// <param name="xOffset">The X coordinate of the barcode.</param>
        /// <param name="yOffset">The Y coordinate of the barcode.</param>
        public AztecBarcodeElement(string value, ElementPlacement placement, float xOffset = 0, float yOffset = 0) : base(value, placement, xOffset, yOffset) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AztecBarcodeElement"/> class.
        /// </summary>
        /// <param name="value">The value of the barcode.</param>
        /// <param name="placement">The placement of the barcode on the page.</param>
        /// <param name="xOffset">The X coordinate of the barcode.</param>
        /// <param name="yOffset">The Y coordinate of the barcode.</param>
        public AztecBarcodeElement(byte[] value, ElementPlacement placement, float xOffset = 0, float yOffset = 0) : base(value, placement, xOffset, yOffset) { }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal override ElementType Type { get; } = ElementType.AztecBarcode;

        /// <summary>
        /// Gets or Sets a boolean indicating whether to process tilde symbol in the input.
        /// </summary>
        /// <remarks>
        /// Setting <b>true</b> will check for ~ character and processes it for FNC1 or ECI characters.
        /// With some of the .Net runtimes (example: .Net Core 2.0), the ECI values 20, 28, 29 and 30 will give the error "No data is available 
        /// for encoding 'code page number'. For information on defining a custom encoding, see the documentation for the Encoding.RegisterProvider method.".         
        /// </remarks>
        public bool? ProcessTilde { get; set; }

        /// <summary>
        /// Gets or Sets the barcode size, <see cref="AztecSymbolSize"/>.
        /// </summary>
        [JsonProperty("symbolSize")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        public AztecSymbolSize? SymbolSize { get; set; }

        /// <summary>
        /// Gets or Sets the error correction value.
        /// </summary>
        /// <remarks>Error correction value may be between 5% to 95%.</remarks>
        public int? AztecErrorCorrection { get; set; }

        /// <summary>
        /// Gets or Sets a boolean representing if the barcode is a reader initialization symbol.
        /// </summary>
        /// <remarks>Setting <b>true</b> will mark the symbol as reader initialization symbol
        /// and the size of the symbol should be one of the following, R15xC15 Compact, R19xC19, R23xC23, R27xC27, R31xC31, R37xC37, R41xC41, R45xC45, R49xC49, R53xC53, R57xC57, R61xC61, R67xC67, R71xC71, R75xC75,
        /// R79xC79, R83xC83, R87xC87, R91xC91, R95xC95, R101xC101, R105xC105, R109xC109, however it is recommended to set Auto.</remarks>
        public bool? ReaderInitializationSymbol { get; set; }

    }
}
