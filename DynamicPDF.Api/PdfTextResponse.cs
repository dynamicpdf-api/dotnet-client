
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents the pdf text response.
    /// </summary>
    public class PdfTextResponse : JsonResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PdfTextResponse"/> class.
        /// </summary>
        public PdfTextResponse() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfResponse"/> class.
        /// </summary>
        /// <param name="jsonContent">The json content</param>
        public PdfTextResponse(string jsonContent) : base(jsonContent)
        {
            Content = JsonConvert.DeserializeObject<List<PdfContent>>(base.JsonContent);
        }

        /// <summary>
        /// Gets the collection of PdfContent.
        /// </summary>
        public List<PdfContent> Content { get; private set; }

    }
}
