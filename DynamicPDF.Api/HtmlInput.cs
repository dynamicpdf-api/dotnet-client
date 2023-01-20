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
        /// <param name="size">The page size of the output PDF.</param>
        /// <param name="orientation">The page orientation of the output PDF.</param>
        /// <param name="margins">The page margins of the output PDF.</param>
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
        public float PageWidth { get; set; } 

        /// <summary>
        /// Gets or sets the page height.
        /// </summary>
        public float PageHeight { get; set; } 

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
                double smaller;
                double larger;
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
                float smaller;
                float larger;
                if (PageWidth > PageHeight)
                {
                    smaller = PageHeight;
                    larger = PageWidth;
                }
                else
                {
                    smaller = PageWidth;
                    larger = PageHeight;
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
