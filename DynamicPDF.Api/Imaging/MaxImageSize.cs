using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPDF.Api.Imaging
{
    /// <summary>
    /// Represents an image size that fits within a specified maximum width and height.
    /// </summary>
    public class MaxImageSize : ImageSize
    {
        /// <summary>
        /// Gets or sets the maximum width of the image.
        /// </summary>
        public int? MaxWidth { get; set; }

        /// <summary>
        /// Gets or sets the maximum height of the image.
        /// </summary>
        public int? MaxHeight { get; set; }

        /// <summary>
        /// Gets or sets the unit of measurement <see cref="ImageSizeUnit"/> for the maximum width and height.
        /// </summary>
        public ImageSizeUnit? Unit { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MaxImageSize"/> class.
        /// </summary>
        public MaxImageSize()
        {
            Type = ImageSizeType.Max;
        }
    }
}
