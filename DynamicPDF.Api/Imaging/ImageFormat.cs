using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPDF.Api.Imaging
{
    /// <summary>
    /// Base class for image formats.
    /// </summary>
    public abstract class ImageFormat
    {
        /// <summary>
        /// Gets or sets the image format type.
        /// </summary>
        public ImageFormatType Type { get; }

        public ImageFormat(ImageFormatType type)
        {
            Type = type;
        }
    }
}
