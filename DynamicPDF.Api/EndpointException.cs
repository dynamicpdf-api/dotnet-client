using System;

namespace DynamicPDF.Api
{
    /// <summary>
    /// The exception that is thrown if issues are there while sending the request.
    /// </summary>
    public class EndpointException : Exception
    {
        // <summary>
        /// Initializes a new instance of the <see cref="EndpointException"/> class.
        /// </summary>
        public EndpointException(string message)
      :
      base(message)
        { }
    }
}
