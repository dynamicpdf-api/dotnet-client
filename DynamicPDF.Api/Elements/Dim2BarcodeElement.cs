using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;

namespace DynamicPDF.Api.Elements
{
    /// <summary>
    /// The base class for 2 dimensional barcodes (Aztec, Pdf417, DataMatrixBarcode and QrCode).
    /// </summary>
    public abstract class Dim2BarcodeElement : BarcodeElement
    {
        internal Dim2BarcodeElement(string value, ElementPlacement placement, float xOffset, float yOffset) : base(value, placement, xOffset, yOffset) { }
        internal Dim2BarcodeElement(byte[] value, ElementPlacement placement, float xOffset, float yOffset)
        {
            ValueType = ValueType.Base64EncodedBytes;
            Value = Value = Convert.ToBase64String(value);
            Placement = placement;
            XOffset = xOffset;
            YOffset = yOffset;
        }

        [JsonProperty("valueType")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal ValueType ValueType { get; set; } = ValueType.String;
    }
}
