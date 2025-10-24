using DynamicPDF.Api;
using DynamicPDF.Api.Elements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace DynamicPDFApiTestForNET.TestCases.FunctionalityTest.PDFEndpoint
{
    [TestClass]
    public class MultipleInputs : TestCase
    {
        public override InputSampleType InputSampleType
        {
            get
            {
                return InputSampleType.MultipleInputs;
            }
        }

        [TestMethod]
        public void Inputs_DifferentInputs_PdfOutput()
        {
            Name = "MultipleInputs";

            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            PdfInput pdfInput = new PdfInput("TFWResources/DocumentA100.pdf");
            MergeOptions mergeOptions = new MergeOptions();
            pdfInput.MergeOptions = mergeOptions;
            pdf.Inputs.Add(pdfInput);

            PageInput pageInput = new PageInput();
            TextElement textElement = new TextElement("Hello World", ElementPlacement.TopLeft);
            textElement.FontSize = 40;
            pageInput.Elements.Add(textElement);
            pdf.Inputs.Add(pageInput);

            PageInput pageInput1 = new PageInput();
            ImageResource img = new ImageResource(base.GetResourcePath("DocumentA.jpeg"), "DocumentA.jpeg");
            ImageElement element = new ImageElement(img, ElementPlacement.TopCenter);
            element.XOffset = 50;
            element.YOffset = 50;
            pageInput1.Elements.Add(element);
            pdf.Inputs.Add(pageInput1);

            string jsonString = File.ReadAllText(base.GetResourcePath("SimpleReportData.json"));
            DlexInput dlexInput = new DlexInput("TFWResources/SimpleReportWithCoverPage.dlex", jsonString);
            dlexInput.LayoutDataResourceName = "SimpleReportData.json";
            pdf.Inputs.Add(dlexInput);

            ImageInput imageInput = new ImageInput("TFWResources/Northwind Logo.gif");
            imageInput.TopMargin = 10;
            imageInput.LeftMargin = 10;
            imageInput.RightMargin = 10;
            imageInput.BottomMargin = 10;
            pdf.Inputs.Add(imageInput);

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
