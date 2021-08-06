

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents an RGB color created using the web hexadecimal convention.
    /// </summary>
    public class WebColor : RgbColor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebColor"/> class.
        /// </summary>
        /// <param name="webHexString">The hexadecimal string representing the color.</param>
        public WebColor(string webHexString) { ColorString = webHexString;  } 

    }
}
