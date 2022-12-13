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
        private api.PageSize pageSize ;
        private api.PageOrientation pageOrientation ;

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlInput"/> class.
        /// </summary>
        /// <param name="resource">The resource of type <see cref="HtmlResource"/>.</param>
        /// <param name="basepath">The basepath options for the url.</param>
        public HtmlInput(HtmlResource resource, string basepath = null, api.PageSize size = api.PageSize.Letter, api.PageOrientation orientation = api.PageOrientation.Portrait, float? margins = null) : base(resource)
        {
            PageSize = size;
            PageOrientation = orientation;
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
        public HtmlInput(string htmlString, string basepath = null, api.PageSize size = api.PageSize.Letter, api.PageOrientation orientation = api.PageOrientation.Portrait, float? margins = null) : base()
        {
            if (htmlString != null && htmlString.Length > 0)
            {
                PageSize = size;
                PageOrientation = orientation;
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
            else
            {
                throw new EndpointException("Specify valid Html string.");
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
                double smallerWidth = 0.0f;
                double largerWidth = 0.0f;
                UnitConverter.GetPaperSize(value, out smallerWidth, out largerWidth);
                if (PageOrientation == PageOrientation.Portrait)
                {
                    PageHeight = (float)largerWidth;
                    PageWidth = (float)smallerWidth;
                }
                else
                {
                    PageHeight = (float)smallerWidth;
                    PageWidth = (float)largerWidth; 
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

                if (PageWidth != null && PageHeight != null)
                {
                    float smallerWidth = (float)PageWidth;
                    float largerWidth = (float)PageHeight;
                    if (PageWidth > PageHeight)
                    {
                        smallerWidth = (float)PageHeight;
                        largerWidth = (float)PageWidth;
                    }
                    else
                    {
                        smallerWidth = (float)PageWidth;
                        largerWidth = (float)PageHeight;
                    }
                    if (PageOrientation == PageOrientation.Portrait)
                    {
                        PageHeight = largerWidth;
                        PageWidth = smallerWidth;
                    }
                    else
                    {
                        PageHeight = smallerWidth;
                        PageWidth = largerWidth;
                    }
                }
 
            }
        } 
    }
}
