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
        public void Tiff_JsonOutput()
        {
            Name = "Tiff";
            
            ImageResource resource = new ImageResource(base.GetResourcePath("fw9_18.tif"));
            
            ImageInfo pdfEndPoint = new ImageInfo(resource);
            ImageResponse response = pdfEndPoint.Process();

            bool pass = false;

            if (response.IsSuccessful)
            {
                File.WriteAllText(base.GetOutputFilePath("Output.json", InputSampleType), response.JsonContent);

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
        public void Gif_JsonOutput()
        {
            Name = "Gif";

            ImageResource resource = new ImageResource(base.GetResourcePath("Northwind Logo.gif"));

            ImageInfo pdfEndPoint = new ImageInfo(resource);
            ImageResponse response = pdfEndPoint.Process();

            bool pass = false;

            if (response.IsSuccessful)
            {
                File.WriteAllText(base.GetOutputFilePath("Output.json", InputSampleType), response.JsonContent);

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
        public void Png_JsonOutput()
        {
            Name = "Png";

            ImageResource resource = new ImageResource(base.GetResourcePath("DPDFLogo.png"));

            ImageInfo pdfEndPoint = new ImageInfo(resource);
            ImageResponse response = pdfEndPoint.Process();

            bool pass = false;

            if (response.IsSuccessful)
            {
                File.WriteAllText(base.GetOutputFilePath("Output.json", InputSampleType), response.JsonContent);

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
        public void Jpg_JsonOutput()
        {
            Name = "Jpg";

            ImageResource resource = new ImageResource(base.GetResourcePath("DocumentA.jpg"));

            ImageInfo pdfEndPoint = new ImageInfo(resource);
            ImageResponse response = pdfEndPoint.Process();

            bool pass = false;

            if (response.IsSuccessful)
            {
                File.WriteAllText(base.GetOutputFilePath("Output.json", InputSampleType), response.JsonContent);

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
        public void MultipleFormats_JsonOutput()
        {
            Name = "MultipleFormat";

            string[] images = { "DocumentA.tiff", "Northwind Logo.gif", "fw9_18.tif", "DPDFLogo.png", "DocumentA.jpg", "DocumentA.jpeg" };
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
