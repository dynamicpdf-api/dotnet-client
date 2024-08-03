using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPDF.Api.Imaging
{
    /// <summary>
    /// Represents monochrome color format for PNG with black threshold.
    /// </summary>
    public class PngMonochromeColorFormat : PngColorFormat
    {
        /// <summary>
        /// Gets or sets the black threshold for monochrome PNG, ranges from 0-255.
        /// </summary>
        public int? BlackThreshold { get; set; }

        /// <summary>
        /// Gets or sets the dithering percentage for PNG.
        /// </summary>
        public int? DitheringPercent { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Api.Imaging.DitheringAlgorithm"/> for PNG.
        /// </summary>
        public DitheringAlgorithm? DitheringAlgorithm { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PngMonochromeColorFormat"/> class with monochrome color format type.
        /// </summary>
        public PngMonochromeColorFormat() : base(ColorFormatType.Monochrome) { }
    }
}
