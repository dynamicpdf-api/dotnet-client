using DynamicPDF.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace DynamicPDFApiTestForNET.TestCases.FunctionalityTest.ImageInfoEndPoint
{
    [TestClass]
    public class ImageInfoSamples : TestCase
    {
        public override InputSampleType InputSampleType
        {
            get
            {
                return InputSampleType.ImageInfo;
            }
        }

        [TestMethod]
        public void MultipleFormats_JsonOutput()
        {
            Name = "MultipleFormat";

            string[] images = {  "Northwind Logo.gif", "fw9_18.tif", "DPDFLogo.png", "DocumentA.jpeg" };
            bool pass = false;
            for (int i = 0; i < images.Length; i++)
            {
                ImageResource resource = new ImageResource(base.GetResourcePath(images[i]));

                ImageInfo pdfEndPoint = new ImageInfo(resource);
                ImageResponse response = pdfEndPoint.Process();

                

                if (response.IsSuccessful)
                {
                    File.WriteAllText(base.GetOutputFilePath("Output"+i+".json", InputSampleType), response.JsonContent);

#if BASELINEREQUIRED
                // Uncomment the line below to recreate the Input PNG Images
                base.CreateInputPngsFromOutputPdf(72, InputSampleType);

                pass = base.CompareOutputPdfToInputPngs(72, InputSampleType);
#else
                    pass = response.IsSuccessful;
#endif

                }
            }
            Assert.IsTrue(pass);
        }

        
    }
}
