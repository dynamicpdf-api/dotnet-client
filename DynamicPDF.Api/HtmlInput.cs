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
    /// Represents a html input.
    /// </summary>
    public class HtmlInput : Input
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlInput"/> class.
        /// </summary>
        /// <param name="resource">The resource of type <see cref="HtmlResource"/>.</param>
        /// <param name="basepath">The basepath options for the url.</param>
        public HtmlInput(HtmlResource resource, string basepath = null) : base(resource)
        {
            Resources.Add(resource);
            resourceName = resource.ResourceName;

            if (basepath != null)
            {
                basePath = basepath;
            }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlInput"/> class.
        /// </summary>
        /// <param name="htmlString">The Html content for conversion.</param>
        /// <param name="basepath">The basepath options for the url.</param>
        public HtmlInput(string htmlString, string basepath = null) : base(htmlString)
        {
            this.htmlString = htmlString;

            if (basepath != null)
            {
                basePath = basepath;
            }
        }

        [JsonProperty]
        internal string resourceName { get; set; } = null;

        /// <summary>
        /// Gets or sets the Html String for Input.
        /// </summary>
        public string htmlString { get; set; } = null;

        /// <summary>
        /// Gets or sets the Basepath option.
        /// </summary>
        public string basePath { get; set; } = null;

        [JsonProperty]
        internal double? pageWidth { get; set; }

        [JsonProperty]
        internal double? pageHeight { get; set; }

        [JsonProperty]
        internal double? topMargin { get; set; }

        [JsonProperty]
        internal double? bottomMargin { get; set; }

        [JsonProperty]
        internal double? rightMargin { get; set; }

        [JsonProperty]
        internal double? leftMargin { get; set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal override InputType Type { get { return InputType.Html; } }

        /// <summary>
        /// Sets the Margin for Pdf Output.
        /// </summary>
        /// <param name="margin">The margin for all four sides.</param>

        public void Margin(double margin)
        {
            topMargin = margin;
            bottomMargin = margin;
            rightMargin = margin;
            leftMargin = margin;
        }

        /// <summary>
        /// Sets the Margin for Pdf Output.
        /// </summary>
        /// <param name="topBottom">The Top and Bottom margin.</param>
        /// <param name="rightLeft">The Right and Left margin.</param>
        public void Margin(double topBottom, double rightLeft)
        {
            topMargin = topBottom;
            bottomMargin = topBottom;
            rightMargin = rightLeft;
            leftMargin = rightLeft;
        }

        /// <summary>
        /// Sets the Margin for Pdf Output.
        /// </summary>
        /// <param name="topBottom">The Top and Bottom margin.</param>
        /// <param name="right">The Right margin.</param>
        /// <param name="left">The Left margin.</param>
        public void Margin(double topBottom, double right, double left)
        {
            topMargin = topBottom;
            bottomMargin = topBottom;
            rightMargin = right;
            leftMargin = left;
        }

        /// <summary>
        /// Sets the Margin for Pdf Output.
        /// </summary>
        /// <param name="top">The Top margin.</param>
        /// <param name="bottom">The Bottom margin.</param>
        /// <param name="right">The Right margin.</param>
        /// <param name="left">The Left margin.</param>

        public void Margin(double top, double bottom, double right, double left)
        {
            topMargin = top;
            bottomMargin = bottom;
            rightMargin = right;
            leftMargin = left;
        }

        /// <summary>
        /// Sets the Page for Pdf Output.
        /// </summary>
        /// <param name="width">The Width of the page.</param>
        /// <param name="height">The Height of the page.</param>
        public void PageSize(double width, double height)
        {
            pageHeight = height;
            pageWidth = width;
        }

        /// <summary>
        /// Sets the Page for Pdf Output.
        /// </summary>
        /// <param name="pageSize">The <see cref="Api.PageSize"/> of the page.</param>
        /// <param name="orientation">The <see cref="PageOrientation"/> of the page.</param>
        public void PageSize(PageSize pageSize, PageOrientation orientation)
        {
            double smaller;
            double larger;

            UnitConverter.GetPaperSize(pageSize, out smaller, out larger);

            if (orientation == PageOrientation.Portrait)
            {
                pageWidth = smaller;
                pageHeight = larger;
            }
            else
            {
                pageWidth = larger;
                pageHeight = smaller;
            }
        }
    }
}
