
using System;

namespace DynamicPDF.Api
{
    internal class AdditionalResource : Resource
    {
        internal AdditionalResource(string resourcePath, string resourceName, ResourceType type) : base(resourcePath, resourceName)
        {
            Type = type;
        }

        internal AdditionalResource(byte[] resourceData, string resourceName, ResourceType type) : base(resourceData, resourceName)
        {
            Type = type;
        }

        internal override ResourceType Type { get; } = ResourceType.LayoutData;

        internal override string FileExtension
        {
            get
            {
                switch (Type)
                {
                    case ResourceType.Image:
                        byte[] fileHeader = new byte[16];
                        Array.Copy(Data, fileHeader, 16);
                        if (ImageResource.IsPngImage(fileHeader))
                        {
                            MimeType = "image/png";
                            return ".png";
                        }
                        else if (ImageResource.IsJpegImage(fileHeader))
                        {
                            MimeType = "image/jpeg";
                            return ".jpeg";
                        }
                        else if (ImageResource.IsGifImage(fileHeader))
                        {
                            MimeType = "image/gif";
                            return ".gif";
                        }
                        else if (ImageResource.IsTiffImage(fileHeader))
                        {
                            MimeType = "image/tiff";
                            return ".tiff";
                        }
                        else if (ImageResource.IsJpeg2000Image(fileHeader))
                        {
                            MimeType = "image/jpeg";
                            return ".jpeg";
                        }
                        else if (ImageResource.IsValidBitmapImage(fileHeader))
                        {
                            MimeType = "image/bmp";
                            return ".bmp";
                        }
                        else
                            throw new EndpointException("Not supported image type or invalid image.");
                    case ResourceType.Pdf:
                        MimeType = "application/pdf";
                        return ".pdf";
                    case ResourceType.LayoutData:
                        MimeType = "application/json";
                        return ".json";
                    case ResourceType.Dlex:
                        MimeType = "application/xml";
                        return ".dlex";
                    case ResourceType.Font:
                        if (Data[0] == 0x4f && Data[1] == 0x54 && Data[2] == 0x54 && Data[3] == 0x4f)
                        {
                            MimeType = "font/otf";
                            return ".otf";
                        }
                        else if (Data[0] == 0x00 && Data[1] == 0x01 && Data[2] == 0x00 && Data[3] == 0x00)
                        {
                            MimeType = "font/ttf";
                            return ".ttf";
                        }
                        else
                        {
                            throw new EndpointException("Unsupported font");
                        }

                }
                return null;
            }

        }

        internal override string MimeType { get; set; } = "";
    }
}
