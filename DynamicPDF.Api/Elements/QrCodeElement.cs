using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace DynamicPDF.Api.Elements
{
    /// <summary>
    /// Represents a QR code barcode element.
    /// </summary>
    /// <remarks>
    /// With some of the .Net runtimes (example: .Net Core 2.0), the Kanchi encoding will give the error 
    /// "No data is available for encoding 932. For information on defining a custom encoding, 
    /// see the documentation for the Encoding.RegisterProvider method.".
    /// </remarks>
    public class QrCodeElement : Dim2BarcodeElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QrCodeElement"/> class.
        /// </summary>
        /// <param name="value">The value of the QR code.</param>
        /// <param name="placement">The placement of the barcode on the page.</param>
        /// <param name="xOffset">The X coordinate of the QR code.</param>
        /// <param name="yOffset">The Y coordinate of the QR code.</param>
        public QrCodeElement(string value, ElementPlacement placement = ElementPlacement.TopLeft, float xOffset = 0, float yOffset = 0) : base(value, placement, xOffset, yOffset) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="QrCodeElement"/> class.
        /// </summary>
        /// <param name="value">The value of the QR code.</param>
        /// <param name="placement">The placement of the barcode on the page.</param>
        /// <param name="xOffset">The X coordinate of the QR code.</param>
        /// <param name="yOffset">The Y coordinate of the QR code.</param>
        public QrCodeElement(byte[] value, ElementPlacement placement = ElementPlacement.TopLeft, float xOffset = 0, float yOffset = 0) : base(value, placement, xOffset, yOffset) { }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal override ElementType Type { get; } = ElementType.QrCode;

        /// <summary>
        /// Gets or sets FNC1 mode.
        /// </summary>
        [JsonProperty("fnc1")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        public QrCodeFnc1? Fnc1 { get; set; }

        /// <summary>
        /// Gets or sets the QR code version.
        /// </summary>
        public int? Version { get; set; }
    }
}
