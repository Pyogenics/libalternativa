using System;
using System.IO;

namespace libalternativa.Utils;

class BigEndianHelper
{
    public static long ReadInt64BE(BinaryReader binaryReader)
    {
        long l = binaryReader.ReadByte() << 56;
        l += binaryReader.ReadByte() << 48;
        l += binaryReader.ReadByte() << 40;
        l += binaryReader.ReadByte() << 32;
        l += binaryReader.ReadByte() << 24;
        l += binaryReader.ReadByte() << 16;
        l += binaryReader.ReadByte() << 8;
        l += binaryReader.ReadByte();
        return l;
    }

    public static int ReadInt32BE(BinaryReader binaryReader)
    {
        int i = binaryReader.ReadByte() << 24;
        i += binaryReader.ReadByte() << 16;
        i += binaryReader.ReadByte() << 8;
        i += binaryReader.ReadByte();
        return i;
    }

    public static short ReadInt16BE(BinaryReader binaryReader)
    {
        short s = (short)(binaryReader.ReadByte() << 8);
        s += binaryReader.ReadByte();
        return s;
    }

    public static ushort ReadUInt16BE(BinaryReader binaryReader)
    {
        ushort s = (ushort)(binaryReader.ReadByte() << 8);
        s += binaryReader.ReadByte();
        return s;
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
