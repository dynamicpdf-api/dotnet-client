using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using api = DynamicPDF.Api;


namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents a html input.
    /// </summary>
    public class HtmlInput : Input
    {
        private api.PageSize pageSize = api.PageSize.A4;
        private api.PageOrientation pageOrientation = api.PageOrientation.Portrait;

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlInput"/> class.
        /// </summary>
        /// <param name="resource">The resource of type <see cref="HtmlResource"/>.</param>
        /// <param name="basepath">The basepath options for the url.</param>
        public HtmlInput(HtmlResource resource, string basepath = null, api.PageSize size = api.PageSize.A4, api.PageOrientation orientation = api.PageOrientation.Portrait, float? margins = null) : base(resource)
        {
            if (orientation != api.PageOrientation.Portrait)
            {
                PageOrientation = orientation;
            }
            PageSize = size;
            if (basepath != null)
            {
                BasePath = basepath;
            }

            if (margins != null)
            {
                TopMargin = margins;
                BottomMargin = margins;
                RightMargin = margins;
                LeftMargin = margins;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlInput"/> class.
        /// </summary>
        /// <param name="resource">The resource of type <see cref="HtmlResource"/>.</param>
        /// <param name="basepath">The basepath options for the url.</param>
        public HtmlInput(string htmlString, string basepath = null, api.PageSize size = api.PageSize.A4, api.PageOrientation orientation = api.PageOrientation.Portrait, float? margins = null) : base()
        {
            if (orientation != api.PageOrientation.Portrait)
            {
                PageOrientation = orientation;
            }
            PageSize = size;
            if (basepath != null)
            {
                BasePath = basepath;
            }
            if (margins != null)
            {
                TopMargin = margins;
                BottomMargin = margins;
                RightMargin = margins;
                LeftMargin = margins;
            }
            if (htmlString != null)
            {
                this.HtmlString = htmlString;
            }
        }   

        /// <summary>
        /// Gets or sets the Html String for Input.
        /// </summary>
        public string HtmlString { get; set; } = null;

        /// <summary>
        /// Gets or sets the Basepath option.
        /// </summary>
        public string BasePath { get; set; } = null;

        /// <summary>
        /// Gets or sets the top margin.
        /// </summary>
        public float? TopMargin { get; set; } = null;

        /// <summary>
        /// Gets or sets the left margin.
        /// </summary>
        public float? LeftMargin { get; set; } = null;

        /// <summary>
        /// Gets or sets the bottom margin.
        /// </summary>
        public float? BottomMargin { get; set; } = null;

        /// <summary>
        /// Gets or sets the right margin.
        /// </summary>
        public float? RightMargin { get; set; } = null;

        /// <summary>
        /// Gets or sets the page width.
        /// </summary>
        public float? PageWidth { get; set; } = null;

        /// <summary>
        /// Gets or sets the page height.
        /// </summary>
        public float? PageHeight { get; set; } = null;

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal override InputType Type { get { return InputType.Html; } }

        /// <summary>
        /// Gets or sets the Page size.
        /// </summary>
        [JsonIgnore]
        public api.PageSize PageSize
        {
            set
            {
                pageSize = value;
                double pgWidth = 0.0f;
                double pgHeight = 0.0f;
                UnitConverter.GetPaperSize(value, out pgWidth, out pgHeight);
                if (PageOrientation == PageOrientation.Portrait)
                {
                    PageHeight = (float)pgHeight;
                    PageWidth = (float)pgWidth;
                }
                else
                {
                    PageHeight = (float)pgWidth;
                    PageWidth = (float)pgHeight; 
                }
            }
            get
            {
                return pageSize;
            }
        }

        /// <summary>
        /// Gets or sets page orientation.
        /// </summary>
        [JsonIgnore]
        public api.PageOrientation PageOrientation
        {
            get
            {
                return pageOrientation;
            }
            set
            {
                pageOrientation = value;
                if (pageOrientation == PageOrientation.Landscape)
                {
                    float? tempWidth = PageWidth;
                    if( PageWidth != null)
                    {
                        PageWidth = PageHeight;
                    }
                    if( PageHeight != null)
                    {
                        PageHeight = tempWidth;
                    }
                }
            }
        } 
    }
}
