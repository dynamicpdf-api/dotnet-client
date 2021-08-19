using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace DynamicPDF.Api
{

    /// <summary>
    /// Represents an image input.
    /// </summary>
    public class ImageInput : Input
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageInput"/> class.
        /// </summary>
        /// <param name="resource">The <see cref="ImageResource"/> object to create ImageInput.</param>
        public ImageInput(ImageResource resource) : base(resource) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageInput"/> class.
        /// </summary>
        /// <param name="cloudResourcePath">The image file path present in cloud resource manager.</param>
        public ImageInput(string cloudResourcePath) : base(cloudResourcePath) { }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal override InputType Type { get { return InputType.Image; } }

        /// <summary>
        /// Gets or sets the scaleX of the image.
        /// </summary>
        public float? ScaleX { get; set; }

        /// <summary>
        /// Gets or sets the scaleY of the image.
        /// </summary>
        public float? ScaleY { get; set; }

        /// <summary>
        /// Gets or sets the top margin.
        /// </summary>
        public float? TopMargin { get; set; }

        /// <summary>
        /// Gets or sets the left margin.
        /// </summary>
        public float? LeftMargin { get; set; }

        /// <summary>
        /// Gets or sets the bottom margin.
        /// </summary>
        public float? BottomMargin { get; set; }

        /// <summary>
        /// Gets or sets the right margin.
        /// </summary>
        public float? RightMargin { get; set; }

        /// <summary>
        /// Gets or sets the page width.
        /// </summary>
        public float? PageWidth { get; set; }

        /// <summary>
        /// Gets or sets the page height.
        /// </summary>
        public float? PageHeight { get; set; }

        /// <summary>
        /// Gets or sets a boolean indicating whether to expand the image.
        /// </summary>
        public bool? ExpandToFit { get; set; }

        /// <summary>
        /// Gets or sets a boolean indicating whether to shrink the image.
        /// </summary>
        public bool? ShrinkToFit { get; set; }

        /// <summary>
        /// Gets or sets the horizontal alignment of the image.
        /// </summary>
        [JsonProperty("align")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        public Align Align { get; set; } = Align.Center;

        /// <summary>
        /// Gets or sets the vertical alignment of the image.
        /// </summary>
        [JsonProperty("vAlign")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        public VAlign VAlign { get; set; } = VAlign.Center;

        /// <summary>
        /// Gets or sets the start page.
        /// </summary>
        public int? StartPage { get; set; }

        /// <summary>
        /// Gets or sets the page count.
        /// </summary>
        public int? PageCount { get; set; }
    }
}
