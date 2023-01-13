using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents a pdf resource.
    /// </summary>
    public class HtmlResource : Resource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlResource"/> class.
        /// </summary>
        /// <param name="html">The input html string.</param>
        /// <param name="resourceName">The name of the resource.</param>
        public HtmlResource(string html, string resourceName = null) : base() 
        {
            Data = Encoding.UTF8.GetBytes(html); 
            if (resourceName == null)
                ResourceName = Guid.NewGuid().ToString() + FileExtension;
            else
                ResourceName = resourceName;
        }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal override ResourceType Type { get; } = ResourceType.Html;

        internal override string FileExtension { get; } = ".html";

        internal override string MimeType { get; set; } = "text/html";
    }
}
