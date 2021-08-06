
namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents a CMYK color.
    /// </summary>
    public class CmykColor : Color
    {
        private float cyan = 0;
        private float magenta = 0;
        private float yellow = 0;
        private float black = 0;
        private string colorString;

        internal CmykColor(string colorString) { ColorString = colorString; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CmykColor"/> class.
        /// </summary>
        /// <param name="cyan">The cyan intensity.</param>
        /// <param name="magenta">The magenta intensity.</param>
        /// <param name="yellow">The yellow intensity.</param>
        /// <param name="black">The black intensity.</param>
        /// <remarks>Values must be between 0.0 and 1.0.</remarks>
        public CmykColor(float cyan, float magenta, float yellow, float black)
        {
            if (cyan < 0.0f || cyan > 1.0f || magenta < 0.0f || magenta > 1.0f || yellow < 0.0f || yellow > 1.0f || black < 0.0f || black > 1.0f)
            {
                throw new EndpointException("CMYK values must be from 0.0 to 1.0.");
            }
            this.cyan = cyan;
            this.magenta = magenta;
            this.yellow = yellow;
            this.black = black;
        }
        /// <summary>Gets the color black.</summary>
        public static CmykColor Black { get { return new CmykColor(1, 1, 1, 1); } }

        /// <summary>Gets the color white.</summary>
        public static CmykColor White { get { return new CmykColor(0, 0, 0, 0); } }
        
        internal override string ColorString
        {
            get
            {
                if (colorString != null)
                    return colorString;
                else
                    return "cmyk(" + cyan.ToString() + "," + magenta.ToString() + "," + yellow.ToString() + "," + black.ToString() + ")";
            }
            set
            {
                colorString = value;
            }
        }

    }
}
