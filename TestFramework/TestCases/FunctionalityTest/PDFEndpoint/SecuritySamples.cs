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
        [TestMethod]
        public void PdfInputFilePathAes256Security_PdfOutput()
        {
            Name = "PdfInputFilePathAes256Security";
            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            PdfResource resource = new PdfResource(base.GetResourcePath("XmpAndOtherSample.pdf"));
            PdfInput input = new PdfInput(resource);
            pdf.Inputs.Add(input);

            Aes256Security security = new Aes256Security("user", "owner");
            security.AllowFormFilling = false;
            security.AllowUpdateAnnotsAndFields = false;
            security.AllowEdit = false;
            security.DocumentComponents = EncryptDocumentComponents.AllExceptMetadata;
            pdf.Security = security;

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
        public void PageInput_Aes128Security_PdfOutput()
        {
            Name = "PageInputAes128Security";
            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            Aes128Security security = new Aes128Security("", "");
            security.OwnerPassword = "owner";
            security.UserPassword = "user";
            security.AllowDocumentAssembly = false;
            security.AllowEdit = false;
            security.DocumentComponents = EncryptDocumentComponents.All;
            pdf.Security = security;

            PageInput input = new PageInput();
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
        public void PdfInputUsingCloudRoot_RC4128Security_PdfOutput()
        {
            Name = "PdfInputCloudRootRC4128Security";
            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            RC4128Security security = new RC4128Security("user", "owner");
            security.AllowHighResolutionPrinting = true;
            security.AllowPrint = true;
            security.EncryptMetadata = true;
            pdf.Security = security;

            PdfInput input = new PdfInput("TFWResources/XmpAndOtherSample.pdf");
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
    }
}
