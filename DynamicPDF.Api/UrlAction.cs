namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents an action linking to an external URL.
    /// </summary>
    public class UrlAction : Action
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UrlAction"/> class.
        /// </summary>
        /// <param name="url">URL the action launches.</param>
        public UrlAction(string url) { Url = url; }

        /// <summary>
        /// Gets or sets the URL launched by the action.
        /// </summary>
        public string Url { get; set; }
    }
}
