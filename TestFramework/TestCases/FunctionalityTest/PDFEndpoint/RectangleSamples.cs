using DynamicPDF.Api;
using DynamicPDF.Api.Elements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DynamicPDFApiTestForNET.TestCases.FunctionalityTest.PDFEndpoint
{
    [TestClass]
    public class RectangleSamples : TestCase
    {
        public override InputSampleType InputSampleType
        {
            get
            {
                return InputSampleType.Rectangle;
            }
        }

        [TestMethod]
        public void PageInput_Pdfoutput()
        {
            Name = "PageInput";
            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            PageInput pageInput = new PageInput();
            RectangleElement element = new RectangleElement(ElementPlacement.TopCenter, 100, 50);
            element.XOffset = 50;
            element.YOffset = 50;
            element.CornerRadius = 10;
            element.BorderWidth = 5;
            element.BorderStyle = LineStyle.Dots;
            element.BorderColor = RgbColor.Blue;
            element.FillColor = RgbColor.Green;
            pageInput.Elements.Add(element);

            pdf.Inputs.Add(pageInput);
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
