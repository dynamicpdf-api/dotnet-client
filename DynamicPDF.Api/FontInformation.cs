namespace DynamicPDF.Api
{
    internal class FontInformation
    {
        private string fontName;
        private string filePath;
        internal FontInformation(string fontName, string filePath)
        {
            this.fontName = fontName;
            this.filePath = filePath;
        }

        internal string FontName
        {
            get
            {
                return this.fontName;
            }
        }

        internal string FilePath
        {
            get
            {
                return this.filePath;
            }
        }
    }
}
