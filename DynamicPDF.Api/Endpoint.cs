using RestSharp;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents the base class for endpoint and has settings for base url, 
    /// api key and creates a rest request object.
    /// </summary>
    public abstract class Endpoint
    {
        private const string endPointVersion = "v1.0";

        internal Endpoint()
        {
        }

        internal RestClient Client { get; set; }

        internal abstract string EndpointName { get; }

        /// <summary>
        /// Gets or sets default base url.
        /// </summary>
        public static string DefaultBaseUrl { get; set; } = "https://api.dynamicpdf.com";

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
            Client = new RestClient(BaseUrl + "/" + endPointVersion + "/" + EndpointName);
            RestRequest restRequest = new RestRequest();
            restRequest.AddHeader("Authorization", "Bearer " + ApiKey);
            return restRequest;
        }
    }
}
