
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents a goto action.
    /// </summary>
    public class GoToAction : Action
    {
        /// <summary>
        /// Initializes a new instance of the  <see cref="GoToAction"/> class.
        /// </summary>
        /// <param name="input">The input of type of any one of following <see cref="ImageInput"/>, <see cref="DlexInput"/>, <see cref="PdfInput"/> or <see cref="PageInput"/>.</param>
        /// <param name="pageOffset">Page number targeted by the destination.</param>
        /// <param name="pageZoom">Zoom used to display the destination.</param>
        public GoToAction(Input  input, int pageOffset = 0, PageZoom pageZoom = PageZoom.FitPage ) { Input = input;  InputID = input.Id; PageOffset = pageOffset; PageZoom = pageZoom; } 
        internal Input Input { get; set; }
       
        [JsonProperty]
        internal string InputID { get; set; }

        /// <summary>
        /// Gets or sets page Offset.
        /// </summary>
        public int PageOffset { get; set; }

        /// <summary>
        /// Gets or sets page zoom.
        /// </summary>
        [JsonProperty("pageZoom")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        public PageZoom PageZoom { get; set; }

    }
}
