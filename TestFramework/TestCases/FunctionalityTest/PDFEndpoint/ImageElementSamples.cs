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
            Name = "ImageElement";
            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            PageInput input = new PageInput();
            pdf.Inputs.Add(input);

            ImageResource resource1 = new ImageResource(base.GetResourcePath("Northwind Logo.gif"), "Northwind Logo.gif");
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
                pass = base.getVerify(InputSampleType, response, pdf);
            }
            Assert.IsTrue(pass);
        }        
    }
}
