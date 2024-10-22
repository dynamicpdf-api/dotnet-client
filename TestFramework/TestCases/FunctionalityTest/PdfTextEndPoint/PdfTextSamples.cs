using DynamicPDF.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace DynamicPDFApiTestForNET.TestCases.FunctionalityTest.PdfTextEndPoint
{
    [TestClass]
    public class PdfTextSamples : TestCase
    {
        public override InputSampleType InputSampleType
        {
            get
            {
                return InputSampleType.PdfText;
            }
        }

        [TestMethod]
        public void TextExtraction()
        {
            Name = "TextExtraction";
            PdfResource resource = new PdfResource(base.GetResourcePath("TimeMachine.pdf"));

            PdfText text = new PdfText(resource);
            PdfTextResponse response = text.Process();
            bool pass = false;
           
            if (response.IsSuccessful)
            {
                pass = base.getVerify(InputSampleType, response);
            }
            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void TextExtractionWithSinglePage()
        {
            Name = "SinglePage";
            PdfResource resource = new PdfResource(base.GetResourcePath("TimeMachine.pdf"));

            PdfText text = new PdfText(resource);
            text.StartPage = 5;
            text.PageCount = 1;
            PdfTextResponse response = text.Process();
            bool pass = false;
            if (response.IsSuccessful)
            {
                pass = base.getVerify(InputSampleType, response);
            }
            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void TextExtractionWithMultipage()
        {
            Name = "MultiPage";
            PdfResource resource = new PdfResource(base.GetResourcePath("TimeMachine.pdf"));
            PdfText text = new PdfText(resource);
            text.StartPage = 2;
            text.PageCount = 3;
            
            PdfTextResponse response = text.Process();
            bool pass = false;
            if (response.IsSuccessful)
            {
                pass = base.getVerify(InputSampleType, response);
            }
            Assert.IsTrue(pass);
        } 

    }
}
