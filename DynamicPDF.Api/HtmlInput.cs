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
                HtmlString = htmlString;
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
            else
            {
                throw new EndpointException("Specify valid Html string.");
            }
        }   

        /// <summary>
        /// Gets the html string for the input.
        /// </summary>
        public string HtmlString { get; internal set; } = null;

        /// <summary>
        /// Gets or sets the base path option.
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
        public float PageWidth { get; set; } = 612.0f;

        /// <summary>
        /// Gets or sets the page height.
        /// </summary>
        public float PageHeight { get; set; } = 792.0f;

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal override InputType Type { get { return InputType.Html; } }

        /// <summary>
        /// Gets or sets the page size.
        /// </summary>
        [JsonIgnore]
        public api.PageSize PageSize
        {
            set
            {
                pageSize = value;
                double smaller = 0.0f;
                double larger = 0.0f;
                UnitConverter.GetPaperSize(value, out smaller, out larger);
                if (PageOrientation == PageOrientation.Portrait)
                {
                    PageHeight = (float)larger;
                    PageWidth = (float)smaller;
                }
                else
                {
                    PageHeight = (float)smaller;
                    PageWidth = (float)larger; 
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
                float smaller = (float)PageWidth;
                float larger = (float)PageHeight;
                if (PageWidth > PageHeight)
                {
                    smaller = (float)PageHeight;
                    larger = (float)PageWidth;
                }
                else
                {
                    smaller = (float)PageWidth;
                    larger = (float)PageHeight;
                }
                if (PageOrientation == PageOrientation.Portrait)
                {
                    PageHeight = larger;
                    PageWidth = smaller;
                }
                else
                {
                    PageHeight = smaller;
                    PageWidth = larger;
                }
            }
        } 
    }
}
