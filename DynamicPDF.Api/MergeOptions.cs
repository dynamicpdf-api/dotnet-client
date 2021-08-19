namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents different options for merging PDF documents.
    /// </summary>
    public class MergeOptions
    {
        /// <summary>
        /// Gets or sets a boolean indicating whether to import document information when merging.
        /// </summary>
        public bool? DocumentInfo { get; set; }

        /// <summary>
        /// Gets or sets a boolean indicating whether to import document level JavaScript when merging.
        /// </summary>
        public bool? DocumentJavaScript { get; set; }

        /// <summary>
        /// Gets or sets a boolean indicating whether to import document properties when merging.
        /// </summary>
        public bool? DocumentProperties { get; set; }

        /// <summary>
        /// Gets or sets a boolean indicating whether to import embedded files when merging.
        /// </summary>
        public bool? EmbeddedFiles { get; set; }

        /// <summary>
        /// Gets or sets a boolean indicating whether to import form fields when merging.
        /// </summary>
        public bool? FormFields { get; set; }

        /// <summary>
        /// Gets or sets a boolean indicating whether to import XFA form data when merging.
        /// </summary>
        public bool? FormsXfaData { get; set; }

        /// <summary>
        /// Gets or sets a boolean indicating whether to import logical structure 
        /// (tagging information) when merging.
        /// </summary>
        public bool? LogicalStructure { get; set; }

        /// <summary>
        /// Gets or sets a boolean indicating whether to import document's opening 
        /// action (initial page and zoom settings) when merging.
        /// </summary>
        public bool? OpenAction { get; set; }

        /// <summary>
        /// Gets or sets a boolean indicating whether to import optional content when merging.
        /// </summary>
        public bool? OptionalContentInfo { get; set; }

        /// <summary>
        /// Gets or sets a boolean indicating whether to import outlines and bookmarks when merging.
        /// </summary>
        public bool? Outlines { get; set; }

        /// <summary>
        /// Gets or sets a boolean indicating whether to import OutputIntent when merging.
        /// </summary>
        public bool? OutputIntent { get; set; }

        /// <summary>
        /// Gets or sets a boolean indicating whether to import PageAnnotations when merging.
        /// </summary>
        public bool? PageAnnotations { get; set; }

        /// <summary>
        /// Gets or sets a boolean indicating whether to import PageLabelsAndSections when merging.
        /// </summary>
        public bool? PageLabelsAndSections { get; set; }

        /// <summary>
        /// Gets or sets the root form field for imported form fields. 
        /// Useful when merging a PDF repeatedly to have a better 
        /// contorl on the form field names.
        /// </summary>
        public string RootFormField { get; set; } = null;

        /// <summary>
        /// Gets or sets a boolean indicating whether to import XmpMetadata when merging.
        /// </summary>
        public bool? XmpMetadata { get; set; }
    }
}
