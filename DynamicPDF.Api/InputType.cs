using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Specifies an input type.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum InputType
    {
        /// <summary>
        /// Pdf input.
        /// </summary>
        Pdf,

        /// <summary>
        /// Image input.
        /// </summary>
        Image,

        /// <summary>
        /// Dlex input.
        /// </summary>
        Dlex,

        /// <summary>
        /// Page input.
        /// </summary>
        Page,

        /// <summary>
        /// Html input.
        /// </summary>
        Html,

        /// <summary>
        /// Word input.
        /// </summary>
        Word
    }
}
