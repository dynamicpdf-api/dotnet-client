using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPDF.Api.Imaging
{
    /// <summary>
    /// Represents BMP image format with color format.
    /// </summary>
    public class BmpImageFormat : ImageFormat
    {
        /// <summary>
        /// Gets or sets the <see cref="BmpColorFormat"/> for BMP.
        /// </summary>
        public BmpColorFormat ColorFormat { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BmpImageFormat"/> class.
        /// </summary>
        public BmpImageFormat() : base(ImageFormatType.BMP) { }
    }
}