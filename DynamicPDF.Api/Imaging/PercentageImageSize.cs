using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPDF.Api.Imaging
{
    /// <summary>
    /// Represents an image size based on percentage scaling.
    /// </summary>
    public class PercentageImageSize : ImageSize
    {
        /// <summary>
        /// Gets or sets the horizontal scaling percentage.
        /// </summary>
        public int? HorizontalPercentage { get; set; }

        /// <summary>
        /// Gets or sets the vertical scaling percentage.
        /// </summary>
        public int? VerticalPercentage { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PercentageImageSize"/> class.
        /// </summary>
        public PercentageImageSize()
        {
            Type = ImageSizeType.Percentage;
        }
    }
}
