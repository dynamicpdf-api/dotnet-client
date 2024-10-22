using DynamicPDF.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace DynamicPDFApiTestForNET.TestCases.FunctionalityTest.PDFEndpoint
{
    [TestClass]
    public class SecuritySamples : TestCase
    {
        public override InputSampleType InputSampleType
        {
            get
            {
                return InputSampleType.Security;
            }
        }
        public Pdf pdfObj(object security, object input)
        {
            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            pdf.Security = (Security)security;
            if(input is PdfInput)
                pdf.Inputs.Add((PdfInput)input);
            else
                pdf.Inputs.Add(new PageInput());

            return pdf;
        }
        [TestMethod]
        public void PdfInputFilePathAes256Security_PdfOutput()
        {
            Name = "PdfInputFilePathAes256Security";

            PdfResource resource = new PdfResource(base.GetResourcePath("XmpAndOtherSample.pdf"), "XmpAndOtherSample.pdf");
            PdfInput input = new PdfInput(resource);

            Aes256Security security = new Aes256Security("user", "owner");
            security.AllowFormFilling = false;
            security.AllowUpdateAnnotsAndFields = false;
            security.AllowEdit = false;
            security.DocumentComponents = EncryptDocumentComponents.AllExceptMetadata;

            Pdf pdf = pdfObj(security, input);

            PdfResponse response = pdf.Process();

            bool pass = false;

            if (response.IsSuccessful)
            {
                pass = base.getVerify(InputSampleType, response, pdf);
            }
            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void PageInput_Aes128Security_PdfOutput()
        {
            Name = "PageInputAes128Security";

            Aes128Security security = new Aes128Security("", "");
            security.OwnerPassword = "owner";
            security.UserPassword = "user";
            security.AllowDocumentAssembly = false;
            security.AllowEdit = false;
            security.DocumentComponents = EncryptDocumentComponents.All;

            PageInput input = new PageInput();

            Pdf pdf = pdfObj(security, input);

            PdfResponse response = pdf.Process();

            bool pass = false;

            if (response.IsSuccessful)
            {
                pass = base.getVerify(InputSampleType, response, pdf);
            }
            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void PdfInputUsingCloudRoot_RC4128Security_PdfOutput()
        {
            Name = "PdfInputCloudRootRC4128Security";
            
            RC4128Security security = new RC4128Security("user", "owner");
            security.AllowHighResolutionPrinting = true;
            security.AllowPrint = true;
            security.EncryptMetadata = true;

            PdfInput input = new PdfInput("TFWResources/XmpAndOtherSample.pdf");

            Pdf pdf = pdfObj(security, input);

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
