using DynamicPDF.Api;
using DynamicPDF.Api.Elements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace DynamicPDFApiTestForNET.TestCases.FunctionalityTest.PDFEndpoint
{
    [TestClass]
    public class FontSamples : TestCase
    {
        public override InputSampleType InputSampleType
        {
            get
            {
                return InputSampleType.Font;
            }
        }
        public Pdf pdfObj(Font font)
        {
            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            PageInput pageInput = new PageInput();
            TextElement element = new TextElement("Hello World", ElementPlacement.TopCenter);
            font.Embed = true;
            font.Subset = true;
            element.Font = font;
            pageInput.Elements.Add(element);

            pdf.Inputs.Add(pageInput);

            return pdf;
        }
        [TestMethod]
        public void PageInput_CoreFont_Pdfoutput()
        {
            Name = "CoreFont";

            Pdf pdf = pdfObj(Font.TimesBoldItalic);

            PdfResponse response = pdf.Process();

            bool pass = false;

            if (response.IsSuccessful)
            {
                pass = base.getVerify(InputSampleType, response, pdf);
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void PageInput_Font_Pdfoutput()
        {
            Name = "FontSample";

            Pdf pdf = pdfObj(Font.FromFile(base.GetResourcePath("DejaVuSans.ttf"), "DejaVuSans.ttf"));

            PdfResponse response = pdf.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                pass = base.getVerify(InputSampleType, response, pdf);
            }
            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void PageInput_GoogleFont_Pdfoutput()
        {
            Name = "GoogleFontSample";

            Pdf pdf = pdfObj(Font.Google("Roboto"));

            PdfResponse response = pdf.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                pass = base.getVerify(InputSampleType, response, pdf);
            }
            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void PageInput_GoogleFontWeight_Pdfoutput()
        {
            Name = "GoogleFontSampleWeight";

            Pdf pdf = pdfObj(Font.Google("Bona Nova:bold"));

            PdfResponse response = pdf.Process();

            bool pass = false;

            if (response.IsSuccessful)
            {
                pass = base.getVerify(InputSampleType, response, pdf);
            }
            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void PageInput_GlobalFont_Pdfoutput()
        {
            Name = "GlobalFontSample";
            
            Pdf pdf = pdfObj(Font.Global("Paris Normal"));

            PdfResponse response = pdf.Process();

            bool pass = false;

            if (response.IsSuccessful)
            {
                pass = base.getVerify(InputSampleType, response, pdf);
            }
            Assert.IsTrue(pass);
        }
    }
}
