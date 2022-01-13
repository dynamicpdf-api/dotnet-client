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
        public void PdfInputs_PdfOutput()
        {
            Name = "PdfInputs";
            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            PdfResource invoiceResource = new PdfResource(base.GetResourcePath("Invoice.pdf"));
            PdfInput invoice = new PdfInput(invoiceResource);
            pdf.Inputs.Add(invoice);

            MemoryStream fw9AcroForm_18Stream = new MemoryStream(File.ReadAllBytes(base.GetResourcePath("Emptypages.pdf")));
            PdfResource fw9AcroForm_18Resource = new PdfResource(fw9AcroForm_18Stream);
            PdfInput fw9AcroForm_18 = new PdfInput(fw9AcroForm_18Resource);
            pdf.Inputs.Add(fw9AcroForm_18);

            PdfInput documentA100 = new PdfInput("TFWResources/DocumentA100.pdf");
            documentA100.StartPage = 5;
            documentA100.PageCount = 25;
            pdf.Inputs.Add(documentA100);


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
        public void FilePathMergeOptions_PdfOutput()
        {
            Name = "FilePathMergeOptions";
            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            PdfResource resource = new PdfResource(base.GetResourcePath("AllPageElements.pdf"));
            PdfInput input = new PdfInput(resource);

            MergeOptions mergeOptions = new MergeOptions();
            mergeOptions.RootFormField = "RootName";
            mergeOptions.Outlines = false;
            input.MergeOptions = mergeOptions;
            pdf.Inputs.Add(input);

            PdfResource fw9AcroForm_18Resource = new PdfResource(File.ReadAllBytes(base.GetResourcePath("fw9AcroForm_18.pdf")));
            PdfInput input1 = new PdfInput(fw9AcroForm_18Resource);

            MergeOptions mergeOptions1 = new MergeOptions();
            mergeOptions1.LogicalStructure = false;
            mergeOptions1.FormFields = false;
            input1.MergeOptions = mergeOptions1;
            pdf.Inputs.Add(input1);

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
