using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using api = DynamicPDF.Api;
using System.Collections.Generic;
using System.Collections;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents a Word input.
    /// </summary>
    public class WordInput : ConverterInput
    {
        private List<TextReplace> textReplace;

        /// <summary>
        /// Initializes a new instance of the <see cref="WordInput"/> class.
        /// </summary>
        /// <param name="resource">The resource of type <see cref="WordResource"/>.</param>
        /// <param name="size">The page size of the output PDF.</param>
        /// <param name="orientation">The page orientation of the output PDF.</param>
        /// <param name="margins">The page margins of the output PDF.</param>
        public WordInput(WordResource resource, api.PageSize size = api.PageSize.Letter, api.PageOrientation orientation = api.PageOrientation.Portrait, float? margins = null) : base(resource, size, orientation, margins)
        { }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal override InputType Type { get { return InputType.Word; } }

        [JsonProperty("textReplace", NullValueHandling = NullValueHandling.Ignore)]
        internal List<TextReplace> GetTextReplace
        {
            get
            {
                if ((textReplace != null && textReplace.Count > 0))
                    return textReplace;
                else
                    return null;
            }
        }

        /// <summary>
        ///  Gets or sets the <see cref="TextReplace"/> object List.
        /// </summary>
        [JsonIgnore]
        public List<TextReplace> TextReplace
        {
            get
            {
                if (this.textReplace == null)
                    this.textReplace = new List<TextReplace>();
                return this.textReplace;
            }
            set => textReplace = value;
        }
    }
}
