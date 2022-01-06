using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents an image resource used to create an <see cref="ImageInput"/> 
    /// object to create PDF from images.
    /// </summary>
    public class ImageResource : Resource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageResource"/> class.
        /// </summary>
        /// <param name="filePath">The image file path.</param>
        /// <param name="resourceName">The name of the resource.</param>
        public ImageResource(string filePath, string resourceName = null) : base(filePath, resourceName) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageResource"/> class.
        /// </summary>
        /// <param name="value">The byte array of the image file.</param>
        /// <param name="resourceName">The name of the resource.</param>
        public ImageResource(byte[] value, string resourceName = null) : base(value, resourceName) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageResource"/> class.
        /// </summary>
        /// <param name="data">The stream of the image file.</param>
        /// <param name="resourceName">The name of the resource.</param>
        public ImageResource(Stream data, string resourceName = null) : base(data, resourceName) { }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        internal override ResourceType Type { get; } = ResourceType.Image;

        internal override string MimeType { get; set; }

        internal override string FileExtension
        {
            get
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
        }

        internal static bool IsJpeg2000Image(byte[] header)
        {
            return (header[0] == 0x00 && header[1] == 0x00 && header[2] == 0x00 && header[3] == 0x0C && header[4] == 0x6A &&
                header[5] == 0x50 && (header[6] == 0x1A || header[6] == 0x20) && (header[7] == 0x1A || header[7] == 0x20) &&
                header[8] == 0x0D && header[9] == 0x0A && header[10] == 0x87 && header[11] == 0x0A) ||
                (header[0] == 0xFF && header[1] == 0x4F && header[2] == 0xFF && header[3] == 0x51 && header[6] == 0x00 && header[7] == 0x00);
        }

        internal static bool IsPngImage(byte[] header)
        {
            return header[0] == 0x89 && header[1] == 0x50 && header[2] == 0x4E && header[3] == 0x47 &&
                header[4] == 0x0D && header[5] == 0x0A && header[6] == 0x1A && header[7] == 0x0A;
        }

        internal static bool IsTiffImage(byte[] header)
        {
            return (header[0] == 0x49 && header[1] == 0x49 && header[2] == 0x2A && header[3] == 0x00) ||
                (header[0] == 0x4D && header[1] == 0x4D && header[2] == 0x00 && header[3] == 0x2A);
        }

        internal static bool IsGifImage(byte[] header)
        {
            return header[0] == 0x47 && header[1] == 0x49 && header[2] == 0x46 && header[3] == 0x38 && (header[4] == 0x37 || header[4] == 0x39) && header[5] == 0x61;
        }

        internal static bool IsJpegImage(byte[] header)
        {
            return header[0] == 0xFF && header[1] == 0xD8 && header[2] == 0xFF;
        }

        internal static bool IsValidBitmapImage(byte[] header)
        {
            return header[0] == 0x42 && header[1] == 0x4D;
        }
    }
}
