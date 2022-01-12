using DynamicPDF.Api;
using DynamicPDF.Api.Elements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace DynamicPDFApiTestForNET.TestCases.FunctionalityTest.PDFEndpoint
{
    [TestClass]
    public class TemplateBarcodeSamples : TestCase
    {
        public override InputSampleType InputSampleType
        {
            get
            {
                return InputSampleType.TemplateBarcode;
            }
        }

        [TestMethod]
        public void PageInputAztecBarcodeElement_Pdfoutput()
        {
            Name = "PageInputAztecBarcodeElement";

            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            PageInput input = new PageInput();
            pdf.Inputs.Add(input);

            Template template = new Template("Temp1");

            AztecBarcodeElement element = new AztecBarcodeElement("Hello World", ElementPlacement.BottomRight);
            element.SymbolSize = AztecSymbolSize.R105xC105;
            element.XDimension = 3;
            element.Color = RgbColor.Red;
            element.AztecErrorCorrection = 30;
            element.ProcessTilde = true;
            element.ReaderInitializationSymbol = true;
            element.Value = "test123";
            element.XOffset = -100;
            element.YOffset = -100;
            template.Elements.Add(element);

            input.Template = template;

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
        public void FilePathDataMatrixBarcodeElement_Pdfoutput()
        {
            Name = "FilePathDataMatrixBarcodeElement";

            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            PdfResource resource = new PdfResource(base.GetResourcePath(@"Emptypages.pdf"));
            PdfInput input = new PdfInput(resource);
            pdf.Inputs.Add(input);

            Template template = new Template("Temp1");

            DataMatrixBarcodeElement element = new DataMatrixBarcodeElement("Hello World", ElementPlacement.TopRight, 0, 0);
            element.Placement = ElementPlacement.TopLeft;
            element.XOffset = 50;
            element.YOffset = 50;
            element.XDimension = 3;
            element.ProcessTilde = true;
            element.Color = RgbColor.Yellow;
            template.Elements.Add(element);
            input.Template = template;

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
        public void CloudRootPdf417BarcodeElement_Pdfoutput()
        {
            Name = "CloudRootPdf417BarcodeElement";

            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            PdfInput input = new PdfInput("Emptypages.pdf");
            pdf.Inputs.Add(input);

            Template template = new Template("Temp1");

            Pdf417BarcodeElement element = new Pdf417BarcodeElement("Hello World", ElementPlacement.TopLeft, 2);
            element.Color = RgbColor.Red;
            element.Compaction = Compaction.Text;
            element.CompactPdf417 = true;
            element.ErrorCorrection = ErrorCorrection.Level6;
            element.EvenPages = true;
            element.Placement = ElementPlacement.TopRight;
            element.ProcessTilde = true;
            element.XDimension = 4;
            element.YDimension = 5;
            element.XOffset = -50;
            element.YOffset = 50;

            template.Elements.Add(element);
            input.Template = template;

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
        public void StreamQrcodeBarcodeElement_PdfOutput()
        {
            Name = "StreamQrcodeBarcodeElement";

            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            MemoryStream memory = new MemoryStream(File.ReadAllBytes(base.GetResourcePath(@"Emptypages.pdf")));
            PdfResource resource = new PdfResource(memory);

            PdfInput input = new PdfInput(resource);
            pdf.Inputs.Add(input);

            Template template = new Template("Temp1");

            QrCodeElement element = new QrCodeElement("Hello World", ElementPlacement.TopCenter, 50, 50);
            element.Color = RgbColor.Orange;
            element.Version = 20;
            element.Fnc1 = QrCodeFnc1.Gs1;
            template.Elements.Add(element);
            input.Template = template;

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
        public void BytesCode128Barcode_PdfOutput()
        {
            Name = "BytesCode128Barcode";

            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            PdfResource resource = new PdfResource(File.ReadAllBytes(base.GetResourcePath(@"Emptypages.pdf")));
            PdfInput input = new PdfInput(resource);

            pdf.Inputs.Add(input);
            Template template = new Template("Temp1");
            Code128BarcodeElement element = new Code128BarcodeElement("Code 128 ~ABarcode.", ElementPlacement.TopCenter, 50);
            element.Height = 60;
            element.XOffset = 100;
            element.YOffset = 100;
            element.Color = RgbColor.Red;
            element.XDimension = 2;
            element.TextColor = RgbColor.Blue;
            element.Font = Font.Courier;
            element.FontSize = 15;
            element.ProcessTilde = true;
            element.UccEan128 = true;
            template.Elements.Add(element);
            input.Template = template;
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
        public void PageInputCode39Barcode_PdfOutput()
        {
            Name = "PageInputCode39Barcode";

            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            PageInput pageInput = new PageInput();
            Code39BarcodeElement element = new Code39BarcodeElement("CODE 39", ElementPlacement.TopCenter, 100, 50, 50);
            element.XDimension = 1.5f;
            element.ShowText = true;
            element.TextColor = RgbColor.Red;
            element.Font = Font.CourierBold;
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
        public void BytesCode25Barcode_PdfOutput()
        {
            Name = "BytesCode25Barcode";

            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            PdfResource resource = new PdfResource(File.ReadAllBytes(base.GetResourcePath(@"Emptypages.pdf")));
            PdfInput input = new PdfInput(resource);

            pdf.Inputs.Add(input);
            Template template = new Template("Temp1");
            Code25BarcodeElement element = new Code25BarcodeElement("1234567890", ElementPlacement.TopCenter, 50);
            element.Height = 80;
            element.XOffset = 100;
            element.YOffset = 100;
            element.Color = RgbColor.Red;
            element.XDimension = 1.5f;
            element.ShowText = true;
            element.OddPages = true;
            template.Elements.Add(element);
            input.Template = template;
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
        public void PageInputCode93Barcode_PdfOutput()
        {
            Name = "PageInputCode93Barcode";

            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            PageInput pageInput = new PageInput();
            Code93BarcodeElement element = new Code93BarcodeElement("CODE 93", ElementPlacement.TopCenter, 50);
            element.Height = 60;
            element.XOffset = 100;
            element.YOffset = 100;
            element.Color = new WebColor("#FF0000");
            element.XDimension = 2;
            element.ShowText = false;
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
        public void StreamCode11Barcode_PdfOutput()
        {
            Name = "StreamCode11Barcode";

            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            MemoryStream memory = new MemoryStream(File.ReadAllBytes(base.GetResourcePath(@"Emptypages.pdf")));
            PdfResource resource = new PdfResource(memory);
            PdfInput input = new PdfInput(resource);

            pdf.Inputs.Add(input);
            Template template = new Template("Temp1");
            Code11BarcodeElement element = new Code11BarcodeElement("12345678", ElementPlacement.BottomLeft, 100, 10, 10);
            element.XDimension = 3;
            element.YOffset = -50;
            element.TextColor = RgbColor.Red;
            element.Font = Font.HelveticaOblique;
            element.FontSize = 20;
            element.EvenPages = true;
            template.Elements.Add(element);
            input.Template = template;
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
        public void CloudSubFolderGs1DataBarBarcode_PdfOutput()
        {
            Name = "CloudSubFolderGs1DataBarBarcode";

            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            PdfInput input = new PdfInput("TFWResources/Emptypages.pdf");

            pdf.Inputs.Add(input);
            Template template = new Template("Temp1");
            Gs1DataBarBarcodeElement element = new Gs1DataBarBarcodeElement("12345678", ElementPlacement.TopCenter, 50, Gs1DataBarType.Omnidirectional);
            element.Placement = ElementPlacement.BottomCenter;
            element.XOffset = 0;
            element.YOffset = -100;
            element.Color = new WebColor("#02F1A5");
            element.XDimension = 1.4f;
            template.Elements.Add(element);
            input.Template = template;
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
        public void PageInputStackedGS1DataBarBarcode_PdfOutput()
        {
            Name = "PageInputStackedGS1DataBarBarcode";

            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            PageInput pageInput = new PageInput();
            StackedGs1DataBarBarcodeElement element = new StackedGs1DataBarBarcodeElement("12345678", ElementPlacement.TopCenter, StackedGs1DataBarType.Stacked, 25);
            element.RowHeight = 60;
            element.XOffset = 10;
            element.YOffset = 20;
            element.Color = RgbColor.Maroon;
            element.XDimension = 1;
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
        public void PageInputWithTemplateIata25Barcode_PdfOutput()
        {
            Name = "PageInputWithTemplateIata25Barcode";

            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            PageInput pageInput = new PageInput();

            Template template = new Template("Temp1");
            Iata25BarcodeElement element = new Iata25BarcodeElement("12345678", ElementPlacement.TopCenter, 50, 100, 0);
            element.Height = 60;
            element.Color = RgbColor.Yellow;
            element.XDimension = 3;
            element.TextColor = RgbColor.Pink;
            element.IncludeCheckDigit = true;
            template.Elements.Add(element);

            pageInput.Template = template;

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
        public void FilePathMsiBarcode_PdfOutput()
        {
            Name = "FilePathMsiBarcode";

            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            PdfResource resource = new PdfResource(base.GetResourcePath(@"Emptypages.pdf"));
            PdfInput input = new PdfInput(resource);

            pdf.Inputs.Add(input);
            Template template = new Template("Temp1");
            MsiBarcodeElement element = new MsiBarcodeElement("1234567890", ElementPlacement.TopCenter, 50);
            element.Height = 70;
            element.XOffset = 20;
            element.YOffset = 20;
            element.Color = RgbColor.Violet;
            element.XDimension = 2;
            element.ShowText = true;
            element.AppendCheckDigit = MsiBarcodeCheckDigitMode.Mod1010;
            element.EvenPages = true;
            element.OddPages = true;
            template.Elements.Add(element);
            input.Template = template;
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
