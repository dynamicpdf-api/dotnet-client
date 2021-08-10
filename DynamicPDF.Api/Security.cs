using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Base class from which all security classes are derived.
    /// </summary>
    public abstract class Security
    {
        internal Security()
        {
        }
        internal Security(string userPwd, string ownerPwd)
        {
            UserPassword = userPwd;
            OwnerPassword = ownerPwd;
        }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal abstract SecurityType Type { get; }

        /// <summary>
        /// Gets or sets if text and images can be copied to the clipboard by the user.
        /// </summary>
        public bool? AllowCopy { get; set; }

        /// <summary>
        /// Gets or sets if the document can be edited by the user.
        /// </summary>
        public bool? AllowEdit { get; set; }

        /// <summary>
        /// Gets or sets if the document can be printed by the user.
        /// </summary>
        public bool? AllowPrint { get; set; }

        /// <summary>
        /// Gets or sets if annotations and form fields can be added, edited
        /// and modified by the user.
        /// </summary>
        public bool? AllowUpdateAnnotsAndFields { get; set; }

        /// <summary>
        /// Gets or sets the owner password.
        /// </summary>
        public string OwnerPassword { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the user password.
        /// </summary>
        public string UserPassword { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets if accessibility programs should be able to read
        /// the documents text and images for the user.
        /// </summary>
        public bool? AllowAccessibility { get; set; }

        /// <summary>
        /// Gets or sets if form filling should be allowed by the user.
        /// </summary>
        public bool? AllowFormFilling { get; set; }

        /// <summary>
        /// Gets or sets if the document can be printed at a high resolution by the user.
        /// </summary>
        public bool? AllowHighResolutionPrinting { get; set; }

        /// <summary>
        /// Gets or sets if the document can be assembled and manipulated by the user.
        /// </summary>
        public bool? AllowDocumentAssembly { get; set; }
    }
}
