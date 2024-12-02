using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DynamicPDF.Api.Imaging
{
    /// <summary>
    /// Represents a PDF Rasterizing endpoint that converts PDF to image.
    /// </summary>
    public class PdfImage : Endpoint
    {
        /// <summary>
        /// Represents a <see cref="PdfResource"/> for converting PDF pages to images.
        /// </summary>
        public PdfResource resource { get; }

        /// <summary>
        /// Gets or sets the starting page number for rasterization.
        /// </summary>
        public int? StartPageNumber { get; set; }

        /// <summary>
        /// Gets or sets the number of pages to rasterize.
        /// </summary>
        public int? PageCount { get; set; }

        /// <summary>
        /// Gets or sets the image format for rasterization.
        /// </summary>
        public ImageFormat ImageFormat { get; set; } = null;

        /// <summary>
        /// Gets or sets the size of the rasterized images.
        /// </summary>
        public ImageSize ImageSize { get; set; } = null;

        /// <summary>
        /// Gets the name of the endpoint used for rasterization.
        /// </summary>
        internal override string EndpointName { get; } = "pdf-image";

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfImage"/> class with the specified PDF resource.
        /// </summary>
        /// <param name="resource">The PDF resource to rasterize.</param>
        public PdfImage(PdfResource resource)
        {
            this.resource = resource;
        }

        /// <summary>
        /// Process the PDF to create Images as per the given data.
        /// </summary>
        public PdfImageResponse Process()
        {
            var task = ProcessAsync();
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Process the PDF to create Images as per the given data.
        /// </summary>
        /// Returns collection of <see cref="ImageResponse"/> tasks.
        public Task<PdfImageResponse> ProcessAsync()
        {
            var request = base.CreateRestRequest();
            request.AddHeader("Content-Type", "multipart/form-data");
            request.AlwaysMultipartFormData = true;

            if (StartPageNumber.HasValue)
                request.AddQueryParameter("sp", StartPageNumber.Value.ToString());
            if (PageCount.HasValue)
                request.AddQueryParameter("pc", PageCount.Value.ToString());

            if (ImageSize != null)
            {
                if (ImageSize is DpiImageSize dpi)
                {
                    request.AddQueryParameter("is", dpi.Type.ToString());
                    if (dpi.HorizontalDpi.HasValue)
                        request.AddQueryParameter("hd", dpi.HorizontalDpi.Value.ToString());
                    if (dpi.VerticalDpi.HasValue)
                        request.AddQueryParameter("vd", dpi.VerticalDpi.Value.ToString());
                }
                else if (ImageSize is FixedImageSize fixedSize)
                {
                    request.AddQueryParameter("is", fixedSize.Type.ToString());
                    if (fixedSize.Height.HasValue)
                        request.AddQueryParameter("ht", fixedSize.Height.Value.ToString());
                    if (fixedSize.Width.HasValue)
                        request.AddQueryParameter("wd", fixedSize.Width.Value.ToString());
                    if (fixedSize.Unit.HasValue)
                        request.AddQueryParameter("ut", fixedSize.Unit.Value.ToString());
                }
                else if (ImageSize is MaxImageSize maxSize)
                {
                    request.AddQueryParameter("is", maxSize.Type.ToString());
                    if (maxSize.MaxHeight.HasValue)
                        request.AddQueryParameter("mh", maxSize.MaxHeight.Value.ToString());
                    if (maxSize.MaxWidth.HasValue)
                        request.AddQueryParameter("mw", maxSize.MaxWidth.Value.ToString());
                    if (maxSize.Unit.HasValue)
                        request.AddQueryParameter("ut", maxSize.Unit.Value.ToString());
                }
                else if (ImageSize is PercentageImageSize percent)
                {
                    request.AddQueryParameter("is", percent.Type.ToString());
                    if (percent.HorizontalPercentage.HasValue)
                        request.AddQueryParameter("hp", percent.HorizontalPercentage.Value.ToString());
                    if (percent.VerticalPercentage.HasValue)
                        request.AddQueryParameter("vp", percent.VerticalPercentage.Value.ToString());
                }
            }

            if (ImageFormat != null)
            {
                if (ImageFormat is GifImageFormat gif)
                {
                    request.AddQueryParameter("if", gif.Type.ToString());
                    if (gif.DitheringPercent.HasValue)
                        request.AddQueryParameter("dp", gif.DitheringPercent.Value.ToString());
                    if (gif.DitheringAlgorithm != null)
                        request.AddQueryParameter("da", gif.DitheringAlgorithm.Value.ToString());
                }
                else if (ImageFormat is JpegImageFormat jpeg)
                {
                    request.AddQueryParameter("if", jpeg.Type.ToString());
                    if (jpeg.Quality.HasValue)
                        request.AddQueryParameter("qt", jpeg.Quality.Value.ToString());
                }
                else if (ImageFormat is PngImageFormat png)
                {
                    request.AddQueryParameter("if", png.Type.ToString());
                    if (png.ColorFormat != null)
                    {
                        request.AddQueryParameter("cf", png.ColorFormat.Type.ToString());
                        if (png.ColorFormat is PngIndexedColorFormat pngicf)
                        {
                            if (pngicf.DitheringAlgorithm.HasValue)
                                request.AddQueryParameter("da", pngicf.DitheringAlgorithm.Value.ToString());
                            if (pngicf.DitheringPercent.HasValue)
                                request.AddQueryParameter("dp", pngicf.DitheringPercent.Value.ToString());
                            if (pngicf.QuantizationAlgorithm.HasValue)
                                request.AddQueryParameter("qa", pngicf.QuantizationAlgorithm.Value.ToString());
                        }
                        else if (png.ColorFormat is PngMonochromeColorFormat pngmccf)
                        {
                            if (pngmccf.BlackThreshold.HasValue)
                                request.AddQueryParameter("bt", pngmccf.BlackThreshold.Value.ToString());
                            if (pngmccf.DitheringAlgorithm.HasValue)
                                request.AddQueryParameter("da", pngmccf.DitheringAlgorithm.Value.ToString());
                            if (pngmccf.DitheringPercent.HasValue)
                                request.AddQueryParameter("dp", pngmccf.DitheringPercent.Value.ToString());
                        }
                    }
                }
                else if (ImageFormat is TiffImageFormat tiff)
                {
                    request.AddQueryParameter("if", tiff.Type.ToString());
                    if (tiff.MultiPage)
                        request.AddQueryParameter("mp", "true");
                    if (tiff.ColorFormat != null)
                    {
                        request.AddQueryParameter("cf", tiff.ColorFormat.Type.ToString());
                        if (tiff.ColorFormat is TiffIndexedColorFormat tifficf)
                        {
                            if (tifficf.DitheringAlgorithm.HasValue)
                                request.AddQueryParameter("da", tifficf.DitheringAlgorithm.Value.ToString());
                            if (tifficf.DitheringPercent.HasValue)
                                request.AddQueryParameter("dp", tifficf.DitheringPercent.Value.ToString());
                            if (tifficf.QuantizationAlgorithm.HasValue)
                                request.AddQueryParameter("qa", tifficf.QuantizationAlgorithm.Value.ToString());
                        }
                        else if (tiff.ColorFormat is TiffMonochromeColorFormat tiffmccf)
                        {
                            if (tiffmccf.CompressionType.HasValue)
                                request.AddQueryParameter("ct", tiffmccf.CompressionType.Value.ToString());
                            if (tiffmccf.BlackThreshold.HasValue)
                                request.AddQueryParameter("bt", tiffmccf.BlackThreshold.Value.ToString());
                            if (tiffmccf.DitheringAlgorithm.HasValue)
                                request.AddQueryParameter("da", tiffmccf.DitheringAlgorithm.Value.ToString());
                            if (tiffmccf.DitheringPercent.HasValue)
                                request.AddQueryParameter("dp", tiffmccf.DitheringPercent.Value.ToString());
                        }
                    }
                }
                else if (ImageFormat is BmpImageFormat bmp)
                {
                    request.AddQueryParameter("if", bmp.Type.ToString());
                    if (bmp.ColorFormat != null)
                    {
                        request.AddQueryParameter("cf", bmp.ColorFormat.Type.ToString());
                        if (bmp.ColorFormat is BmpMonochromeColorFormat bmpmcf)
                        {
                            if(bmpmcf.BlackThreshold.HasValue)
                                request.AddQueryParameter("bt", bmpmcf.BlackThreshold.Value.ToString());
                            if (bmpmcf.DitheringPercent.HasValue)
                                request.AddQueryParameter("dp", bmpmcf.DitheringPercent.Value.ToString());
                            if (bmpmcf.DitheringAlgorithm.HasValue)
                                request.AddQueryParameter("da", bmpmcf.DitheringAlgorithm.Value.ToString());
                        }
                        
                    }
                }
            }

            RestClient restClient = base.Client;

            return Task<PdfImageResponse>.Run(() =>
            {
                PdfImageResponse response = new PdfImageResponse();
                if (resource == null) throw new EndpointException("Required a pdf Resource.");

                request.AddFile("pdf", resource.Data, resource.ResourceName, resource.MimeType);

                IRestResponse restResponse = restClient.Post(request);
                if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string jsonString = restResponse.Content;
                    response = JsonConvert.DeserializeObject<PdfImageResponse>(jsonString);

                    string imageType = response.ContentType;
                    response.ImageFormat = imageType.Substring(imageType.IndexOf('/') + 1);
                    response.IsSuccessful = true;
                    response.StatusCode = restResponse.StatusCode;
                }
                else
                {
                    if (restResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        throw new EndpointException("Invalid api key specified.");
                    }
                    string errorMessage = string.Empty;
                    string errorId = string.Empty;
                    var errorJson = JsonConvert.DeserializeObject<Dictionary<string, string>>(restResponse.Content);
                    errorJson.TryGetValue("message", out errorMessage);
                    errorJson.TryGetValue("id", out errorId);
                    if (errorId != string.Empty)
                        response.ErrorId = new Guid(errorId);
                    response.ErrorJson = restResponse.Content;
                    response.ErrorMessage = errorMessage;
                    response.IsSuccessful = false;
                    response.StatusCode = restResponse.StatusCode;
                }
                return response;
            });
        }
    }
}