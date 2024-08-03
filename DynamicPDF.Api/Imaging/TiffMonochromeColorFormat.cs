using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPDF.Api.Imaging
{
    /// <summary>
    /// Represents monochrome color format for TIFF with black threshold and compression type.
    /// </summary>
    public class TiffMonochromeColorFormat : TiffColorFormat
    {
        /// <summary>
        /// Gets or sets the black threshold for monochrome TIFF, ranges from 0-255.
        /// </summary>
        public int? BlackThreshold { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Api.Imaging.CompressionType"/> for monochrome TIFF.
        /// </summary>
        public CompressionType? CompressionType { get; set; }

        /// <summary>
        /// Gets or sets the dithering percentage for TIFF.
        /// </summary>
        public int? DitheringPercent { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Api.Imaging.DitheringAlgorithm"/> for TIFF.
        /// </summary>
        public DitheringAlgorithm? DitheringAlgorithm { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TiffMonochromeColorFormat"/> class with monochrome color format type.
        /// </summary>
        public TiffMonochromeColorFormat() : base(ColorFormatType.Monochrome) { }
    }
}
