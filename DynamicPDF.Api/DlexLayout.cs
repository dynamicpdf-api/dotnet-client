using RestSharp;
using System.Threading.Tasks;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents a Dlex layout endpoint.
    /// </summary>
    public class DlexLayout : Endpoint
    {
        private LayoutDataResource resource;

        /// <summary>
        /// Initializes a new instance of the <see cref="DlexLayout"/> class using the 
        /// DLEX file path present in the cloud environment and the JSON data for the PDF report.
        /// </summary>
        /// <param name="cloudDlexPath">The DLEX file path present in the resource manager.</param>
        /// <param name="layoutData">The <see cref="LayoutDataResource"/>, json data file used to create the PDF report.</param>
        public DlexLayout(string cloudDlexPath, LayoutDataResource layoutData) : base()
        {
            DlexPath = cloudDlexPath;
            this.resource = layoutData;
        }

        internal override string EndpointName { get; } = "dlex-layout";

        /// <summary>
        /// Gets or sets the DLEX file path present in the resource manager.
        /// </summary>
        public string DlexPath { get; set; }

        /// <summary>
        /// Process the DLEX and layout data to create PDF report.
        /// </summary>
        public PdfResponse Process()
        {
            var task = ProcessAsync();
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Process the DLEX and layout data to create PDF report.
        /// </summary>
        /// Returns collection of <see cref="PdfResponse"/> tasks.
        public Task<PdfResponse> ProcessAsync()
        {
            var request = base.CreateRestRequest();
            request.AddHeader("Content-Type", "multipart/form-data");
            request.AlwaysMultipartFormData = true;
            RestClient restClient = base.Client;
            return Task<PdfResponse>.Run(() =>
            {
                PdfResponse response = null;
                if (resource != null)
                    request.AddFile("LayoutData", resource.Data, resource.LayoutDataResourceName, resource.MimeType);
                if (DlexPath != null)
                    request.AddParameter("DlexPath", DlexPath);

                IRestResponse restResponse = restClient.Post(request);
                if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    response = new PdfResponse(restResponse.RawBytes);
                    response.IsSuccessful = true;
                    response.StatusCode = restResponse.StatusCode;
                }
                else
                {
                    response = new PdfResponse();
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
