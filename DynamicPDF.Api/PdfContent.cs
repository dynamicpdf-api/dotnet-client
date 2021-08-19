namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents the pdf content
    /// </summary>
    public class PdfContent
    {
        /// <summary>
        /// Gets or sets the page number.
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Gets the text in the pdf.
        /// </summary>
        public string Text { get; set; }
    }
}
