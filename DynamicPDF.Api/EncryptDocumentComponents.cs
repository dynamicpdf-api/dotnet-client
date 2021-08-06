using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Specifies the document components to be encrypted. 
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EncryptDocumentComponents
    {
        /// <summary>
        /// Encrypts all document contents.
        /// </summary>
        All,
        /// <summary>
        /// Encrypts all document contents except metadata.
        /// </summary>
        AllExceptMetadata
    }
}
