namespace DynamicPDF.Api
{
    /// <summary>
    /// Specifies encryption type.
    /// </summary>
    public enum EncryptionType
    {

        /// <summary>
        /// RC4 40 bit security.
        /// </summary>
        RC440,

        /// <summary>
        /// RC4 128 bit security.
        /// </summary>
        RC4128,

        /// <summary>
        /// AES 128 bit security.
        /// </summary>
        Aes128,

        /// <summary>
        /// AES 256 bit security.
        /// </summary>
        Aes256,

        /// <summary>
        /// No security.
        /// </summary>
        None
    }
}
