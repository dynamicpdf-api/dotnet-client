namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents information of a signature field.
    /// </summary>
    public class SignatureFieldInformation
    {
        /// <summary>
        /// Gets or Sets the name of a signature field.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets the boolean, indicating the field signed or not.
        /// </summary>
        public bool Signed { get; set; }
    }
}