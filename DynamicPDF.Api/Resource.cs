using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;
using System.Text;

namespace DynamicPDF.Api
{
    /// <summary>
    /// Represents the base class resource.
    /// </summary>
    public abstract class Resource
    {
        internal Resource() { }

        internal Resource(string filePath, string resourceName)
        {
            if (File.Exists(filePath))
            {
                Data = Resource.GetFileData(filePath);
                FilePath = filePath;
            }
            else
                throw new EndpointException("File does not exist.");

            if (resourceName != null)
                ResourceName = resourceName;

            if (resourceName == null)
                ResourceName = Guid.NewGuid().ToString() + FileExtension;
        }

        internal Resource(byte[] value, string resourceName)
        {
            if (value.Length > 0)
                Data = value;
            else
                throw new EndpointException("Byte array is empty.");

            ResourceName = resourceName;

            if (resourceName == null)
                ResourceName = Guid.NewGuid().ToString() + FileExtension;
        }

        internal Resource(Stream steam, string resourceName)
        {
            if (steam != null)
                Data = Resource.GetSteamData(steam);
            else
                throw new EndpointException("Stream is null.");

            ResourceName = resourceName;

            if (resourceName == null)
                ResourceName = Guid.NewGuid().ToString() + FileExtension;
        }

        internal string FilePath { get; set; }

        internal byte[] Data { get; set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]

        internal abstract ResourceType Type { get; }

        internal abstract string FileExtension { get; }

        internal abstract string MimeType { get; set; }

        /// <summary>
        /// Gets or sets the resource name.
        /// </summary>
        /// <remarks>For word resources, the resource name should be specified with a file extension.</remarks>
        public virtual string ResourceName { get; set; }

        internal static byte[] GetSteamData(Stream stream)
        {
            byte[] data = null;
            if (stream != null && stream.Length > 0)
            {
                data = new byte[stream.Length - stream.Position];
                stream.Read(data, (int)stream.Position, data.Length);
            }
            return data;
        }
        internal static byte[] GetUTF8FileData(string filePath)
        {
            return Encoding.UTF8.GetBytes(File.ReadAllText(filePath));
        }

        internal static byte[] GetFileData(string filePath)
        {
            byte[] data = null;
            using (MemoryStream ms = new MemoryStream())
            using (FileStream fs = File.OpenRead(filePath))
            {
                fs.Position = 0;
                fs.CopyTo(ms);
                data = ms.ToArray();
            }
            return data;
        }
    }
}
