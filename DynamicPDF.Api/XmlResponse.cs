namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents the xml response.
    /// </summary>
    public class XmlResponse : Response
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XmlResponse"/> class.
        /// </summary>
        public XmlResponse() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlResponse"/> class.
        /// </summary>
        /// <param name="xmlContent">The xml content of the response.</param>
        public XmlResponse(string xmlContent) { Content = xmlContent; }

        /// <summary>
        /// Gets the xml content.
        /// </summary>
        public string Content { get; private set; }
    }
}
