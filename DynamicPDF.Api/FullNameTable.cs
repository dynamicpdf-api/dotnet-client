using System.Text;
using System.IO;

namespace DynamicPDF.Api
{
    internal class FullNameTable
    {
        private static Encoding objUnicode = Encoding.BigEndianUnicode;
        private string fullFontName = string.Empty;
        private byte[] data;
        private byte[] tableDirectory;

        internal FullNameTable(Stream reader, byte[] tableDirectory, int position)
        {
            if (tableDirectory != null)
            {
                this.tableDirectory = tableDirectory;

                int intOffset = ReadULong(tableDirectory, position + 8);
                int intLength = ReadULong(tableDirectory, position + 12);

                data = new byte[intLength];

                reader.Seek(intOffset, SeekOrigin.Begin);
                reader.Read(data, 0, intLength);
            }

            int dataStart = ReadUShort(4);
            int headerStart = 6;
            int headerEnd = (ReadUShort(2) * 12);

            for (int i = headerStart; i < headerEnd; i += 12)
            {
                if (ReadUShort(i + 6) == 4) //4 is the Name ID for Full font name 
                {
                    if (ReadUShort(i) == 3 && ReadUShort(i + 2) == 1 && ReadUShort(i + 4) == 0x0409) //3 for PlatForm ID, 1 for Encoding ID and 0x0409 Language ID for English(United States)
                    {
                        fullFontName = objUnicode.GetString(data, dataStart + ReadUShort(i + 10), ReadUShort(i + 8)).Trim().Replace(" ", string.Empty);
                        fullFontName = fullFontName.Replace("-", string.Empty);
                        break;
                    }
                }
            }

            if (fullFontName.Length == 0)
            {
                for (int i = headerStart; i < headerEnd; i += 12)
                {
                    if (ReadUShort(i + 6) == 4) //4 is the Name ID for Full font name 
                    {
                        if (ReadUShort(i) == 3 && ReadUShort(i + 2) == 0 && ReadUShort(i + 4) == 0x0409) //3 for PlatForm ID, 0 for Encoding ID and 0x0409 Language ID for English(United States)
                        {
                            fullFontName = objUnicode.GetString(data, dataStart + ReadUShort(i + 10), ReadUShort(i + 8)).Trim().Replace(" ", string.Empty);
                            fullFontName = fullFontName.Replace("-", string.Empty);
                            break;
                        }
                    }
                }
            }

            data = null;
        }

        internal string FontName
        {
            get { return fullFontName; }
        }

        private int ReadULong(byte[] data, int index)
        {
            int intReturn = data[index++];
            intReturn *= 0x100;
            intReturn += data[index++];
            intReturn *= 0x100;
            intReturn += data[index++];
            intReturn *= 0x100;
            intReturn += data[index];
            return intReturn;
        }

        private int ReadULong(int index)
        {
            return ReadULong(data, index);
        }

        private int ReadUShort(int index)
        {
            return (int)(data[index++] << 8 | data[index]);
        }

        private int ReadUShort1(int index)
        {
            return (int)(data[index++] | data[index] << 8);
        }

        private int ReadShort(int index)
        {
            return (int)(data[index++] << 8 | data[index]);
        }

        private int ReadByte(int index)
        {
            return data[index++];
        }

        private float ReadFixed(int index)
        {
            int intInteger = data[index++];
            if (intInteger > 127) intInteger -= 256;
            intInteger *= 0x100;
            intInteger += data[index++];
            intInteger *= 0x100;
            intInteger += data[index++];
            intInteger *= 0x100;
            intInteger += data[index];
            return intInteger / 0x10000;
        }

        private short ReadFWord(int index)
        {
            short intReturn = data[index++];
            if (intReturn > 127) intReturn -= 256;
            intReturn *= 0x100;
            intReturn += data[index];
            return intReturn;
        }
    }
}
