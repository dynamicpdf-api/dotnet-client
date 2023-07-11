namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents the find and replace values and its options.
    /// </summary>
    public class TextReplace
    {
        /// <summary>
        /// Creates new instance of text replace.
        /// </summary>
        /// <param name="text">Text to find.</param>
        /// <param name="replaceText">Text to replace.</param>
        /// <param name="matchCase">True value will make the search operation case sensitive.</param>
        public TextReplace(string text, string replaceText, bool matchCase = false)
        {
            this.Text = text;
            this.ReplaceText = replaceText;
            this.MatchCase = matchCase;
        }

        /// <summary>
        /// Gets or sets the find text value. This string will be replaced with <see cref="ReplaceText"/> during conversion.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets replace text value. This string will replace the <see cref="Text"/> during conversion.
        /// </summary>
        public string ReplaceText { get; set; }

        /// <summary>
        /// If true, the search operation will be case sensitive.
        /// </summary>
        public bool MatchCase { get; set; } = false;
    }
}
