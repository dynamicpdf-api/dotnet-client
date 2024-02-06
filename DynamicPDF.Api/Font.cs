using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents font.
    /// </summary>
    public class Font
    {
        private static Font timesRoman = null;
        private static Font timesBold = null;
        private static Font timesItalic = null;
        private static Font timesBoldItalic = null;
        private static Font helvetica = null;
        private static Font helveticaBold = null;
        private static Font helveticaOblique = null;
        private static Font helveticaBoldOblique = null;
        private static Font courier = null;
        private static Font courierBold = null;
        private static Font courierOblique = null;
        private static Font courierBoldOblique = null;
        private static Font symbol = null;
        private static Font zapfDingbats = null;
        private static bool loadRequired = true;
        private static object lockObject = new object();
        private static List<FontInformation> fontDetails = new List<FontInformation>();
        private static string pathToFontsResourceDirectory = "";

        FontResource resource;

        static Font()
        {

            try
            {
                string windDir = Environment.GetEnvironmentVariable("WINDIR");
                if (windDir != null && windDir.Length > 0)
                {
                    pathToFontsResourceDirectory = System.IO.Path.Combine(windDir, "Fonts");
                }
            }
            catch (Exception)
            { }
        }

        internal Font() { }

        internal Font(FontResource fontResource, string resourceName = null)
        {
            this.resource = fontResource;
            ResourceName = resourceName;
            Name = System.Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Font"/> class 
        /// using the font name that is present in the cloud resource manager.
        /// </summary>
        /// <param name="cloudResourceName">The font name present in the cloud resource manager.</param>
        public Font(string cloudResourceName)
        {
            this.ResourceName = cloudResourceName;
            Name = System.Guid.NewGuid().ToString();
        }

        [JsonProperty]
        internal string Name { get; set; }

        internal FontResource Resource { get { return resource; } }


        /// <summary>
        /// Gets or sets a boolean indicating whether to embed the font.
        /// </summary>
        public bool? Embed { get; set; }

        /// <summary>
        /// Gets or sets a boolean indicating whether to subset embed the font.
        /// </summary>
        public bool? Subset { get; set; }

        /// <summary>
        /// Gets or sets a name for the font resource.
        /// </summary>
        public string ResourceName { get; set; }

        /// <summary>
        /// Gets the Times Roman core font with Latin 1 encoding.
        /// </summary>
        public static Font TimesRoman
        {
            get
            {
                if (timesRoman == null)
                {
                    timesRoman = new Font();
                    timesRoman.Name = "timesRoman";
                }
                return timesRoman;
            }
        }

        /// <summary>
        /// Gets the Times Bold core font with Latin 1 encoding.
        /// </summary>
        public static Font TimesBold
        {
            get
            {
                if (timesBold == null)
                {
                    timesBold = new Font();
                    timesBold.Name = "timesBold";
                }
                return timesBold;
            }
        }

        /// <summary>
        /// Gets the Times Italic core font with Latin 1 encoding.
        /// </summary>
        public static Font TimesItalic
        {
            get
            {
                if (timesItalic == null)
                {
                    timesItalic = new Font();
                    timesItalic.Name = "timesItalic";
                }
                return timesItalic;
            }
        }

        /// <summary>
        /// Gets the Times Bold Italic core font with Latin 1 encoding.
        /// </summary>
        public static Font TimesBoldItalic
        {
            get
            {
                if (timesBoldItalic == null)
                {
                    timesBoldItalic = new Font();
                    timesBoldItalic.Name = "timesBoldItalic";
                }
                return timesBoldItalic;
            }
        }

        /// <summary>
        /// Gets the Helvetica core font with Latin 1 encoding.
        /// </summary>
        public static Font Helvetica
        {
            get
            {
                if (helvetica == null)
                {
                    helvetica = new Font();
                    helvetica.Name = "helvetica";
                }
                return helvetica;
            }
        }

        /// <summary>
        /// Gets the Helvetica Bold core font with Latin 1 encoding.
        /// </summary>
        public static Font HelveticaBold
        {
            get
            {
                if (helveticaBold == null)
                {
                    helveticaBold = new Font();
                    helveticaBold.Name = "helveticaBold";
                }
                return helveticaBold;
            }
        }

        /// <summary>
        /// Gets the Helvetica Oblique core font with Latin 1 encoding.
        /// </summary>
        public static Font HelveticaOblique
        {
            get
            {
                if (helveticaOblique == null)
                {
                    helveticaOblique = new Font();
                    helveticaOblique.Name = "helveticaOblique";
                }
                return helveticaOblique;
            }
        }

        /// <summary>
        /// Gets the Helvetica Bold Oblique core font with Latin 1 encoding.
        /// </summary>
        public static Font HelveticaBoldOblique
        {
            get
            {
                if (helveticaBoldOblique == null)
                {
                    helveticaBoldOblique = new Font();
                    helveticaBoldOblique.Name = "helveticaBoldOblique";
                }
                return helveticaBoldOblique;
            }
        }

        /// <summary>
        /// Gets the Courier core font with Latin 1 encoding.
        /// </summary>
        public static Font Courier
        {
            get
            {
                if (courier == null)
                {
                    courier = new Font();
                    courier.Name = "courier";
                }
                return courier;
            }
        }

        /// <summary>
        /// Gets the Courier Bold core font with Latin 1 encoding.
        /// </summary>
        public static Font CourierBold
        {
            get
            {
                if (courierBold == null)
                {
                    courierBold = new Font();
                    courierBold.Name = "courierBold";
                }
                return courierBold;
            }
        }

        /// <summary>
        /// Gets the Courier Oblique core font with Latin 1 encoding.
        /// </summary>
        public static Font CourierOblique
        {
            get
            {
                if (courierOblique == null)
                {
                    courierOblique = new Font();
                    courierOblique.Name = "courierOblique";
                }
                return courierOblique;
            }
        }

        /// <summary>
        /// Gets the Courier Bold Oblique core font with Latin 1 encoding.
        /// </summary>
        public static Font CourierBoldOblique
        {
            get
            {
                if (courierBoldOblique == null)
                {
                    courierBoldOblique = new Font();
                    courierBoldOblique.Name = "courierBoldOblique";
                }
                return courierBoldOblique;
            }
        }

        /// <summary>
        /// Gets the Symbol core font.
        /// </summary>
        public static Font Symbol
        {
            get
            {
                if (symbol == null)
                {
                    symbol = new Font();
                    symbol.Name = "symbol";
                }
                return symbol;
            }
        }

        /// <summary>
        /// Gets the Zapf Dingbats core font.
        /// </summary>
        public static Font ZapfDingbats
        {
            get
            {
                if (zapfDingbats == null)
                {
                    zapfDingbats = new Font();
                    zapfDingbats.Name = "zapfDingbats";
                }
                return zapfDingbats;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Font"/> class 
        /// using the file path of the font and resource name.
        /// </summary>
        /// <param name="filePath">The file path of the font file.</param>
        /// <param name="resourceName">The resource name for the font.</param>
        public static Font FromFile(string filePath, string resourceName = null)
        {
            FontResource resource = new FontResource(filePath, resourceName);
            Font font = new Font(resource, resource.ResourceName);
            return font;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Font"/> class 
        /// using the stream of the font file and resource name.
        /// </summary>
        /// <param name="stream">The stream of the font file.</param>
        /// <param name="resourceName">The resource name for the font.</param>
        public static Font FromStream(Stream stream, string resourceName = null)
        {
            FontResource resource = new FontResource(stream, resourceName);
            return new Font(resource, resource.ResourceName);
        }

        internal static string GetGoogleFontText(string name, int weight, bool italic)
        {
            StringBuilder fontText = new StringBuilder(name);
            fontText.Append(":");
            fontText.Append(weight);
            if (italic)
                fontText.Append("italic");
            return fontText.ToString();
        }

        /// <summary>
        /// Gets the font from the google.
        /// </summary>
        /// <param name="fontName">The name of the google font.</param>
        /// <returns>The font object.</returns>
        public static Font Google(string fontName)
        {
            Font font = new Font();
            font.Name = fontName;
            return font;
        }

        /// <summary>
        /// Gets the font from the google.
        /// </summary>
        /// <param name="fontName">The name of the google font.</param>
        /// <param name="weight">The weight of the font.</param>
        /// <param name="italic">The italic property of the font.</param>
        /// <returns>The font object.</returns>
        public static Font Google(string fontName, int weight = 400, bool italic = false)
        {            
            Font font = new Font();
            font.Name = Font.GetGoogleFontText(fontName, weight, italic);
            return font;
        }

        /// <summary>
        /// Gets the font from the google.
        /// </summary>
        /// <param name="fontName">The name of the google font.</param>
        /// <param name="bold">If true font weight will be taken as 700 otherwise 400.</param>
        /// <param name="italic">The italic property of the font.</param>
        /// <returns>The font object.</returns>
        public static Font Google(string fontName, bool bold = false, bool italic = false)
        {
            Font font = new Font();
            if(bold)
                font.Name = Font.GetGoogleFontText(fontName, 700, italic);
            else
                font.Name = Font.GetGoogleFontText(fontName, 400, italic);
            return font;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Font"/> class 
        /// using the system font name and resource name.
        /// </summary>
        /// <param name="fontName">The name of the font in the system.</param>
        /// <param name="resourceName">The resource name for the font.</param>
        public static Font FromSystem(string fontName, string resourceName = null)
        {
            FontResource fontResource;

            if (fontName == null) return null;
            if (fontName == string.Empty || fontName.Length < 1) return null;

            fontName = fontName.Replace("-", string.Empty);
            fontName = fontName.Replace(" ", string.Empty);

            if (loadRequired)
            {
                LoadFonts();
            }

            foreach (FontInformation fontDetail in fontDetails)
            {
                if (fontDetail.FontName.ToUpper() == fontName.ToUpper())
                {
                    fontResource = new FontResource(fontDetail.FilePath, resourceName);
                    return new Font(fontResource, fontResource.ResourceName);
                }
            }

            return null;
        }

        private static void LoadFonts()
        {
            lock (lockObject)
            {
                if (loadRequired)
                {
                    if (pathToFontsResourceDirectory != null && pathToFontsResourceDirectory != string.Empty)
                    {
                        DirectoryInfo di = new DirectoryInfo(pathToFontsResourceDirectory);
                        FileInfo[] allFiles = di.GetFiles();

                        Stream reader;
                        FullNameTable nameTable;

                        foreach (FileInfo file in allFiles)
                        {
                            reader = new FileStream(file.FullName, FileMode.Open, FileAccess.Read, FileShare.Read);
                            nameTable = ReadFontNameTable(reader);
                            if (nameTable != null)
                            {
                                fontDetails.Add(new FontInformation(nameTable.FontName, file.FullName));
                            }
                        }
                    }
                }
            }
        }

        private static FullNameTable ReadFontNameTable(Stream reader)
        {
            FullNameTable nameTable = null;
            try
            {
                reader.Seek(4, SeekOrigin.Begin);
                int intTableCount = (reader.ReadByte() << 8) | reader.ReadByte();
                if (intTableCount > 0)
                {
                    byte[] bytTableDirectory = new byte[intTableCount * 16];
                    reader.Seek(12, SeekOrigin.Begin);
                    reader.Read(bytTableDirectory, 0, intTableCount * 16);
                    for (int i = 0; i < bytTableDirectory.Length; i += 16)
                    {
                        switch (BitConverter.ToInt32(bytTableDirectory, i))
                        {
                            case 1701667182: // "name" 
                                nameTable = new FullNameTable(reader, bytTableDirectory, i);
                                break;
                        }
                    }
                }
            }
            catch { }
            return nameTable;
        }
    }
}
