namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents the pdf response.
    /// </summary>
    public class PdfResponse : Response
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PdfResponse"/> class.
        /// </summary>
        public PdfResponse() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfResponse"/> class.
        /// </summary>
        /// <param name="pdfContent">The byte array of pdf content.</param>
        public PdfResponse(byte[] pdfContent) { Content = pdfContent; }

        /// <summary>
        /// Gets the content od pdf.
        /// </summary>
        public byte[] Content { get; private set; }
    }
}
