using Newtonsoft.Json;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents the pdf inforamtion response.
    /// </summary>
    public class PdfInfoResponse : JsonResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PdfInfoResponse"/> class.
        /// </summary>
        public PdfInfoResponse() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfInfoResponse"/> class.
        /// </summary>
        /// <param name="jsonContent">The json of pdf information.</param>
        public PdfInfoResponse(string jsonContent) : base(jsonContent)
        {
            Content = JsonConvert.DeserializeObject<PdfInformation>(base.JsonContent);
        }

        /// <summary>
        /// Gets the pdf information content.
        /// </summary>
        public PdfInformation Content { get; private set; }
    }
}
