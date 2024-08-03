using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPDF.Api.Imaging
{
    /// <summary>
    /// Enum representing quantization algorithms.
    /// </summary>
    public enum QuantizationAlgorithm
    {
        /// <summary>
        /// Octree quantization algorithm.
        /// </summary>
        Octree,

        /// <summary>
        /// Web-safe color quantization algorithm.
        /// </summary>
        WebSafe,

        /// <summary>
        /// Werner quantization algorithm.
        /// </summary>
        Werner,

        /// <summary>
        /// Wu quantization algorithm.
        /// </summary>
        WU
    }
}
