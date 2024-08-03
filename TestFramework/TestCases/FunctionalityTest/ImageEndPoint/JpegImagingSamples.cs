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
    public class JpegImagingSamples : TestCase
    {
        public override InputSampleType InputSampleType
        {
            get
            {
                return InputSampleType.Imaging;
            }
        }

        [TestMethod]
        public void TestJpegImageFormat()
        {
            Name = "JpegImageFormat";

            PdfImage pdfImage = new PdfImage(new PdfResource(base.GetResourcePath("DocumentA.pdf")));
            JpegImageFormat jpegImageFormat = new JpegImageFormat();
            pdfImage.ImageFormat = jpegImageFormat;

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"JpegImageFormat_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestJpegImageFormat_PageCount()
        {
            Name = "JpegImageFormat";

            PdfImage pdfImage = new PdfImage(new PdfResource(base.GetResourcePath("DocumentA.pdf")));
            pdfImage.PageCount = 2;
            JpegImageFormat jpegImageFormat = new JpegImageFormat();
            pdfImage.ImageFormat = jpegImageFormat;

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"JpegImageFormat_WithPageCount_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestJpegImageFormat_FixedSize_InPoint()
        {
            Name = "JpegImageFormat";

            PdfImage pdfImage = new PdfImage(new PdfResource(base.GetResourcePath("DocumentA.pdf")));
            FixedImageSize fixedImageSize = new FixedImageSize();
            fixedImageSize.Unit = ImageSizeUnit.Point;
            fixedImageSize.Width = 500;
            fixedImageSize.Height = 500;
            pdfImage.ImageSize = fixedImageSize;

            JpegImageFormat jpegImageFormat = new JpegImageFormat();
            pdfImage.ImageFormat = jpegImageFormat;

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"JpegImageFormat_Fixed_Point_Size_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestJpegImageFormat_FixedSize_InInch()
        {
            Name = "JpegImageFormat";

            PdfImage pdfImage = new PdfImage(new PdfResource(base.GetResourcePath("DocumentA.pdf")));
            FixedImageSize fixedImageSize = new FixedImageSize();
            fixedImageSize.Unit = ImageSizeUnit.Inch;
            fixedImageSize.Width = 5;
            fixedImageSize.Height = 5;
            pdfImage.ImageSize = fixedImageSize;

            JpegImageFormat jpegImageFormat = new JpegImageFormat();
            pdfImage.ImageFormat = jpegImageFormat;

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"JpegImageFormat_Fixed_Inch_Size_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestJpegImageFormat_FixedSize_InMillimeter()
        {
            Name = "JpegImageFormat";

            PdfImage pdfImage = new PdfImage(new PdfResource(base.GetResourcePath("DocumentA.pdf")));
            FixedImageSize fixedImageSize = new FixedImageSize();
            fixedImageSize.Unit = ImageSizeUnit.Millimeter;
            fixedImageSize.Width = 200;
            fixedImageSize.Height = 200;
            pdfImage.ImageSize = fixedImageSize;

            JpegImageFormat jpegImageFormat = new JpegImageFormat();
            pdfImage.ImageFormat = jpegImageFormat;

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"JpegImageFormat_Fixed_Millimeter_Size_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestJpegImageFormat_MaxSize_InPoint()
        {
            Name = "JpegImageFormat";

            PdfImage pdfImage = new PdfImage(new PdfResource(base.GetResourcePath("DocumentA.pdf")));
            MaxImageSize maxImageSize = new MaxImageSize();
            maxImageSize.Unit = ImageSizeUnit.Point;
            maxImageSize.MaxWidth = 500;
            maxImageSize.MaxHeight = 500;
            pdfImage.ImageSize = maxImageSize;

            JpegImageFormat jpegImageFormat = new JpegImageFormat();
            pdfImage.ImageFormat = jpegImageFormat;

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"JpegImageFormat_Max_Point_Size_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestJpegImageFormat_MaxSize_InInch()
        {
            Name = "JpegImageFormat";

            PdfImage pdfImage = new PdfImage(new PdfResource(base.GetResourcePath("DocumentA.pdf")));
            MaxImageSize maxImageSize = new MaxImageSize();
            maxImageSize.Unit = ImageSizeUnit.Inch;
            maxImageSize.MaxWidth = 7;
            maxImageSize.MaxHeight = 7;
            pdfImage.ImageSize = maxImageSize;

            JpegImageFormat jpegImageFormat = new JpegImageFormat();
            pdfImage.ImageFormat = jpegImageFormat;

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"JpegImageFormat_Max_Inch_Size_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestJpegImageFormat_MaxSize_InMillimeter()
        {
            Name = "JpegImageFormat";

            PdfImage pdfImage = new PdfImage(new PdfResource(base.GetResourcePath("DocumentA.pdf")));
            MaxImageSize maxImageSize = new MaxImageSize();
            maxImageSize.Unit = ImageSizeUnit.Millimeter;
            maxImageSize.MaxWidth = 400;
            maxImageSize.MaxHeight = 400;
            pdfImage.ImageSize = maxImageSize;

            JpegImageFormat jpegImageFormat = new JpegImageFormat();
            pdfImage.ImageFormat = jpegImageFormat;

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"JpegImageFormat_Max_Millimeter_Size_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestJpegImageFormat_Dpi_ImageSize()
        {
            Name = "JpegImageFormat";

            PdfImage pdfImage = new PdfImage(new PdfResource(base.GetResourcePath("DocumentA.pdf")));
            DpiImageSize dpiImageSize = new DpiImageSize();
            dpiImageSize.HorizontalDpi = 155;
            dpiImageSize.VerticalDpi = 155;
            JpegImageFormat jpegImageFormat = new JpegImageFormat();
            pdfImage.ImageFormat = jpegImageFormat;
            pdfImage.ImageSize = dpiImageSize;

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"JpegImageFormat_Dpi_ImageSize_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestJpegImageFormat_Percentage_ImageSize()
        {
            Name = "JpegImageFormat";

            PdfImage pdfImage = new PdfImage(new PdfResource(base.GetResourcePath("DocumentA.pdf")));
            PercentageImageSize percentageImageSize = new PercentageImageSize();
            percentageImageSize.VerticalPercentage = 50;
            percentageImageSize.HorizontalPercentage = 50;
            JpegImageFormat jpegImageFormat = new JpegImageFormat();
            pdfImage.ImageFormat = jpegImageFormat;
            pdfImage.ImageSize = percentageImageSize;

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"JpegImageFormat_Percentage_ImageSize_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestJpegImageFormat_Quality()
        {
            Name = "JpegImageFormat";

            PdfImage pdfImage = new PdfImage(new PdfResource(base.GetResourcePath("DocumentA.pdf")));
            JpegImageFormat jpegImageFormat = new JpegImageFormat();
            jpegImageFormat.Quality = 10;
            pdfImage.ImageFormat = jpegImageFormat;

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"JpegImageFormat_Quality_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
    }
}
