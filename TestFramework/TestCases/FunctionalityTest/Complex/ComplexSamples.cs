using DynamicPDF.Api;
using DynamicPDF.Api.Elements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace DynamicPDFApiTestForNET.TestCases.FunctionalityTest.Complex
{
    [TestClass]
    public class ComplexSamples : TestCase
    {
        public override InputSampleType InputSampleType
        {
            get
            {
                return InputSampleType.Complex;
            }
        }

        [TestMethod]
        public void PdfInputPageInput_PageAndPdf_PdfOutput()
        {
            Name = "PageAndPdf";

            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            PageInput pageInput = new PageInput();
            TextElement element = new TextElement("First Page", ElementPlacement.TopLeft);

            pageInput.Elements.Add(element);
            pdf.Inputs.Add(pageInput);

            PdfResource resource = new PdfResource(base.GetResourcePath("DocumentA100.pdf"));
            PdfInput pdfInput = new PdfInput(resource);
            pdf.Inputs.Add(pdfInput);

            PdfResponse response = pdf.Process();

            bool pass = false;

            if (response.IsSuccessful)
            {
                File.WriteAllBytes(base.GetOutputFilePath("Output.pdf", InputSampleType), response.Content);

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
        public void PageInput_SamePageInput_PdfOutput()
        {
            Name = "SamePageInput";

            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            PageInput pageInput = new PageInput();
            TextElement element = new TextElement("Hello World", ElementPlacement.TopLeft);

            pageInput.Elements.Add(element);
            pdf.Inputs.Add(pageInput);
            pdf.Inputs.Add(pageInput);
            pdf.Inputs.Add(pageInput);

            PdfResponse response = pdf.Process();

            bool pass = false;

            if (response.IsSuccessful)
            {
                File.WriteAllBytes(base.GetOutputFilePath("Output.pdf", InputSampleType), response.Content);

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
        public void PageInput_SamePageInputWithImage_PdfOutput()
        {
            Name = "SamePageInputWithImage";

            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            PageInput pageInput = new PageInput();
            ImageResource imageResource = new ImageResource(base.GetResourcePath("Northwind Logo.gif"));
            ImageElement imageElement = new ImageElement(imageResource, ElementPlacement.TopLeft);

            pageInput.Elements.Add(imageElement);
            pdf.Inputs.Add(pageInput);
            pdf.Inputs.Add(pageInput);

            PdfResponse response = pdf.Process();

            bool pass = false;

            if (response.IsSuccessful)
            {
                File.WriteAllBytes(base.GetOutputFilePath("Output.pdf", InputSampleType), response.Content);

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
        public void PdfInput_MergeSamePdfInput_PdfOutput()
        {
            Name = "MergeSamePdfInput";

            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            PdfResource resource = new PdfResource(base.GetResourcePath("DocumentA100.pdf"));
            PdfInput pdfInput = new PdfInput(resource);
            pdf.Inputs.Add(pdfInput);
            pdf.Inputs.Add(pdfInput);

            PdfResponse response = pdf.Process();

            bool pass = false;

            if (response.IsSuccessful)
            {
                File.WriteAllBytes(base.GetOutputFilePath("Output.pdf", InputSampleType), response.Content);

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
        public void PdfInputPageInput_MergeSamePdfAndAppendPage_PdfOutput()
        {
            Name = "MergeSamePdfAndAppendPage";

            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            PageInput pageInput = new PageInput();
            TextElement element = new TextElement("First Page", ElementPlacement.TopLeft);
            element.Color = RgbColor.Red;
            element.Font = Font.CourierBold;
            element.FontSize = 20;
            pageInput.Elements.Add(element);
            pdf.Inputs.Add(pageInput);

            PdfResource resource = new PdfResource(base.GetResourcePath("DocumentA100.pdf"));
            PdfInput pdfInput = new PdfInput(resource);
            pdf.Inputs.Add(pdfInput);

            PdfResource resource1 = new PdfResource(base.GetResourcePath("DocumentA100.pdf"));
            PdfInput pdfInput1 = new PdfInput(resource1);
            pdf.Inputs.Add(pdfInput1);

            PdfInput pdfInput2 = new PdfInput("DocumentA100.pdf");
            pdf.Inputs.Add(pdfInput2);

            PageInput pageInput1 = new PageInput();
            TextElement element1 = new TextElement("Last Page", ElementPlacement.TopLeft);
            element1.Color = RgbColor.Blue;
            element1.Font = Font.TimesItalic;
            element1.FontSize = 20;
            pageInput1.Elements.Add(element1);
            pdf.Inputs.Add(pageInput1);


            PdfResponse response = pdf.Process();

            bool pass = false;

            if (response.IsSuccessful)
            {
                File.WriteAllBytes(base.GetOutputFilePath("Output.pdf", InputSampleType), response.Content);

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
        public void ImageInput_AddSameImageInput_PdfOutput()
        {
            Name = "AddSameImageInput";

            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            ImageResource resource = new ImageResource(base.GetResourcePath("Northwind Logo.gif"));
            ImageInput imageInput = new ImageInput(resource);
            pdf.Inputs.Add(imageInput);

            pdf.Inputs.Add(imageInput);

            PdfResponse response = pdf.Process();

            bool pass = false;

            if (response.IsSuccessful)
            {
                File.WriteAllBytes(base.GetOutputFilePath("Output.pdf", InputSampleType), response.Content);

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
        public void ImageInputPageInputPdfInput_AddSameImages_PdfOutput()
        {
            Name = "AddSameImages";

            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            PageInput pageInput = new PageInput();
            TextElement element = new TextElement("Add Same Image Resource", ElementPlacement.TopLeft);
            pageInput.Elements.Add(element);
            pdf.Inputs.Add(pageInput);

            ImageResource resource = new ImageResource(base.GetResourcePath("Northwind Logo.gif"));
            ImageInput imageInput = new ImageInput(resource);
            pdf.Inputs.Add(imageInput);

            ImageResource resource1 = new ImageResource(base.GetResourcePath("Northwind Logo.gif"));
            ImageInput imageInput1 = new ImageInput(resource1);
            imageInput1.TopMargin = 50;
            imageInput1.BottomMargin = 50;
            imageInput1.LeftMargin = 50;
            imageInput1.RightMargin = 50;
            pdf.Inputs.Add(imageInput1);

            ImageResource resource2 = new ImageResource(base.GetResourcePath("DPDFLogo.png"));
            ImageInput imageInput2 = new ImageInput(resource2);
            pdf.Inputs.Add(imageInput2);

            ImageInput imageInput3 = new ImageInput("TFWResources/fw9_18.tif");
            pdf.Inputs.Add(imageInput3);

            PdfResource resource3 = new PdfResource(base.GetResourcePath("DocumentA100.pdf"));
            PdfInput pdfInput = new PdfInput(resource3);
            ImageElement imageElement = new ImageElement(resource1, ElementPlacement.TopLeft);
            imageElement.XOffset = 25;
            imageElement.YOffset = 25;
            Template template = new Template("Temp1");
            template.Elements.Add(imageElement);
            pdfInput.Template = template;
            pdf.Inputs.Add(pdfInput);

            PdfResponse response = pdf.Process();

            bool pass = false;

            if (response.IsSuccessful)
            {
                File.WriteAllBytes(base.GetOutputFilePath("Output.pdf", InputSampleType), response.Content);

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
        public void DlexInputPageInput_AddSameDlexInput_PdfOutput()
        {
            Name = "AddSameDlexInput";

            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            ImageResource img = new ImageResource(base.GetResourcePath("Northwind Logo.gif"), "northwind logo.gif");
            pdf.Resources.Add(img);

            DlexResource dlex = new DlexResource(base.GetResourcePath("SimpleReportWithCoverPage.dlex"));
            LayoutDataResource layoutData = new LayoutDataResource(base.GetResourcePath("SimpleReportData.json"));
            DlexInput input = new DlexInput(dlex, layoutData);
            pdf.Inputs.Add(input);

            pdf.Inputs.Add(input);

            PdfResponse response = pdf.Process();

            bool pass = false;

            if (response.IsSuccessful)
            {
                File.WriteAllBytes(base.GetOutputFilePath("Output.pdf", InputSampleType), response.Content);

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
        public void DlexInputPageInput_AddSameDlex_PdfOutput()
        {
            Name = "AddSameDlex";

            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            PageInput pageInput = new PageInput();
            TextElement element = new TextElement("Hello World", ElementPlacement.TopLeft);
            element.FontSize = 20;
            pageInput.Elements.Add(element);
            pdf.Inputs.Add(pageInput);

            ImageResource img = new ImageResource(base.GetResourcePath("Northwind Logo.gif"), "northwind logo.gif");
            pdf.Resources.Add(img);

            DlexResource dlex = new DlexResource(base.GetResourcePath("SimpleReportWithCoverPage.dlex"));
            LayoutDataResource layoutData = new LayoutDataResource(base.GetResourcePath("SimpleReportData.json"));
            DlexInput input = new DlexInput(dlex, layoutData);
            pdf.Inputs.Add(input);

            DlexResource dlex1 = new DlexResource(base.GetResourcePath("SimpleReportWithCoverPage.dlex"));
            LayoutDataResource layoutData1 = new LayoutDataResource(base.GetResourcePath("SimpleReportData.json"));
            DlexInput input1 = new DlexInput(dlex1, layoutData1);
            pdf.Inputs.Add(input1);

            string jsonString = File.ReadAllText(base.GetResourcePath("SimpleReportData.json"));

            DlexInput input2 = new DlexInput("SimpleReportWithCoverPage.dlex", jsonString);
            pdf.Inputs.Add(input2);

            PdfResponse response = pdf.Process();

            bool pass = false;

            if (response.IsSuccessful)
            {
                File.WriteAllBytes(base.GetOutputFilePath("Output.pdf", InputSampleType), response.Content);

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
        public void PdfInputPageInput_ElemetsWithSecurity_PdfOutput()
        {
            Name = "ElemetsWithSecurity";

            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            Aes128Security aes128Security = new Aes128Security("", "owner");
            aes128Security.AllowPrint = false;
            pdf.Security = aes128Security;

            PageInput pageInput = new PageInput();
            RectangleElement rectangleElement = new RectangleElement(ElementPlacement.TopLeft, 100, 100);
            rectangleElement.BorderColor = RgbColor.Red;
            rectangleElement.FillColor = RgbColor.Green;
            rectangleElement.BorderWidth = 3;
            pageInput.Elements.Add(rectangleElement);

            TextElement textElement = new TextElement("Rectangle Element", ElementPlacement.TopCenter);
            pageInput.Elements.Add(textElement);
            pdf.Inputs.Add(pageInput);

            PdfResource resource = new PdfResource(base.GetResourcePath("DocumentA100.pdf"));
            PdfInput pdfInput = new PdfInput(resource);
            Template template = new Template("Temp1");

            LineElement lineElement = new LineElement(ElementPlacement.TopLeft, 600, 50);
            lineElement.Color = RgbColor.Blue;
            lineElement.XOffset = 10;
            lineElement.YOffset = 50;
            lineElement.Width = 2;
            lineElement.LineStyle = LineStyle.Dots;
            template.Elements.Add(lineElement);
            pdfInput.Template = template;
            pdf.Inputs.Add(pdfInput);

            PdfResponse response = pdf.Process();

            bool pass = false;

            if (response.IsSuccessful)
            {
                File.WriteAllBytes(base.GetOutputFilePath("Output.pdf", InputSampleType), response.Content);

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
        public void PageInputImageInput_DifferentElemnts_PdfOutput()
        {
            Name = "DifferentElemnts";

            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            PageInput pageInput = new PageInput();
            TextElement textElement = new TextElement("Hello World", ElementPlacement.TopLeft);
            textElement.FontSize = 40;
            pageInput.Elements.Add(textElement);

            PageNumberingElement pageNumbering = new PageNumberingElement("%%CP%% of %%TP%%", ElementPlacement.TopCenter);
            pageNumbering.YOffset = -20;
            pageInput.Elements.Add(pageNumbering);

            RectangleElement rectangleElement = new RectangleElement(ElementPlacement.TopLeft, 200, 150);
            rectangleElement.YOffset = 100;
            pageInput.Elements.Add(rectangleElement);

            LineElement lineElement = new LineElement(ElementPlacement.TopLeft, 400, 400);
            lineElement.YOffset = 400;
            lineElement.Color = RgbColor.Red;
            pageInput.Elements.Add(lineElement);

            Code128BarcodeElement code128BarcodeElement = new Code128BarcodeElement("Code 128 Barcode.", ElementPlacement.BottomLeft, 50);
            pageInput.Elements.Add(code128BarcodeElement);

            AztecBarcodeElement aztecBarcodeElement = new AztecBarcodeElement("Hello World", ElementPlacement.BottomRight);
            aztecBarcodeElement.Color = RgbColor.Blue;
            pageInput.Elements.Add(aztecBarcodeElement);
            pdf.Inputs.Add(pageInput);

            PageInput pageInput1 = new PageInput();
            ImageResource imageResource = new ImageResource(base.GetResourcePath("Northwind Logo.gif"));
            ImageElement imageElement = new ImageElement(imageResource, ElementPlacement.TopLeft);
            imageElement.ScaleX = 0.5f;
            imageElement.ScaleY = 0.5f;
            pageInput1.Elements.Add(imageElement);
            pageInput1.Elements.Add(pageNumbering);
            pdf.Inputs.Add(pageInput1);

            Template template = new Template("TempA");
            template.Elements.Add(pageNumbering);

            ImageInput imageInput = new ImageInput(imageResource);
            imageInput.TopMargin = 50;
            imageInput.Template = template;
            pdf.Inputs.Add(imageInput);

            PdfResponse response = pdf.Process();

            bool pass = false;

            if (response.IsSuccessful)
            {
                File.WriteAllBytes(base.GetOutputFilePath("Output.pdf", InputSampleType), response.Content);

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
        public void Inputs_DifferentInputs_PdfOutput()
        {
            Name = "DifferentInputs";

            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            PdfInput pdfInput = new PdfInput("DocumentA100.pdf");
            MergeOptions mergeOptions = new MergeOptions();
            pdfInput.MergeOptions = mergeOptions;
            pdf.Inputs.Add(pdfInput);

            PageInput pageInput = new PageInput();
            TextElement textElement = new TextElement("Hello World", ElementPlacement.TopLeft);
            textElement.FontSize = 40;
            pageInput.Elements.Add(textElement);
            pdf.Inputs.Add(pageInput);

            ImageResource img = new ImageResource(base.GetResourcePath("Northwind Logo.gif"), "northwind logo.gif");
            pdf.Resources.Add(img);
            string jsonString = File.ReadAllText(base.GetResourcePath("SimpleReportData.json"));
            DlexInput dlexInput = new DlexInput("SimpleReportWithCoverPage.dlex", jsonString);
            pdf.Inputs.Add(dlexInput);

            ImageInput imageInput = new ImageInput("Northwind Logo.gif");
            imageInput.TopMargin = 10;
            imageInput.LeftMargin = 10;
            imageInput.RightMargin = 10;
            imageInput.BottomMargin = 10;
            pdf.Inputs.Add(imageInput);

            PdfResponse response = pdf.Process();

            bool pass = false;

            if (response.IsSuccessful)
            {
                File.WriteAllBytes(base.GetOutputFilePath("Output.pdf", InputSampleType), response.Content);

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
        public void PageInputs_DifferentBarcode_PdfOutput()
        {
            Name = "DifferentBarcode";

            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            PageInput pageInput = new PageInput();
            TextElement textElement = new TextElement("1D Barcodes", ElementPlacement.TopCenter, 0, -20);
            pageInput.Elements.Add(textElement);

            TextElement element1 = new TextElement("Code128Barcode", ElementPlacement.TopLeft, 0, 20);
            pageInput.Elements.Add(element1);
            Code128BarcodeElement code128BarcodeElement = new Code128BarcodeElement("Code 128 Barcode.", ElementPlacement.TopLeft, 50);
            code128BarcodeElement.YOffset = 50;
            pageInput.Elements.Add(code128BarcodeElement);

            TextElement element2 = new TextElement("Code39Barcode", ElementPlacement.TopRight, 0, 20);
            pageInput.Elements.Add(element2);
            Code39BarcodeElement code39BarcodeElement = new Code39BarcodeElement("CODE 39", ElementPlacement.TopRight, 50);
            code39BarcodeElement.YOffset = 50;
            pageInput.Elements.Add(code39BarcodeElement);

            TextElement element3 = new TextElement("Code25Barcode", ElementPlacement.TopLeft, 0, 220);
            pageInput.Elements.Add(element3);
            Code25BarcodeElement code25BarcodeElement = new Code25BarcodeElement("1234567890", ElementPlacement.TopLeft, 50);
            code25BarcodeElement.YOffset = 250;
            pageInput.Elements.Add(code25BarcodeElement);

            TextElement element4 = new TextElement("Code93Barcode", ElementPlacement.TopCenter, 0, 220);
            pageInput.Elements.Add(element4);
            Code93BarcodeElement code93BarcodeElement = new Code93BarcodeElement("CODE 93", ElementPlacement.TopCenter, 50);
            code93BarcodeElement.YOffset = 250;
            pageInput.Elements.Add(code93BarcodeElement);

            TextElement element5 = new TextElement("Code11Barcode", ElementPlacement.TopRight, 0, 220);
            pageInput.Elements.Add(element5);
            Code11BarcodeElement code11BarcodeElement = new Code11BarcodeElement("12345678", ElementPlacement.TopRight, 50);
            code11BarcodeElement.YOffset = 250;
            pageInput.Elements.Add(code11BarcodeElement);

            TextElement element6 = new TextElement("Gs1DataBarBarcode", ElementPlacement.TopLeft, 0, 420);
            pageInput.Elements.Add(element6);
            Gs1DataBarBarcodeElement gs1DataBarBarcodeElement = new Gs1DataBarBarcodeElement("12345678", ElementPlacement.TopLeft, 50, Gs1DataBarType.Omnidirectional);
            gs1DataBarBarcodeElement.YOffset = 450;
            pageInput.Elements.Add(gs1DataBarBarcodeElement);

            TextElement element7 = new TextElement("StackedGs1DataBarBarcode", ElementPlacement.TopCenter, 0, 420);
            pageInput.Elements.Add(element7);
            StackedGs1DataBarBarcodeElement stackedGs1DataBarBarcodeElement = new StackedGs1DataBarBarcodeElement("12345678", ElementPlacement.TopCenter, StackedGs1DataBarType.Stacked, 25);
            stackedGs1DataBarBarcodeElement.YOffset = 450;
            pageInput.Elements.Add(stackedGs1DataBarBarcodeElement);

            TextElement element8 = new TextElement("Iata25Barcode", ElementPlacement.TopRight, 0, 420);
            pageInput.Elements.Add(element8);
            Iata25BarcodeElement iata25BarcodeElement = new Iata25BarcodeElement("12345678", ElementPlacement.TopRight, 50);
            iata25BarcodeElement.YOffset = 450;
            pageInput.Elements.Add(iata25BarcodeElement);

            TextElement element9 = new TextElement("MsiBarcode", ElementPlacement.TopCenter, 0, 620);
            pageInput.Elements.Add(element9);
            MsiBarcodeElement msiBarcodeElement = new MsiBarcodeElement("1234567890", ElementPlacement.TopCenter, 50);
            msiBarcodeElement.YOffset = 650;
            pageInput.Elements.Add(msiBarcodeElement);

            pdf.Inputs.Add(pageInput);

            PageInput pageInput1 = new PageInput();
            TextElement textElement1 = new TextElement("2D Barcodes", ElementPlacement.TopCenter, 0, -20);
            pageInput1.Elements.Add(textElement1);

            TextElement element10 = new TextElement("AztecBarcode", ElementPlacement.TopLeft, 0, 20);
            pageInput1.Elements.Add(element10);
            AztecBarcodeElement aztecBarcodeElement = new AztecBarcodeElement("Hello World", ElementPlacement.TopLeft);
            aztecBarcodeElement.YOffset = 50;
            pageInput1.Elements.Add(aztecBarcodeElement);

            TextElement element11 = new TextElement("DataMatrixBarcode", ElementPlacement.TopRight, 0, 20);
            pageInput1.Elements.Add(element11);
            DataMatrixBarcodeElement dataMatrixBarcodeElement = new DataMatrixBarcodeElement("Hello World", ElementPlacement.TopRight);
            dataMatrixBarcodeElement.YOffset = 50;
            pageInput1.Elements.Add(dataMatrixBarcodeElement);

            TextElement element12 = new TextElement("Pdf417Barcode", ElementPlacement.TopLeft, 0, 170);
            pageInput1.Elements.Add(element12);
            Pdf417BarcodeElement pdf417BarcodeElement = new Pdf417BarcodeElement("Hello World", ElementPlacement.TopLeft, 3);
            pdf417BarcodeElement.YOffset = 200;
            pageInput1.Elements.Add(pdf417BarcodeElement);

            TextElement element13 = new TextElement("QrCode", ElementPlacement.TopRight, 0, 170);
            pageInput1.Elements.Add(element13);
            QrCodeElement qrCodeElement = new QrCodeElement("Hello World", ElementPlacement.TopRight);
            qrCodeElement.YOffset = 200;
            pageInput1.Elements.Add(qrCodeElement);

            pdf.Inputs.Add(pageInput1);

            PdfResponse response = pdf.Process();

            bool pass = false;

            if (response.IsSuccessful)
            {
                File.WriteAllBytes(base.GetOutputFilePath("Output.pdf", InputSampleType), response.Content);

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
        public void PdfInputPageInput_ElementsWithOutlines_PdfOutput()
        {
            Name = "ElementsWithOutlines";

            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            PageInput pageInput = new PageInput();
            pageInput.Id = "page1";
            TextElement textElement = new TextElement("Page Input With Eelements", ElementPlacement.TopLeft);
            textElement.FontSize = 20;
            textElement.Color = new RgbColor(1, 0, 0);
            pageInput.Elements.Add(textElement);

            LineElement lineElement = new LineElement(ElementPlacement.TopLeft, 400, 50);
            lineElement.YOffset = 50;
            lineElement.Color = RgbColor.Yellow;
            pageInput.Elements.Add(lineElement);

            Template template = new Template("TemplatePage");
            PageNumberingElement pageNumberingElement = new PageNumberingElement("%%CP%% of %%TP%%", ElementPlacement.TopRight);
            pageNumberingElement.Font = Font.Courier;
            template.Elements.Add(pageNumberingElement);
            pageInput.Template = template;

            Outline outline = pdf.Outlines.Add("Outline Page Input");
            outline.Color = RgbColor.Red;
            outline.Style = OutlineStyle.Bold;
            outline.Expanded = true;

            GoToAction linkTo = new GoToAction(pageInput);
            linkTo.PageZoom = PageZoom.FitPage;
            outline.Action = linkTo;
            
            pdf.Inputs.Add(pageInput);

            PdfResource resource = new PdfResource(base.GetResourcePath("DocumentA100.pdf"));
            PdfInput pdfInput = new PdfInput(resource);
            pdfInput.Id = "pdf1";
            pdfInput.Template = template;

            Outline outline1 = pdf.Outlines.Add("Outline Pdf Input");
            outline1.Style = OutlineStyle.Italic;

            GoToAction linkTo1 = new GoToAction(pdfInput);
            linkTo1.PageZoom = PageZoom.FitHeight;

            outline1.Action = linkTo1;
            pdf.Inputs.Add(pdfInput);

            ImageResource img = new ImageResource(base.GetResourcePath("Northwind Logo.gif"), "northwind logo.gif");
            pdf.Resources.Add(img);
            DlexResource dlex = new DlexResource(base.GetResourcePath("SimpleReportWithCoverPage.dlex"));
            LayoutDataResource layoutData = new LayoutDataResource(base.GetResourcePath("SimpleReportData.json"));
            DlexInput dlexInput = new DlexInput(dlex, layoutData);
            dlexInput.Id = "dlex1";

            Outline outline2 = pdf.Outlines.Add("Outline Dlex Input");
            outline2.Style = OutlineStyle.Regular;
            outline2.Color = RgbColor.Green;

            GoToAction linkTo2 = new GoToAction(dlexInput);
            linkTo2.PageZoom = PageZoom.FitHeight;

            outline2.Action = linkTo2;
            pdf.Inputs.Add(dlexInput);

            ImageResource imageResource = new ImageResource(base.GetResourcePath("Northwind Logo.gif"));
            ImageInput imageInput = new ImageInput(imageResource);
            imageInput.TopMargin = 50;
            imageInput.LeftMargin = 50;
            imageInput.RightMargin = 50;
            imageInput.BottomMargin = 50;
            imageInput.Id = "img1";

            Outline outline3 = pdf.Outlines.Add("Outline Image Input");
            outline3.Style = OutlineStyle.Regular;
            outline3.Color = RgbColor.Blue;

            GoToAction linkTo3 = new GoToAction(imageInput);
            linkTo3.PageZoom = PageZoom.FitHeight;

            outline3.Action = linkTo3;
            pdf.Inputs.Add(imageInput);


            PdfResponse response = pdf.Process();

            bool pass = false;

            if (response.IsSuccessful)
            {
                File.WriteAllBytes(base.GetOutputFilePath("Output.pdf", InputSampleType), response.Content);

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
