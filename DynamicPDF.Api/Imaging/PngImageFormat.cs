using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPDF.Api.Imaging
{
    /// <summary>
    /// Represents PNG image format with color format.
    /// </summary>
    public class PngImageFormat : ImageFormat
    {
        /// <summary>
        /// Gets or sets the color format for PNG, <see cref="PngColorFormat"/>.
        /// </summary>
        public PngColorFormat ColorFormat { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PngImageFormat"/> class.
        /// </summary>
        public PngImageFormat() : base(ImageFormatType.PNG) { }
    }
}
