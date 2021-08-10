using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents a goto action in a PDF document that navigates 
    /// to a specific page using page number and zoom options.
    /// </summary>
    public class GoToAction : Action
    {
        /// <summary>
        /// Initializes a new instance of the  <see cref="GoToAction"/> class 
        /// using an input to create the PDF, page number, and a zoom option.
        /// </summary>
        /// <param name="input">Any of the <see cref="ImageInput"/>, <see cref="DlexInput"/>, 
        /// <see cref="PdfInput"/> or <see cref="PageInput"/> objects to create PDF.</param>
        /// <param name="pageOffset">Page number to navigate.</param>
        /// <param name="pageZoom"><see cref="PageZoom"/> to display the destination.</param>
        public GoToAction(Input input, int pageOffset = 0, PageZoom pageZoom = PageZoom.FitPage) { Input = input; InputID = input.Id; PageOffset = pageOffset; PageZoom = pageZoom; }

        internal Input Input { get; set; }

        [JsonProperty]
        internal string InputID { get; set; }

        /// <summary>
        /// Gets or sets page Offset.
        /// </summary>
        public int PageOffset { get; set; }

        /// <summary>
        /// Gets or sets <see cref="PageZoom"/> to display the destination.
        /// </summary>
        [JsonProperty("pageZoom")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        public PageZoom PageZoom { get; set; }
    }
}
