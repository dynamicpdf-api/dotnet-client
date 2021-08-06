namespace DynamicPDF.Api.Elements
{
    /// <summary>
    /// The type of Compaction to encode.
    /// </summary>
    public enum Compaction
    {
        /// <summary>
        /// Byte Compaction.
        /// </summary>
        Byte,

        /// <summary>
        /// Text Compaction.
        /// </summary>
        Text,

        /// <summary>
        /// Numeric Compaction.
        /// </summary>
        Numeric,

        /// <summary>
        /// All Compactions.
        /// </summary>
        Auto
    }
}
