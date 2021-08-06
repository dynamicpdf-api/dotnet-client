
namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents options for merging PDF documents.
    /// </summary>
    public class MergeOptions
    {
        /// <summary>
        /// Gets or sets a value indicating if document information should be imported.
        /// </summary>
        public bool? DocumentInfo { get; set; }

        /// <summary>
        /// Gets or sets a value indicating if document level JavaScript should be imported.
        /// </summary>
        public bool? DocumentJavaScript { get; set; }

        /// <summary>
        /// Gets or sets a value indicating if document properties should be imported.
        /// </summary>
        public bool? DocumentProperties { get; set; }

        /// <summary>
        /// Gets or sets a value indicating if the Embedded files should be imported.
        /// </summary>
        public bool? EmbeddedFiles { get; set; }

        /// <summary>
        /// Gets or sets a value indicating if form fields should be imported.
        /// </summary>
        public bool? FormFields { get; set; }

        /// <summary>
        /// Gets or sets a value indicating if form XFA data should be imported.
        /// </summary>
        public bool? FormsXfaData { get; set; }

        /// <summary>
        /// Gets or Sets the value indicating if logical structure should be imported.
        /// </summary>
        public bool? LogicalStructure { get; set; }

        /// <summary>
        /// Gets or sets a value indicating if the documents opening action (initial page and zoom settings) should be imported.
        /// </summary>
        public bool? OpenAction { get; set; }

        /// <summary>
        /// Gets or sets the Output Content should be imported.
        /// </summary>
        public bool? OptionalContentInfo { get; set; }

        /// <summary>
        /// Gets or sets a value indicating if outlines and bookmarks should be imported.
        /// </summary>
        public bool? Outlines { get; set; }

        /// <summary>
        /// Gets or Sets a value indication if OutputIntent should be imported.
        /// </summary>
        public bool? OutputIntent { get; set; }

        /// <summary>
        /// Gets or sets a value indicating if annotations should be imported.
        /// </summary>
        public bool? PageAnnotations { get; set; }

        /// <summary>
        /// Gets or sets a value indicating if page labels and sections should be imported.
        /// </summary>
        public bool? PageLabelsAndSections { get; set; }

        /// <summary>
        /// Gets or sets the root form field for imported form fields.
        /// </summary>
        public string RootFormField { get; set; } = null;

        /// <summary>
        /// Gets or sets a value indicating if Xmp Metadata should be imported.
        /// </summary>
        public bool? XmpMetadata { get; set; }
    }
}
