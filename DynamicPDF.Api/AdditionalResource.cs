
using System;
using System.IO;

namespace DynamicPDF.Api
{
    internal class AdditionalResource : Resource
    {
        internal AdditionalResource(string resourcePath, string resourceName) : base(resourcePath, resourceName)
        {
            Type = GetResourceType(resourcePath);
        }

        internal AdditionalResource(byte[] resourceData, string resourceName, ResourceType type) : base(resourceData, resourceName)
        {
            Type = type;
        }

        private ResourceType GetResourceType(string resourcePath)
        {
            ResourceType type = ResourceType.Pdf;
            string fileExtension = Path.GetExtension(resourcePath);
            switch(fileExtension)
            {
                case ".pdf":
                    type = ResourceType.Pdf;
                    break;
                case ".dlex":
                    type = ResourceType.Dlex;
                    break;
                case ".json":
                    type = ResourceType.LayoutData;
                    break;
                case ".ttf":
                case ".otf":
                    type = ResourceType.Font;
                    break;
                case ".tiff":
                case ".tif":
                case ".png":
                case ".gif":
                case ".jpeg":
                case ".jpg":
                case ".bmp":
                    type = ResourceType.Image;
                    break;
            }
            return type;
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
