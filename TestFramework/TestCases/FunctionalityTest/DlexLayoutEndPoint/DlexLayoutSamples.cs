﻿using DynamicPDF.Api;
using DynamicPDF.Api.Elements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace DynamicPDFApiTestForNET.TestCases.FunctionalityTest.DlexLayoutEndPoint
{
    [TestClass]
    public class DlexLayoutSamples : TestCase
    {
        public override InputSampleType InputSampleType
        {
            get
            {
                return InputSampleType.DlexLayout;
            }
        }

        [TestMethod]
        public void DlexLayout()
        {
            Name = "Simple";
            LayoutDataResource layoutData = new LayoutDataResource(base.GetResourcePath("SimpleReportData.json"));

            DlexLayout dlexEndpoint = new DlexLayout("TFWResources/SimpleReportWithCoverPage.dlex", layoutData);
           
            PdfResponse response = dlexEndpoint.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                File.WriteAllBytes(base.GetOutputFilePath("Output.pdf", InputSampleType), (byte[])response.Content);

#if BASELINEREQUIRED
                // Uncomment the line below to recreate the Input PNG Images
                base.CreateInputPngsFromOutputPdf(72, InputSampleType);

                pass = base.CompareOutputPdfToInputPngs(72, InputSampleType);
#else
                pass = response.IsSuccessful;
#endif

            }
            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void InvoiceData_Pdfoutput()
        {
            Name = "InvoiceData";

            var invoiceLinqData = InvoiceData.Order11077;

            LayoutDataResource layoutDataResource = new LayoutDataResource(invoiceLinqData);
            DlexLayout dlexEndpoint = new DlexLayout("TFWResources/InvoiceOrderId.dlex", layoutDataResource);

            PdfResponse response = dlexEndpoint.Process();
            bool pass = false;

            if (response.IsSuccessful)
            {
                File.WriteAllBytes(base.GetOutputFilePath("Output.pdf", InputSampleType), (byte[])response.Content);

#if BASELINEREQUIRED
                // Uncomment the line below to recreate the Input PNG Images
                base.CreateInputPngsFromOutputPdf(72, InputSampleType);

                pass = base.CompareOutputPdfToInputPngs(72, InputSampleType);
#else
                pass = response.IsSuccessful;
#endif

            }
            Assert.IsTrue(pass);
        }

    }
}