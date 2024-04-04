using Newtonsoft.Json;
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

        internal ConverterInput(Resource resource, PageSize pageSize, PageOrientation pageOrientation, float? margins) : base(resource)
        {
            PageSize = pageSize;
            PageOrientation = pageOrientation;

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
        public float PageWidth { get; set; }

        /// <summary>
        /// Gets or sets the page height.
        /// </summary>
        public float PageHeight { get; set; }

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
