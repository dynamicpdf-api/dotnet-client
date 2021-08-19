namespace DynamicPDF.Api
{
    /// <summary>
    /// Specifies type of page zoom.
    /// </summary>
    public enum PageZoom
    {
        /// <summary>
        /// Keep unchanged.
        /// </summary>
        Retain,

        /// <summary>
        /// Fit page in window.
        /// </summary>
        FitPage,

        /// <summary>
        /// Fit width of page in window.
        /// </summary>
        FitWidth,

        /// <summary>
        /// Fit height of page in window.
        /// </summary>
        FitHeight,

        /// <summary>
        /// Fit all elements of page in window.
        /// </summary>
        FitBox,
    }
}
