

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents an RGB color.
    /// </summary>
    public class RgbColor : Color
    {
        private string colorString;
        private float red;
        private float green;
        private float blue;

        internal RgbColor() { }
        internal RgbColor(string colorString) { this.colorString = colorString; }
       
        /// <summary>
        /// Initializes a new instance of the <see cref="RgbColor"/> class.
        /// </summary>
        /// <param name="red">The red intensity.</param>
        /// <param name="green">The green intensity.</param>
        /// <param name="blue">The blue intensity.</param>
        public RgbColor(float red, float green, float blue)
        {
            if (red < 0.0f || red > 1.0f || green < 0.0f || green > 1.0f || blue < 0.0f || blue > 1.0f)
            {
                throw new EndpointException("RGB values must be from 0.0 to 1.0.");
            }
            this.red = red;
            this.green = green;
            this.blue = blue;
        }

        internal override string ColorString
        {
            get
            {
                if (colorString != null)
                    return colorString;
                else
                    return "rgb(" + red.ToString() + "," + blue.ToString() + "," + green.ToString() + ")";
            }
            set
            {
                colorString = value;
            }
        }

        /// <summary>Gets the color red.</summary>
        public static RgbColor Red { get { return new RgbColor("Red"); } }
        /// <summary>Gets the color blue.</summary>
        public static RgbColor Blue { get { return new RgbColor("Blue");  } }
        /// <summary>Gets the color green.</summary>
        public static RgbColor Green { get { return new RgbColor("Green"); } }
        /// <summary>Gets the color black.</summary>
        public static RgbColor Black { get { return new RgbColor("Black"); } }

        /// <summary>Gets the color silver.</summary>
        public static RgbColor Silver { get { return new RgbColor("Silver"); } }

        /// <summary>Gets the color dark gray.</summary>
        public static RgbColor DarkGray { get { return new RgbColor("DarkGray"); } }

        /// <summary>Gets the color gray.</summary>
        public static RgbColor Gray { get { return new RgbColor("Gray"); } }

        /// <summary>Gets the color dim gray.</summary>
        public static RgbColor DimGray { get { return new RgbColor("DimGray"); } }

        /// <summary>Gets the color white.</summary>
        public static RgbColor White { get { return new RgbColor("White"); } }

        /// <summary>Gets the color lime.</summary>
        public static RgbColor Lime { get { return new RgbColor("Lime"); } }

        /// <summary>Gets the color aqua.</summary>
        public static RgbColor Aqua { get { return new RgbColor("Aqua"); } }

        /// <summary>Gets the color purple.</summary>
        public static RgbColor Purple { get { return new RgbColor("Purple"); } }

        /// <summary>Gets the color cyan.</summary>
        public static RgbColor Cyan { get { return new RgbColor("Cyan"); } }

        /// <summary>Gets the color magenta.</summary>
        public static RgbColor Magenta { get { return new RgbColor("Magenta"); } }

        /// <summary>Gets the color yellow.</summary>
        public static RgbColor Yellow { get { return new RgbColor("Yellow"); } }

        /// <summary>Gets the color alice blue.</summary>
        public static RgbColor AliceBlue { get { return new RgbColor("AliceBlue"); } }

        /// <summary>Gets the color antique white.</summary>
        public static RgbColor AntiqueWhite { get { return new RgbColor("AntiqueWhite"); } }

        /// <summary>Gets the color aquamarine.</summary>
        public static RgbColor Aquamarine { get { return new RgbColor("Aquamarine"); } }

        /// <summary>Gets the color azure.</summary>
        public static RgbColor Azure { get { return new RgbColor("Azure"); } }
        
        /// <summary>Gets the color beige.</summary>
        public static RgbColor Beige { get { return new RgbColor("Beige"); } }

        /// <summary>Gets the color bisque.</summary>
        public static RgbColor Bisque { get { return new RgbColor("Bisque"); } }

        /// <summary>Gets the color blanched almond.</summary>
        public static RgbColor BlanchedAlmond { get { return new RgbColor("BlanchedAlmond"); } }

        /// <summary>Gets the color blue violet.</summary>
        public static RgbColor BlueViolet { get { return new RgbColor("BlueViolet"); } }

        /// <summary>Gets the color brown.</summary>
        public static RgbColor Brown { get { return new RgbColor("Brown"); } }

        /// <summary>Gets the color burly wood.</summary>
        public static RgbColor BurlyWood { get { return new RgbColor("BurlyWood"); } }

        /// <summary>Gets the color cadet blue.</summary>
        public static RgbColor CadetBlue { get { return new RgbColor("CadetBlue"); } }

        /// <summary>Gets the color chartreuse.</summary>
        public static RgbColor Chartreuse { get { return new RgbColor("Chartreuse"); } }

        /// <summary>Gets the color chocolate.</summary>
        public static RgbColor Chocolate { get { return new RgbColor("Chocolate"); } }

        /// <summary>Gets the color coral.</summary>
        public static RgbColor Coral { get { return new RgbColor("Coral"); } }

        /// <summary>Gets the color cornflower blue.</summary>
        public static RgbColor CornflowerBlue { get { return new RgbColor("CornflowerBlue"); } }

        /// <summary>Gets the color cornsilk.</summary>
        public static RgbColor Cornsilk { get { return new RgbColor("Cornsilk"); } }

        /// <summary>Gets the color crimson.</summary>
        public static RgbColor Crimson { get { return new RgbColor("Crimson"); } }

        /// <summary>Gets the color dark blue.</summary>
        public static RgbColor DarkBlue { get { return new RgbColor("DarkBlue"); } }

        /// <summary>Gets the color dark cyan.</summary>
        public static RgbColor DarkCyan { get { return new RgbColor("DarkCyan"); } }

        /// <summary>Gets the color dark golden rod.</summary>
        public static RgbColor DarkGoldenRod { get { return new RgbColor("DarkGoldenRod"); } }

        /// <summary>Gets the color dark green.</summary>
        public static RgbColor DarkGreengreen { get { return new RgbColor("DarkGreen"); } }

        /// <summary>Gets the color dark khaki.</summary>
        public static RgbColor DarkKhaki { get { return new RgbColor("DarkKhaki"); } }

        /// <summary>Gets the color dark magenta.</summary>
        public static RgbColor DarkMagenta { get { return new RgbColor("DarkMagenta"); } }

        /// <summary>Gets the color dark olive green.</summary>
        public static RgbColor DarkOliveGreen { get { return new RgbColor("DarkOliveGreen"); } }

        /// <summary>Gets the color dark orange.</summary>
        public static RgbColor DarkOrange { get { return new RgbColor("DarkOrange"); } }

        /// <summary>Gets the color dark orchid.</summary>
        public static RgbColor DarkOrchid { get { return new RgbColor("DarkOrchid"); } }

        /// <summary>Gets the color dark red.</summary>
        public static RgbColor DarkRed { get { return new RgbColor("DarkRed"); } }

        /// <summary>Gets the color dark salmon.</summary>
        public static RgbColor DarkSalmon { get { return new RgbColor("DarkSalmon"); } }

        /// <summary>Gets the color dark sea green.</summary>
        public static RgbColor DarkSeaGreen { get { return new RgbColor("DarkSeaGreen"); } }

        /// <summary>Gets the color dark slate blue.</summary>
        public static RgbColor DarkSlateBlue { get { return new RgbColor("DarkSlateBlue"); } }

        /// <summary>Gets the color dark slate gray.</summary>
        public static RgbColor DarkSlateGray { get { return new RgbColor("DarkSlateGray"); } }

        /// <summary>Gets the color dark turquoise.</summary>
        public static RgbColor DarkTurquoise { get { return new RgbColor("DarkTurquoise"); } }

        /// <summary>Gets the color dark violet.</summary>
        public static RgbColor DarkViolet { get { return new RgbColor("DarkViolet"); } }

        /// <summary>Gets the color deep pink.</summary>
        public static RgbColor DeepPink { get { return new RgbColor("DeepPink"); } }

        /// <summary>Gets the color deep sky blue.</summary>
        public static RgbColor DeepSkyBlue { get { return new RgbColor("DeepSkyBlue"); } }

        /// <summary>Gets the color dodger blue.</summary>
        public static RgbColor DodgerBlue { get { return new RgbColor("DodgerBlue"); } }

        /// <summary>Gets the color feldspar.</summary>
        public static RgbColor Feldspar { get { return new RgbColor("Feldspar"); } }

        /// <summary>Gets the color fire brick.</summary>
        public static RgbColor FireBrick { get { return new RgbColor("FireBrick"); } }

        /// <summary>Gets the color floral white.</summary>
        public static RgbColor FloralWhite { get { return new RgbColor("FloralWhite"); } }

        /// <summary>Gets the color forest green.</summary>
        public static RgbColor ForestGreen { get { return new RgbColor("ForestGreen"); } }

        /// <summary>Gets the color fuchsia.</summary>
        public static RgbColor Fuchsia { get { return new RgbColor("Fuchsia"); } }

        /// <summary>Gets the color ghost white.</summary>
        public static RgbColor GhostWhite { get { return new RgbColor("GhostWhite"); } }

        /// <summary>Gets the color gold.</summary>
        public static RgbColor Gold { get { return new RgbColor("Gold"); } }

        /// <summary>Gets the color golden rod.</summary>
        public static RgbColor GoldenRod { get { return new RgbColor("GoldenRod"); } }

        /// <summary>Gets the color green yellow.</summary>
        public static RgbColor GreenYellow { get { return new RgbColor("GreenYellow"); } }

        /// <summary>Gets the color honey dew.</summary>
        public static RgbColor HoneyDew { get { return new RgbColor("HoneyDew"); } }

        /// <summary>Gets the color hot pink.</summary>
        public static RgbColor HotPink { get { return new RgbColor("HotPink"); } }

        /// <summary>Gets the color indian red.</summary>
        public static RgbColor IndianRed { get { return new RgbColor("IndianRed"); } }

        /// <summary>Gets the color indigo.</summary>
        public static RgbColor Indigo { get { return new RgbColor("Indigo"); } }

        /// <summary>Gets the color ivory.</summary>
        public static RgbColor Ivory { get { return new RgbColor("Ivory"); } }

        /// <summary>Gets the color khaki.</summary>
        public static RgbColor Khaki { get { return new RgbColor("Khaki"); } }

        /// <summary>Gets the color lavender.</summary>
        public static RgbColor Lavender { get { return new RgbColor("Lavender"); } }

        /// <summary>Gets the color lavender blush.</summary>
        public static RgbColor LavenderBlush { get { return new RgbColor("LavenderBlush"); } }

        /// <summary>Gets the color lawn Green.</summary>
        public static RgbColor LawnGreen { get { return new RgbColor("LawnGreen"); } }

        /// <summary>Gets the color lemon chiffon.</summary>
        public static RgbColor LemonChiffon { get { return new RgbColor("LemonChiffon"); } }

        /// <summary>Gets the color light blue.</summary>
        public static RgbColor LightBlue { get { return new RgbColor("LightBlue"); } }

        /// <summary>Gets the color light coral.</summary>
        public static RgbColor LightCoral { get { return new RgbColor("LightCoral"); } }

        /// <summary>Gets the color light cyan.</summary>
        public static RgbColor LightCyan { get { return new RgbColor("LightCyan"); } }

        /// <summary>Gets the color light golden rod yellow.</summary>
        public static RgbColor LightGoldenRodYellow { get { return new RgbColor("LightGoldenRodYellow"); } }

        /// <summary>Gets the color light grey.</summary>
        public static RgbColor LightGrey { get { return new RgbColor("LightGrey"); } }

        /// <summary>Gets the color light green.</summary>
        public static RgbColor LightGreen { get { return new RgbColor("LightGreen"); } }

        /// <summary>Gets the color light pink.</summary>
        public static RgbColor LightPink { get { return new RgbColor("LightPink"); } }

        /// <summary>Gets the color light salmon.</summary>
        public static RgbColor LightSalmon { get { return new RgbColor("LightSalmon"); } }

        /// <summary>Gets the color light sea green.</summary>
        public static RgbColor LightSeaGreen { get { return new RgbColor("LightSeaGreen"); } }

        /// <summary>Gets the color light sky blue.</summary>
        public static RgbColor LightSkyBlue { get { return new RgbColor("LightSkyBlue"); } }

        /// <summary>Gets the color light slate blue.</summary>
        public static RgbColor LightSlateBlue { get { return new RgbColor("LightSlateBlue"); } }
        /// <summary>Gets the color light slate gray.</summary>
        public static RgbColor LightSlateGray { get { return new RgbColor("LightSlateGray"); } }

        /// <summary>Gets the color light steel blue.</summary>
        public static RgbColor LightSteelBlue { get { return new RgbColor("LightSteelBlue"); } }

        /// <summary>Gets the color light yellow.</summary>
        public static RgbColor LightYellow { get { return new RgbColor("LightYellow"); } }

        /// <summary>Gets the color lime green.</summary>
        public static RgbColor LimeGreen { get { return new RgbColor("LimeGreen"); } }

        /// <summary>Gets the color linen.</summary>
        public static RgbColor Linen { get { return new RgbColor("Linen"); } }

        /// <summary>Gets the color maroon.</summary>
        public static RgbColor Maroon { get { return new RgbColor("Maroon"); } }

        /// <summary>Gets the color medium aqua marine.</summary>
        public static RgbColor MediumAquaMarine { get { return new RgbColor("MediumAquaMarine"); } }

        /// <summary>Gets the color medium blue.</summary>
        public static RgbColor MediumBlue { get { return new RgbColor("MediumBlue"); } }

        /// <summary>Gets the color medium orchid.</summary>
        public static RgbColor MediumOrchid { get { return new RgbColor("MediumOrchid"); } }

        /// <summary>Gets the color medium purple.</summary>
        public static RgbColor MediumPurple { get { return new RgbColor("MediumPurple"); } }

        /// <summary>Gets the color medium sea green.</summary>
        public static RgbColor MediumSeaGreen { get { return new RgbColor("MediumSeaGreen"); } }

        /// <summary>Gets the color medium slate blue.</summary>
        public static RgbColor MediumSlateBlue { get { return new RgbColor("MediumSlateBlue"); } }

        /// <summary>Gets the color medium spring green.</summary>
        public static RgbColor MediumSpringGreen { get { return new RgbColor("MediumSpringGreen"); } }

        /// <summary>Gets the color medium turquoise.</summary>
        public static RgbColor MediumTurquoise { get { return new RgbColor("MediumTurquoise"); } }

        /// <summary>Gets the color medium violet red.</summary>
        public static RgbColor MediumVioletRed { get { return new RgbColor("MediumVioletRed"); } }

        /// <summary>Gets the color midnight blue.</summary>
        public static RgbColor MidnightBlue { get { return new RgbColor("MidnightBlue"); } }

        /// <summary>Gets the color mint cream.</summary>
        public static RgbColor MintCream { get { return new RgbColor("MintCream"); } }
        /// <summary>Gets the color misty rose.</summary>
        public static RgbColor MistyRose { get { return new RgbColor("MistyRose"); } }
        /// <summary>Gets the color moccasin.</summary>
        public static RgbColor Moccasin { get { return new RgbColor("Moccasin"); } }

        /// <summary>Gets the color navajo white.</summary>
        public static RgbColor NavajoWhite { get { return new RgbColor("NavajoWhite"); } }

        /// <summary>Gets the color navy.</summary>
        public static RgbColor Navy { get { return new RgbColor("Navy"); } }

        /// <summary>Gets the color old lace.</summary>
        public static RgbColor OldLace { get { return new RgbColor("OldLace"); } }

        /// <summary>Gets the color olive.</summary>
        public static RgbColor Olive { get { return new RgbColor("Olive"); } }

        /// <summary>Gets the color olive drab.</summary>
        public static RgbColor OliveDrab { get { return new RgbColor("OliveDrab"); } }

        /// <summary>Gets the color gainsboro.</summary>
        public static RgbColor Gainsboro { get { return new RgbColor("Gainsboro"); } }

        /// <summary>Gets the color orange.</summary>
        public static RgbColor Orange { get { return new RgbColor("Orange"); } }

        /// <summary>Gets the color orange red.</summary>
        public static RgbColor OrangeRed { get { return new RgbColor("OrangeRed"); } }

        /// <summary>Gets the color orchid.</summary>
        public static RgbColor Orchid { get { return new RgbColor("Orchid"); } }

        /// <summary>Gets the color pale golden rod.</summary>
        public static RgbColor PaleGoldenRod { get { return new RgbColor("PaleGoldenRod"); } }

        /// <summary>Gets the color pale green.</summary>
        public static RgbColor PaleGreen { get { return new RgbColor("PaleGreen"); } }

        /// <summary>Gets the color pale turquoise.</summary>
        public static RgbColor PaleTurquoise { get { return new RgbColor("PaleTurquoise"); } }

        /// <summary>Gets the color pale violet red.</summary>
        public static RgbColor PaleVioletRed { get { return new RgbColor("PaleVioletRed"); } }

        /// <summary>Gets the color papaya whip.</summary>
        public static RgbColor PapayaWhip { get { return new RgbColor("PapayaWhip"); } }

        /// <summary>Gets the color peach puff.</summary>
        public static RgbColor PeachPuff { get { return new RgbColor("PeachPuff"); } }

        /// <summary>Gets the color peru.</summary>
        public static RgbColor Peru { get { return new RgbColor("Peru"); } }

        /// <summary>Gets the color pink.</summary>
        public static RgbColor Pink { get { return new RgbColor("Pink"); } }

        /// <summary>Gets the color plum.</summary>
        public static RgbColor Plum { get { return new RgbColor("Plum"); } }

        /// <summary>Gets the color powder blue.</summary>
        public static RgbColor PowderBlue { get { return new RgbColor("PowderBlue"); } }

        /// <summary>Gets the color rosy brown.</summary>
        public static RgbColor RosyBrown { get { return new RgbColor("RosyBrown"); } }

        /// <summary>Gets the color royal blue.</summary>
        public static RgbColor RoyalBlue { get { return new RgbColor("RoyalBlue"); } }

        /// <summary>Gets the color saddle brown.</summary>
        public static RgbColor SaddleBrown { get { return new RgbColor("SaddleBrown"); } }

        /// <summary>Gets the color salmon.</summary>
        public static RgbColor Salmon { get { return new RgbColor("Salmon"); } }

        /// <summary>Gets the color sandy brown.</summary>
        public static RgbColor SandyBrown { get { return new RgbColor("SandyBrown"); } }

        /// <summary>Gets the color sea green.</summary>
        public static RgbColor SeaGreen { get { return new RgbColor("SeaGreen"); } }

        /// <summary>Gets the color sea shell.</summary>
        public static RgbColor SeaShell { get { return new RgbColor("SeaShell"); } }

        /// <summary>Gets the color sienna.</summary>
        public static RgbColor Sienna { get { return new RgbColor("Sienna"); } }

        /// <summary>Gets the color sky blue.</summary>
        public static RgbColor SkyBlue { get { return new RgbColor("SkyBlue"); } }

        /// <summary>Gets the color slate blue.</summary>
        public static RgbColor SlateBlue { get { return new RgbColor("SlateBlue"); } }

        /// <summary>Gets the color slate gray.</summary>
        public static RgbColor SlateGray { get { return new RgbColor("SlateGray"); } }

        /// <summary>Gets the color snow.</summary>
        public static RgbColor Snow { get { return new RgbColor("Snow"); } }

        /// <summary>Gets the color spring green.</summary>
        public static RgbColor SpringGreen { get { return new RgbColor("SpringGreen"); } }

        /// <summary>Gets the color steel blue.</summary>
        public static RgbColor SteelBlue { get { return new RgbColor("SteelBlue"); } }

        /// <summary>Gets the color Tan.</summary>
        public static RgbColor tan { get { return new RgbColor("Tan"); } }

        /// <summary>Gets the color teal.</summary>
        public static RgbColor Teal { get { return new RgbColor("Teal"); } }

        /// <summary>Gets the color thistle.</summary>
        public static RgbColor Thistle { get { return new RgbColor("Thistle"); } }

        /// <summary>Gets the color tomato.</summary>
        public static RgbColor Tomato { get { return new RgbColor("Tomato"); } }

        /// <summary>Gets the color turquoise.</summary>
        public static RgbColor Turquoise { get { return new RgbColor("Turquoise"); } }
        /// <summary>Gets the color violet.</summary>
        public static RgbColor Violet { get { return new RgbColor("Violet"); } }

        /// <summary>Gets the color violet red.</summary>
        public static RgbColor VioletRed { get { return new RgbColor("VioletRed"); } }

        /// <summary>Gets the color wheat.</summary>
        public static RgbColor Wheat { get { return new RgbColor("Wheat"); } }

        /// <summary>Gets the color white smoke.</summary>
        public static RgbColor WhiteSmoke { get { return new RgbColor("WhiteSmoke"); } }

        /// <summary>Gets the color yellow green.</summary>
        public static RgbColor YellowGreen { get { return new RgbColor("YellowGreen"); } }

    }
}
