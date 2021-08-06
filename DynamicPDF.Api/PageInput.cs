using DynamicPDF.Api.Elements;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents a page input.
    /// </summary>
    public class PageInput : Input
    {
        private List<Element> elements;

        /// <summary>
        /// Initializes a new instance of the <see cref="PageInput"/> class.
        /// </summary>
        /// <param name="pageWidth">The width of the page.</param>
        /// <param name="pageHeight">The height of the page.</param>
        public PageInput(float pageWidth, float pageHeight) { PageWidth = pageWidth; PageHeight = pageHeight; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PageInput"/> class.
        /// </summary>
        public PageInput() { }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal override InputType Type { get { return InputType.Page; } }

        /// <summary>
        /// Gets or sets the width of the page.
        /// </summary>
        public float? PageWidth { get; set; }

        /// <summary>
        /// Gets or sets the height of the page.
        /// </summary>
        public float? PageHeight { get; set; }

        /// <summary>
        /// Gets or sets the elements of the page.
        /// </summary>
        public List<Element> Elements
        {
            get
            {
                if (elements == null)
                {
                    elements = new List<Element>();
                }
                return elements;
            }
        }
    }
}
