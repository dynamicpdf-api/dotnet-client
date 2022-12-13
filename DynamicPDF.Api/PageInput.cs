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
        public PageInput(api.PageSize size = PageSize.Letter, api.PageOrientation orientation = api.PageOrientation.Portrait, float? margins = null) 
        { 
            if(orientation != api.PageOrientation.Portrait)
                PageOrientation = orientation;
            if(size != PageSize.A4) 
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

        ///// <summary>
        ///// Initializes a new instance of the <see cref="PageInput"/> class.
        ///// </summary>
        //public PageInput() { }

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
