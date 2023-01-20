using DynamicPDF.Api;
using DynamicPDF.Api.Elements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace DynamicPDFApiTestForNET.TestCases.FunctionalityTest.PDFEndpoint
{
    [TestClass]
    public class ImageElementSamples : TestCase
    {
        public override InputSampleType InputSampleType
        {
            get
            {
                return InputSampleType.ImageElement;
            }
        }

        [TestMethod]
        public void PdfPageInput_Page_Pdfoutput()
        {
            Name = "PageElement";
            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            PageInput input = new PageInput();
            pdf.Inputs.Add(input);

            ImageResource resource1 = new ImageResource(base.GetResourcePath("Northwind Logo.gif"));
            ImageElement element = new ImageElement(resource1, ElementPlacement.TopCenter);
            element.XOffset = 50;
            element.YOffset = 50;
            element.ScaleX = 3;
            element.ScaleY = 3;
            input.Elements.Add(element);

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
