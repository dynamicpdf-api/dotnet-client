using DynamicPDF.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;


namespace DynamicPDFApiTestForNET.TestCases.FunctionalityTest.PdfXmpEndPoint
{
    [TestClass]
    public class PdfXmpSamples : TestCase
    {
        public override InputSampleType InputSampleType
        {
            get
            {
                return InputSampleType.PdfXmp;
            }
        }

        [TestMethod]
        public void XmpResource()
        {
            Name = "XmpResource";
            PdfResource resource = new PdfResource(base.GetResourcePath("XmpAndOtherSample.pdf"));
            PdfXmp xmp = new PdfXmp(resource);
            
            XmlResponse response = xmp.Process();
            
            bool pass = false;
            if (response.IsSuccessful)
            {
                File.WriteAllText(base.GetOutputFilePath("Output.xml", InputSampleType), response.Content);

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
