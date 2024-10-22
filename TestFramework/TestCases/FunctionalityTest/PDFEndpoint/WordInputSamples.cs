using DynamicPDF.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace DynamicPDFApiTestForNET.TestCases.FunctionalityTest.PDFEndpoint
{
    [TestClass]
    public class WordInputSamples : TestCase
    {
        public override InputSampleType InputSampleType
        {
            get
            {
                return InputSampleType.Word;
            }
        }

        [TestMethod]
        public void WordFile_pdfoutput()
        {
            Name = "WordToPdf";
            Pdf pdf = new Pdf();

            WordResource wordResource = new WordResource(base.GetResourcePath("Doc1.docx"), "Doc1.docx");
            WordInput word = new WordInput(wordResource);

            word.PageWidth = 300;
            word.PageHeight = 200;

            word.TopMargin = 10;
            word.BottomMargin = 10;
            word.RightMargin = 40;
            word.LeftMargin = 40;

            pdf.Inputs.Add(word);

            PdfResponse response = pdf.Process();

            bool pass = false;
            if (response.IsSuccessful)
            {
                pass = base.getVerify(InputSampleType, response, pdf);
            }
            Assert.IsTrue(pass);

        }
        [TestMethod]
        public void WordFileTextReplace_pdfoutput()
        {
            Name = "WordToPdfTextReplace";
            Pdf pdf = new Pdf();

            WordResource wordResource = new WordResource(base.GetResourcePath("Doc1.docx"), "Doc1.docx");
            WordInput word = new WordInput(wordResource);

            word.PageWidth = 300;
            word.PageHeight = 200;

            word.TopMargin = 10;
            word.BottomMargin = 10;
            word.RightMargin = 40;
            word.LeftMargin = 40;
            word.TextReplace.Add(new TextReplace("ve", "Data", true));
            pdf.Inputs.Add(word);

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
