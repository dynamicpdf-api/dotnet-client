
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents AES 256 bit PDF document security.
    /// </summary>
    /// <remarks>
    /// AES 256 bit PDF security is compatible with PDF version 1.5 and higher. 
    /// This class is FIPS compliant when used in applications targetting .NET framework v3.5 or higher. 
    /// Adobe Acrobat Reader version X or higher is needed to open these documents. 
    public class Aes256Security : Security
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Aes256Security"/> class by 
        /// taking the owner and user passwords as parameters to create PDF.
        /// </summary>
        /// <param name="ownerPassword">The owner password to open the document.</param>
        /// <param name="userPassword">The user password to open the document.</param>
        public Aes256Security(string userPassword, string ownerPassword) : base(userPassword, ownerPassword) { }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal override SecurityType Type { get { return SecurityType.Aes256; } }

        /// <summary>
        /// Gets or sets the <see cref="EncryptDocumentComponents"/>, components of the document to be encrypted. 
        /// We can encrypt all the PDF content or the content, excluding the metadata.
        /// </summary>
        [JsonProperty("documentComponents")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        public EncryptDocumentComponents? DocumentComponents { get; set; }
    }
}
