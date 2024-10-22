using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Text;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents the Layout data resource used to create PDF reports.
    /// </summary>
    public class LayoutDataResource : Resource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LayoutDataResource"/> class 
        /// using the layout data object and a resource name.
        /// </summary>
        /// <param name="layoutData">Serializable object data to create PDF report.</param>
        /// <param name="layoutDataResourceName">The name for layout data resource.</param>
        public LayoutDataResource(Object layoutData, string layoutDataResourceName = null) : base()
        {
            String jsonText = JsonConvert.SerializeObject(layoutData, new JsonSerializerSettings
            {
            });

            Data = Encoding.UTF8.GetBytes(jsonText);
            if (layoutDataResourceName == null)
                LayoutDataResourceName = Guid.NewGuid().ToString() + ".json";
            else
                LayoutDataResourceName = layoutDataResourceName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayoutDataResource"/> class 
        /// using a JSON file with data and a resource name.
        /// </summary>
        /// <param name="layoutData">The layout data JSON file path or JSON string.</param>
        /// <param name="layoutDataResourceName">The name for layout data resource.</param>
        public LayoutDataResource(string layoutData, string layoutDataResourceName = null) : base()
        {
            if (layoutData.EndsWith(".json"))
            {
                Data = Resource.GetUTF8FileData(layoutData);
            }
            else
            {
                Data = Encoding.UTF8.GetBytes(layoutData);
            }
            if (layoutDataResourceName == null)
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
        /// Gets or sets name of the layout data resource.
        /// </summary>
        public string LayoutDataResourceName { get; set; }
    }
}
