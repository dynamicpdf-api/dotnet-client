using DynamicPDF.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace DynamicPDFApiTestForNET.TestCases.FunctionalityTest.PDFEndpoint
{
    [TestClass]
    public class ExcelInputSamples : TestCase
    {
        public override InputSampleType InputSampleType
        {
            get
            {
                return InputSampleType.Excel;
            }
        }

        [TestMethod]
        public void ExcelFile_pdfoutput()
        {
            Name = "ExcelToPdf";
            Pdf pdf = new Pdf();

            ExcelResource excelResource = new ExcelResource(base.GetResourcePath("DocumentA.xlsx"));
            ExcelInput excel = new ExcelInput(excelResource);

            excel.PageWidth = 300;
            excel.PageHeight = 200;

            excel.TopMargin = 10;
            excel.BottomMargin = 10;
            excel.RightMargin = 40;
            excel.LeftMargin = 40;

            pdf.Inputs.Add(excel);

            PdfResponse response = pdf.Process();

            bool pass = false;
            if (response.IsSuccessful)
            {
                System.IO.File.WriteAllBytes(base.GetOutputFilePath("Doc1.pdf", InputSampleType), (byte[])response.Content);

                pass = response.IsSuccessful;
            }
            Assert.IsTrue(pass);
        }
    }
}
