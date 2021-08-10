namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents information of a MultiSelectListBox.
    /// </summary>
    public class MultiSelectListBoxInformation
    {
        /// <summary>
        /// Gets or Sets the name of a MultiSelectListBox.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a collection of values of the MultiSelectListBox.
        /// </summary>
        public string[] Values { get; set; }

        /// <summary>
        /// Gets or sets a collection of default values of the MultiSelectListBox.
        /// </summary>
        public string[] DefaultValues { get; set; }

        /// <summary>
        /// Gets or sets a collection of export values of the MultiSelectListBox.
        /// </summary>
        public string[] ExportValues { get; set; }

        /// <summary>
        /// Gets or sets a collection of items of the MultiSelectListBox.
        /// </summary>
        public string[] Items { get; set; }

        /// <summary>
        /// Gets or sets a collection of export values of the MultiSelectListBox.
        /// </summary>
        public string[] ItemsExportValues { get; set; }
    }
}