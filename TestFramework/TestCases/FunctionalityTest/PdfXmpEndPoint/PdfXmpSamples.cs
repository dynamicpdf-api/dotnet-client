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
                pass = base.getVerify(InputSampleType, response);
            }
            Assert.IsTrue(pass);
        }
    }
}
