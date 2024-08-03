using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPDF.Api.Imaging
{
    /// <summary>
    /// Represents JPEG image format with quality.
    /// </summary>
    public class JpegImageFormat : ImageFormat
    {
        /// <summary>
        /// Gets or sets the quality of the JPEG image.
        /// </summary>
        /// <remarks>
        /// The quality ranges from 0 to 100, where 0 indicates highly compressed and low quality and 100 indicates high quality and less compressed image.
        /// </remarks>
        public int? Quality { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="JpegImageFormat"/> class.
        /// </summary>
        public JpegImageFormat() : base(ImageFormatType.JPEG) { }
    }
}
