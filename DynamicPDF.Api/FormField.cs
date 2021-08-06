
namespace DynamicPDF.Api
{
    /// <summary>
    /// Class represents the form field.
    /// </summary>
    public class FormField
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormField"/> class.
        /// </summary>
        /// <param name="name">The name of the form field.</param>
        public FormField(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormField"/> class.
        /// </summary>
        /// <param name="name">The name of the form field.</param>
        /// <param name="value">The value of the form field.</param>
        public FormField(string name, string value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Gets or sets name for the form field.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets value for the form field.
        /// </summary>
        public string Value { get; set; } = null;

        /// <summary>
        /// Gets or sets boolean, indicating whether the field should be flatten or not.
        /// </summary>
        public bool? Flatten { get; set; }

        /// <summary>
        ///Gets or sets boolean, indicating whether the field should be removed or not.
        /// </summary>
        public bool? Remove { get; set; }

    }
}
