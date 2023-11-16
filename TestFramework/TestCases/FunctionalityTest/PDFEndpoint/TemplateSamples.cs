using DynamicPDF.Api;
using DynamicPDF.Api.Elements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
namespace DynamicPDFApiTestForNET.TestCases.FunctionalityTest.PDFEndpoint
{
    [TestClass]
    public class TemplateSamples : TestCase
    {
        public override InputSampleType InputSampleType
        {
            get
            {
                return InputSampleType.Template;
            }
        }

        [TestMethod]
        public void FilePathInputTextElement_Pdfoutput()
        {
            Name = "FilePathInputTextElement";

            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            PdfResource resource = new PdfResource(base.GetResourcePath(@"DocumentA100.pdf"));
            PdfInput input = new PdfInput(resource);

            pdf.Inputs.Add(input);

            Template template = new Template("Temp1");
            TextElement element = new TextElement("Hello World",ElementPlacement.TopCenter);
            element.XOffset = 0;
            element.YOffset = 0;
            element.Color = RgbColor.Green;
            element.FontSize = 20;
            element.Font = Font.TimesRoman;
            template.Elements.Add(element);
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
        public void TestPdfProducer_Pdfoutput()
        {
            Name = "TestPdfProducer";

            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;
            pdf.Producer = "ceTe";

            PdfResource resource = new PdfResource(base.GetResourcePath(@"DocumentA100.pdf"));
            PdfInput input = new PdfInput(resource);

            pdf.Inputs.Add(input);

            Template template = new Template("Temp1");
            TextElement element = new TextElement("Hello World",ElementPlacement.TopCenter);
            element.XOffset = 0;
            element.YOffset = 0;
            element.Color = RgbColor.Green;
            element.FontSize = 20;
            element.Font = Font.TimesRoman;
            template.Elements.Add(element);
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
    }
}
