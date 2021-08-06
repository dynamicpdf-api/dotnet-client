using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace DynamicPDF.Api.Elements
{
    /// <summary>
    /// Represents an image element.
    /// </summary>
    /// <remarks>This class can be used to place images on a page.</remarks>
    public class ImageElement : Element
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageElement"/> class.
        /// </summary>
        /// <param name="resource"><see cref="ImageResource"/> object containing the image resource.</param>
        /// <param name="placement">The placement of the image on the page.</param>
        /// <param name="xOffset">X coordinate of the image.</param>
        /// <param name="yOffset">Y coordinate of the image.</param>
        public ImageElement(ImageResource resource, ElementPlacement placement, float xOffset = 0, float yOffset = 0) : base()
        {
            Resource = resource;
            ResourceName = resource.ResourceName;
            Placement = placement;
            XOffset = xOffset;
            YOffset = yOffset;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageElement"/> class.
        /// </summary>
        /// <param name="resourceName">The name of the image resource.</param>
        /// <param name="placement">The placement of the image on the page.</param>
        /// <param name="xOffset">X coordinate of the image.</param>
        /// <param name="yOffset">Y coordinate of the image.</param>
        public ImageElement(string resourceName, ElementPlacement placement, float xOffset = 0, float yOffset = 0) : base()
        {
            ResourceName = resourceName;
            Placement = placement;
            XOffset = xOffset;
            YOffset = yOffset;
        }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal override ElementType Type { get; } = ElementType.Image;
        internal override Resource Resource { get; set; }
        [JsonProperty]
        internal string ResourceName { get; set; }

        /// <summary>
        /// Gets or sets the horizontal scale of the image.
        /// </summary>
        public float? ScaleX { get; set; }

        /// <summary>
        /// Gets or sets the vertical scale of the image.
        /// </summary>
        public float? ScaleY { get; set; }

        /// <summary>
        /// Gets or sets the maximum height of the image.
        /// </summary>
        public float? MaxHeight { get; set; }

        /// <summary>
        /// Gets or sets the maximum width of the image.
        /// </summary>
        public float? MaxWidth { get; set; }
    }
}
