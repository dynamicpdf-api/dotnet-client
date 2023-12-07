using RestSharp;
using System.Collections.Generic;
using System.IO;
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
        /// Gets or sets the collection of resource.
        /// </summary>
        public HashSet<Resource> Resources { get; } = new HashSet<Resource>();

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

        /// <summary>
        /// Initializes a new instance of the <see cref="DlexInput"/> class by posting the 
        /// DLEX file and the JSON data file from the client to the API to create the PDF report.
        /// </summary>
        /// <param name="dlexResource">The <see cref="DlexResource"/>, dlex file created as per the desired PDF report layout design.</param>
        /// <param name="layoutData">The <see cref="LayoutDataResource"/>, json data file used to create the PDF report.</param>
        public DlexLayout(DlexResource dlexResource, LayoutDataResource layoutData) : base()
        {
            Resources.Add(dlexResource);
            this.resource = layoutData;
        }

        internal override string EndpointName { get; } = "dlex-layout";

        /// <summary>
        /// Gets or sets the DLEX file path present in the resource manager.
        /// </summary>
        public string DlexPath { get; set; }

        /// <summary>
        /// Adds additional resource to the endpoint.
        /// </summary>
        /// <param name="resourcePath">The resource file path.</param>
        /// <param name="resourceName">The name of the resource.</param>
        public void AddAdditionalResource(string resourcePath, string resourceName = null)
        {
            if (resourceName == null)
                resourceName = Path.GetFileName(resourcePath);
            AdditionalResource resource = new AdditionalResource(resourcePath, resourceName);
            if(resource.Type == ResourceType.LayoutData )
                throw new EndpointException("Layout data resources cannot be added to a DlexLayout object.");
            else if( resource.Type == ResourceType.Dlex)
                throw new EndpointException("Dlex resources cannot be added to a DlexLayout object.");
            else
                Resources.Add(resource);
        }

        /// <summary>
        /// Adds additional resource to the endpoint.
        /// </summary>
        /// <param name="resourceData">The resource data.</param>
        /// <param name="additionalResourceType">The type of the additional resource.</param>
        /// <param name="resourceName">The name of the resource.</param>
        public void AddAdditionalResource(byte[] resourceData, AdditionalResourceType additionalResourceType, string resourceName)
        {
            ResourceType type = ResourceType.Pdf;
            switch (additionalResourceType)
            {
                case AdditionalResourceType.Font:
                    type = ResourceType.Font;
                    break;
                case AdditionalResourceType.Image:
                    type = ResourceType.Image;
                    break;
                case AdditionalResourceType.Pdf:
                    type = ResourceType.Pdf;
                    break;
                default:
                    throw new EndpointException("This type of resource not allowed");
            }
            AdditionalResource resource = new AdditionalResource(resourceData, resourceName, type);
            Resources.Add(resource);
        }

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
                if (Resources != null && Resources.Count > 0)
                {
                    foreach (Resource resource in Resources)
                    {
                         request.AddFile("Resource", resource.Data, resource.ResourceName, resource.MimeType);
                    }
                }

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
