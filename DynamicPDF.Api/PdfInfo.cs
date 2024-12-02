using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System;
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
                    if (restResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        throw new EndpointException("Invalid api key specified.");
                    }
                    response = new PdfInfoResponse();
                    string errorMessage = string.Empty;
                    string errorId = string.Empty;
                    var errorJson = JsonConvert.DeserializeObject<Dictionary<string, string>>(restResponse.Content);
                    errorJson.TryGetValue("message", out errorMessage);
                    errorJson.TryGetValue("id", out errorId);
                    if (errorId != string.Empty)
                        response.ErrorId = new Guid(errorId);
                    response.ErrorJson = restResponse.Content;
                    response.ErrorMessage = errorMessage;
                    response.IsSuccessful = false;
                    response.StatusCode = restResponse.StatusCode;
                }
                return response;
            });
        }
    }
}
