using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPDF.Api.Imaging
{
    /// <summary>
    /// Base class for all color formats
    /// </summary>
    public abstract class ColorFormat
    {
        /// <summary>
        /// Gets or sets the color format type.
        /// </summary>
        public ColorFormatType Type { get; set; }
    }
}
