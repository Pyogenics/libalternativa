using System.IO;
using System.Text;

namespace libalternativa.Alternativa.Formats.Tanki.A3D;

class IOHelper
{
    public static string ReadNullTerminatedString(BinaryReader binaryReader)
    {
        StringBuilder stringBuilder = new();

        char c = binaryReader.ReadChar();
        while (c != '\0')
        {
            stringBuilder.Append(c);
            c = binaryReader.ReadChar();
        }

        return stringBuilder.ToString();
    }

    public static string ReadLengthPrefixedString(BinaryReader binaryReader)
    {
        StringBuilder stringBuilder = new();

        int length = binaryReader.ReadInt32();
        char[] chars = binaryReader.ReadChars(length);
        stringBuilder.Append(chars);

        // Padding
        int paddingSize = CalculatePaddingSize(length);
        binaryReader.ReadBytes(paddingSize);

        return stringBuilder.ToString();
    }

    public static int CalculatePaddingSize(int dataLength)
    {
        return (((dataLength + 3) / 4) * 4) - dataLength;
    }
}
