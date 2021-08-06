using RestSharp;
using System.Threading.Tasks;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents the pdf xmp endpoint.
    /// </summary>
    public class PdfXmp : Endpoint
    {
        PdfResource resource;

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfXmp"/> class.
        /// </summary>
        /// <param name="resource">The image resource of type <see cref="PdfResource"/>.</param>
        public PdfXmp(PdfResource resource)
        {
            this.resource = resource;
        }

        internal override string EndpointName { get; } = "pdf-xmp";

        /// <summary>
        /// Process the pdf resource to get pdf's xmp data.
        /// </summary>
        public XmlResponse Process()
        {
            var task = ProcessAsync();
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Process the pdf resource to get pdf's xmp data.
        /// </summary>
        /// Returns collection of <see cref="XmlResponse"/> as multithreading tasks <see cref="Task"/>.
        public Task<XmlResponse> ProcessAsync()
        {
            var request = base.CreateRestRequest();
            request.AddHeader("Content-Type", "application/pdf");
            RestClient restClient = base.Client;
            return Task<XmlResponse>.Run(() =>
            {
                XmlResponse response = null;
                request.AddParameter("", resource.Data, "application/pdf", ParameterType.RequestBody);
                IRestResponse restResponse = restClient.Post(request);
                if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    response = new XmlResponse(restResponse.Content);
                    response.IsSuccessful = true;
                }
                else
                {
                    response = new XmlResponse();
                    response.ErrorJson = restResponse.Content; 
                    response.ErrorId = response.ErrorId;
                    response.ErrorMessage = restResponse.ErrorMessage;
                    response.IsSuccessful  = false;
                    response.StatusCode = restResponse.StatusCode;
                }
                return response;
            });
        }
    }
}
