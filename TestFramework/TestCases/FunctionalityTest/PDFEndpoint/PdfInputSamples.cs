using DynamicPDF.Api;
using DynamicPDF.Api.Elements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace DynamicPDFApiTestForNET.TestCases.FunctionalityTest.PDFEndpoint
{
    [TestClass]
    public class PdfInputSamples : TestCase
    {
        public override InputSampleType InputSampleType
        {
            get
            {
                return InputSampleType.PdfInput;
            }
        }       

        [TestMethod]
        public void FilePathMergeOptions_PdfOutput()
        {
            Name = "FilePathMergeOptions";
            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            PdfResource resource = new PdfResource(base.GetResourcePath("AllPageElements.pdf"), "AllPageElements.pdf");
            PdfInput input = new PdfInput(resource);

            MergeOptions mergeOptions = new MergeOptions();
            mergeOptions.RootFormField = "RootName";
            mergeOptions.Outlines = false;
            input.MergeOptions = mergeOptions;
            pdf.Inputs.Add(input);

            PdfResource fw9AcroForm_14Resource = new PdfResource(File.ReadAllBytes(base.GetResourcePath("fw9AcroForm_14.pdf")), "fw9AcroForm_14.pdf");
            PdfInput input1 = new PdfInput(fw9AcroForm_14Resource);

            MergeOptions mergeOptions1 = new MergeOptions();
            mergeOptions1.LogicalStructure = false;
            mergeOptions1.FormFields = false;
            input1.MergeOptions = mergeOptions1;
            pdf.Inputs.Add(input1);

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
