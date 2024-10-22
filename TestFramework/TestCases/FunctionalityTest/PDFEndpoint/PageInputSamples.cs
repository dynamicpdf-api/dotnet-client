using DynamicPDF.Api;
using DynamicPDF.Api.Elements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace DynamicPDFApiTestForNET.TestCases.FunctionalityTest.PDFEndpoint
{
    [TestClass]
    public class PageInputSamples : TestCase
    {
        public override InputSampleType InputSampleType
        {
            get
            {
                return InputSampleType.PageInput;
            }
        }
        [TestMethod]
        public void PageInput_TextElement_Pdfoutput()
        {
            Name = "TextElement";
            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;
            pdf.Subject = "topLevel document metadata";
            pdf.Creator = "John Creator";
            pdf.Producer = "ceTe Software";
            pdf.Keywords = "dynamicpdf api example pdf dotnet instructions";
            pdf.Tag = true;

            PageInput pageInput = new PageInput();
            TextElement element = new TextElement("Hello World", ElementPlacement.TopCenter);
            pageInput.Elements.Add(element);

            pdf.Inputs.Add(pageInput);
            PdfResponse response = pdf.Process();

            bool pass = false;

            if (response.IsSuccessful)
            {
                pass = base.getVerify(InputSampleType, response, pdf);
            }
            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void PageInput_TextElementAddedToPageAndTemplate_Pdfoutput()
        {
            Name = "TextElementAddedToPageAndTemplate";
            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            PageInput pageInput = pdf.AddPage(500, 500);

            Template template = new Template("Temp1");
            TextElement element1 = new TextElement("Hello World", ElementPlacement.TopLeft);
            template.Elements.Add(element1);

            pageInput.Template = template;

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
