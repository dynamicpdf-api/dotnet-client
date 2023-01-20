using DynamicPDF.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace DynamicPDFApiTestForNET.TestCases.FunctionalityTest.PDFEndpoint
{
    [TestClass]
    public class FormFillingSamples : TestCase
    {
        public override InputSampleType InputSampleType
        {
            get
            {
                return InputSampleType.FormFilling;
            }
        }

        [TestMethod]
        public void PdfInputFilePath_PdfOutput()
        {
            Name = "PdfInputFilePath";
            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            PdfResource resource = new PdfResource(base.GetResourcePath("fw9AcroForm_14.pdf"));
            PdfInput input = new PdfInput(resource);
            pdf.Inputs.Add(input);

            FormField field = new FormField("topmostSubform[0].Page1[0].f1_1[0]", "Any Company, Inc.");
            pdf.FormFields.Add(field);
            FormField field1 = new FormField("topmostSubform[0].Page1[0].f1_2[0]", "Any Company");
            pdf.FormFields.Add(field1);
            FormField field2 = new FormField("topmostSubform[0].Page1[0].FederalClassification[0].c1_1[0]", "1");
            pdf.FormFields.Add(field2);
            FormField field3 = new FormField("topmostSubform[0].Page1[0].Address[0].f1_7[0]", "123 Main Street");
            pdf.FormFields.Add(field3);
            FormField field4 = new FormField("topmostSubform[0].Page1[0].Address[0].f1_8[0]", "Washington, DC  22222");
            pdf.FormFields.Add(field4);
            FormField field5 = new FormField("topmostSubform[0].Page1[0].f1_9[0]", "Any Requester");
            pdf.FormFields.Add(field5);
            FormField field6 = new FormField("topmostSubform[0].Page1[0].f1_10[0]", "17288825617");
            pdf.FormFields.Add(field6);
            FormField field7 = new FormField("topmostSubform[0].Page1[0].EmployerID[0].f1_14[0]", "52");
            pdf.FormFields.Add(field7);
            FormField field8 = new FormField("topmostSubform[0].Page1[0].EmployerID[0].f1_15[0]", "1234567");
            pdf.FormFields.Add(field8);

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
