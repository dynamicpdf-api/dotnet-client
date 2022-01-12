using DynamicPDF.Api;
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

            DlexLayout dlexEndpoint = new DlexLayout("SimpleReportWithCoverPage.dlex", layoutData);
           
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
        public void ContactListDlex_Pdfoutput()
        {
            Name = "ContactListDlex";

            LayoutDataResource layoutData = new LayoutDataResource(base.GetResourcePath("ContactList.json"));

            DlexLayout dlexEndpoint = new DlexLayout("ContactList.dlex", layoutData);


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
        public void ContentGroupSubReport_Pdfoutput()
        {
            Name = "ContentGroupSubReport";

            LayoutDataResource layoutData = new LayoutDataResource(base.GetResourcePath("ContentGroupSubReportData.json"));

            DlexLayout dlexEndpoint = new DlexLayout("TFWResources/ContentGroupSubReport.dlex", layoutData);


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
        public void AllReportElements_Pdfoutput()
        {
            Name = "AllReportElements";

            LayoutDataResource layoutData = new LayoutDataResource(base.GetResourcePath("AllReportElementsData.json"));

            DlexLayout dlexEndpoint = new DlexLayout("TFWResources/AllReportElements.dlex", layoutData);


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
        public void ContentGroup_Pdfoutput()
        {
            Name = "ContentGroup";

            LayoutDataResource layoutData = new LayoutDataResource(base.GetResourcePath("ContentGroupData.json"));

            DlexLayout dlexEndpoint = new DlexLayout("TFWResources/ContentGroup.dlex", layoutData);


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
        public void Invoice_Pdfoutput()
        {
            Name = "Invoice";

            LayoutDataResource layoutData = new LayoutDataResource(base.GetResourcePath("InvoiceReportData.json"));

            DlexLayout dlexEndpoint = new DlexLayout("TFWResources/Invoice.dlex", layoutData);


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
