using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Text;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents the Layout data resource.
    /// </summary>
    public class LayoutDataResource : Resource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LayoutDataResource"/> class.
        /// </summary>
        /// <param name="layoutData">The layout data.</param>
        /// <param name="layoutDataResourceName">The name for layout data resource.</param>
        public LayoutDataResource(Object layoutData, string layoutDataResourceName = null) : base() 
        {
            String jsonText = JsonConvert.SerializeObject(layoutData, new JsonSerializerSettings
            {
            });

            Data = Encoding.UTF8.GetBytes(jsonText);
            if (LayoutDataResourceName == null)
                LayoutDataResourceName = Guid.NewGuid().ToString() + ".json";
            else
                LayoutDataResourceName = layoutDataResourceName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayoutDataResource"/> class.
        /// </summary>
        /// <param name="layoutData">The layout data string.</param>
        /// <param name="layoutDataResourceName">The name for layout data resource.</param>
        public LayoutDataResource(string layoutData, string layoutDataResourceName = null) : base() 
        {
             Data = Resource.GetUTF8FileData(layoutData);
            if (LayoutDataResourceName == null)
                LayoutDataResourceName = Guid.NewGuid().ToString() + ".json";
            else
                LayoutDataResourceName = layoutDataResourceName;
        }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal override ResourceType Type { get; } = ResourceType.LayoutData;
        internal override string FileExtension { get; } = ".json";
        internal override string MimeType { get; set; } = "application/json";

        /// <summary>
        /// Gets or sets name for layout data resource.
        /// </summary>
        public string LayoutDataResourceName { get; set; }
    }
}
