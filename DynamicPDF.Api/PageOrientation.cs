using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents different types of the page orientation.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PageOrientation
    {
        /// <summary>
        /// Page Orientation of portrait.
        /// </summary>
        Portrait,

        /// <summary>
        /// Page Orientation of landscape.
        /// </summary>
        Landscape,
    }
}
