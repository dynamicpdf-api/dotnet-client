using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPDF.Api.Imaging
{
    /// <summary>
    /// Base class for image size types.
    /// </summary>
    public abstract class ImageSize
    {
        /// <summary>
        /// Type of the image size.
        /// </summary>
        public ImageSizeType Type { get; set; }
    }
}
