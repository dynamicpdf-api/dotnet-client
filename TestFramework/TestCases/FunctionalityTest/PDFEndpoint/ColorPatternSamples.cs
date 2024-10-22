using DynamicPDF.Api;
using DynamicPDF.Api.Elements;
using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Reflection.Metadata;

namespace DynamicPDFApiTestForNET.TestCases.FunctionalityTest.PDFEndpoint
{
    [TestClass]
    public class ColorPatternSamples : TestCase
    {
        public override InputSampleType InputSampleType
        {
            get
            {
                return InputSampleType.ColorPattern;
            }
        }
        public Pdf pdfObj(Color color)
        {
            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            PageInput input = new PageInput();
            pdf.Inputs.Add(input);

            TextElement textElement = new TextElement("Hello World", ElementPlacement.TopCenter);
            textElement.Color = color;
            input.Elements.Add(textElement);

            return pdf;
        }

        [TestMethod]
        public void PdfPageInput_NamedColorSample_PdfOutput()
        {
            Name = "NamedColor";

            Pdf pdf = pdfObj(RgbColor.Red);

            PdfResponse response = pdf.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                pass = base.getVerify(InputSampleType, response, pdf);
            }
            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void PdfPageInput_RGBColorSample_PdfOutput()
        {
            Name = "RGBColor";

            Pdf pdf = pdfObj(new RgbColor(0, 1, 0));

            PdfResponse response = pdf.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                pass = base.getVerify(InputSampleType, response, pdf);
            }
            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void PdfPageInput_CMYKColorSample_PdfOutput()
        {
            Name = "CMYKColor";

            Pdf pdf = pdfObj(new CmykColor(0, 1, 0, 0));

            PdfResponse response = pdf.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                pass = base.getVerify(InputSampleType, response, pdf);
            }
            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void PdfPageInput_GrayScaleColorSample_PdfOutput()
        {
            Name = "GrayScale";

            Pdf pdf = pdfObj(new Grayscale(0.8f));

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
