

using System;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents the base class for response.
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Gets the boolean, indicating the response's status.
        /// </summary>
        public bool IsSuccessful { get; internal set; }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        public string ErrorMessage { get; internal set; }

        /// <summary>
        /// Gets the error id.
        /// </summary>
        public Guid? ErrorId { get; internal set; }

        /// <summary>
        /// Gets the status code.
        /// </summary>
        public System.Net.HttpStatusCode StatusCode { get; internal set; }

        /// <summary>
        /// Gets the error json.
        /// </summary>
        public string ErrorJson { get; internal set; }

    }
}
