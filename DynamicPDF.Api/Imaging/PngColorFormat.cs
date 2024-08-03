using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPDF.Api.Imaging
{
    /// <summary>
    /// Base class for PNG color formats, used for RGB, RGBA, and Grayscale color formats.
    /// </summary>
    public class PngColorFormat : ColorFormat
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PngColorFormat"/> class.
        /// </summary>
        /// <param name="type">The color format type.</param>
        public PngColorFormat(ColorFormatType type)
        {
            Type = type;
        }
    }
}
