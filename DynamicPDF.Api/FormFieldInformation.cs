using System.Collections.Generic;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents the form field information containing the collection 
    /// of different types of field informations.
    /// </summary>
    public class FormFieldInformation
    {
        internal FormFieldInformation() { }

        /// <summary>
        /// Gets or sets a collection of <see cref="SignatureFieldInformation"/>.
        /// </summary>
        public List<SignatureFieldInformation> SignatureFields { get; set; }

        /// <summary>
        /// Gets or sets a collection of <see cref="TextFieldInformation"/>.
        /// </summary>
        public List<TextFieldInformation> TextFields { get; set; }

        /// <summary>
        /// Gets or sets a collection of <see cref="ChoiceFieldInformation"/>.
        /// </summary>
        public List<ChoiceFieldInformation> ChoiceFields { get; set; }

        /// <summary>
        /// Gets or sets a collection of <see cref="ButtonFieldInformation"/>.
        /// </summary>
        public List<ButtonFieldInformation> ButtonFields { get; set; }

        /// <summary>
        /// Gets or sets a collection of <see cref="PushButtonInformation"/>.
        /// </summary>
        public List<PushButtonInformation> PushButtons { get; set; }

        /// <summary>
        /// Gets or sets a collection of <see cref="MultiSelectListBoxInformation"/>.
        /// </summary>
        public List<MultiSelectListBoxInformation> MultiSelectListBoxFields { get; set; }
    }
}