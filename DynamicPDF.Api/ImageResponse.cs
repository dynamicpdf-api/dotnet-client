using Newtonsoft.Json;
using System.Collections.Generic;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents an image response.
    /// </summary>
    public class ImageResponse : JsonResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageResponse"/> class.
        /// </summary>
        public ImageResponse() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageResponse"/> class.
        /// </summary>
        /// <param name="jsonContent">The image content of the response.</param>
        public ImageResponse(string jsonContent) : base(jsonContent)
        {
            Content = JsonConvert.DeserializeObject<List<ImageInformation>>(base.JsonContent);
        }

        /// <summary>
        /// Gets or sets a collection of <see cref="ImageInformation"/>.
        /// </summary>
        public List<ImageInformation> Content { get; private set; }
    }
}
