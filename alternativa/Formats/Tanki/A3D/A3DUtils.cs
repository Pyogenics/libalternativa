using System.IO;
using System.Text;

namespace libalternativa.Formats.Tanki.A3D;

class A3DUtils
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
}
