using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPDF.Api.Imaging
{
    /// <summary>
    /// Represents an image size with fixed dimensions.
    /// </summary>
    public class FixedImageSize : ImageSize
    {
        /// <summary>
        /// Gets or sets the width of the image.
        /// </summary>
        public int? Width { get; set; }

        /// <summary>
        /// Gets or sets the height of the image.
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// Gets or sets the unit of measurement <see cref="ImageSizeUnit"/> for the width and height.
        /// </summary>
        public ImageSizeUnit? Unit { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FixedImageSize"/> class and sets the image size type to Fixed.
        /// </summary>
        public FixedImageSize()
        {
            Type = ImageSizeType.Fixed;
        }
    }
}
