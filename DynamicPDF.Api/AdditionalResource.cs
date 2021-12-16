
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
                if (Type == ResourceType.Image)
                {
                    byte[] fileHeader = new byte[16];
                    Array.Copy(Data, fileHeader, 16);
                    if (IsPngImage(fileHeader))
                    {
                        MimeType = "image/png";
                        return ".png";
                    }
                    else if (IsJpegImage(fileHeader))
                    {
                        MimeType = "image/jpeg";
                        return ".jpeg";
                    }
                    else if (IsGifImage(fileHeader))
                    {
                        MimeType = "image/gif";
                        return ".gif";
                    }
                    else if (IsTiffImage(fileHeader))
                    {
                        MimeType = "image/tiff";
                        return ".tiff";
                    }
                    else if (IsJpeg2000Image(fileHeader))
                    {
                        MimeType = "image/jpeg";
                        return ".jpeg";
                    }
                    else if (IsValidBitmapImage(fileHeader))
                    {
                        MimeType = "image/bmp";
                        return ".bmp";
                    }
                    else
                        throw new EndpointException("Not supported image type or invalid image.");
                }
                else if (Type == ResourceType.Pdf)
                {
                    MimeType = "application/pdf";
                    return ".pdf";
                }
                else if (Type == ResourceType.LayoutData)
                {
                    MimeType = "application/json";
                    return ".json";
                }
                else if (Type == ResourceType.Dlex)
                {
                    MimeType = "application/xml";
                    return ".dlex";
                }
                else if (Type == ResourceType.Font)
                {
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


        private static bool IsJpeg2000Image(byte[] header)
        {
            return (header[0] == 0x00 && header[1] == 0x00 && header[2] == 0x00 && header[3] == 0x0C && header[4] == 0x6A &&
                header[5] == 0x50 && (header[6] == 0x1A || header[6] == 0x20) && (header[7] == 0x1A || header[7] == 0x20) &&
                header[8] == 0x0D && header[9] == 0x0A && header[10] == 0x87 && header[11] == 0x0A) ||
                (header[0] == 0xFF && header[1] == 0x4F && header[2] == 0xFF && header[3] == 0x51 && header[6] == 0x00 && header[7] == 0x00);
        }

        private static bool IsPngImage(byte[] header)
        {
            return header[0] == 0x89 && header[1] == 0x50 && header[2] == 0x4E && header[3] == 0x47 &&
                header[4] == 0x0D && header[5] == 0x0A && header[6] == 0x1A && header[7] == 0x0A;
        }

        private static bool IsTiffImage(byte[] header)
        {
            return (header[0] == 0x49 && header[1] == 0x49 && header[2] == 0x2A && header[3] == 0x00) ||
                (header[0] == 0x4D && header[1] == 0x4D && header[2] == 0x00 && header[3] == 0x2A);
        }

        private static bool IsGifImage(byte[] header)
        {
            return header[0] == 0x47 && header[1] == 0x49 && header[2] == 0x46 && header[3] == 0x38 && (header[4] == 0x37 || header[4] == 0x39) && header[5] == 0x61;
        }

        private static bool IsJpegImage(byte[] header)
        {
            return header[0] == 0xFF && header[1] == 0xD8 && header[2] == 0xFF;
        }

        private static bool IsValidBitmapImage(byte[] header)
        {
            return header[0] == 0x42 && header[1] == 0x4D;
        }

        internal override string MimeType { get; set; } = "";
    }
}
