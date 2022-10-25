using DynamicPDF.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DynamicPDFApiTestForNET.TestCases.FunctionalityTest.PDFEndpoint
{
    [TestClass]
    public class HtmlInputSamples : TestCase
    {
        public override InputSampleType InputSampleType
        {
            get
            {
                return InputSampleType.Html;
            }
        }

        [TestMethod]
        public void HtmlString_pdfoutput()
        {
            Name = "HtmlToPdf";
            Pdf pdf = new Pdf();

            HtmlInput html = new HtmlInput("<html><body>hello</body></html>");
            html.PageSize(300,200);
            html.Margin(10, 40);

            pdf.Inputs.Add(html);

            PdfResponse response = pdf.Process();

            bool pass = false;
            if (response.IsSuccessful)
            {
                File.WriteAllBytes(base.GetOutputFilePath("HtmlStringOP.pdf", InputSampleType), (byte[])response.Content);

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);

        }

        [TestMethod]
        public void HtmlResource_pdfoutput()
        {
            Name = "HtmlToPdf";
            Pdf pdf = new Pdf();

            HtmlResource file = new HtmlResource(base.GetResourcePath("html.html"));

            HtmlInput html = new HtmlInput(file);
            html.PageSize(PageSize.B4, PageOrientation.Landscape);

            html.Margin(50,80);

            pdf.Inputs.Add(html);

            PdfResponse response = pdf.Process();

            bool pass = false;
            if (response.IsSuccessful)
            {
                File.WriteAllBytes(base.GetOutputFilePath("HtmlFileOP.pdf", InputSampleType), (byte[])response.Content);

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
    }
}
