namespace DynamicPDF.Api.Elements
{
    /// <summary>
    /// Specifies EncodingType.
    /// </summary>
    public enum DataMatrixEncodingType
    {
        /// <summary>
        /// Calculates Encoding based on Value.
        /// </summary>
        Auto,

        /// <summary>
        /// Calculates ASCII Encoding based on Value.
        /// </summary>
        AutoAscii,

        /// <summary>
        /// ASCII Encoding.
        /// </summary>
        Ascii,

        /// <summary>
        /// Extended ASCII Encoding.
        /// </summary>
        ExtendedAscii,

        /// <summary>
        /// Double digit Encoding.
        /// </summary>
        DoubleDigit,

        /// <summary>
        /// C40 Encoding.
        /// </summary>
        C40,

        /// <summary>
        /// Text Encoding.
        /// </summary>
        Text,

        /// <summary>
        /// ANSI X12 Encoding.
        /// </summary>
        AnsiX12,

        /// <summary>
        /// EDIFACT Encoding.
        /// </summary>
        Edifact,

        /// <summary>
        /// Base256 Encoding.
        /// </summary>
        Base256
    }
}
