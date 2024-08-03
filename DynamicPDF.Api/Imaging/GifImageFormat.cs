using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPDF.Api.Imaging
{
    /// <summary>
    /// Represents GIF image format with dithering properties.
    /// </summary>
    public class GifImageFormat : ImageFormat
    {
        /// <summary>
        /// Gets or sets the dithering percentage.
        /// </summary>
        public int? DitheringPercent { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Api.Imaging.DitheringAlgorithm"/>.
        /// </summary>
        public DitheringAlgorithm? DitheringAlgorithm { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GifImageFormat"/> class and sets the image format type to GIF.
        /// </summary>
        public GifImageFormat() : base(ImageFormatType.GIF) { }
    }
}
