using DynamicPDF.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
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

        [TestMethod]
        public void TextExtractionWithStream()
        {
            Name = "Stream";
            PdfResource resource = new PdfResource(base.GetResourcePath("HARDWARE_SPEC_2025-04-23a.pdf"));

            PdfText text = new PdfText(resource, 2, 1);
            text.TextOrder = TextOrder.Stream;
            PdfTextResponse response = text.Process();
            bool pass = false;
            if (response.IsSuccessful)
            {
                pass = base.getVerify(InputSampleType, response);
            }
        }

        [TestMethod]
        public void TextExtractionWithVisible()
        {
            Name = "Visible";
            PdfResource resource = new PdfResource(base.GetResourcePath("HARDWARE_SPEC_2025-04-23a.pdf"));

            PdfText text = new PdfText(resource, 2, 1);
            text.TextOrder = TextOrder.Visible;
            PdfTextResponse response = text.Process();
            bool pass = false;
            if (response.IsSuccessful)
            {
                pass = base.getVerify(InputSampleType, response);
            }
        }

        [TestMethod]
        public void TextExtractionWithVisibleExtraSpace()
        {
            Name = "VisibleExtraSpace";
            PdfResource resource = new PdfResource(base.GetResourcePath("HARDWARE_SPEC_2025-04-23a.pdf"));

            PdfText text = new PdfText(resource, 2, 1);
            text.TextOrder = TextOrder.VisibleExtraSpace;
            PdfTextResponse response = text.Process();
            bool pass = false;
            if (response.IsSuccessful)
            {
                pass = base.getVerify(InputSampleType, response);
            }
        }
    }
}
