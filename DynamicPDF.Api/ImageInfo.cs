﻿using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents an image information endpoint.
    /// </summary>
    public class ImageInfo : Endpoint
    {
        ImageResource resource;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageInfo"/> class.
        /// </summary>
        /// <param name="resource">The image resource of type <see cref="ImageResource"/>.</param>
        public ImageInfo(ImageResource resource)
        {
            this.resource = resource;
        }

        internal override string EndpointName { get; } = "image-info";

        /// <summary>
        /// Process the image resource to get image's information.
        /// </summary>
        public ImageResponse Process()
        {
            var task = ProcessAsync();
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Process the image resource to get image's information.
        /// </summary>
        /// Returns collection of <see cref="ImageResponse"/> as multithreading tasks <see cref="Task"/>.
        public Task<ImageResponse> ProcessAsync()
        {
            var request = base.CreateRestRequest();

            request.AddHeader("Content-Type", "image/" + resource.FileExtension.Substring(1));

            RestClient restClient = base.Client;
            return Task<ImageResponse>.Run(() =>
            {
                ImageResponse response = null;
                request.AddParameter("", resource.Data, "image/" + resource.FileExtension.Substring(1), ParameterType.RequestBody);
                IRestResponse restResponse = restClient.Post(request);
                if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    response = new ImageResponse(restResponse.Content);
                    response.IsSuccessful = true;
                    response.StatusCode = restResponse.StatusCode;
                }
                else
                {
                    if (restResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        throw new EndpointException("Invalid api key specified.");
                    }
                    response = new ImageResponse();
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
