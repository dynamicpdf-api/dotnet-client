using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace DynamicPDF.Api.Elements
{
    /// <summary>
    /// Represents a page numbering label page element.
    /// </summary>
    /// <remarks>
    /// This class can be used to add page numbering to a PDF document. The following tokens can be used within the
    /// text of a PageNumberingLabel. They will be replaced with the appropriate value when the PDF is output.
    /// <list type="table">
    /// <listheader>
    /// <term>Token</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>CP</term>
    /// <description>Current page. The default numbering style is numeric.</description>
    /// </item>
    /// <item>
    /// <term>TP</term>
    /// <description>Total pages. The default numbering style is numeric.</description>
    /// </item>
    /// <item>
    /// <term>SP</term>
    /// <description>Section page.</description>
    /// </item>
    /// <item>
    /// <term>ST</term>
    /// <description>Section Total.</description>
    /// </item>
    /// <item>
    /// <term>PR</term>
    /// <description>Prefix.</description>
    /// </item>
    /// </list>
    /// <p/>
    /// All tokens except the /%/%PR/%/% token can also contain a numbering style specifier. The numbering style specifier
    /// is placed in parenthesis after the token.
    /// <list type="table">
    /// <listheader>
    /// <term>Numbering Style</term>
    /// <description>Description</description>
    /// </listheader>
    /// <item>
    /// <term>1</term>
    /// <description>Numeric. Arabic numbers are used: 1, 2, 3, etc. Example: "/%/%CP(1)/%/%"</description>
    /// </item>
    /// <item>
    /// <term>i</term>
    /// <description>Lower Case Roman Numerals. Lower case roman numerals are used: i, ii, iii, etc.
    /// Example: "/%/%CP(i)/%/%".</description>
    /// </item>
    /// <item>
    /// <term>I</term>
    /// <description>Upper Case Roman Numerals. Upper case roman numerals are used: I, II, III, etc.
    /// Example: "/%/%CP(I)/%/%".</description>
    /// </item>
    /// <item>
    /// <term>a</term>
    /// <description>Lower Latin Letters. Lower case Latin letters are used: a, b, c, etc. After z, aa is used
    /// followed by bb, cc, etc. Example: "/%/%CP(a)/%/%".</description>
    /// </item>
    /// <item>
    /// <term>A</term>
    /// <description>Upper Latin Letters. Upper case Latin letters are used: A, B, C, etc. After Z, AA is used
    /// followed by BB, CC, etc. Example: "/%/%CP(A)/%/%".</description>
    /// </item>
    /// <item>
    /// <term>b</term>
    /// <description>Lower Latin Letters. Lower case Latin letters are used: a, b, c, etc. After z, aa is used
    /// followed by ab, ac, etc. Example: "/%/%CP(b)/%/%".</description>
    /// </item>
    /// <item>
    /// <term>B</term>
    /// <description>Lower Latin Letters. Lower case Latin letters are used: A, B, C, etc. After Z, AA is used
    /// followed by AB, AC, etc. Example: "/%/%CP(B)/%/%".</description>
    /// </item>
    /// </list>
    /// <p/>
    /// There should be no spaces within a token, only the token and optional numbering style specifier. This
    /// token is <b>invalid</b> /%/%CP ( i )/%/% because of the extra spaces.<p/>Here are some examples of valid tokens:
    /// <ul style="margin-top: 0px;">
    /// <li>/%/%SP/%/%</li>
    /// <li>/%/%SP(I)/%/%</li>
    /// <li>/%/%PR/%/%</li>
    /// <li>/%/%ST(B)/%/%</li>
    /// </ul>
    /// </remarks>
    public class PageNumberingElement : Element
    {
        private Font font;
        private Color color;

        /// <summary>
        /// Initializes a new instance of the <see cref="PageNumberingElement"/> class.
        /// </summary>
        /// <param name="text">Text to display in the label.</param>
        /// <param name="placement">The placement of the page numbering element on the page.</param>
        /// <param name="xOffset">X coordinate of the label.</param>
        /// <param name="yOffset">Y coordinate of the label.</param>
        public PageNumberingElement(string text, ElementPlacement placement, float xOffset = 0, float yOffset = 0) : base(text, placement, xOffset, yOffset) { }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal override ElementType Type { get; } = ElementType.PageNumbering;

        internal override Resource Resource { get; set; }

        internal override Font TextFont { get { return font; } }

        [JsonProperty("font")]
        internal string FontName { get; set; }

        [JsonProperty("color")]
        internal string ColorName { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Color"/> object to use for the text of the label.
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
                ColorName = value.ColorString;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="Font"/> object to use for the text of the label.
        /// </summary>
        [JsonIgnore]
        public Font Font
        {
            get
            {
                return font;
            }
            set
            {
                font = value;
                FontName = font.Name;
                Resource = font.Resource;
            }
        }

        /// <summary>
        /// Gets or sets the font size for the text of the label.
        /// </summary>
        public float? FontSize { get; set; }

        /// <summary>
        /// Gets or sets the text to display in the label.
        /// </summary>
        public string Text
        {
            get
            {
                return InputValue;
            }
            set
            {
                InputValue = value;
            }
        }
    }
}
