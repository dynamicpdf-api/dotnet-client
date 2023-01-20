using DynamicPDF.Api;
using DynamicPDF.Api.Elements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace DynamicPDFApiTestForNET.TestCases.FunctionalityTest.PDFEndpoint
{

    [TestClass]
    public class LineSample : TestCase
    {
        public override InputSampleType InputSampleType
        {
            get
            {
                return InputSampleType.Line;
            }
        }

        [TestMethod]
        public void PageInput_Pdfoutput()
        {
            Name = "PageInput";
            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            PageInput input = new PageInput();
            pdf.Inputs.Add(input);

            LineElement element = new LineElement(ElementPlacement.TopLeft, 200, 200);
            element.Color = new RgbColor(0, 0, 1);
            element.XOffset = 50;
            element.YOffset = 50;
            element.LineStyle = LineStyle.DashLarge;
            element.Width = 4;
            input.Elements.Add(element);

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
