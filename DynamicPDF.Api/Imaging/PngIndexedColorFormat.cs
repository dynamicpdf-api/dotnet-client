using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPDF.Api.Imaging
{
    /// <summary>
    /// Represents indexed color format for PNG.
    /// </summary>
    public class PngIndexedColorFormat : PngColorFormat
    {
        /// <summary>
        /// Gets or sets the <see cref="Api.Imaging.QuantizationAlgorithm"/> for PNG.
        /// </summary>
        public QuantizationAlgorithm? QuantizationAlgorithm { get; set; }

        /// <summary>
        /// Gets or sets the dithering percentage for PNG.
        /// </summary>
        public int? DitheringPercent { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Api.Imaging.DitheringAlgorithm"/> for PNG.
        /// </summary>
        public DitheringAlgorithm? DitheringAlgorithm { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PngIndexedColorFormat"/> class with indexed color format type.
        /// </summary>
        public PngIndexedColorFormat() : base(ColorFormatType.Indexed) { }
    }
}
