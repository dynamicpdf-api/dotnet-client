using System.Collections.Generic;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents the pdf inforamtion.
    /// </summary>
    public class PdfInformation
    {
        /// <summary>
        /// Gets the author.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets the subject.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets the keywords.
        /// </summary>
        public string Keywords { get; set; }

        /// <summary>
        /// Gets the creator.
        /// </summary>
        public string Creator { get; set; }

        /// <summary>
        /// Gets the producer.
        /// </summary>
        public string Producer { get; set; }

        /// <summary>
        /// Gets the title.
        /// </summary>
        public string Title { get; set; }

        internal PdfInformation() { }

        /// <summary>
        /// Gets the collection of PageInformation.
        /// </summary>
        public List<PageInformation> Pages { get; set; } = new List<PageInformation>();

        /// <summary>
        /// Gets the form fields.
        /// </summary>
        public FormFieldInformation FormFields { get; set; }

        /// <summary>
        /// Gets the custom properties.
        /// </summary>
        public Dictionary<string, string> CustomProperties { get; set; }

        /// <summary>
        /// Gets the boolean representing xmp meta data.
        /// </summary>
        public bool XmpMetaData { get; set; }

        /// <summary>
        /// Gets the boolean, indicating whether the pdf is signed.
        /// </summary>
        public bool Signed { get; set; }

        /// <summary>
        /// Gets the boolean, indicating whether the pdf is tagged.
        /// </summary>
        public bool Tagged { get; set; }
    }
}
