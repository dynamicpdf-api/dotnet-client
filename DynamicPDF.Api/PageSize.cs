using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents different types of the page size.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PageSize
    {
        /// <summary>
        /// Page Size of A3.
        /// </summary>
        A3,

        /// <summary>
        /// Page Size of A4.
        /// </summary>
        A4,

        /// <summary>
        /// Page Size of A5.
        /// </summary>
        A5,

        /// <summary>
        /// Page Size of A5.
        /// </summary>
        A6,

        /// <summary>
        /// Page Size of B3.
        /// </summary>
        B3,

        /// <summary>
        /// Page Size of B4.
        /// </summary>
        B4,

        /// <summary>
        /// Page Size of B5.
        /// </summary>
        B5,

        /// <summary>
        /// Page Size of B5JIS.
        /// </summary>
        B5JIS,

        /// <summary>
        /// Page Size of DoublePostcard.
        /// </summary>
        DoublePostcard,

        /// <summary>
        /// Page Size of Envelope10.
        /// </summary>
        Envelope10,

        /// <summary>
        /// Page Size of EnvelopeDL.
        /// </summary>
        EnvelopeDL,

        /// <summary>
        /// Page Size of EnvelopeC5.
        /// </summary>
        EnvelopeC5,

        /// <summary>
        /// Page Size of EnvelopeB5.
        /// </summary>
        EnvelopeB5,

        /// <summary>
        /// Page Size of EnvelopeMonarch.
        /// </summary>
        EnvelopeMonarch,

        /// <summary>
        /// Page Size of Executive.
        /// </summary>
        Executive,

        /// <summary>
        /// Page Size of Legal.
        /// </summary>
        Legal,

        /// <summary>
        /// Page Size of Folio.
        /// </summary>
        Folio,

        /// <summary>
        /// Page Size of Letter.
        /// </summary>
        Letter,

        /// <summary>
        /// Page Size of Postcard.
        /// </summary>
        Postcard,

        /// <summary>
        /// Page Size of PRC16K.
        /// </summary>
        PRC16K,

        /// <summary>
        /// Page Size of PRC32K.
        /// </summary>
        PRC32K,

        /// <summary>
        /// Page Size of Quatro.
        /// </summary>
        Quatro,

        /// <summary>
        /// Page Size of Statement.
        /// </summary>
        Statement,

        /// <summary>
        /// Page Size of Tabloid.
        /// </summary>
        Tabloid
    }
}
