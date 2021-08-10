using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;

namespace DynamicPDF.Api.Elements
{
    /// <summary>
    /// Base class from which all page elements are derived.
    /// </summary>
    public abstract class Element
    {
        internal Element() { }
        internal Element(string value, ElementPlacement placement, float xOffset, float yOfset)
        {
            InputValue = value;
            Placement = placement;
            XOffset = xOffset;
            YOffset = yOfset;
        }

        internal Element(string value) { InputValue = value; }

        internal abstract ElementType Type { get; }

        internal virtual Resource Resource { get { return null; } set { } }

        internal string InputValue { get; set; }

        internal virtual Font TextFont { get; }

        /// <summary>
        /// Gets and sets placement of the page element on the page.
        /// </summary>
        [JsonProperty("placement")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        public ElementPlacement Placement { get; set; }

        /// <summary>
        /// Gets or sets the X coordinate of the page element.
        /// </summary>
        public float? XOffset { get; set; }

        /// <summary>
        /// Gets or sets the Y coordinate of the page element.
        /// </summary>
        public float? YOffset { get; set; }

        /// <summary>
        /// Gets or sets the boolean value specifying whether the element should be added to even pages or not.
        /// </summary>
        public bool? EvenPages { get; set; }

        /// <summary>
        /// Gets or sets the boolean value specifying whether the element should be added to odd pages or not.
        /// </summary>
        public bool? OddPages { get; set; }
    }
}
