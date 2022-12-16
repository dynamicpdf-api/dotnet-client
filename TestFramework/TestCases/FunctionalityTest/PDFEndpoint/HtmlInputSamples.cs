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

            html.PageWidth = 300;
            html.PageHeight = 200;

            html.TopMargin = 10;
            html.BottomMargin = 10;
            html.RightMargin = 40;
            html.LeftMargin = 40;

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
        public void HtmlStringParameters_pdfoutput()
        {
            Name = "HtmlToPdf";
            Pdf pdf = new Pdf();

            HtmlInput html = new HtmlInput("<html><body>hello</body></html>",null, PageSize.Letter, PageOrientation.Portrait, 10f);

            pdf.Inputs.Add(html);

            PdfResponse response = pdf.Process();

            bool pass = false;
            if (response.IsSuccessful)
            {
                File.WriteAllBytes(base.GetOutputFilePath("HtmlStringParameters.pdf", InputSampleType), (byte[])response.Content);

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
            html.PageSize = PageSize.B4;
            html.PageOrientation = PageOrientation.Landscape;

            html.TopMargin = 50;
            html.BottomMargin = 50;
            html.RightMargin = 80;
            html.LeftMargin = 80;


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

        [TestMethod]
        public void HtmlResourcePageSize_pdfoutput()
        {
            Name = "HtmlToPdf";
            Pdf pdf = new Pdf();

            HtmlResource file = new HtmlResource(base.GetResourcePath("html.html"));

            HtmlInput html = new HtmlInput(file);
            html.PageSize = PageSize.Postcard;


            pdf.Inputs.Add(html);

            PdfResponse response = pdf.Process();

            bool pass = false;
            if (response.IsSuccessful)
            {
                File.WriteAllBytes(base.GetOutputFilePath("HtmlFilePageSize.pdf", InputSampleType), (byte[])response.Content);

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void HtmlResourcePageHeightPageWidth_pdfoutput()
        {
            Name = "HtmlToPdf";
            Pdf pdf = new Pdf();

            HtmlResource file = new HtmlResource(base.GetResourcePath("html.html"));

            HtmlInput html = new HtmlInput(file);
            html.PageHeight = 400;
            html.PageWidth = 300;


            pdf.Inputs.Add(html);

            PdfResponse response = pdf.Process();

            bool pass = false;
            if (response.IsSuccessful)
            {
                File.WriteAllBytes(base.GetOutputFilePath("HtmlFilePageHeightPageWidth.pdf", InputSampleType), (byte[])response.Content);

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void HtmlResourceParameters_pdfoutput()
        {
            Name = "HtmlToPdf";
            Pdf pdf = new Pdf();

            HtmlResource file = new HtmlResource(base.GetResourcePath("html.html"));

            HtmlInput html = new HtmlInput(file, null, PageSize.A3, PageOrientation.Landscape, 30f);

            pdf.Inputs.Add(html);

            PdfResponse response = pdf.Process();

            bool pass = false;
            if (response.IsSuccessful)
            {
                File.WriteAllBytes(base.GetOutputFilePath("HtmlFilePageHeightPageWidth.pdf", InputSampleType), (byte[])response.Content);

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
    }
}
