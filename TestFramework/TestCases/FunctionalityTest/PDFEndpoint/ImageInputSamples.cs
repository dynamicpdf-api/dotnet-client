using DynamicPDF.Api;
using DynamicPDF.Api.Elements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace DynamicPDFApiTestForNET.TestCases.FunctionalityTest.PDFEndpoint
{
    [TestClass]
    public class ImageInputSamples : TestCase
    {
        public override InputSampleType InputSampleType
        {
            get
            {
                return InputSampleType.ImageInput;
            }
        }

        [TestMethod]
        public void FilePathImage_Pdfoutput()
        {
            Name = "FilePathPngImage";
            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            ImageResource resource = new ImageResource(base.GetResourcePath("DPDFLogo.png"), "DPDFLogo.png");
            ImageInput input = new ImageInput(resource);
            input.ScaleX = 4;
            input.ScaleY = 4;
            input.PageWidth = 400;
            input.PageHeight = 400;

            pdf.Inputs.Add(input);
            
            PdfResponse response = pdf.Process();

            bool pass = false;

            if (response.IsSuccessful)
            {
                pass = base.getVerify(InputSampleType, response, pdf);
            }
            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void FilePathMultiTiffImage_Pdfoutput()
        {
            Name = "FilePathMultiTiffImage";
            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;

            ImageResource resource = new ImageResource(base.GetResourcePath("fw9_18.tif"), "fw9_18.tif");
            ImageInput input = new ImageInput(resource);
            input.RightMargin = 50;
            input.BottomMargin = 50;
            input.TopMargin = 50;
            input.LeftMargin = 50;
            pdf.Inputs.Add(input);

            PdfResponse response = pdf.Process();

            bool pass = false;

            if (response.IsSuccessful)
            {
                pass = base.getVerify(InputSampleType, response, pdf);
            }
            Assert.IsTrue(pass);
        }
    }
}
