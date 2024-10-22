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
        public Pdf pdfObj(DlexResource dlex, LayoutDataResource layoutData, Template template)
        {
            Pdf pdf = new Pdf();
            string apiKey = pdf.BaseUrl;
            pdf.Author = Author;
            pdf.Title = Title;

            DlexInput input = pdf.AddDlex(dlex, layoutData);
            if (template != null)
            {
                input.Template = template;
                pdf.Inputs.Add(input);
            }

            return pdf;
        }

        [TestMethod]
        public void SimpleDlex_Pdfoutput()
        {
            Name = "SimpleDlex_Pdfoutput";

            Pdf pdf = pdfObj(new DlexResource(base.GetResourcePath("SimpleReportWithCoverPage.dlex"), "SimpleReportWithCoverPage.dlex"), new LayoutDataResource(base.GetResourcePath("SimpleReportData.json"), "SimpleReportData.json"), null);

            pdf.AddAdditionalResource(base.GetResourcePath("Northwind Logo.gif"));

            PdfResponse response = pdf.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                pass = base.getVerify(InputSampleType, response, pdf);
            }
            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void Template_Pdfoutput()
        {
            Name = "Template_Pdfoutput";

            Template template = new Template("temp1");
            TextElement textElement = new TextElement("HelloWorld", ElementPlacement.TopRight);
            textElement.YOffset = -40;
            template.Elements.Add(textElement);

            Pdf pdf = pdfObj(new DlexResource(base.GetResourcePath("SimpleReportWithCoverPage.dlex"), "SimpleReportWithCoverPage.dlex"), new LayoutDataResource(base.GetResourcePath("SimpleReportData.json"), "SimpleReportData.json"), template);

            pdf.AddAdditionalResource(base.GetResourcePath("Northwind Logo.gif"));

            PdfResponse response = pdf.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                pass = base.getVerify(InputSampleType, response, pdf);
            }
            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void ImageURI_Pdfoutput()
        {
            Name = "ImageURI_Pdfoutput";

            Pdf pdf = pdfObj(new DlexResource(base.GetResourcePath("dynamic-image.dlex"), "dynamic-image.dlex"), new LayoutDataResource(base.GetResourcePath("ImageData.json"), "ImageData.json"), null);

            PdfResponse response = pdf.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                pass = base.getVerify(InputSampleType, response, pdf);
            }
            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void SimpleDlex_CloudData_Pdfoutput()
        {
            Name = "SimpleDlex_CloudData";

            Pdf pdf = new Pdf();
            string apiKey = pdf.BaseUrl;
            pdf.Author = Author;
            pdf.Title = Title;

            string jsonString = File.ReadAllText(base.GetResourcePath("SimpleReportData.json"));

            DlexInput input = new DlexInput("TFWResources/SimpleReportWithCoverPage.dlex", jsonString);
            input.LayoutDataResourceName = "SimpleReportData.json";
            pdf.Inputs.Add(input);

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
