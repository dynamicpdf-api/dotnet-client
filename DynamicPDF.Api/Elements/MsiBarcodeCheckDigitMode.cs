namespace DynamicPDF.Api.Elements
{
    /// <summary>
    /// MSI Barcode check digit modes.
    /// </summary>
    public enum MsiBarcodeCheckDigitMode
    {
        /// <summary>
        /// No check digit.
        /// </summary>
        None,

        /// <summary>
        /// check digit of mod 10.
        /// </summary>
        Mod10,

        /// <summary>
        /// check digit of mod 11.
        /// </summary>
        Mod11,

        /// <summary>
        /// check digit of mod 1010.
        /// </summary>
        Mod1010,

        /// <summary>
        /// check digit of mod 1110.
        /// </summary>
        Mod1110
    }
}
