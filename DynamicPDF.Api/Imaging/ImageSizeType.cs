using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPDF.Api.Imaging
{
    /// <summary>
    /// Specifies the type of image size.
    /// </summary>
    public enum ImageSizeType
    {
        /// <summary>
        /// DPI-based image size.
        /// </summary>
        Dpi,

        /// <summary>
        /// Fixed image size.
        /// </summary>
        Fixed,

        /// <summary>
        /// Image size that fits within a given maximum size.
        /// </summary>
        Max,

        /// <summary>
        /// Percentage-based image size.
        /// </summary>
        Percentage
    }
}
