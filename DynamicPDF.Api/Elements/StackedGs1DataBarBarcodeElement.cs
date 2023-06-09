using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace DynamicPDF.Api.Elements
{
    /// <summary>
    /// Represents a StackedGS1DataBar barcode element.
    /// </summary>
    /// <remarks>This class can be used to place a StackedGS1DataBar barcode on a page.</remarks>
    public class StackedGs1DataBarBarcodeElement : TextBarcodeElement
    {
        StackedGs1DataBarType stackedGs1DataBarType;

        /// <summary>
        /// Initializes a new instance of the <see cref="StackedGs1DataBarBarcodeElement"/> class.
        /// </summary>
        /// <param name="value">The value of the barcode.</param>
        /// <param name="placement">The placement of the barcode on the page.</param>
        /// <param name="stackedGs1DataBarType">The StackedGS1DataBarType of the barcode.</param>
        /// <param name="rowHeight">The row height of the barcode.</param>
        /// <param name="xOffset">The X coordinate of the barcode.</param>
        /// <param name="yOffset">The Y coordinate of the barcode.</param>
        public StackedGs1DataBarBarcodeElement(string value, ElementPlacement placement, StackedGs1DataBarType stackedGs1DataBarType, float rowHeight, float xOffset = 0, float yOffset = 0) : base(value, placement, xOffset, yOffset) { this.stackedGs1DataBarType = stackedGs1DataBarType; RowHeight = rowHeight; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StackedGs1DataBarBarcodeElement"/> class.
        /// </summary>
        /// <param name="value">The value of the barcode.</param>
        /// <param name="stackedGs1DataBarType">The StackedGS1DataBarType of the barcode.</param>
        /// <param name="rowHeight">The row height of the barcode.</param>
        /// <param name="placement">The placement of the barcode on the page.</param>
        /// <param name="xOffset">The X coordinate of the barcode.</param>
        /// <param name="yOffset">The Y coordinate of the barcode.</param>
        public StackedGs1DataBarBarcodeElement(string value, StackedGs1DataBarType stackedGs1DataBarType, float rowHeight, ElementPlacement placement = ElementPlacement.TopLeft, float xOffset = 0, float yOffset = 0) : base(value, placement, xOffset, yOffset) { this.stackedGs1DataBarType = stackedGs1DataBarType; RowHeight = rowHeight; }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal override ElementType Type { get; } = ElementType.StackedGs1DataBarBarcode;

        [JsonProperty("stackedGs1DataBarType")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal StackedGs1DataBarType StackedGs1DataBarType { get { return stackedGs1DataBarType; } }

        /// <summary>
        /// Gets or Sets the segment count of the Expanded Stacked barcode.
        /// </summary>
        /// <remarks>This is used only for the ExpandedStacked Gs1DataBar type.</remarks>
        public int? ExpandedStackedSegmentCount { get; set; }

        /// <summary>
        /// Gets or sets the row height of the barcode.
        /// </summary>
        public float RowHeight { get; set; }
    }
}
