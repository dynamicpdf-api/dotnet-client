using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPDF.Api.Imaging
{
    /// <summary>
    /// Enum representing dithering algorithms.
    /// </summary>
    public enum DitheringAlgorithm
    {
        /// <summary>
        /// Floyd-Steinberg dithering algorithm.
        /// </summary>
        FloydSteinberg,

        /// <summary>
        /// Bayer dithering algorithm.
        /// </summary>
        Bayer,

        /// <summary>
        /// No dithering.
        /// </summary>
        None
    }
}
