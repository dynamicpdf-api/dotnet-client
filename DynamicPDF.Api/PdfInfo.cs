using RestSharp;
using System.Threading.Tasks;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents the pdf info endpoint.
    /// </summary>
    public class PdfInfo : Endpoint
    {
        private PdfResource resource;

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfInfo"/> class.
        /// </summary>
        /// <param name="resource">The resource of type <see cref="PdfResource"/>.</param>
        public PdfInfo(PdfResource resource)
        {
            this.resource = resource;
        }

        internal override string EndpointName { get; } = "pdf-info";

        /// <summary>
        /// Process the pdf resource to get pdf's information.
        /// </summary>
        public PdfInfoResponse Process()
        {
            var task = ProcessAsync();
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Process the pdf resource to get pdf's information.
        /// </summary>
        /// Returns collection of <see cref="PdfInfoResponse"/> as multithreading tasks <see cref="Task"/>.
        public Task<PdfInfoResponse> ProcessAsync()
        {
            var request = base.CreateRestRequest();
            request.AddHeader("Content-Type", "application/pdf");
            RestClient restClient = base.Client;
            return Task<PdfInfoResponse>.Run(() =>
            {
                PdfInfoResponse response = new PdfInfoResponse();
                request.AddParameter("", resource.Data, "application/pdf", ParameterType.RequestBody);

                IRestResponse restResponse = restClient.Post(request);
                if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    response = new PdfInfoResponse(restResponse.Content);
                    response.IsSuccessful = true;
                    response.StatusCode = restResponse.StatusCode;
                }
                else
                {
                    response = new PdfInfoResponse();
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
