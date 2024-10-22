using DynamicPDF.Api.Elements;
using DynamicPDF.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using DynamicPDF.Api.Imaging;
using System.IO;

namespace DynamicPDFApiTestForNET.TestCases.FunctionalityTest.PdfImageEndPoint
{
    [TestClass]
    public class BmpImagingSamples : TestCase
    {
        public override InputSampleType InputSampleType
        {
            get
            {
                return InputSampleType.Imaging;
            }
        }
        public PdfImage getPdfImage(string inputFile, BmpColorFormat colorFormat = null)
        {
            PdfImage pdfImage = new PdfImage(new PdfResource(inputFile));
            BmpImageFormat bmpImageFormat = new BmpImageFormat();
            pdfImage.ImageFormat = bmpImageFormat;

            if(colorFormat!=null)
                bmpImageFormat.ColorFormat = colorFormat;

            return pdfImage;
        }

        [TestMethod]
        public void TestBmpImageFormat()
        {
            Name = "BmpImageFormat";

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentSinglePage.pdf"));
            
            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"BmpImageFormat{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }
                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestBmpImageFormat_PageCount()
        {
            Name = "BmpImageFormat";

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentA.pdf"));
            pdfImage.PageCount = 2;

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"BmpImageFormat_WithPageCount_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestBmpImageFormat_FixedSize_InPoint()
        {
            Name = "BmpImageFormat";

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentSinglePage.pdf"));
            FixedImageSize fixedImageSize = new FixedImageSize();
            fixedImageSize.Unit = ImageSizeUnit.Point;
            fixedImageSize.Width = 500;
            fixedImageSize.Height = 500;
            pdfImage.ImageSize = fixedImageSize;

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"BmpImageFormat_Fixed_Point_Size_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }
                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestBmpImageFormat_FixedSize_InInch()
        {
            Name = "BmpImageFormat";

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentSinglePage.pdf"));
            FixedImageSize fixedImageSize = new FixedImageSize();
            fixedImageSize.Unit = ImageSizeUnit.Inch;
            fixedImageSize.Width = 5;
            fixedImageSize.Height = 5;
            pdfImage.ImageSize = fixedImageSize;

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"BmpImageFormat_Fixed_Inch_Size_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestBmpImageFormat_FixedSize_InMillimeter()
        {
            Name = "BmpImageFormat";

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentSinglePage.pdf"));
            FixedImageSize fixedImageSize = new FixedImageSize();
            fixedImageSize.Unit = ImageSizeUnit.Millimeter;
            fixedImageSize.Width = 200;
            fixedImageSize.Height = 200;
            pdfImage.ImageSize = fixedImageSize;

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"BmpImageFormat_Fixed_Millimeter_Size_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestBmpImageFormat_MaxSize_InPoint()
        {
            Name = "BmpImageFormat";

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentSinglePage.pdf"));
            MaxImageSize maxImageSize = new MaxImageSize();
            maxImageSize.Unit = ImageSizeUnit.Point;
            maxImageSize.MaxWidth = 500;
            maxImageSize.MaxHeight = 500;
            pdfImage.ImageSize = maxImageSize;

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"BmpImageFormat_Max_Point_Size_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestBmpImageFormat_MaxSize_InInch()
        {
            Name = "BmpImageFormat";

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentSinglePage.pdf"));
            MaxImageSize maxImageSize = new MaxImageSize();
            maxImageSize.Unit = ImageSizeUnit.Inch;
            maxImageSize.MaxWidth = 7;
            maxImageSize.MaxHeight = 7;
            pdfImage.ImageSize = maxImageSize;

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"BmpImageFormat_Max_Inch_Size_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestBmpImageFormat_MaxSize_InMillimeter()
        {
            Name = "BmpImageFormat";

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentSinglePage.pdf"));
            MaxImageSize maxImageSize = new MaxImageSize();
            maxImageSize.Unit = ImageSizeUnit.Millimeter;
            maxImageSize.MaxWidth = 400;
            maxImageSize.MaxHeight = 400;
            pdfImage.ImageSize = maxImageSize;

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"BmpImageFormat_Max_Millimeter_Size_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestBmpImageFormat_Dpi_ImageSize()
        {
            Name = "BmpImageFormat";

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentSinglePage.pdf"));
            DpiImageSize dpiImageSize = new DpiImageSize();
            dpiImageSize.HorizontalDpi = 155;
            dpiImageSize.VerticalDpi = 155;
            pdfImage.ImageSize = dpiImageSize;

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"BmpImageFormat_Dpi_ImageSize_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestBmpImageFormat_Percentage_ImageSize()
        {
            Name = "BmpImageFormat";

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentSinglePage.pdf"));
            PercentageImageSize percentageImageSize = new PercentageImageSize();
            percentageImageSize.VerticalPercentage = 50;
            percentageImageSize.HorizontalPercentage = 50;
            pdfImage.ImageSize = percentageImageSize;
            
            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"BmpImageFormat_Percentage_ImageSize_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }
                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestBmpImageFormat_Floyd_MonoChrome()
        {
            Name = "BmpImageFormat";

            BmpMonochromeColorFormat bmpMonochromeColorFormat = new BmpMonochromeColorFormat();
            bmpMonochromeColorFormat.DitheringAlgorithm = DitheringAlgorithm.FloydSteinberg;
            bmpMonochromeColorFormat.DitheringPercent = 50;

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentSinglePage.pdf"), bmpMonochromeColorFormat);

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"BmpImageFormat_Floyd_MonoChrome_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestBmpImageFormat_Bayer_MonoChrome()
        {
            Name = "BmpImageFormat";

            BmpMonochromeColorFormat bmpMonochromeColorFormat = new BmpMonochromeColorFormat();
            bmpMonochromeColorFormat.DitheringAlgorithm = DitheringAlgorithm.Bayer;
            bmpMonochromeColorFormat.DitheringPercent = 50;

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentSinglePage.pdf"), bmpMonochromeColorFormat);

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"BmpImageFormat_Bayer_MonoChrome_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestBmpImageFormat_RgbColorFormat()
        {
            Name = "BmpImageFormat";

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentSinglePage.pdf"), new BmpColorFormat(ColorFormatType.Rgb));

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"BmpImageFormat_Rgb_ColorFormat_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestBmpImageFormat_RgbaColorFormat()
        {
            Name = "BmpImageFormat";

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentSinglePage.pdf"), new BmpColorFormat(ColorFormatType.RgbA));

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"BmpImageFormat_Rgba_ColorFormat_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestBmpImageFormat_GrayscaleColorFormat()
        {
            Name = "BmpImageFormat";

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentSinglePage.pdf"), new BmpColorFormat(ColorFormatType.Grayscale));

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"BmpImageFormat_Grayscale_ColorFormat_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }
                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestBmpImageFormat_MonochromeColorFormat()
        {
            Name = "BmpImageFormat";

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentSinglePage.pdf"), new BmpColorFormat(ColorFormatType.Monochrome));

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"BmpImageFormat_Monochrome_ColorFormat_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }
                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestBmpImageFormat_IndexedColorFormat()
        {
            Name = "BmpImageFormat";

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentSinglePage.pdf"), new BmpColorFormat(ColorFormatType.Indexed));

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"BmpImageFormat_Indexed_ColorFormat_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestBmpImageFormat_BlackThreshold()
        {
            Name = "BmpImageFormat";

            BmpMonochromeColorFormat bmpMonochromeColorFormat = new BmpMonochromeColorFormat();
            bmpMonochromeColorFormat.BlackThreshold = 200;

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("Gray.pdf"), bmpMonochromeColorFormat);

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"BmpImageFormat_BlackThreshold_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
    }
}
