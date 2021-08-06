using RestSharp;
using System.Collections.Generic;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents base class for endpoint.
    /// </summary>
    public abstract class Endpoint
    {
        internal Endpoint()
        {
        }

        internal RestClient Client { get; set; }

        internal abstract string EndpointName { get; }

        /// <summary>
        /// Gets or sets default base url.
        /// </summary>
        public static string DefaultBaseUrl { get; set; } = "https://api.dynamicpdf.com/v1.0";

        /// <summary>
        /// Gets or sets default api key.
        /// </summary>
        public static string DefaultApiKey { get; set; }

        /// <summary>
        /// Gets or sets base url for the api.
        /// </summary>
        public string BaseUrl { get; set; } = DefaultBaseUrl;

        /// <summary>
        /// Gets or sets api key.
        /// </summary>
        public string ApiKey { get; set; } = DefaultApiKey;

        protected RestRequest CreateRestRequest()
        {
            Client = new RestClient(BaseUrl + "/" + EndpointName);
            RestRequest restRequest = new RestRequest();
            restRequest.AddHeader("Authorization", "Bearer " + ApiKey);
            return restRequest;
        }

    }
}
