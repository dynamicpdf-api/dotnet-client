using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using DynamicPDF.Api;


namespace DynamicPDFApiTestForNET.TestCases
{
    public abstract class TestCase
    {
        private string inputFilesFolder;
        private string outputFilesFolder;
        private string baselinePNGsFolder;

        internal const string Author = "ceTe Software";
        internal const string Title = "First Rest API";
        private static string testFrameWorkRootFolder;

        #region Constructors

        protected TestCase()
        {
            switch (this.InputSampleType)
            {
                case InputSampleType.DlexLayout:
                    DlexLayout.DefaultApiKey = "ApiKey";
                    DlexLayout.DefaultBaseUrl = "https://api.dynamicpdf.com";
                    break;
                case InputSampleType.ImageInfo:
                    ImageInfo.DefaultApiKey = "ApiKey";
                    ImageInfo.DefaultBaseUrl = "https://api.dynamicpdf.com";
                    break;
                case InputSampleType.PdfInfo:
                    PdfInfo.DefaultApiKey = "ApiKey";
                    PdfInfo.DefaultBaseUrl = "https://api.dynamicpdf.com";
                    break;
                case InputSampleType.PdfText:
                    PdfText.DefaultApiKey = "ApiKey";
                    PdfText.DefaultBaseUrl = "https://api.dynamicpdf.com";
                    break;
                case InputSampleType.PdfXmp:
                    PdfXmp.DefaultApiKey = "ApiKey";
                    PdfXmp.DefaultBaseUrl= "https://api.dynamicpdf.com";
                    break;
                default:
                    Pdf.DefaultApiKey = "ApiKey";
                    Pdf.DefaultBaseUrl= "https://api.dynamicpdf.com";
                    break;
            }
            testFrameWorkRootFolder = Path.GetFullPath(@"..\..\..\");

            this.inputFilesFolder = Path.Combine(testFrameWorkRootFolder, "Resources");
            this.outputFilesFolder = Path.Combine(testFrameWorkRootFolder, "Outputs");
            this.baselinePNGsFolder = Path.Combine(testFrameWorkRootFolder, "BaselinePNGs");
        }

        public string Name { get; set; }

        public abstract InputSampleType InputSampleType { get; }

        public string GetOutputPdfFilePath(InputSampleType inputSampleType)
        {
            string filePath = GetFilePath(inputSampleType, this.outputFilesFolder);
            return Path.Combine(filePath, "Output.pdf");
        }

        #endregion

        #region Protected Propeties

        protected string InputFilesFolder
        {
            get { return inputFilesFolder; }
        }

        protected string OutputFilesFolder
        {
            get { return outputFilesFolder; }
        }

        #endregion

        #region Protected Methods

        protected string GetOutputFilePath(string fileName, InputSampleType inputSampleType)
        {
            string filePath = GetFilePath(inputSampleType, this.outputFilesFolder);
            return Path.Combine(filePath, fileName);
        }

        protected string GetResourcePath(string fileName)
        {
            string filePath = "";
            switch (this.InputSampleType)
            {
                case InputSampleType.DlexLayout:
                    filePath = Path.Combine(this.InputFilesFolder, Path.Combine("FunctionalityTest\\DlexLayout"));
                    break;
                case InputSampleType.PdfText:
                    filePath = Path.Combine(this.InputFilesFolder, Path.Combine("FunctionalityTest\\PdfText"));
                    break;
                case InputSampleType.PdfXmp:
                    filePath = Path.Combine(this.InputFilesFolder, Path.Combine("FunctionalityTest\\PdfXmp"));
                    break;
                case InputSampleType.ImageInfo:
                    filePath = Path.Combine(this.InputFilesFolder, Path.Combine("FunctionalityTest\\ImageInfo"));
                    break;
                case InputSampleType.PdfInfo:
                    filePath = Path.Combine(this.InputFilesFolder, Path.Combine("FunctionalityTest\\PdfInfo"));
                    break;
                case InputSampleType.Complex:
                default:
                    filePath = Path.Combine(this.InputFilesFolder, Path.Combine("FunctionalityTest\\PdfEndpoint"));
                    break;
            }

            return Path.Combine(filePath, fileName);
        }

        protected string GetOutputPngFilePath(int pageNumber, InputSampleType inputSampleType)
        {
            if (pageNumber < 1) throw new Exception("Page Number must be greater than 0.");
            string filePath = GetFilePath(inputSampleType, this.outputFilesFolder);
            return Path.Combine(filePath, "Output_Page" + pageNumber.ToString() + ".png");
        }

        protected string GetInputPngFilePath(int pageNumber, InputSampleType inputSampleType)
        {
            if (pageNumber < 1) throw new Exception("Page Number must be greater than 0.");
            string filePath = GetFilePath(inputSampleType, baselinePNGsFolder);
            return Path.Combine(filePath, "Baseline_Page" + pageNumber.ToString() + ".png");
        }


        #endregion

        #region Private Methods

        private bool ComparePngs(int pageNumber, InputSampleType inputSampleType)
        {
            int baselineWidth;
            int baselineHeight;
            int outputWidth;
            int outputHeight;
            int baselineStride;
            int outputStride;

            Bitmap inputBitmap = new Bitmap(GetInputPngFilePath(pageNumber, inputSampleType));

            baselineWidth = inputBitmap.Width;
            baselineHeight = inputBitmap.Height;

            byte[] inputData = GetBitmapImageData(inputBitmap, out baselineStride);
            inputBitmap.Dispose();

            Bitmap outputBitmap = new Bitmap(GetOutputPngFilePath(pageNumber, inputSampleType));

            outputWidth = outputBitmap.Width;
            outputHeight = outputBitmap.Height;

            byte[] outputData = GetBitmapImageData(outputBitmap, out outputStride);
            outputBitmap.Dispose();
            int i = 0;
            bool bImageMatches = true;
            if (inputData.Length == outputData.Length)
            {
                for (i = 0; i < inputData.Length; i++)
                {
                    if (inputData[i] != outputData[i])
                    {
                        bImageMatches = false;
                        break;
                    }
                }
            }
            else
                bImageMatches = false;


            if (bImageMatches == false)
            {
                ImageComparisonFile baseLineOutputFiles = new ImageComparisonFile();

                baseLineOutputFiles.BaseLineData = inputData;
                baseLineOutputFiles.OutputData = outputData;

                baseLineOutputFiles.BaselineWidth = baselineWidth;
                baseLineOutputFiles.BaselineHeight = baselineHeight;

                baseLineOutputFiles.OutputWidth = outputWidth;
                baseLineOutputFiles.OutputHeight = outputHeight;

                baseLineOutputFiles.baselineStride = baselineStride;
                baseLineOutputFiles.outputStride = outputStride;

                baseLineOutputFiles.BaseLinePng = GetInputPngFilePath(pageNumber, inputSampleType);
                baseLineOutputFiles.OutputPng = GetOutputPngFilePath(pageNumber, inputSampleType);

                baseLineOutputFiles.PageNumber = pageNumber;

                ThreadPool.QueueUserWorkItem(new WaitCallback(GenerateDifferenceImage), baseLineOutputFiles);
            }

            // System.GC.GetTotalMemory(true);

            return bImageMatches;
        }

        private byte[] GetBitmapImageData(Bitmap bitmap, out int stride)
        {
            BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            int length = bitmapData.Stride * bitmap.Height;
            stride = bitmapData.Stride;
            byte[] data = new byte[length];
            System.Runtime.InteropServices.Marshal.Copy(bitmapData.Scan0, data, 0, length);
            return data;
        }


        private void GenerateDifferenceImage(object compareFiles)
        {
            ImageComparisonFile baseLineOutputFiles = compareFiles as ImageComparisonFile;

            int width = (baseLineOutputFiles.BaselineWidth >= baseLineOutputFiles.OutputWidth) ? baseLineOutputFiles.BaselineWidth : baseLineOutputFiles.OutputWidth;
            int height = (baseLineOutputFiles.BaselineHeight >= baseLineOutputFiles.OutputHeight) ? baseLineOutputFiles.BaselineHeight : baseLineOutputFiles.OutputHeight;

            int stride = (width * 3);

            if ((stride % 4) != 0)
            {
                stride += (4 - (stride % 4));
            }

            int dataSize = stride * height;

            byte[] compareData = new byte[dataSize];

            int baselineDifference = (baseLineOutputFiles.BaselineWidth * 3) - baseLineOutputFiles.baselineStride;

            int remainder = baseLineOutputFiles.BaseLineData.Length % 3;

            for (int i = 0; i < baseLineOutputFiles.BaseLineData.Length - remainder; i += 3)
            {
                if (i + 3 > baseLineOutputFiles.OutputData.Length)
                    break;
                if (baseLineOutputFiles.BaseLineData[i] == baseLineOutputFiles.OutputData[i])
                {
                    compareData[i] = (byte)(baseLineOutputFiles.BaseLineData[i] * 0.40);
                    compareData[i + 1] = (byte)(baseLineOutputFiles.BaseLineData[i + 1] * 0.40);
                    compareData[i + 2] = (byte)(baseLineOutputFiles.BaseLineData[i + 2] * 0.40);
                }
                else
                {
                    compareData[i] = 0;
                    compareData[i + 1] = 255;
                    compareData[i + 2] = 255;
                }
            }

            if (remainder > 0)
            {
                if (remainder == 1)
                {
                    if (baseLineOutputFiles.BaseLineData[baseLineOutputFiles.BaseLineData.Length - 1] == baseLineOutputFiles.OutputData[baseLineOutputFiles.BaseLineData.Length - 1])
                    {
                        compareData[baseLineOutputFiles.BaseLineData.Length - 1] = (byte)(baseLineOutputFiles.BaseLineData[baseLineOutputFiles.BaseLineData.Length - 1] * 0.40);
                    }
                    else
                    {
                        compareData[baseLineOutputFiles.BaseLineData.Length - 1] = 0;
                    }
                }

                if (remainder == 2)
                {
                    if (baseLineOutputFiles.BaseLineData[baseLineOutputFiles.BaseLineData.Length - 2] == baseLineOutputFiles.OutputData[baseLineOutputFiles.BaseLineData.Length - 2])
                    {
                        compareData[baseLineOutputFiles.BaseLineData.Length - 2] = (byte)(baseLineOutputFiles.BaseLineData[baseLineOutputFiles.BaseLineData.Length - 2] * 0.40);
                        compareData[baseLineOutputFiles.BaseLineData.Length - 1] = (byte)(baseLineOutputFiles.BaseLineData[baseLineOutputFiles.BaseLineData.Length - 1] * 0.40);
                    }
                    else
                    {
                        compareData[baseLineOutputFiles.BaseLineData.Length - 2] = 0;
                        compareData[baseLineOutputFiles.BaseLineData.Length - 1] = 255;
                    }
                }
            }

            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            BitmapData bitmapData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            System.Runtime.InteropServices.Marshal.Copy(compareData, 0, bitmapData.Scan0, compareData.Length);
            bmp.UnlockBits(bitmapData);

            bmp.Save(outputFilesFolder + "\\Difference_Page" + baseLineOutputFiles.PageNumber + ".bmp");

            bmp.Dispose();
        }

        private string GetFilePath(InputSampleType inputSampleType, string rootPath)
        {
            string filePath = "";
            switch (inputSampleType)
            {
                case InputSampleType.Dlex:
                    filePath = Path.Combine(rootPath, Path.Combine("FunctionalityTest\\PdfEndpoint\\DlexInputSamples", Name));
                    break;
                case InputSampleType.ColorPattern:
                    filePath = Path.Combine(rootPath, Path.Combine("FunctionalityTest\\PdfEndpoint\\ColorPatternSamples", Name));
                    break;
                case InputSampleType.Font:
                    filePath = Path.Combine(rootPath, Path.Combine("FunctionalityTest\\PdfEndpoint\\FontSamples", Name));
                    break;
                case InputSampleType.FormFilling:
                    filePath = Path.Combine(rootPath, Path.Combine("FunctionalityTest\\PdfEndpoint\\FormFillingSamples", Name));
                    break;
                case InputSampleType.FormFlattenAndRemove:
                    filePath = Path.Combine(rootPath, Path.Combine("FunctionalityTest\\PdfEndpoint\\FormFlattenAndRemoveSamples", Name));
                    break;
                case InputSampleType.ImageElement:
                    filePath = Path.Combine(rootPath, Path.Combine("FunctionalityTest\\PdfEndpoint\\ImageElementSamples", Name));
                    break;
                case InputSampleType.ImageInput:
                    filePath = Path.Combine(rootPath, Path.Combine("FunctionalityTest\\PdfEndpoint\\ImageInputSamples", Name));
                    break;
                case InputSampleType.Line:
                    filePath = Path.Combine(rootPath, Path.Combine("FunctionalityTest\\PdfEndpoint\\LineSample", Name));
                    break;
                case InputSampleType.Outline:
                    filePath = Path.Combine(rootPath, Path.Combine("FunctionalityTest\\PdfEndpoint\\OutlineSamples", Name));
                    break;
                case InputSampleType.PageInput:
                    filePath = Path.Combine(rootPath, Path.Combine("FunctionalityTest\\PdfEndpoint\\PageInputSamples", Name));
                    break;
                case InputSampleType.PdfInput:
                    filePath = Path.Combine(rootPath, Path.Combine("FunctionalityTest\\PdfEndpoint\\PdfInputSamples", Name));
                    break;
                case InputSampleType.Rectangle:
                    filePath = Path.Combine(rootPath, Path.Combine("FunctionalityTest\\PdfEndpoint\\RectangleSamples", Name));
                    break;
                case InputSampleType.Security:
                    filePath = Path.Combine(rootPath, Path.Combine("FunctionalityTest\\PdfEndpoint\\SecuritySamples", Name));
                    break;
                case InputSampleType.TemplateBarcode:
                    filePath = Path.Combine(rootPath, Path.Combine("FunctionalityTest\\PdfEndpoint\\TemplateBarcodeSamples", Name));
                    break;
                case InputSampleType.TemplatePageNumberingLabel:
                    filePath = Path.Combine(rootPath, Path.Combine("FunctionalityTest\\PdfEndpoint\\TemplatePageNumberingSamples", Name));
                    break;
                case InputSampleType.Template:
                    filePath = Path.Combine(rootPath, Path.Combine("FunctionalityTest\\PdfEndpoint\\TemplateSamples", Name));
                    break;
                case InputSampleType.DlexLayout:
                    filePath = Path.Combine(rootPath, Path.Combine("FunctionalityTest\\DlexLayout", Name));
                    break;
                case InputSampleType.PdfText:
                    filePath = Path.Combine(rootPath, Path.Combine("FunctionalityTest\\PdfText", Name));
                    break;
                case InputSampleType.PdfXmp:
                    filePath = Path.Combine(rootPath, Path.Combine("FunctionalityTest\\PdfXmp", Name));
                    break;
                case InputSampleType.ImageInfo:
                    filePath = Path.Combine(rootPath, Path.Combine("FunctionalityTest\\ImageInfo", Name));
                    break;
                case InputSampleType.PdfInfo:
                    filePath = Path.Combine(rootPath, Path.Combine("FunctionalityTest\\PdfInfo", Name));
                    break;
                case InputSampleType.Complex:
                    filePath = Path.Combine(rootPath, Path.Combine("FunctionalityTest\\Complex", Name));
                    break;
            }
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            return filePath;
        }

        #endregion

    }

    internal class ImageComparisonFile
    {
        internal string BaseLinePng;
        internal string OutputPng;

        internal byte[] BaseLineData;
        internal byte[] OutputData;

        internal int BaselineWidth;
        internal int BaselineHeight;

        internal int OutputWidth;
        internal int OutputHeight;

        internal int baselineStride;
        internal int outputStride;


        internal int PageNumber;
    }

    public enum InputSampleType
    {
        None,
        ColorPattern,
        Complex,
        Dlex,
        Font,
        FormFilling,
        FormFlattenAndRemove,
        ImageElement,
        ImageInput,
        Line,
        Outline,
        PageInput,
        PdfInput,
        Rectangle,
        Security,
        TemplateBarcode,
        TemplatePageNumberingLabel,
        Template,
        DlexLayout,
        PdfText,
        PdfXmp,
        ImageInfo,
        PdfInfo,
    }
}
