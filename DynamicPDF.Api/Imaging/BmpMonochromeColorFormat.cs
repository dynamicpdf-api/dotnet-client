using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPDF.Api.Imaging
{
    /// <summary>
    /// Represents monochrome color format for BMP.
    /// </summary>
    public class BmpMonochromeColorFormat : BmpColorFormat
    {
        /// <summary>
        /// Gets or sets the black threshold for monochrome BMP, ranges from 0-255.
        /// </summary>
        public int? BlackThreshold { get; set; }

        /// <summary>
        /// Gets or sets the dithering percentage for BMP.
        /// </summary>
        public int? DitheringPercent { get; set; }

        /// <summary>
        /// Gets or sets the dithering algorithm for BMP.
        /// </summary>
        public DitheringAlgorithm? DitheringAlgorithm { get; set; }

        /// <summary>
        /// Creates object for monochrome color format for BMP image format.
        /// </summary>
        public BmpMonochromeColorFormat() : base(ColorFormatType.Monochrome) { }
    }
}
