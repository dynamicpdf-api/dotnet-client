using DynamicPDF.Api;
using DynamicPDF.Api.Elements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace DynamicPDFApiTestForNET.TestCases.FunctionalityTest.PDFEndpoint
{
    [TestClass]

    public class OutlineSamples : TestCase
    {
        public override InputSampleType InputSampleType
        {
            get
            {
                return InputSampleType.Outline;
            }
        }
        public Pdf pdfObj()
        {
            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            return pdf;
        }
        [TestMethod]
        public void PdfInputUsingFilePath_Outline_GotoAction_Pdfoutput()
        {
            Name = "OutlineGoToAction";
            Pdf pdf = pdfObj();

            PdfResource resource = new PdfResource(base.GetResourcePath("EmptyPages.pdf"), "EmptyPages.pdf");
            PdfInput input = new PdfInput(resource);
            pdf.Inputs.Add(input);

            PdfResource resource1 = new PdfResource(base.GetResourcePath("SinglePage.pdf"), "SinglePage.pdf");
            PdfInput input1 = new PdfInput(resource1);
            pdf.Inputs.Add(input1);

            Outline outline = pdf.Outlines.Add("OutlineA");
            outline.Color = RgbColor.Red;
            outline.Style = OutlineStyle.Bold;
            outline.Expanded = true;

            GoToAction linkTo = new GoToAction(input1);
            linkTo.PageOffset = -5;
            linkTo.PageZoom = PageZoom.FitPage;

            outline.Action = linkTo;

            PdfResponse response = pdf.Process();

            bool pass = false;

            if (response.IsSuccessful)
            {
                pass = base.getVerify(InputSampleType, response, pdf);
            }
            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void PdfInputUsingFilePath_Outline_urlaction_Pdfoutput()
        {
            Name = "OutlineUrlAction";
            Pdf pdf = pdfObj();

            PdfResource resource = new PdfResource(base.GetResourcePath("EmptyPages.pdf"), "EmptyPages.pdf");
            PdfInput input = new PdfInput(resource);

            pdf.Inputs.Add(input);

            Outline outline3 = pdf.Outlines.Add("OutlineA");
            outline3.Expanded = true;
            outline3.Style = OutlineStyle.Bold;
            outline3.Color = RgbColor.Red;

            UrlAction action3 = new UrlAction("https://www.dynamicpdf.com");
            outline3.Action = action3;

            PdfResponse response = pdf.Process();

            bool pass = false;

            if (response.IsSuccessful)
            {
                pass = base.getVerify(InputSampleType, response, pdf);
            }
            Assert.IsTrue(pass);

        }

        [TestMethod]
        public void AddOutlinesForNewPdf()
        {
            Name = "OutlinesForNewPdf";
            Pdf pdf = pdfObj();

            PageInput pageInput = pdf.AddPage();
            TextElement element = new TextElement("Hello World 1", ElementPlacement.TopCenter);
            pageInput.Elements.Add(element);

            PageInput pageInput1 = pdf.AddPage();
            TextElement element1 = new TextElement("Hello World 2", ElementPlacement.TopCenter);
            pageInput1.Elements.Add(element1);

            PageInput pageInput2 = pdf.AddPage();
            TextElement element2 = new TextElement("Hello World 3", ElementPlacement.TopCenter);
            pageInput2.Elements.Add(element2);

            Outline rootOutline = pdf.Outlines.Add("Root Outline");

            rootOutline.Children.Add("Page 1", pageInput);
            rootOutline.Children.Add("Page 2", pageInput1);
            rootOutline.Children.Add("Page 3", pageInput2);


            PdfResponse response = pdf.Process();

            bool pass = false;

            if (response.IsSuccessful)
            {
                pass = base.getVerify(InputSampleType, response, pdf);
            }
            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void AddOutlinesForExsistingPdf()
        {
            Name = "OutlinesForExsistingPdf";
            Pdf pdf = pdfObj();

            PdfResource resource1 = new PdfResource(base.GetResourcePath("DocumentA100.pdf"), "DocumentA100.pdf");
            PdfInput input1 = pdf.AddPdf(resource1);
            input1.Id = "document2";

            PdfResource resource2 = new PdfResource(base.GetResourcePath("InvoiceTemplate.pdf"), "InvoiceTemplate.pdf");
            PdfInput input2 = pdf.AddPdf(resource2);
            input2.Id = "invoice";

            Outline rootOutline = pdf.Outlines.Add("Root Outline");
            rootOutline.Expanded = true;

            rootOutline.Children.Add("DocumentA 100", input1, 0, PageZoom.FitPage);
            rootOutline.Children.Add("Invoice", input2);


            PdfResponse response = pdf.Process();

            bool pass = false;

            if (response.IsSuccessful)
            {
                pass = base.getVerify(InputSampleType, response, pdf);
            }
            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void MergeExsistingOutlinesWithRootoutline()
        {
            Name = "ImportOutlines";
            Pdf pdf = pdfObj();

            PdfResource resource = new PdfResource(base.GetResourcePath("AllPageElements.pdf"), "AllPageElements.pdf");
            PdfInput input = pdf.AddPdf(resource);
            input.Id = "AllPageElements";
            pdf.Inputs.Add(input);

            PdfResource resource1 = new PdfResource(base.GetResourcePath("PdfOutlineInput.pdf"), "PdfOutlineInput.pdf");
            PdfInput input1 = pdf.AddPdf(resource1);
            input1.Id = "outlineDoc1";
            pdf.Inputs.Add(input1);

            Outline rootOutline = pdf.Outlines.Add("Imported Outline");
            rootOutline.Expanded = true;

            rootOutline.Children.AddPdfOutlines(input);
            rootOutline.Children.AddPdfOutlines(input1);

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
