using Newtonsoft.Json;
using System;
using api = DynamicPDF.Api;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents the base class for inputs.
    /// </summary>
    public abstract class ConverterInput : Input
    {
        private api.PageSize pageSize;
        private api.PageOrientation pageOrientation;

        internal ConverterInput(Resource resource, PageSize? pageSize, PageOrientation? pageOrientation, float? margins) : base(resource)
        {
            if (pageSize.HasValue) PageSize = pageSize.Value;
            if (pageOrientation.HasValue) PageOrientation = pageOrientation.Value;

            if (margins != null)
            {
                TopMargin = margins;
                BottomMargin = margins;
                RightMargin = margins;
                LeftMargin = margins;
            }
        }

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
                if (PageWidth.HasValue && PageHeight.HasValue)
                {
                    float smaller;
                    float larger;
                    if (PageWidth > PageHeight)
                    {
                        smaller = PageHeight.Value;
                        larger = PageWidth.Value;
                    }
                    else
                    {
                        smaller = PageWidth.Value;
                        larger = PageHeight.Value;
                    }
                    if (PageOrientation == PageOrientation.Landscape)
                    {
                        PageHeight = smaller;
                        PageWidth = larger;
                    }
                    else
                    {
                        PageHeight = larger;
                        PageWidth = smaller;
                    }
                }
            }
        }
    }
}