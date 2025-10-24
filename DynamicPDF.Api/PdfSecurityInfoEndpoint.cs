using RestSharp;
using System.Threading.Tasks;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents the pdf security info endpoint.
    /// </summary>
    public class PdfSecurityInfoEndpoint : Endpoint
    {
        private PdfResource resource;

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfSecurityInfo"/> class.
        /// </summary>
        /// <param name="resource">The resource of type <see cref="PdfResource"/>.</param>
        public PdfSecurityInfoEndpoint(PdfResource resource)
        {
            this.resource = resource;
        }

        internal override string EndpointName { get; } = "pdf-security-info";

        /// <summary>
        /// Process the pdf resource to get pdf's security information.
        /// </summary>
        public PdfSecurityInfoResponse Process()
        {
            var task = ProcessAsync();
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Process the pdf resource to get pdf's security information.
        /// </summary>
        /// Returns collection of <see cref="PdfInfoResponse"/> as multithreading tasks <see cref="Task"/>.
        public Task<PdfSecurityInfoResponse> ProcessAsync()
        {
            var request = base.CreateRestRequest();
            request.AddHeader("Content-Type", "application/pdf");
            RestClient restClient = base.Client;
            return Task<PdfSecurityInfoResponse>.Run(() =>
            {
                PdfSecurityInfoResponse response = new PdfSecurityInfoResponse();
                request.AddParameter("", resource.Data, "application/pdf", ParameterType.RequestBody);

                IRestResponse restResponse = restClient.Post(request);
                if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    response = new PdfSecurityInfoResponse(restResponse.Content);
                    response.IsSuccessful = true;
                    response.StatusCode = restResponse.StatusCode;
                }
                else
                {
                    response = new PdfSecurityInfoResponse();
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
