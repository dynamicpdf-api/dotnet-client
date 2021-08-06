namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents information of a text field.
    /// </summary>
    public class TextFieldInformation
    {
        /// <summary>
        /// Gets or Sets the name of the Text field.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets the value of the Text field.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets or Sets the default value of the Text field.
        /// </summary>
        public string DefaultValue { get; set; }
    }
}