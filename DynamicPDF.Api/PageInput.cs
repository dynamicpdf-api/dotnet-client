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

        /// <summary>
        /// Initializes a new instance of the <see cref="PageInput"/> class.
        /// </summary>
        /// <param name="size">The size of the page.</param>
        /// <param name="orientation">The orientation of the page.</param>
        /// <param name="margins">The margins of the page.</param>
        public PageInput(api.PageSize? size = null, api.PageOrientation? orientation = null, float? margins = null)
        {
            if (size.HasValue)
                PageSize = size.Value;

            if (orientation.HasValue)
                PageOrientation = orientation.Value;

            if (margins != null)
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
        public float? PageWidth { get; set; } = null;

        /// <summary>
        /// Gets or sets the height of the page.
        /// </summary>
        public float? PageHeight { get; set; } = null;

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
                double smaller;
                double larger;
                UnitConverter.GetPaperSize(value, out smaller, out larger);
                if (PageOrientation == PageOrientation.Landscape)
                {
                    PageHeight = (float)smaller;
                    PageWidth = (float)larger;
                }
                else
                {
                    PageHeight = (float)larger;
                    PageWidth = (float)smaller;
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
                float largerWidth;

                if (PageWidth.HasValue && PageHeight.HasValue)
                {
                    if (PageWidth > PageHeight)
                    {
                        smaller = PageHeight.Value;
                        largerWidth = PageWidth.Value;
                    }
                    else
                    {
                        smaller = PageWidth.Value;
                        largerWidth = PageHeight.Value;
                    }
                    if (PageOrientation == PageOrientation.Landscape)
                    {
                        PageHeight = smaller;
                        PageWidth = largerWidth;
                    }
                    else
                    {
                        PageHeight = largerWidth;
                        PageWidth = smaller;
                    }
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
