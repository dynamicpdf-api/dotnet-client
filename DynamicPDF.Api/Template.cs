using DynamicPDF.Api.Elements;
using System;
using System.Collections.Generic;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents a document template.
    /// </summary>
    public class Template
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Template"/> class.
        /// </summary>
        /// <param name="id">The id string representing id for the template.</param>
        public Template(string id = null)
        {
            if (id == null)
                Id = Guid.NewGuid().ToString();
            else
                Id = id;
        }

        /// <summary>
        /// Gets or sets the id for the template.
        /// </summary>
        public string Id { get; set; } = null;

        /// <summary>
        /// Gets or sets the elements for the template.
        /// </summary>
        public List<Element> Elements { get; set; } = new List<Element>();
    }
}

