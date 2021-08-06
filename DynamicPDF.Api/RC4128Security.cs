using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents RC4 128 bit PDF document security.
    /// </summary>
    /// <remarks>
    /// RC4 128 bit PDF security, with UseCryptFilter property set to false is compatible with PDF version 1.4 or higher and can be read
    /// with Adobe Acrobat Reader version 5 or higher. By default UseCryptFilter property is false. RC4 128 bit PDF security with crypt filter 
    /// is compatible with PDF version 1.5 or higher and can be read with Adobe Acrobat Reader version 6 and higher. 
    /// Older readers will not be able to read document encrypted with this security.
    public class RC4128Security : Security
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RC4128Security"/> class.
        /// </summary>
        /// <param name="ownerPassword">The owner password to open the document.</param>
        /// <param name="userPassword">The user password to open the document.</param>
        public RC4128Security( string userPassword, string ownerPassword) : base(userPassword, ownerPassword) { }
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal override SecurityType Type { get { return SecurityType.RC4128; } }

        /// <summary>
        /// Gets or sets the documents components to be encrypted.
        /// </summary>
        public bool? EncryptMetadata { get; set; }

    }
}
