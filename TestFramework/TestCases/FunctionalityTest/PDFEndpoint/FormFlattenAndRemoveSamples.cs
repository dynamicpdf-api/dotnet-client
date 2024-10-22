using DynamicPDF.Api;
using DynamicPDF.Api.Elements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
namespace DynamicPDFApiTestForNET.TestCases.FunctionalityTest.PDFEndpoint
{
    [TestClass]
    public class FormFlattenAndRemoveSamples : TestCase
    {
        public override InputSampleType InputSampleType
        {
            get
            {
                return InputSampleType.FormFlattenAndRemove;
            }
        }
        public Pdf pdfObj(PdfInput input, FormField[] fields)
        {
            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            pdf.Inputs.Add(input);

            if (fields != null) 
            {
                foreach (FormField field in fields)
                {
                    pdf.FormFields.Add(field);
                }
            }
            return pdf;
        }

        [TestMethod]
        public void PdfInputFilePath_FormFlattenField_Pdfoutput()
        {
            Name = "FilePathField";

            PdfResource resource = new PdfResource(base.GetResourcePath("fw9AcroForm_14.pdf"), "fw9AcroForm_14.pdf");
            PdfInput input = new PdfInput(resource);

            FormField field = new FormField("topmostSubform[0].Page1[0].f1_1[0]", "Any Company, Inc.");
            field.Flatten = true;

            FormField field1 = new FormField("topmostSubform[0].Page1[0].f1_2[0]", "Any Company");
            field1.Flatten = true;

            FormField field2 = new FormField("topmostSubform[0].Page1[0].FederalClassification[0].c1_1[0]", "1");
            field2.Flatten = true;

            FormField field3 = new FormField("topmostSubform[0].Page1[0].Address[0].f1_7[0]", "123 Main Street");
            field3.Flatten = false;

            FormField field4 = new FormField("topmostSubform[0].Page1[0].Address[0].f1_8[0]", "Washington, DC  22222");
            field4.Flatten = false;

            FormField field5 = new FormField("topmostSubform[0].Page1[0].f1_9[0]", "Any Requester");
            field5.Flatten = true;

            FormField[] fields = { field, field1, field2, field3, field4, field5 };

            Pdf pdf = pdfObj(input, fields);

            PdfResponse response = pdf.Process();

            bool pass = false;

            if (response.IsSuccessful)
            {
                pass = base.getVerify(InputSampleType, response, pdf);
            }
            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void PdfInputUsingCloudRoot_FormFlattenFieldRemove_Pdfoutput()
        {
            Name = "CloudRootFieldRemove";

            PdfInput input = new PdfInput("TFWResources/fw9AcroForm_14.pdf");

            FormField field = new FormField("topmostSubform[0].Page1[0].f1_1[0]");
            field.Remove = true;

            FormField field1 = new FormField("topmostSubform[0].Page1[0].f1_2[0]");
            field1.Remove = true;

            FormField field2 = new FormField("topmostSubform[0].Page1[0].Address[0].f1_7[0]", "123 Main Street");
            field2.Remove = false;

            FormField field3 = new FormField("topmostSubform[0].Page1[0].Address[0].f1_8[0]", "Washington, DC  22222");
            field3.Remove = false;

            FormField field4 = new FormField("topmostSubform[0].Page1[0].f1_9[0]");
            field4.Remove = true;

            FormField[] fields = { field, field1, field2, field3, field4 };

            Pdf pdf = pdfObj(input, fields);

            PdfResponse response = pdf.Process();

            bool pass = false;

            if (response.IsSuccessful)
            {
                pass = base.getVerify(InputSampleType, response, pdf);
            }
            Assert.IsTrue(pass);
        }

        
        [TestMethod]
        public void PdfInputUsingStream_FormFlattenAllFields_Pdfoutput()
        {
            Name = "StreamAllFields";

            MemoryStream memory = new MemoryStream(File.ReadAllBytes(base.GetResourcePath("fw9AcroForm_14.pdf")));
            PdfResource resource = new PdfResource(memory, "fw9AcroForm_14.pdf");
            PdfInput input = new PdfInput(resource);

            FormField field = new FormField("topmostSubform[0].Page1[0].f1_1[0]", "Any Company, Inc.");
            FormField field1 = new FormField("topmostSubform[0].Page1[0].f1_2[0]", "Any Company");
            FormField field2 = new FormField("topmostSubform[0].Page1[0].FederalClassification[0].c1_1[0]", "1");
            FormField field3 = new FormField("topmostSubform[0].Page1[0].Address[0].f1_7[0]", "123 Main Street");
            FormField field4 = new FormField("topmostSubform[0].Page1[0].Address[0].f1_8[0]", "Washington, DC  22222");
            FormField field5 = new FormField("topmostSubform[0].Page1[0].f1_9[0]", "Any Requester");
            FormField field6 = new FormField("topmostSubform[0].Page1[0].f1_10[0]", "17288825617");
            FormField field7 = new FormField("topmostSubform[0].Page1[0].EmployerID[0].f1_14[0]", "52");
            FormField field8 = new FormField("topmostSubform[0].Page1[0].EmployerID[0].f1_15[0]", "1234567");

            FormField[] fields = { field, field1, field2, field3, field4, field5, field6, field7, field8 };
            Pdf pdf = pdfObj(input, fields);
            pdf.FlattenAllFormFields = true;

            PdfResponse response = pdf.Process();

            bool pass = false;

            if (response.IsSuccessful)
            {
                pass = base.getVerify(InputSampleType, response, pdf);
            }
            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void PdfInputUsingFilePath_RetainSignature_Pdfoutput()
        {
            Name = "FilePathRetainSignature";

            PdfResource resource = new PdfResource(base.GetResourcePath("Signature.pdf"), "Signature.pdf");
            PdfInput input = new PdfInput(resource);

            Pdf pdf = pdfObj(input, null);
            pdf.FlattenAllFormFields = true;
            pdf.RetainSignatureFormFields = true;

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
