using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPDF.Api.Imaging
{
    /// <summary>
    /// Represents indexed color format for TIFF.
    /// </summary>
    public class TiffIndexedColorFormat : TiffColorFormat
    {
        /// <summary>
        /// Gets or sets the <see cref="Api.Imaging.QuantizationAlgorithm"/> for TIFF.
        /// </summary>
        public QuantizationAlgorithm? QuantizationAlgorithm { get; set; }

        /// <summary>
        /// Gets or sets the dithering percentage for TIFF.
        /// </summary>
        public int? DitheringPercent { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Api.Imaging.DitheringAlgorithm"/> for TIFF.
        /// </summary>
        public DitheringAlgorithm? DitheringAlgorithm { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TiffIndexedColorFormat"/> class with indexed color format type.
        /// </summary>
        public TiffIndexedColorFormat() : base(ColorFormatType.Indexed) { }
    }
}
