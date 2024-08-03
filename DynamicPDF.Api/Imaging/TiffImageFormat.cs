using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPDF.Api.Imaging
{
    /// <summary>
    /// Represents TIFF image format with color format.
    /// </summary>
    public class TiffImageFormat : ImageFormat
    {
        /// <summary>
        /// Gets or sets a value indicating whether the TIFF image format supports multiple pages.
        /// </summary>
        public bool MultiPage { get; set; } = false;

        /// <summary>
        /// Gets or sets the color format for TIFF, <see cref="TiffColorFormat"/>.
        /// </summary>
        public TiffColorFormat ColorFormat { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TiffImageFormat"/> class.
        /// </summary>
        public TiffImageFormat() : base(ImageFormatType.TIFF) { }
    }
}
