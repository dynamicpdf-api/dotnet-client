using DynamicPDF.Api;
using DynamicPDF.Api.Elements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace DynamicPDFApiTestForNET.TestCases.FunctionalityTest.PDFEndpoint
{
    [TestClass]
    public class DlexInputSamples : TestCase
    {
        public override InputSampleType InputSampleType
        {
            get
            {
                return InputSampleType.Dlex;
            }
        }

        [TestMethod]
        public void SimpleDlex_Pdfoutput()
        {
            Name = "SimpleDlex_Pdfoutput";
            
            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            DlexResource dlex = new DlexResource(base.GetResourcePath("SimpleReportWithCoverPage.dlex"));
            LayoutDataResource layoutData = new LayoutDataResource(base.GetResourcePath("SimpleReportData.json"));
            DlexInput input = pdf.AddDlex(dlex, layoutData);
            pdf.AddAdditionalResource(base.GetResourcePath("Northwind Logo.gif"));
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
        public void SimpleDlex_CloudData_Pdfoutput()
        {
            Name = "SimpleDlex_CloudData";

            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            string jsonString = File.ReadAllText(base.GetResourcePath("SimpleReportData.json"));

            DlexInput input = new DlexInput("TFWResources/SimpleReportWithCoverPage.dlex", jsonString);
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
        public void Template_Pdfoutput()
        {
            Name = "Template_Pdfoutput";
            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            DlexResource dlex = new DlexResource(base.GetResourcePath("SimpleReportWithCoverPage.dlex"));
            LayoutDataResource layoutData = new LayoutDataResource(base.GetResourcePath("SimpleReportData.json"));
            DlexInput input = new DlexInput(dlex, layoutData);
            pdf.AddAdditionalResource(base.GetResourcePath("Northwind Logo.gif"));
            Template template = new Template("temp1");
            TextElement textElement = new TextElement("HelloWorld", ElementPlacement.TopRight);
            textElement.YOffset = -40;
            template.Elements.Add(textElement);
            input.Template = template;

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
