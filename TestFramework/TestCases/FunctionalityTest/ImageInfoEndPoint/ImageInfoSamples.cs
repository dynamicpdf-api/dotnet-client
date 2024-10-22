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

                string outputFileName = base.GetOutputFilePath("MultipleFormat_JsonOutput_" + i + ".json", InputSampleType);
                string baselineFileName = base.GetBaselineFilePath("MultipleFormat_JsonBaseline_" + i + ".json", InputSampleType);

                if (response.IsSuccessful)
                {
                    File.WriteAllText(outputFileName, response.JsonContent);

                    if (createBaseline)
                        CreateBaselineFromOutput(outputFileName, baselineFileName);

                    pass = base.compareOutputWithBaseline(outputFileName, baselineFileName);
                }
            }
            Assert.IsTrue(pass);
        }
    }
}
