using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents an outline.
    /// </summary>
    public class Outline
    {
        private Color color;
        private OutlineList children;

        /// <summary>
        /// Initializes a new instance of the <see cref="Outline"/> class.
        /// </summary>
        /// <param name="input">The input of type <see cref="PdfInput"/> .</param>
        internal Outline(PdfInput input)
        {
            FromInputID = input.Id;
            if (input.MergeOptions == null)
            {
                input.MergeOptions = new MergeOptions() { Outlines = false };
            }
            else
            {
                input.MergeOptions.Outlines = false;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Outline"/> class.
        /// </summary>
        /// <param name="text">text for the outline.</param>
        /// <param name="action">Action of the outline.</param>
        internal Outline(string text, Action action = null) { Text = text; Action = action; }

        [JsonProperty("color")]
        internal string ColorName { get; set; }

        /// <summary>
        /// Gets or sets the text of the outline.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the style of the outline.
        /// </summary>
        [JsonProperty("style")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        public OutlineStyle? Style { get; set; }

        /// <summary>
        /// Gets or sets a value specifying if the outline is expanded.
        /// </summary>
        public bool? Expanded { get; set; }

        /// <summary>
        /// Gets or sets a collection of child outlines.
        /// </summary>
        [JsonIgnore]
        public OutlineList Children 
        {
            get
            {
                if (children == null)
                    children = new OutlineList();
                return children;
            }
        }

        /// <summary>
        /// Gets or sets the Action of the outline.
        /// </summary>
        [JsonProperty("linkTo")]
        public Action Action { get; set; }
        [JsonProperty]
        internal string FromInputID { get; set; }

        /// <summary>
        /// Gets or sets the color of the outline.
        /// </summary>
        [JsonIgnore]
        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
                ColorName = color.ColorString;
            }
        }

        /// <summary>
        /// Gets or sets a collection of child outlines.
        /// </summary>
        [JsonProperty("children")]
        internal List<Outline> GetChildren
        {
            get
            {
                if (children != null)
                    return children.Outlines;
                return null;
            }
        }
    }
}
