namespace DynamicPDF.Api
{
    /// <summary>
    /// Specifies Color Space.
    /// </summary>
    public enum ColorSpaceType
    {
        /// <summary>
        /// Represents a Monochrome color space.
        /// </summary>
        Monochrome,
        /// <summary>
        /// Represents a Grayscale color space.
        /// </summary>
        Grayscale,
        /// <summary>
        /// Represents an RGB color space.
        /// </summary>
        RGB,
        /// <summary>
        /// Represents a CMYK color space.
        /// </summary>
        CMYK,
        /// <summary>
        /// Represents an Indexed color space.
        /// </summary>
        Indexed,
        /// <summary>
        /// Unknown color space.
        /// </summary>
        Unknown
    }
}
