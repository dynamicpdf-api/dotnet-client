using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents a Dlex input.
    /// </summary>
    public class DlexInput : Input
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DlexInput"/> class by posting the 
        /// DLEX file and the JSON data file from the client to the API to create the PDF report.
        /// </summary>
        /// <param name="dlexResource">The <see cref="DlexResource"/>, dlex file created as per the desired PDF report layout design.</param>
        /// <param name="layoutData">The <see cref="LayoutDataResource"/>, json data file used to create the PDF report.</param>
        public DlexInput(DlexResource dlexResource, LayoutDataResource layoutData) : base()
        {
            ResourceName = dlexResource.ResourceName;
            LayoutDataResourceName = layoutData.LayoutDataResourceName;
            Resources.Add(dlexResource);
            Resources.Add(layoutData);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DlexInput"/> class by taking the 
        /// DLEX file path that is present in the cloud environment and the JSON data file from the client.
        /// </summary>
        /// <param name="cloudResourcePath">The DLEX file path present in the resource manager.</param>
        /// <param name="layoutData">The <see cref="LayoutDataResource"/>, json data file used to create the PDF report.</param>
        public DlexInput(string cloudResourcePath, LayoutDataResource layoutData) : base()
        {
            ResourceName = cloudResourcePath;
            LayoutDataResourceName = layoutData.LayoutDataResourceName;
            Resources.Add(layoutData);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DlexInput"/> class.
        /// </summary>
        /// <param name="cloudResourcePath">The DLEX file path present in the resource manager.</param>
        /// <param name="cloudLayoutDataPath">The JSON data file path present in the resource manager used to create the PDF report.</param>
        public DlexInput(string cloudResourcePath, string cloudLayoutDataPath) : base()
        {
            ResourceName = cloudResourcePath;
            LayoutDataResourceName = cloudLayoutDataPath;
        }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal override InputType Type { get { return InputType.Dlex; } }

        /// <summary>
        /// Gets or sets the name for layout data resource.
        /// </summary>
        public string LayoutDataResourceName { get; set; }
    }
}
