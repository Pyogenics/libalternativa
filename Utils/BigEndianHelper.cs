using System;
using System.IO;

namespace libalternativa.Utils;

class BigEndianHelper
{
    public static int ReadInt32BE(BinaryReader binaryReader)
    {
        int i = binaryReader.ReadByte() << 24;
        i += binaryReader.ReadByte() << 16;
        i += binaryReader.ReadByte() << 8;
        i += binaryReader.ReadByte();
        return i;
    }

    public static int ReadInt16BE(BinaryReader binaryReader)
    {
        int i = binaryReader.ReadByte() << 8;
        i += binaryReader.ReadByte();
        return i;
    }

    public static float ReadSingleBE(BinaryReader binaryReader)
    {
        byte[] f = binaryReader.ReadBytes(4);
        Array.Reverse(f);
        return BitConverter.ToSingle(f);
    }

    public static double ReadDoubleBE(BinaryReader binaryReader)
    {
        byte[] d = binaryReader.ReadBytes(8);
        Array.Reverse(d);
        return BitConverter.ToDouble(d);
    }
}
