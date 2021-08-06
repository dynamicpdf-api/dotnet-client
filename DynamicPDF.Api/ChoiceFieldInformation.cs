namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents the information of a choice field in interactive forms.
    /// A choice field contains several text items,
    /// one or more of which may be selected as the field value.
    /// </summary>
    public class ChoiceFieldInformation
    {
        /// <summary>
        /// Gets or Sets the name of the choice field.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ChoiceFieldType"/>. ex: ListBox, ComboBox etc.
        /// </summary>
        public ChoiceFieldType Type { get; set; }

        /// <summary>
        /// Gets or sets the value of the choice field.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets or Sets the default value of the choice field.
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// Gets or Sets the export value.
        /// </summary>
        public string ExportValue { get; set; }

        /// <summary>
        /// Gets the collection of items.
        /// </summary>
        public string[] Items { get; set; }

        /// <summary>
        /// Gets the collection of export values of the items present in the choice field.
        /// </summary>
        public string[] ItemExportValues { get; set; }
    }
}