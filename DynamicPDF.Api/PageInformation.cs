namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents a page information.
    /// </summary>
    public class PageInformation
    {
        /// <summary>
        /// Gets or sets the page number.
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Gets or sets the width of the page.
        /// </summary>
        public float Width { get; set; }

        /// <summary>
        /// Gets or sets the height of the page.
        /// </summary>
        public float Height { get; set; }
    }
}