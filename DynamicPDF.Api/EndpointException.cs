using System;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents the exception that occurs in case of any issues with sending the request.
    /// </summary>
    public class EndpointException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EndpointException"/> class.
        /// </summary>
        public EndpointException(string message) : base(message) { }
    }
}
