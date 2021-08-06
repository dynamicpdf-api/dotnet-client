
namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents information of the image.
    /// </summary>
    public class ImageInformation
    {
        /// <summary>
        /// Gets page number of the pdf where the image is present.
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Gets the width of the image.
        /// </summary>
        public float Width { get; set; }

        /// <summary>
        /// Gets the height of the image.
        /// </summary>
        public float Height { get; set; }

        /// <summary>
        /// Gets the horizondalDpi of the image.
        /// </summary>
        public float HorizondalDpi { get; set; }

        /// <summary>
        /// Gets the verticalDpi of the image.
        /// </summary>
        public float VerticalDpi { get; set; }

        /// <summary>
        /// Gets the number Of color components in the image.
        /// </summary>
        public float NumberOfComponents { get; set; }

        /// <summary>
        /// Gets the bits per component of the image.
        /// </summary>
        public float BitsPerComponent { get; set; }

        /// <summary>
        /// Gets the clor space of the image.
        /// </summary>
        public ColorSpaceType ColorSpace { get; set; }
    }
}
