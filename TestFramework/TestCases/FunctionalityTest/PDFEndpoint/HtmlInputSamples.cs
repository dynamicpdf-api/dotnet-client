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
            Name = "HtmlString";
            Pdf pdf = new Pdf();
            
            HtmlResource htmlResource = new HtmlResource("<html><body>hello</body></html>");
            htmlResource.ResourceName = "htmlString";
            HtmlInput html = new HtmlInput(htmlResource);

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
                pass = base.getVerify(InputSampleType, response, pdf);
            }
            Assert.IsTrue(pass, result);

        }

        [TestMethod]
        public void HtmlStringParameters_pdfoutput()
        {
            Name = "HtmlStringParameters";
            Pdf pdf = new Pdf();

            HtmlResource htmlResource = new HtmlResource("<html><body>hello</body></html>");
            htmlResource.ResourceName = "htmlString";
            HtmlInput html = new HtmlInput(htmlResource, null, PageSize.Letter, PageOrientation.Portrait, 10f);

            pdf.Inputs.Add(html);

            PdfResponse response = pdf.Process();

            bool pass = false;
            if (response.IsSuccessful)
            {
                pass = base.getVerify(InputSampleType, response, pdf);
            }
            Assert.IsTrue(pass);

        }

        [TestMethod]
        public void HtmlResource_pdfoutput()
        {
            Name = "HtmlResource";
            Pdf pdf = new Pdf();

            string htmlString;
            using (var reader = new StreamReader(File.OpenRead(base.GetResourcePath("html.html")), Encoding.UTF8))
            {
                htmlString = reader.ReadToEnd();
            }
            HtmlResource file = new HtmlResource(htmlString, "html.html");

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
                pass = base.getVerify(InputSampleType, response, pdf);
            }
            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void HtmlResourcePageSize_pdfoutput()
        {
            Name = "HtmlResourcePageSize";
            Pdf pdf = new Pdf();

            string htmlString;
            using (var reader = new StreamReader(File.OpenRead(base.GetResourcePath("html.html")), Encoding.UTF8))
            {
                htmlString = reader.ReadToEnd();
            }
            HtmlResource file = new HtmlResource(htmlString, "html.html");

            HtmlInput html = new HtmlInput(file);
            html.PageSize = PageSize.Postcard;

            pdf.Inputs.Add(html);

            PdfResponse response = pdf.Process();

            bool pass = false;
            if (response.IsSuccessful)
            {
                pass = base.getVerify(InputSampleType, response, pdf);
            }
            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void HtmlResourcePageHeightPageWidth_pdfoutput()
        {
            Name = "HtmlResourcePageHeightPageWidth";
            Pdf pdf = new Pdf();

            string htmlString;
            using (var reader = new StreamReader(File.OpenRead(base.GetResourcePath("html.html")), Encoding.UTF8))
            {
                htmlString = reader.ReadToEnd();
            }
            HtmlResource file = new HtmlResource(htmlString, "html.html");

            HtmlInput html = new HtmlInput(file);
            html.PageHeight = 400;
            html.PageWidth = 300;

            pdf.Inputs.Add(html);

            PdfResponse response = pdf.Process();

            bool pass = false;
            if (response.IsSuccessful)
            {
                pass = base.getVerify(InputSampleType, response, pdf);
            }
            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void HtmlResourceParameters_pdfoutput()
        {
            Name = "HtmlResourceParameters";
            Pdf pdf = new Pdf();

            string htmlString;
            using (var reader = new StreamReader(File.OpenRead(base.GetResourcePath("html.html")), Encoding.UTF8))
            {
                htmlString = reader.ReadToEnd();
            }
            HtmlResource file = new HtmlResource(htmlString, "html.html");

            HtmlInput html = new HtmlInput(file, null, PageSize.A3, PageOrientation.Landscape, 30f);

            pdf.Inputs.Add(html);

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
