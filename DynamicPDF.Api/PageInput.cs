using DynamicPDF.Api.Elements;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using api = DynamicPDF.Api;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents a page input.
    /// </summary>
    public class PageInput : Input
    {
        private List<Element> elements;
        private api.PageSize pageSize;
        private api.PageOrientation pageOrientation;
        private const float DefaultPageHeight = 792.0f;
        private const float DefaultPagewidth = 612.0f;

        /// <summary>
        /// Initializes a new instance of the <see cref="PageInput"/> class.
        /// </summary>
        /// <param name="size">The size of the page.</param>
        /// <param name="orientation">The orientation of the page.</param>
        /// <param name="margins">The margins of the page.</param>
        public PageInput(api.PageSize size = PageSize.Letter, api.PageOrientation orientation = api.PageOrientation.Portrait, float? margins = null) 
        { 
            if(orientation != api.PageOrientation.Portrait)
                PageOrientation = orientation;
            if(size != PageSize.Letter )
                PageSize = size;
            if(margins != null)
            {
                TopMargin = margins;
                BottomMargin = margins;
                RightMargin = margins;
                LeftMargin = margins;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PageInput"/> class.
        /// </summary>
        /// <param name="pageWidth">The width of the page.</param>
        /// <param name="pageHeight">The height of the page.</param>
        public PageInput(float pageWidth, float pageHeight) { PageWidth = pageWidth; PageHeight = pageHeight; }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal override InputType Type { get { return InputType.Page; } }

        /// <summary>
        /// Gets or sets the width of the page.
        /// </summary>
        [JsonIgnore]
        public float? PageWidth { get; set; } = null;

        /// <summary>
        /// Gets or sets the height of the page.
        /// </summary>
        [JsonIgnore]
        public float? PageHeight { get; set; } = null;

        [JsonProperty("PageWidth")]
        internal float Widht { get { return ((PageWidth == null) ? DefaultPagewidth : PageWidth.Value); } }

        [JsonProperty("PageHeight")]
        internal float Height { get { return ((PageHeight == null) ? DefaultPageHeight : PageHeight.Value); } }

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
        /// Gets or sets the Page size.
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
                float largerWidth = (float)PageHeight;
                if (PageWidth > PageHeight)
                {
                    smaller = (float)PageHeight;
                    largerWidth = (float)PageWidth;
                }
                else
                {
                    smaller = (float)PageWidth;
                    largerWidth = (float)PageHeight;
                }
                if (PageOrientation == PageOrientation.Portrait)
                {
                    PageHeight = largerWidth;
                    PageWidth = smaller;
                }
                else
                {
                    PageHeight = smaller;
                    PageWidth = largerWidth;
                }

            }
        }

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
