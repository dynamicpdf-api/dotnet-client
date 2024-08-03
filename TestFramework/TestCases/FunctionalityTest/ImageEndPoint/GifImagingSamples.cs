using DynamicPDF.Api.Elements;
using DynamicPDF.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using DynamicPDF.Api.Imaging;

namespace DynamicPDFApiTestForNET.TestCases.FunctionalityTest.PdfImageEndPoint
{
    [TestClass]
    public class GifImagingSamples : TestCase
    {
        public override InputSampleType InputSampleType
        {
            get
            {
                return InputSampleType.Imaging;
            }
        }

        [TestMethod]
        public void TestGifImageFormat()
        {
            Name = "GifImageFormat";

            PdfImage pdfImage = new PdfImage(new PdfResource(base.GetResourcePath("DocumentA.pdf")));
            GifImageFormat GifImageFormat = new GifImageFormat();
            pdfImage.ImageFormat = GifImageFormat;

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"GifImageFormat{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestGifImageFormat_PageCount()
        {
            Name = "GifImageFormat";

            PdfImage pdfImage = new PdfImage(new PdfResource(base.GetResourcePath("DocumentA.pdf")));
            pdfImage.PageCount = 2;
            GifImageFormat GifImageFormat = new GifImageFormat();
            pdfImage.ImageFormat = GifImageFormat;

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"GifImageFormat_WithPageCount_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestGifImageFormat_FixedSize_InPoint()
        {
            Name = "GifImageFormat";

            PdfImage pdfImage = new PdfImage(new PdfResource(base.GetResourcePath("DocumentA.pdf")));
            FixedImageSize fixedImageSize = new FixedImageSize();
            fixedImageSize.Unit = ImageSizeUnit.Point;
            fixedImageSize.Width = 500;
            fixedImageSize.Height = 500;
            pdfImage.ImageSize = fixedImageSize;

            GifImageFormat GifImageFormat = new GifImageFormat();
            pdfImage.ImageFormat = GifImageFormat;

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"GifImageFormat_Fixed_Point_Size_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestGifImageFormat_FixedSize_InInch()
        {
            Name = "GifImageFormat";

            PdfImage pdfImage = new PdfImage(new PdfResource(base.GetResourcePath("DocumentA.pdf")));
            FixedImageSize fixedImageSize = new FixedImageSize();
            fixedImageSize.Unit = ImageSizeUnit.Inch;
            fixedImageSize.Width = 5;
            fixedImageSize.Height = 5;
            pdfImage.ImageSize = fixedImageSize;

            GifImageFormat GifImageFormat = new GifImageFormat();
            pdfImage.ImageFormat = GifImageFormat;

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"GifImageFormat_Fixed_Inch_Size_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestGifImageFormat_FixedSize_InMillimeter()
        {
            Name = "GifImageFormat";

            PdfImage pdfImage = new PdfImage(new PdfResource(base.GetResourcePath("DocumentA.pdf")));
            FixedImageSize fixedImageSize = new FixedImageSize();
            fixedImageSize.Unit = ImageSizeUnit.Millimeter;
            fixedImageSize.Width = 200;
            fixedImageSize.Height = 200;
            pdfImage.ImageSize = fixedImageSize;

            GifImageFormat GifImageFormat = new GifImageFormat();
            pdfImage.ImageFormat = GifImageFormat;

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"GifImageFormat_Fixed_Millimeter_Size_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestGifImageFormat_MaxSize_InPoint()
        {
            Name = "GifImageFormat";

            PdfImage pdfImage = new PdfImage(new PdfResource(base.GetResourcePath("DocumentA.pdf")));
            MaxImageSize maxImageSize = new MaxImageSize();
            maxImageSize.Unit = ImageSizeUnit.Point;
            maxImageSize.MaxWidth = 500;
            maxImageSize.MaxHeight = 500;
            pdfImage.ImageSize = maxImageSize;

            GifImageFormat GifImageFormat = new GifImageFormat();
            pdfImage.ImageFormat = GifImageFormat;

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"GifImageFormat_Max_Point_Size_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestGifImageFormat_MaxSize_InInch()
        {
            Name = "GifImageFormat";

            PdfImage pdfImage = new PdfImage(new PdfResource(base.GetResourcePath("DocumentA.pdf")));
            MaxImageSize maxImageSize = new MaxImageSize();
            maxImageSize.Unit = ImageSizeUnit.Inch;
            maxImageSize.MaxWidth = 7;
            maxImageSize.MaxHeight = 7;
            pdfImage.ImageSize = maxImageSize;

            GifImageFormat GifImageFormat = new GifImageFormat();
            pdfImage.ImageFormat = GifImageFormat;

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"GifImageFormat_Max_Inch_Size_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestGifImageFormat_MaxSize_InMillimeter()
        {
            Name = "GifImageFormat";

            PdfImage pdfImage = new PdfImage(new PdfResource(base.GetResourcePath("DocumentA.pdf")));
            MaxImageSize maxImageSize = new MaxImageSize();
            maxImageSize.Unit = ImageSizeUnit.Millimeter;
            maxImageSize.MaxWidth = 400;
            maxImageSize.MaxHeight = 400;
            pdfImage.ImageSize = maxImageSize;

            GifImageFormat GifImageFormat = new GifImageFormat();
            pdfImage.ImageFormat = GifImageFormat;

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"GifImageFormat_Max_Millimeter_Size_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestGifImageFormat_Dpi_ImageSize()
        {
            Name = "GifImageFormat";

            PdfImage pdfImage = new PdfImage(new PdfResource(base.GetResourcePath("DocumentA.pdf")));
            DpiImageSize dpiImageSize = new DpiImageSize();
            dpiImageSize.HorizontalDpi = 155;
            dpiImageSize.VerticalDpi = 155;
            GifImageFormat GifImageFormat = new GifImageFormat();
            pdfImage.ImageFormat = GifImageFormat;
            pdfImage.ImageSize = dpiImageSize;

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"GifImageFormat_Dpi_ImageSize_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestGifImageFormat_Percentage_ImageSize()
        {
            Name = "GifImageFormat";

            PdfImage pdfImage = new PdfImage(new PdfResource(base.GetResourcePath("DocumentA.pdf")));
            PercentageImageSize percentageImageSize = new PercentageImageSize();
            percentageImageSize.VerticalPercentage = 50;
            percentageImageSize.HorizontalPercentage = 50;
            GifImageFormat GifImageFormat = new GifImageFormat();
            pdfImage.ImageFormat = GifImageFormat;
            pdfImage.ImageSize = percentageImageSize;

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"GifImageFormat_Percentage_ImageSize_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestGifImageFormat_Floyd()
        {
            Name = "GifImageFormat";

            PdfImage pdfImage = new PdfImage(new PdfResource(base.GetResourcePath("DocumentA.pdf")));
            GifImageFormat gifImageFormat = new GifImageFormat();
            gifImageFormat.DitheringAlgorithm = DitheringAlgorithm.FloydSteinberg;
            pdfImage.ImageFormat = gifImageFormat;

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"GifImageFormat_Floyd_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestGifImageFormat_Bayer()
        {
            Name = "GifImageFormat";

            PdfImage pdfImage = new PdfImage(new PdfResource(base.GetResourcePath("DocumentA.pdf")));
            GifImageFormat gifImageFormat = new GifImageFormat();
            gifImageFormat.DitheringAlgorithm = DitheringAlgorithm.Bayer;
            pdfImage.ImageFormat = gifImageFormat;

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"GifImageFormat_Bayer_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
    }
}
