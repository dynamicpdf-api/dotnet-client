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
    /// Represents a Word resource.
    /// </summary>
    public class WordResource : Resource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WordResource"/> class.
        /// </summary>
        /// <param name="path">The input file path.</param>
        /// <param name="resourceName">The name of the resource.</param>
        public WordResource(string path, string resourceName = null) : base() 
        {
            Data = File.ReadAllBytes(path); 
            if (resourceName == null)
                ResourceName = Guid.NewGuid().ToString() + FileExtension;
            else
                ResourceName = resourceName;
        }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal override ResourceType Type { get; } = ResourceType.Word;

        internal override string FileExtension { get; } = ".docx";

        internal override string MimeType { get; set; } = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
    }
}
