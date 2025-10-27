using Newtonsoft.Json;

using System.Threading.Tasks;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents the pdf security info endpoint.
    /// </summary>
    public class PdfSecurityInfo 
    {
        /// <summary>
        /// Gets or sets the encryption type.
        /// </summary>
        [JsonProperty("encryptionType")]
        public string EncryptionTypeString { get; set; }

        [JsonIgnore]
        public EncryptionType EncryptionType
        {
            get
            {
                switch(EncryptionTypeString)
                {
                    case "rc4-40":
                        return EncryptionType.RC440;
                    case "rc4-128":
                        return EncryptionType.RC4128;
                    case "aes-128-cbc":
                        return EncryptionType.Aes128Cbc;
                    case "aes-256-cbc":
                        return EncryptionType.Aes256Cbc;
                    default:
                        return EncryptionType.None;
                }
            }
        }

        /// <summary>
        ///  Gets or sets if the document can be edited by the user.
        /// </summary>
        public bool? AllowEdit { get; set; } = null;

        /// <summary>
        /// Gets or sets if the document can be printed by the user.
        /// </summary>
        public bool? AllowPrint { get; set; } = null;

        /// <summary>
        /// Gets or sets if annotations and form fields can be added, edited
        /// and modified by the user.
        /// </summary>
        public bool? AllowUpdateAnnotsAndFields { get; set; } = null;

        /// <summary>
        /// Gets or sets if text and images can be copied to the clipboard by the user.
        /// </summary>
        public bool? AllowCopy { get; set; } = null;

        /// <summary>
        /// Gets or sets if the document can be printed at a high resolution by the user.
        /// </summary>
        public bool? AllowHighResolutionPrinting { get; set; } = null;

        /// <summary>
        /// Gets or sets if the document can be assembled and manipulated by the user.
        /// </summary>
        public bool? AllowDocumentAssembly { get; set; } = null;

        /// <summary>
        /// Gets or sets if form filling should be allowed by the user.
        /// </summary>
        public bool? AllowFormFilling { get; set; } = null;

        /// <summary>
        /// Gets or sets if accessibility programs should be able to read
        /// the documents text and images for the user.
        /// </summary>
        public bool? AllowAccessibility { get; set; } = null;

        /// <summary>
        /// Gets or sets a value indicating whether all data should be encrypted except for metadata.
        /// </summary>
        public bool? EncryptAllExceptMetadata { get; set; } = null;

        /// <summary>
        /// Gets or sets a value indicating whether only file attachments should be encrypted.
        /// </summary>
        public bool? EncryptOnlyFileAttachments { get; set; } = null;

        /// <summary>
        /// Gets or sets a value indicating whether the PDF document has an owner password set.
        /// </summary>
        public bool HasOwnerPassword { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the PDF document has an user password set.
        /// </summary>
        public bool HasUserPassword { get; set; }
    }
}
