
namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents a style of line.
    /// </summary>
    public class LineStyle
    {
        private static System.Globalization.NumberFormatInfo objFormatter = new System.Globalization.NumberFormatInfo();

        internal LineStyle(string lineStyle) { LineStyleString = lineStyle; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LineStyle"/> class.
        /// </summary>
        /// <param name="dashArray">The array specifying the line style.</param>
        /// <param name="dashPhase">The phase of the line style.</param>
        public LineStyle(float[] dashArray, float dashPhase = 0)
        {
            string strLineStyle = "[";
            for (int i = 0; i < dashArray.Length; i++)
            {
                float val = dashArray[i];
                if (i == dashArray.Length - 1)
                    strLineStyle += val.ToString("0.00", objFormatter);
                else
                    strLineStyle += val.ToString("0.00", objFormatter) + ",";
            }
            strLineStyle += "]";
            if(dashPhase != 0)
            {
                strLineStyle += dashPhase.ToString("0.00", objFormatter);
            }
            LineStyleString = strLineStyle;
        }

        internal string LineStyleString {get;set;}
        /// <summary>
        /// Gets a solid line.
        /// </summary>
        public static LineStyle Solid { get { return new LineStyle("solid"); } }

        /// <summary>
        /// Gets a dotted line.
        /// </summary>
        public static LineStyle Dots { get { return new LineStyle("dots"); } }

        /// <summary>
        /// Gets a line with small dashes.
        /// </summary>
        public static LineStyle DashSmall { get { return new LineStyle("dashSmall"); } }

        /// <summary>
        /// Gets a dashed line.
        /// </summary>
        public static LineStyle Dash { get { return new LineStyle("dash"); } }

        /// <summary>
        /// Gets a line with large dashes. 
        /// </summary>
        public static LineStyle DashLarge { get { return new LineStyle("dashLarge"); } }

        /// <summary>
        /// Gets a invisible line. 
        /// </summary>
        public static LineStyle None { get { return new LineStyle("none"); } }
    }
}
