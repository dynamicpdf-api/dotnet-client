

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents the base class for json response.
    /// </summary>
    public abstract class JsonResponse : Response
    {
        internal JsonResponse() { }
        internal JsonResponse(string jsonContent) { JsonContent = jsonContent;  }

        /// <summary>
        /// Gets the json content.
        /// </summary>
        public string JsonContent { get; private set; }

    }
}
