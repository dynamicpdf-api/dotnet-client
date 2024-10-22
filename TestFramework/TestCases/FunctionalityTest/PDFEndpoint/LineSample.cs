using DynamicPDF.Api;
using DynamicPDF.Api.Elements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text;

namespace DynamicPDFApiTestForNET.TestCases.FunctionalityTest.PDFEndpoint
{

    [TestClass]
    public class LineSample : TestCase
    {
        public override InputSampleType InputSampleType
        {
            get
            {
                return InputSampleType.Line;
            }
        }
       
        [TestMethod]
        public void PageInput_Pdfoutput()
        {
            Name = "LineElement";
            Pdf pdf = new Pdf();
            pdf.Author = Author;
            pdf.Title = Title;
            
            PageInput input = new PageInput();
            pdf.Inputs.Add(input);

            LineElement element = new LineElement(ElementPlacement.TopLeft, 200, 200);
            element.Color = new RgbColor(0, 0, 1);
            element.XOffset = 100;
            element.YOffset = 100;
            element.LineStyle = LineStyle.DashLarge;
            element.Width = 4;
            input.Elements.Add(element);

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
