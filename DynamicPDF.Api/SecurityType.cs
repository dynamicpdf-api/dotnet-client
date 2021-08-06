using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents different types of the security.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SecurityType
    {
        /// <summary>
        /// AES 128 bit security.
        /// </summary>
        Aes128,

        /// <summary>
        /// AES 256 bit security.
        /// </summary>
        Aes256,

        /// <summary>
        /// RC4 128 bit security.
        /// </summary>
        RC4128
    }
}
