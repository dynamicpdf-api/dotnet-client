using System.Collections.Generic;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents information of a form field.
    /// </summary>
    public class FormFieldInformation
    {
        internal FormFieldInformation() { }

        /// <summary>
        /// Gets or sets the collection of SignatureField information.
        /// </summary>
        public List<SignatureFieldInformation> SignatureFields { get; set; }

        /// <summary>
        /// Gets or sets the collection of TextField information.
        /// </summary>
        public List<TextFieldInformation> TextFields { get; set; }

        /// <summary>
        /// Gets or sets the collection of ChoiceField information.
        /// </summary>
        public List<ChoiceFieldInformation> ChoiceFields { get; set; }

        /// <summary>
        /// Gets or sets the collection of ButtonField information.
        /// </summary>
        public List<ButtonFieldInformation> ButtonFields { get; set; }

        /// <summary>
        /// Gets or sets the collection of PushButton field information.
        /// </summary>
        public List<PushButtonInformation> PushButtons { get; set; }

        /// <summary>
        /// Gets or sets the collection of MultiSelectListBox field information.
        /// </summary>
        public List<MultiSelectListBoxInformation> MultiSelectListBoxFields { get; set; }
    }
}