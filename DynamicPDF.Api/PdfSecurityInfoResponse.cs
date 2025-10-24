using Newtonsoft.Json;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents the pdf security information response.
    /// </summary>
    public class PdfSecurityInfoResponse : JsonResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PdfSecurityInfoResponse"/> class.
        /// </summary>
        public PdfSecurityInfoResponse() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfSecurityInfoResponse"/> class.
        /// </summary>
        /// <param name="jsonContent">The json of pdf information.</param>
        public PdfSecurityInfoResponse(string jsonContent) : base(jsonContent)
        {
            Content = JsonConvert.DeserializeObject<PdfSecurityInfo>(base.JsonContent);
        }

        /// <summary>
        /// Gets the pdf security information content.
        /// </summary>
        public PdfSecurityInfo Content { get; private set; }
    }
}
