using RestSharp;
using System.Threading.Tasks;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents the pdf text endpoint.
    /// </summary>
    public class PdfText : Endpoint
    {
        PdfResource resource;

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfText"/> class.
        /// </summary>
        /// <param name="resource">The image resource of type <see cref="PdfResource"/>.</param>
        /// <param name="startPage">The start page.</param>
        /// <param name="pageCount">The page count.</param>
        public PdfText(PdfResource resource, int startPage = 1, int pageCount = 0)
        {
            this.resource = resource;
            StartPage = startPage;
            PageCount = pageCount;
        }

        internal override string EndpointName { get; } = "pdf-text";

        /// <summary>
        /// Gets or sets the start page.
        /// </summary>
        public int StartPage { get; set; }

        /// <summary>
        /// Gets or sets the page count.
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// Process the pdf resource to get pdf's text.
        /// </summary>
        public PdfTextResponse Process()
        {
            var task = ProcessAsync();
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Process the pdf resource to get pdf's information.
        /// </summary>
        /// Returns collection of <see cref="PdfTextResponse"/> as multithreading tasks <see cref="Task"/>.
        public Task<PdfTextResponse> ProcessAsync()
        {
            var request = base.CreateRestRequest();
            request.AddHeader("Content-Type", "application/pdf");
            RestClient restClient = base.Client;
            return Task<PdfTextResponse>.Run(() =>
            {
                PdfTextResponse response = null;
                request.AddParameter("", resource.Data, "application/pdf", ParameterType.RequestBody);
                request.AddQueryParameter("StartPage", StartPage.ToString());
                request.AddQueryParameter("PageCount", PageCount.ToString());
                IRestResponse restResponse = restClient.Post(request);
                if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    response = new PdfTextResponse(restResponse.Content);
                    response.IsSuccessful = true;
                    response.StatusCode = restResponse.StatusCode;
                }
                else
                {
                    response = new PdfTextResponse();
                    string output = restResponse.Content;
                    response.ErrorJson = restResponse.Content;
                    response.ErrorId = response.ErrorId;
                    response.ErrorMessage = restResponse.ErrorMessage;
                    response.IsSuccessful = false;
                    response.StatusCode = restResponse.StatusCode;
                }
                return response;
            });
        }
    }
}
