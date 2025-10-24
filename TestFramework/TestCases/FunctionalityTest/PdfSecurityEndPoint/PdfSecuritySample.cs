using DynamicPDF.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DynamicPDFApiTestForNET.TestCases.FunctionalityTest.PdfSecurityEndPoint
{
    [TestClass]
    public class PdfSecuritySample : TestCase
    {
        public override InputSampleType InputSampleType
        {
            get
            {
                return InputSampleType.PdfSecurityInfo;
            }
        }

        [TestMethod]
        public void Aes128PdfSecurityInfo()
        {
            Name = "Aes128PdfSecurity";
            PdfResource resource = new PdfResource(base.GetResourcePath("Aes128Security.pdf"), "Aes128Security.pdf");

            PdfSecurityInfoEndpoint pdfInfo = new PdfSecurityInfoEndpoint(resource);
            PdfSecurityInfoResponse response = pdfInfo.Process();

            bool pass = false;

            if (response.IsSuccessful)
            {
                pass = base.getVerify(InputSampleType, response);
            }
            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void Aes256PdfSecurityInfo()
        {
            Name = "Aes256PdfSecurity";
            PdfResource resource = new PdfResource(base.GetResourcePath("Aes256Security.pdf"), "Aes256Security.pdf");

            PdfSecurityInfoEndpoint pdfInfo = new PdfSecurityInfoEndpoint(resource);
            PdfSecurityInfoResponse response = pdfInfo.Process();

            bool pass = false;

            if (response.IsSuccessful)
            {
                pass = base.getVerify(InputSampleType, response);
            }
            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void Rc440PdfSecurityInfo()
        {
            Name = "Rc440PdfSecurity";
            PdfResource resource = new PdfResource(base.GetResourcePath("Rc440Security.pdf"), "Rc440Security.pdf");

            PdfSecurityInfoEndpoint pdfInfo = new PdfSecurityInfoEndpoint(resource);
            PdfSecurityInfoResponse response = pdfInfo.Process();

            bool pass = false;

            if (response.IsSuccessful)
            {
                pass = base.getVerify(InputSampleType, response);
            }
            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void Rc4128PdfSecurityInfo()
        {
            Name = "Rc4128PdfSecurity";
            PdfResource resource = new PdfResource(base.GetResourcePath("Rc4128Security.pdf"), "Rc4128Security.pdf");

            PdfSecurityInfoEndpoint pdfInfo = new PdfSecurityInfoEndpoint(resource);
            PdfSecurityInfoResponse response = pdfInfo.Process();

            bool pass = false;

            if (response.IsSuccessful)
            {
                pass = base.getVerify(InputSampleType, response);
            }
            Assert.IsTrue(pass);
        }

    }
}
