using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using DynamicPDF.Api;
using DynamicPDF.Api.Imaging;


namespace DynamicPDFApiTestForNET.TestCases
{
    public abstract class TestCase
    {
        private string inputFilesFolder;
        private string outputFilesFolder;

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
                    PdfXmp.DefaultBaseUrl = "https://api.dynamicpdf.com";
                    break;
				case InputSampleType.Imaging:
                    PdfImage.DefaultApiKey = "ApiKey";
                    PdfImage.DefaultBaseUrl = "https://api.dynamicpdf.com";
                    break;
                default:
                    Pdf.DefaultApiKey = "ApiKey";
                    Pdf.DefaultBaseUrl = "https://api.dynamicpdf.com";
                    break;
            }
            testFrameWorkRootFolder = Path.GetFullPath(@"..\..\..\");

            this.inputFilesFolder = Path.Combine(testFrameWorkRootFolder, "Resources");
            this.outputFilesFolder = Path.Combine(testFrameWorkRootFolder, "Outputs");
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
            return Path.Combine(this.InputFilesFolder, fileName);
        }


        #endregion

        #region Private Method
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
                case InputSampleType.MultipleInputs:
                    filePath = Path.Combine(rootPath, Path.Combine("FunctionalityTest\\PdfEndpoint\\MultipleInputs", Name));
                    break;
                case InputSampleType.Html:
                    filePath = Path.Combine(rootPath, Path.Combine("FunctionalityTest\\PdfEndpoint", Name));
                    break;
                case InputSampleType.Word:
                    filePath = Path.Combine(rootPath, Path.Combine("FunctionalityTest\\PdfEndpoint\\WordInputSamples", Name));
                    break;
                case InputSampleType.Excel:
                    filePath = Path.Combine(rootPath, Path.Combine("FunctionalityTest\\PdfEndpoint\\ExcelInputSamples", Name));
                    break;
                case InputSampleType.Imaging:
                    filePath = Path.Combine(rootPath, Path.Combine("FunctionalityTest\\ImageEndpoint", Name));
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

    public enum InputSampleType
    {
        None,
        ColorPattern,
        Dlex,
        Font,
        FormFilling,
        FormFlattenAndRemove,
        ImageElement,
        ImageInput,
        Line,
        MultipleInputs,
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
        Html,
        Word,
        Excel,
        Imaging
    }
}
