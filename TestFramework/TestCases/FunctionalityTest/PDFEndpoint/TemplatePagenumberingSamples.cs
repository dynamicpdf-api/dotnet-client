using DynamicPDF.Api;
using DynamicPDF.Api.Elements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace DynamicPDFApiTestForNET.TestCases.FunctionalityTest.PDFEndpoint
{
    [TestClass]
    public class TemplatePagenumberingSamples : TestCase
    {
        public override InputSampleType InputSampleType
        {
            get
            {
                return InputSampleType.TemplatePageNumberingLabel;
            }
        }

        [TestMethod]
        public void FilePathInputPNE_PdfOutput()
        {
            Name = "FilePathInputPNE";

            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            PdfResource resource = new PdfResource(base.GetResourcePath(@"DocumentA100.pdf"));
            PdfInput input = new PdfInput(resource);

            Font fontResource = Font.FromFile(base.GetResourcePath(@"DejaVuSans.ttf"), "DvsFont");

            Template templateA = new Template("TemplateA");
            PageNumberingElement element = new PageNumberingElement("%%CP%% of %%TP%%", ElementPlacement.TopCenter);
            element.Font = fontResource;
            element.FontSize = 14.0f;
            element.Color = RgbColor.Red;
            templateA.Elements.Add(element);
            input.Template = templateA;

            pdf.Inputs.Add(input);
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
        public void FilePathPNEsWithTokens_PdfOutput()
        {
            Name = "FilePathPNEsWithTokens";

            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            PdfResource pdfResource = new PdfResource(base.GetResourcePath(@"Emptypages.pdf"));
            PdfInput emptypages = new PdfInput(pdfResource);

            Template templateA = new Template("TemplateA");
            PageNumberingElement topLeftElement = new PageNumberingElement("%%CP(1)%% of %%TP%%", ElementPlacement.TopLeft);
            topLeftElement.EvenPages = true;
            templateA.Elements.Add(topLeftElement);

            PageNumberingElement topCenterElement = new PageNumberingElement("%%SP(I)%% of %%ST%%", ElementPlacement.TopCenter);
            topCenterElement.OddPages = true;
            templateA.Elements.Add(topCenterElement);

            PageNumberingElement topRightElement = new PageNumberingElement("%%CP(i)%% of %%TP%%", ElementPlacement.TopRight);
            topRightElement.EvenPages = true;
            templateA.Elements.Add(topRightElement);

            PageNumberingElement bottomLeftElement = new PageNumberingElement("%%CP(I)%% of %%TP%%", ElementPlacement.BottomLeft);
            bottomLeftElement.OddPages = true;
            templateA.Elements.Add(bottomLeftElement);

            PageNumberingElement bottomCenterElement = new PageNumberingElement("%%CP(b)%% of %%TP%%", ElementPlacement.BottomCenter);
            bottomCenterElement.EvenPages = true;
            templateA.Elements.Add(bottomCenterElement);

            PageNumberingElement bottomRightElement = new PageNumberingElement("%%CP(a)%% of %%TP%%", ElementPlacement.BottomRight);
            bottomRightElement.OddPages = true;
            templateA.Elements.Add(bottomRightElement);

            emptypages.Template = templateA;

            pdf.Inputs.Add(emptypages);

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
