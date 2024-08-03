using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPDF.Api.Imaging
{
    /// <summary>
    /// Enum representing color formats.
    /// </summary>
    public enum ColorFormatType
    {
        /// <summary>
        /// RGB color format.
        /// </summary>
        Rgb,

        /// <summary>
        /// RGBA color format.
        /// </summary>
        RgbA,

        /// <summary>
        /// Grayscale color format.
        /// </summary>
        Grayscale,

        /// <summary>
        /// Monochrome color format.
        /// </summary>
        Monochrome,

        /// <summary>
        /// Indexed color format.
        /// </summary>
        Indexed
    }
}
