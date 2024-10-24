﻿using DynamicPDF.Api.Elements;
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
    public class TiffImagingSamples : TestCase
    {
        public override InputSampleType InputSampleType
        {
            get
            {
                return InputSampleType.Imaging;
            }
        }
        public PdfImage getPdfImage(string inputFile, TiffColorFormat colorFormat = null, bool multiPageTiff = false)
        {
            PdfImage pdfImage = new PdfImage(new PdfResource(inputFile));
            TiffImageFormat tiffImageFormat = new TiffImageFormat();
            pdfImage.ImageFormat = tiffImageFormat;

            if (colorFormat != null) 
                tiffImageFormat.ColorFormat = colorFormat;

            if (multiPageTiff)
                tiffImageFormat.MultiPage = true;

            return pdfImage;
        }
        [TestMethod]
        public void TestTiffImageFormat()
        {
            Name = "TiffImageFormat";

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentSinglePage.pdf"));

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"TiffImageFormat_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }
                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestTiffImageFormat_PageCount()
        {
            Name = "TiffImageFormat";

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentA.pdf"));
            pdfImage.PageCount = 2;

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"TiffImageFormat_WithPageCount_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestTiffImageFormat_FixedSize_InPoint()
        {
            Name = "TiffImageFormat";

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
                    File.WriteAllBytes(base.GetOutputFilePath($"TiffImageFormat_Fixed_Point_Size_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestTiffImageFormat_FixedSize_InInch()
        {
            Name = "TiffImageFormat";

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
                    File.WriteAllBytes(base.GetOutputFilePath($"TiffImageFormat_Fixed_Inch_Size_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestTiffImageFormat_FixedSize_InMillimeter()
        {
            Name = "TiffImageFormat";

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
                    File.WriteAllBytes(base.GetOutputFilePath($"TiffImageFormat_Fixed_Millimeter_Size_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestTiffImageFormat_MaxSize_InPoint()
        {
            Name = "TiffImageFormat";

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
                    File.WriteAllBytes(base.GetOutputFilePath($"TiffImageFormat_Max_Point_Size_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }
                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestTiffImageFormat_MaxSize_InInch()
        {
            Name = "TiffImageFormat";

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
                    File.WriteAllBytes(base.GetOutputFilePath($"TiffImageFormat_Max_Inch_Size_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestTiffImageFormat_MaxSize_InMillimeter()
        {
            Name = "TiffImageFormat";

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
                    File.WriteAllBytes(base.GetOutputFilePath($"TiffImageFormat_Max_Millimeter_Size_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestTiffImageFormat_Dpi_ImageSize()
        {
            Name = "TiffImageFormat";

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
                    File.WriteAllBytes(base.GetOutputFilePath($"TiffImageFormat_Dpi_ImageSize_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestTiffImageFormat_Percentage_ImageSize()
        {
            Name = "TiffImageFormat";

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
                    File.WriteAllBytes(base.GetOutputFilePath($"TiffImageFormat_Percentage_ImageSize_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestTiffImageFormat_Floyd_MonoChrome()
        {
            Name = "TiffImageFormat";

            TiffMonochromeColorFormat tiffMonochromeColorFormat = new TiffMonochromeColorFormat();
            tiffMonochromeColorFormat.DitheringAlgorithm = DitheringAlgorithm.FloydSteinberg;
            tiffMonochromeColorFormat.DitheringPercent = 50;

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentSinglePage.pdf"), tiffMonochromeColorFormat);

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"TiffImageFormat_Floyd_MonoChrome_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestTiffImageFormat_Floyd_Indexed()
        {
            Name = "TiffImageFormat";

            TiffIndexedColorFormat tiffIndexedColorFormat = new TiffIndexedColorFormat();
            tiffIndexedColorFormat.DitheringAlgorithm = DitheringAlgorithm.FloydSteinberg;
            tiffIndexedColorFormat.DitheringPercent = 50;

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentSinglePage.pdf"), tiffIndexedColorFormat);
            
            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"TiffImageFormat_Floyd_Indexed_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestTiffImageFormat_Bayer_MonoChrome()
        {
            Name = "TiffImageFormat";

            TiffMonochromeColorFormat tiffMonochromeColorFormat = new TiffMonochromeColorFormat();
            tiffMonochromeColorFormat.DitheringAlgorithm = DitheringAlgorithm.Bayer;
            tiffMonochromeColorFormat.DitheringPercent = 50;

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentSinglePage.pdf"), tiffMonochromeColorFormat);

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"TiffImageFormat_Bayer_MonoChrome_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestTiffImageFormat_Bayer_Indexed()
        {
            Name = "TiffImageFormat";

            TiffIndexedColorFormat tiffIndexedColorFormat = new TiffIndexedColorFormat();
            tiffIndexedColorFormat.DitheringAlgorithm = DitheringAlgorithm.Bayer;
            tiffIndexedColorFormat.DitheringPercent = 50;

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentSinglePage.pdf"), tiffIndexedColorFormat);
            
            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"TiffImageFormat_Bayer_Indexed_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestTiffImageFormat_Qa_Octree()
        {
            Name = "TiffImageFormat";

            TiffIndexedColorFormat tiffIndexedColorFormat = new TiffIndexedColorFormat();
            tiffIndexedColorFormat.QuantizationAlgorithm = QuantizationAlgorithm.Octree;

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentSinglePage.pdf"), tiffIndexedColorFormat);

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"TiffImageFormat_Qa_Octree_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestTiffImageFormat_Qa_WU()
        {
            Name = "TiffImageFormat";

            TiffIndexedColorFormat tiffIndexedColorFormat = new TiffIndexedColorFormat();
            tiffIndexedColorFormat.QuantizationAlgorithm = QuantizationAlgorithm.WU;

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentSinglePage.pdf"), tiffIndexedColorFormat);

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"TiffImageFormat_Qa_WU_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestTiffImageFormat_Qa_WebSafe()
        {
            Name = "TiffImageFormat";

            TiffIndexedColorFormat tiffIndexedColorFormat = new TiffIndexedColorFormat();
            tiffIndexedColorFormat.QuantizationAlgorithm = QuantizationAlgorithm.WebSafe;

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentSinglePage.pdf"), tiffIndexedColorFormat);

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"TiffImageFormat_Qa_WebSafe_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestTiffImageFormat_Qa_Werner()
        {
            Name = "TiffImageFormat";

            TiffIndexedColorFormat tiffIndexedColorFormat = new TiffIndexedColorFormat();
            tiffIndexedColorFormat.QuantizationAlgorithm = QuantizationAlgorithm.Werner;

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentSinglePage.pdf"), tiffIndexedColorFormat);

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"TiffImageFormat_Qa_Werner_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestTiffImageFormat_RgbColorFormat()
        {
            Name = "TiffImageFormat";

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentSinglePage.pdf"), new TiffColorFormat(ColorFormatType.Rgb));

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"TiffImageFormat_Rgb_ColorFormat_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestTiffImageFormat_RgbaColorFormat()
        {
            Name = "TiffImageFormat";

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentSinglePage.pdf"), new TiffColorFormat(ColorFormatType.RgbA));

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"TiffImageFormat_Rgba_ColorFormat_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestTiffImageFormat_GrayscaleColorFormat()
        {
            Name = "TiffImageFormat";

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentSinglePage.pdf"), new TiffColorFormat(ColorFormatType.Grayscale));

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"TiffImageFormat_Grayscale_ColorFormat_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestTiffImageFormat_MonochromeColorFormat()
        {
            Name = "TiffImageFormat";

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentSinglePage.pdf"), new TiffColorFormat(ColorFormatType.Monochrome));

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"TiffImageFormat_Monochrome_ColorFormat_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestTiffImageFormat_IndexedColorFormat()
        {
            Name = "TiffImageFormat";

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentSinglePage.pdf"), new TiffColorFormat(ColorFormatType.Indexed));

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"TiffImageFormat_Indexed_ColorFormat_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestTiffImageFormat_BlackThreshold()
        {
            Name = "TiffImageFormat";

            TiffMonochromeColorFormat tiffMonochromeColorFormat = new TiffMonochromeColorFormat();
            tiffMonochromeColorFormat.BlackThreshold = 200;

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("Gray.pdf"), tiffMonochromeColorFormat);

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"TiffImageFormat_BlackThreshold_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
        [TestMethod]
        public void TestTiffImageFormat_MultiPage()
        {
            Name = "TiffImageFormat";

            PdfImage pdfImage = getPdfImage(base.GetResourcePath("DocumentA.pdf"), null, true);

            PdfImageResponse response = pdfImage.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                for (int i = 0; i < response.Images.Count; i++)
                {
                    File.WriteAllBytes(base.GetOutputFilePath($"TiffImageFormat_MultiPageTiff_{i}.{response.ImageFormat}", InputSampleType), Convert.FromBase64String(response.Images[i].Data));
                }

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
    }
}
