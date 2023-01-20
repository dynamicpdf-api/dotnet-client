using DynamicPDF.Api;
using DynamicPDF.Api.Elements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

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

        [TestMethod]
        public void PdfPageInput_NamedColorSample_PdfOutput()
        {
            Name = "NamedColor";

            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            PageInput input = new PageInput();
            pdf.Inputs.Add(input);

            Template template = new Template("Temp1");
            TextElement textElement = new TextElement("Hello World", ElementPlacement.TopCenter);
            textElement.Color = RgbColor.Red;
            template.Elements.Add(textElement);
            input.Template = template;

            PdfResponse response = pdf.Process();

            bool pass = false;

            if (response.IsSuccessful)
            {
                File.WriteAllBytes(base.GetOutputFilePath("Output.pdf", InputSampleType), (byte[])response.Content);

#if BASELINEREQUIRED
                // Uncomment the line below to recreate the Input PNG Images
                base.CreateInputPngsFromOutputPdf(72, InputSampleType);

                pass = base.CompareOutputPdfToInputPngs(72, InputSampleType);
#else
                pass = response.IsSuccessful;
#endif

            }
            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void PdfPageInput_RGBColorSample_PdfOutput()
        {
            Name = "RGBColor";
            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            PageInput input = new PageInput();
            pdf.Inputs.Add(input);

            TextElement textElement = new TextElement("Hello World", ElementPlacement.TopCenter);
            textElement.Color = new RgbColor(0, 1, 0);
            input.Elements.Add(textElement);

            PdfResponse response = pdf.Process();

            bool pass = false;

            if (response.IsSuccessful)
            {
                File.WriteAllBytes(base.GetOutputFilePath("Output.pdf", InputSampleType), (byte[])response.Content);

#if BASELINEREQUIRED
                // Uncomment the line below to recreate the Input PNG Images
                base.CreateInputPngsFromOutputPdf(72, InputSampleType);

                pass = base.CompareOutputPdfToInputPngs(72, InputSampleType);
#else
                pass = response.IsSuccessful;
#endif

            }
            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void PdfPageInput_CMYKColorSample_PdfOutput()
        {
            Name = "CMYKColor";
            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            PageInput input = new PageInput();
            pdf.Inputs.Add(input);

            TextElement textElement = new TextElement("Hello World", ElementPlacement.TopCenter);
            textElement.Color = new CmykColor(0, 1, 0, 0);
            input.Elements.Add(textElement);

            PdfResponse response = pdf.Process();

            bool pass = false;

            if (response.IsSuccessful)
            {
                File.WriteAllBytes(base.GetOutputFilePath("Output.pdf", InputSampleType), (byte[])response.Content);

#if BASELINEREQUIRED
                // Uncomment the line below to recreate the Input PNG Images
                base.CreateInputPngsFromOutputPdf(72, InputSampleType);

                pass = base.CompareOutputPdfToInputPngs(72, InputSampleType);
#else
                pass = response.IsSuccessful;
#endif

            }
            Assert.IsTrue(pass);

        }

        [TestMethod]
        public void PdfPageInput_GrayScaleColorSample_PdfOutput()
        {
            Name = "GrayScale";
            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            PageInput input = new PageInput();
            pdf.Inputs.Add(input);

            TextElement textElement = new TextElement("Hello World", ElementPlacement.TopCenter);
            textElement.Color = new Grayscale(0.8f);
            input.Elements.Add(textElement);

            PdfResponse response = pdf.Process();

            bool pass = false;

            if (response.IsSuccessful)
            {
                File.WriteAllBytes(base.GetOutputFilePath("Output.pdf", InputSampleType), (byte[])response.Content);

#if BASELINEREQUIRED
                // Uncomment the line below to recreate the Input PNG Images
                base.CreateInputPngsFromOutputPdf(72, InputSampleType);

                pass = base.CompareOutputPdfToInputPngs(72, InputSampleType);
#else
                pass = response.IsSuccessful;
#endif

            }
            Assert.IsTrue(pass);
        }
    }
}
