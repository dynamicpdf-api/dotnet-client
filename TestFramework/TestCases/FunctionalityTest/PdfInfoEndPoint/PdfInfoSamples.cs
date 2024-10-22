using DynamicPDF.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace DynamicPDFApiTestForNET.TestCases.FunctionalityTest.PdfInfoEndPoint
{
    [TestClass]
    public class PdfInfoSamples : TestCase
    {
        public override InputSampleType InputSampleType
        {
            get
            {
                return InputSampleType.PdfInfo;
            }
        }

        [TestMethod]
        public void AllFormFields_JsonOutput()
        {
            Name = "AllFormFields";
            PdfResource resource = new PdfResource(base.GetResourcePath("AllFormFields.pdf"), "AllFormFields.pdf");

            PdfInfo pdfInfo = new PdfInfo(resource);
            PdfInfoResponse response = pdfInfo.Process();
            bool pass = false;
            if (response.IsSuccessful)
            {
                File.WriteAllText(base.GetOutputFilePath("AllFormFields_JsonOutput.json", InputSampleType), response.JsonContent);
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
