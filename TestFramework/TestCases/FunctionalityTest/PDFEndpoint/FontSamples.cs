﻿using DynamicPDF.Api;
using DynamicPDF.Api.Elements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace DynamicPDFApiTestForNET.TestCases.FunctionalityTest.PDFEndpoint
{
    [TestClass]
    public class FontSamples : TestCase
    {
        public override InputSampleType InputSampleType
        {
            get
            {
                return InputSampleType.Font;
            }
        }

        [TestMethod]
        public void PageInput_CoreFont_Pdfoutput()
        {
            Name = "CoreFont";

            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            PageInput pageInput = new PageInput();
            TextElement element = new TextElement("Hello World", ElementPlacement.TopCenter);
            element.Font = Font.TimesBoldItalic;
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

        [TestMethod]
        public void PageInput_Font_Pdfoutput()
        {
            Name = "FontSample";
            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            Font font = Font.FromFile(base.GetResourcePath("DejaVuSans.ttf"));
            font.Embed = true;
            font.Subset = true;

            PageInput pageInput = new PageInput();

            TextElement element = new TextElement("Hello World", ElementPlacement.TopLeft);
            element.Font = font;
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
        [TestMethod]
        public void PageInput_GoogleFont_Pdfoutput()
        {
            Name = "GoogleFontSample";
            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            Font font = Font.Google("Roboto");
            font.Embed = true;
            font.Subset = true;

            PageInput pageInput = new PageInput();

            TextElement element = new TextElement("Hello World", ElementPlacement.TopLeft);
            element.Font = font;
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

        [TestMethod]
        public void PageInput_GoogleFontWeight_Pdfoutput()
        {
            Name = "GoogleFontSampleWeight";
            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            Font font = Font.Google("Bona Nova:bold");
            font.Embed = true;
            font.Subset = true;

            PageInput pageInput = new PageInput();

            TextElement element = new TextElement("Hello World", ElementPlacement.TopLeft);
            element.Font = font;
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

        [TestMethod]
        public void PageInput_GlobalFont_Pdfoutput()
        {
            Name = "GlobalFontSample";
            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            Font font = Font.Global("Paris Normal");
            font.Embed = true;
            font.Subset = true;

            PageInput pageInput = new PageInput();

            TextElement element = new TextElement("Hello World", ElementPlacement.TopLeft);
            element.Font = font;
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
