using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPDF.Api.Imaging
{
    /// <summary>
    /// Represents an image size defined by DPI (Dots Per Inch).
    /// </summary>
    public class DpiImageSize : ImageSize
    {
        /// <summary>
        /// Gets or sets the horizontal DPI (Dots Per Inch) of the image.
        /// </summary>
        public int? HorizontalDpi { get; set; }

        /// <summary>
        /// Gets or sets the vertical DPI (Dots Per Inch) of the image.
        /// </summary>
        public int? VerticalDpi { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DpiImageSize"/> class and sets the image size type to DPI.
        /// </summary>
        public DpiImageSize()
        {
            Type = ImageSizeType.Dpi;
        }
    }
}
