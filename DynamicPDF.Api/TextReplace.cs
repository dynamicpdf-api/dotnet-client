using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace DynamicPDF.Api
{
    public class TextReplace
    {

        /// <summary>
        /// Represents the find and replace values and its options.
        /// </summary>
        /// <param name="text">Text to find.</param>
        /// <param name="replaceText">Text to replace.</param>
        public TextReplace(string text, string replaceText)
        {
            this.Text = text;
            this.ReplaceText = replaceText;
            this.MatchCase = false;
        }

        /// <summary>
        /// Represents the find and replace values and its options.
        /// </summary>
        /// <param name="text">Text to find.</param>
        /// <param name="replaceText">Text to replace.</param>
        /// <param name="matchCase">True value will make the search operation case sensitive.</param>
        public TextReplace(string text, string replaceText, bool matchCase)
        {
            this.Text = text;
            this.ReplaceText = replaceText;
            this.MatchCase = matchCase;
        }

        /// <summary>
        /// Gets or sets the Find Text value. This string will be replaced with <see cref="ReplaceText"/> during conversion.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets ReplaceText value.This string will replace the <see cref="Text"/> during conversion.
        /// </summary>
        public string ReplaceText { get; set; }

        /// <summary>
        /// If True, the search operation will be case sensitive.
        /// </summary>
        public bool MatchCase { get; set; } = false;
    }
}
