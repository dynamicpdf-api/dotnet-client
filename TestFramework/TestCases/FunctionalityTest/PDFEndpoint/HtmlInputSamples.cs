using DynamicPDF.Api;
using DynamicPDF.Api.Elements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace DynamicPDFApiTestForNET.TestCases.FunctionalityTest.PDFEndpoint
{
    [TestClass]
    public class HtmlInputSamples : TestCase
    {
        public override InputSampleType InputSampleType
        {
            get
            {
                return InputSampleType.html;
            }
        }
        [TestMethod]
        public void HtmlStringInput()
        {
            Name = "HtmlStringInputPdfOutput";
            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;
            string htmlString = "<h1>DynamicPDF</h1><h1>Hello World!</h1><script>document.write(new Date().toString())</script><br/><img src='https://www.dynamicpdf.com/images/logo.png' />";
            HtmlInput input = new HtmlInput(htmlString);
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
        public void HtmlFileInput()
        {
            Name = "HtmlFileInputPdfOutput";
            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            HtmlResource resource = new HtmlResource(base.GetResourcePath("HtmlWithAllTags.html"));
            HtmlInput input = new HtmlInput(resource);
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
        public void HtmlInput_With_AllProperties()
        {
            Name = "HtmlInputWithAllProperties";
            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            Template template = new Template("Temp1");
            TextElement element1 = new TextElement("Hello World", ElementPlacement.TopLeft);
            template.Elements.Add(element1);
            HtmlResource resource = new HtmlResource(base.GetResourcePath("SampleHtml.html"));
            HtmlInput input = new HtmlInput(resource);
            input.BasePath = "https://www.dynamicpdf.com/images/";
            input.BottomMargin = 10;
            input.LeftMargin = 10;
            input.RightMargin = 10;
            input.TopMargin = 50;
            input.Id = "Html input with all properties";
            input.PageHeight = 700;
            input.PageWidth = 500;
            input.PageOrientation = PageOrientation.Landscape;
            input.PageSize = PageSize.Letter;
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
