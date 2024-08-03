using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPDF.Api.Imaging
{
    /// <summary>
    /// Base class for TIFF color formats and used for RGB and Grayscale color formats.
    /// </summary>
    public class TiffColorFormat : ColorFormat
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TiffColorFormat"/> class with the specified color format type.
        /// </summary>
        /// <param name="type">The color format type.</param>
        public TiffColorFormat(ColorFormatType type)
        {
            Type = type;
        }
    }
}
