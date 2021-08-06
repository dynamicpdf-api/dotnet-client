using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DynamicPDF.Api.Elements
{
    /// <summary>
    /// Represents page element type.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ElementType
    {
        /// <summary>
        /// Image element.
        /// </summary>
        Image,

        /// <summary>
        /// Text element.
        /// </summary>
        Text,

        /// <summary>
        /// Page numbering element.
        /// </summary>
        PageNumbering,

        /// <summary>
        /// Code 128 barcode element.
        /// </summary>
        Code128Barcode,

        /// <summary>
        /// Code 39 barcode element.
        /// </summary>
        Code39Barcode,

        /// <summary>
        /// Code 2 of 5 barcode element.
        /// </summary>
        Code25Barcode,

        /// <summary>
        /// Code 93 barcode element.
        /// </summary>
        Code93Barcode,

        /// <summary>
        /// Code 11 barcode element.
        /// </summary>
        Code11Barcode,

        /// <summary>
        /// GS1 databar barcode element.
        /// </summary>
        Gs1DataBarBarcode,

        /// <summary>
        /// IATA 25 barcode element.
        /// </summary>
        Iata25Barcode,

        /// <summary>
        /// MSI barcode element.
        /// </summary>
        MsiBarcode,

        /// <summary>
        /// Stacked GS1 databar barcode element.
        /// </summary>
        StackedGs1DataBarBarcode,

        /// <summary>
        /// Aztec barcode element.
        /// </summary>
        AztecBarcode,

        /// <summary>
        /// QR Code barcode element.
        /// </summary>
        QrCode,

        /// <summary>
        /// PDF417 barcode element.
        /// </summary>
        Pdf417Barcode,

        /// <summary>
        /// Data Matrix barcode element.
        /// </summary>
        DataMatrixBarcode,

        /// <summary>
        /// Rectangle element.
        /// </summary>
        Rectangle,

        /// <summary>
        /// Line element.
        /// </summary>
        Line
    }
}
