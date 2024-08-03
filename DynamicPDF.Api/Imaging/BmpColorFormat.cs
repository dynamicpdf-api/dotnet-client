using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPDF.Api.Imaging
{
    /// <summary>
    /// Base class for BMP color formats
    /// </summary>
    public class BmpColorFormat : ColorFormat
    {
        /// <summary>
        /// Creates BmpColorFormat object with the given type.
        /// </summary>
        public BmpColorFormat(ColorFormatType type)
        {
            if (type != ColorFormatType.Monochrome)
                Type = ColorFormatType.Rgb;
            else
                Type = type;
        }   
    }
}
