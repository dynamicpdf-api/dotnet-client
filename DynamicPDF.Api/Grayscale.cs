namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents a grayscale color.
    /// </summary>
    public class Grayscale : Color
    {
        private string colorString;
        private float grayLevel;

        internal Grayscale(string colorString) { ColorString = colorString; }

        /// <summary>
        /// Initializes a new instance of the  <see cref="Grayscale"/> class.
        /// </summary>
        /// <param name="grayLevel">The gray level for the color.</param>
        public Grayscale(float grayLevel) { this.grayLevel = grayLevel; }

        /// <summary>Gets the color black.</summary>
        public static Grayscale Black { get { return new Grayscale(0); } }

        /// <summary>Gets the color white.</summary>
        public static Grayscale White { get { return new Grayscale(1); } }

        internal override string ColorString
        {
            get
            {
                if (colorString != null)
                    return colorString;
                else
                    return "gray(" + grayLevel.ToString() + ")";
            }
            set
            {
                colorString = value;
            }
        }
    }
}
