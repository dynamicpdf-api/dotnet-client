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
    public class PngImagingSamples : TestCase
    {
        public override InputSampleType InputSampleType
        {
            get
            {
                return InputSampleType.Imaging;
            }
        }
        public PdfImage getPdfImage(string inputFile, PngColorFormat colorFormat = null)
        {
            PdfImage pdfImage = new PdfImage(new PdfResource(inputFile));
            PngImageFormat pngImageFormat = new PngImageFormat();
            pdfImage.ImageFormat = pngImageFormat;

            if (colorFormat != null)
                pngImageFormat.ColorFormat = colorFormat;

            return pdfImage;
        }

        [TestMethod]
        public void TestPngImageFormat()
        {
            Name = "PngImageFormat";

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentSinglePage.pdf"));

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"PngImageFormat_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestPngImageFormat_PageCount()
        {
            Name = "PngImageFormat";

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentA.pdf"));
            pdfImage.PageCount = 2;

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"PngImageFormat_WithPageCount_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestPngImageFormat_FixedSize_InPoint()
        {
            Name = "PngImageFormat";

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
                    File.WriteAllBytes(base.GetOutputFilePath($"PngImageFormat_Fixed_Point_Size_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestPngImageFormat_FixedSize_InInch()
        {
            Name = "PngImageFormat";

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
                    File.WriteAllBytes(base.GetOutputFilePath($"PngImageFormat_Fixed_Inch_Size_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestPngImageFormat_FixedSize_InMillimeter()
        {
            Name = "PngImageFormat";

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
                    File.WriteAllBytes(base.GetOutputFilePath($"PngImageFormat_Fixed_Millimeter_Size_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestPngImageFormat_MaxSize_InPoint()
        {
            Name = "PngImageFormat";

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
                    File.WriteAllBytes(base.GetOutputFilePath($"PngImageFormat_Max_Point_Size_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestPngImageFormat_MaxSize_InInch()
        {
            Name = "PngImageFormat";

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
                    File.WriteAllBytes(base.GetOutputFilePath($"PngImageFormat_Max_Inch_Size_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestPngImageFormat_MaxSize_InMillimeter()
        {
            Name = "PngImageFormat";

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
                    File.WriteAllBytes(base.GetOutputFilePath($"PngImageFormat_Max_Millimeter_Size_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestPngImageFormat_Dpi_ImageSize()
        {
            Name = "PngImageFormat";

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
                    File.WriteAllBytes(base.GetOutputFilePath($"PngImageFormat_Dpi_ImageSize_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestPngImageFormat_Percentage_ImageSize()
        {
            Name = "PngImageFormat";

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
                    File.WriteAllBytes(base.GetOutputFilePath($"PngImageFormat_Percentage_ImageSize_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestPngImageFormat_Floyd_MonoChrome()
        {
            Name = "PngImageFormat";

            PngMonochromeColorFormat pngMonochromeColorFormat = new PngMonochromeColorFormat();
            pngMonochromeColorFormat.DitheringAlgorithm = DitheringAlgorithm.FloydSteinberg;
            pngMonochromeColorFormat.DitheringPercent = 50;

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentSinglePage.pdf"), pngMonochromeColorFormat);

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"PngImageFormat_Floyd_MonoChrome_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestPngImageFormat_Floyd_Indexed()
        {
            Name = "PngImageFormat";

            PngIndexedColorFormat pngIndexedColorFormat = new PngIndexedColorFormat();
            pngIndexedColorFormat.DitheringAlgorithm = DitheringAlgorithm.FloydSteinberg;
            pngIndexedColorFormat.DitheringPercent = 50;

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentSinglePage.pdf"), pngIndexedColorFormat);

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"PngImageFormat_Floyd_Indexed_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestPngImageFormat_Bayer_MonoChrome()
        {
            Name = "PngImageFormat";

            PngMonochromeColorFormat pngMonochromeColorFormat = new PngMonochromeColorFormat();
            pngMonochromeColorFormat.DitheringAlgorithm = DitheringAlgorithm.Bayer;
            pngMonochromeColorFormat.DitheringPercent = 50;

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentSinglePage.pdf"), pngMonochromeColorFormat);

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"PngImageFormat_Bayer_MonoChrome_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestPngImageFormat_Bayer_Indexed()
        {
            Name = "PngImageFormat";

            PngIndexedColorFormat pngIndexedColorFormat = new PngIndexedColorFormat();
            pngIndexedColorFormat.DitheringAlgorithm = DitheringAlgorithm.Bayer;
            pngIndexedColorFormat.DitheringPercent = 50;

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentSinglePage.pdf"), pngIndexedColorFormat);

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"PngImageFormat_Bayer_Indexed_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestPngImageFormat_Qa_Octree()
        {
            Name = "PngImageFormat";

            PngIndexedColorFormat pngIndexedColorFormat = new PngIndexedColorFormat();
            pngIndexedColorFormat.QuantizationAlgorithm = QuantizationAlgorithm.Octree;

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentSinglePage.pdf"), pngIndexedColorFormat);

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"PngImageFormat_Qa_Octree_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestPngImageFormat_Qa_WU()
        {
            Name = "PngImageFormat";

            PngIndexedColorFormat pngIndexedColorFormat = new PngIndexedColorFormat();
            pngIndexedColorFormat.QuantizationAlgorithm = QuantizationAlgorithm.WU;

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentSinglePage.pdf"), pngIndexedColorFormat);

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"PngImageFormat_Qa_WU_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestPngImageFormat_Qa_WebSafe()
        {
            Name = "PngImageFormat";

            PngIndexedColorFormat pngIndexedColorFormat = new PngIndexedColorFormat();
            pngIndexedColorFormat.QuantizationAlgorithm = QuantizationAlgorithm.WebSafe;

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentSinglePage.pdf"), pngIndexedColorFormat);

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"PngImageFormat_Qa_WebSafe_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestPngImageFormat_Qa_Werner()
        {
            Name = "PngImageFormat";

            PngIndexedColorFormat pngIndexedColorFormat = new PngIndexedColorFormat();
            pngIndexedColorFormat.QuantizationAlgorithm = QuantizationAlgorithm.Werner;

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentSinglePage.pdf"), pngIndexedColorFormat);

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"PngImageFormat_Qa_Werner_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestPngImageFormat_RgbColorFormat()
        {
            Name = "PngImageFormat";

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentSinglePage.pdf"), new PngColorFormat(ColorFormatType.Rgb));

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"PngImageFormat_Rgb_ColorFormat_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestPngImageFormat_RgbaColorFormat()
        {
            Name = "PngImageFormat";

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentSinglePage.pdf"), new PngColorFormat(ColorFormatType.RgbA));

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"PngImageFormat_Rgba_ColorFormat_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestPngImageFormat_GrayscaleColorFormat()
        {
            Name = "PngImageFormat";

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentSinglePage.pdf"), new PngColorFormat(ColorFormatType.Grayscale));

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"PngImageFormat_Grayscale_ColorFormat_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestPngImageFormat_MonochromeColorFormat()
        {
            Name = "PngImageFormat";

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentSinglePage.pdf"), new PngColorFormat(ColorFormatType.Monochrome));

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"PngImageFormat_Monochrome_ColorFormat_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestPngImageFormat_IndexedColorFormat()
        {
            Name = "PngImageFormat";

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentSinglePage.pdf"), new PngColorFormat(ColorFormatType.Indexed));

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"PngImageFormat_Indexed_ColorFormat_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestPngImageFormat_BlackThreshold()
        {
            Name = "PngImageFormat";

            PngMonochromeColorFormat pngMonochromeColorFormat = new PngMonochromeColorFormat();
            pngMonochromeColorFormat.BlackThreshold = 200;

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("Gray.pdf"), pngMonochromeColorFormat);

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"PngImageFormat_BlackThreshold_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
    }
}
