using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace DynamicPDF.Api.Elements
{
    /// <summary>
    /// Represents a Data Matrix  barcode element.
    /// </summary>
    /// <remarks>
    /// With some of the .Net runtimes (example: .Net Core 2.0), the ECI values 20, 28, 29 and 30 will give the error "No data is available 
    /// for encoding 'code page number'. For information on defining a custom encoding, see the documentation for the Encoding.RegisterProvider method.". 
    /// </remarks>
    public class DataMatrixBarcodeElement : Dim2BarcodeElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataMatrixBarcodeElement"/> class.
        /// </summary>
        /// <param name="value">The value of the barcode.</param>
        /// <param name="placement">The placement of the barcode on the page.</param>
        /// <param name="xOffset">The X coordinate of the barcode.</param>
        /// <param name="yOffset">The Y coordinate of the barcode.</param>
        /// <param name="symbolSize">The symbol size of the barcode.</param>
        /// <param name="encodingType">The encoding type of the barcode.</param>
        /// <param name="functionCharacter">The function character of the barcode.</param>
        public DataMatrixBarcodeElement(string value, ElementPlacement placement = ElementPlacement.TopLeft, float xOffset = 0, float yOffset = 0, DataMatrixSymbolSize symbolSize = DataMatrixSymbolSize.Auto, DataMatrixEncodingType encodingType = DataMatrixEncodingType.Auto, DataMatrixFunctionCharacter functionCharacter = DataMatrixFunctionCharacter.None)
             : base(value, placement, xOffset, yOffset)
        {
            DataMatrixSymbolSize = symbolSize;
            DataMatrixEncodingType = encodingType;
            DataMatrixFunctionCharacter = functionCharacter;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataMatrixBarcodeElement"/> class.
        /// </summary>
        /// <param name="value">The value of the barcode.</param>
        /// <param name="placement">The placement of the barcode on the page.</param>
        /// <param name="xOffset">The X coordinate of the barcode.</param>
        /// <param name="yOffset">The Y coordinate of the barcode.</param>
        /// <param name="symbolSize">The symbol size of the barcode.</param>
        /// <param name="encodingType">The encoding type of the barcode.</param>
        /// <param name="functionCharacter">The function character of the barcode.</param>
        public DataMatrixBarcodeElement(byte[] value, ElementPlacement placement = ElementPlacement.TopLeft, float xOffset = 0, float yOffset = 0, DataMatrixSymbolSize symbolSize = DataMatrixSymbolSize.Auto, DataMatrixEncodingType encodingType = DataMatrixEncodingType.Auto, DataMatrixFunctionCharacter functionCharacter = DataMatrixFunctionCharacter.None)
                 : base(value, placement, xOffset, yOffset)
        {
            DataMatrixSymbolSize = symbolSize;
            DataMatrixEncodingType = encodingType;
            DataMatrixFunctionCharacter = functionCharacter;
        }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal override ElementType Type { get; } = ElementType.DataMatrixBarcode;

        /// <summary>
        /// Gets or sets whether to process tilde character.
        /// </summary>
        /// <remarks>
        /// Setting <b>true</b> will check for ~ character and processes it for FNC1 or ECI characters.
        /// With some of the .Net runtimes (example: .Net Core 2.0), the ECI values 20, 28, 29 and 30 will give the error "No data is available 
        /// for encoding 'code page number'. For information on defining a custom encoding, see the documentation for the Encoding.RegisterProvider method.". 
        /// </remarks>
        public bool? ProcessTilde { get; set; }

        [JsonProperty("dataMatrixSymbolSize")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal DataMatrixSymbolSize DataMatrixSymbolSize { get; set; }

        [JsonProperty("dataMatrixEncodingType")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal DataMatrixEncodingType DataMatrixEncodingType { get; set; }

        [JsonProperty("dataMatrixFunctionCharacter")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal DataMatrixFunctionCharacter DataMatrixFunctionCharacter { get; set; }
    }
}
