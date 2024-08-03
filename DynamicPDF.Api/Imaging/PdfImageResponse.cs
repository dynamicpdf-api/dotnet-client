using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPDF.Api.Imaging
{
    public class PdfImageResponse : Response
    {
        /// <summary>
        /// Image format.
        /// </summary>
        public string ImageFormat { get; set; }
        /// <summary>
        /// Data of the images.
        /// </summary>
        public List<Image> Images { get; set; } = new List<Image>();
        public string ContentType { get; set; }
        public int HorizontalDpi { get; set; }
        public int VerticalDpi { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfImageResponse"/> class.
        /// </summary>
        public PdfImageResponse() { }

    }

    public class Image
    {
        public int PageNumber { get; set; }
        public string Data { get; set; }
        public int BilledPages { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
