namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents a form field in the PDF document.
    /// </summary>
    public class FormField
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormField"/> class 
        /// using the name of the form field as a parameter.
        /// </summary>
        /// <param name="name">The name of the form field.</param>
        public FormField(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormField"/> class 
        /// using the name and the value of the form field as parameters.
        /// </summary>
        /// <param name="name">The name of the form field.</param>
        /// <param name="value">The value of the form field.</param>
        public FormField(string name, string value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Gets or sets name of the form field.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets value of the form field.
        /// </summary>
        public string Value { get; set; } = null;

        /// <summary>
        /// Gets or sets a boolean indicating whether to flatten the form field.
        /// </summary>
        public bool? Flatten { get; set; }

        /// <summary>
        /// Gets or sets a boolean indicating whether to remove the form field.
        /// </summary>
        public bool? Remove { get; set; }
    }
}
