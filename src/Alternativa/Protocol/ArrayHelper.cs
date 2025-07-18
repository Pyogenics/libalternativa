using System;
using System.IO;
using libalternativa.Utils;

namespace libalternativa.Alternativa.Protocol;

class ArrayHelper
{
    public static int ReadLength(BinaryReader binaryReader)
    {
        int length;
        int flags = binaryReader.ReadByte();
        if ((flags & 0b10000000) == 0)
        {
            // Short array, length in last 7 bits of flags (first bit is already 0 so we can just return the flags as length)
            length = flags;
        }
        else
        {
            // Long array, length in last 6 bits of flags + upto 2 extra bytes
            if ((flags & 0b01000000) == 0)
            {
                // 1 extra byte
                length = (flags & 0b00111111) << 8;
                length += binaryReader.ReadByte();
            }
            else
            {
                // 2 extra bytes
                length = (flags & 0b00111111) << 16;
                length += binaryReader.ReadByte() << 8;
                length += binaryReader.ReadByte();
            }
        }
        return length;
    }

    public static T[] ReadObjectArray<T>(BinaryReader binaryReader, OptionalMask optionalMask) where T : IProtocolObject, new()
    {
        int length = ReadLength(binaryReader);
        T[] objects = new T[length];
        for (int objectI = 0; objectI < length; objectI++)
        {
            T obj = new();
            obj.Decode(binaryReader, optionalMask);
            objects[objectI] = obj;
        }
        return objects;
    }

    public static string ReadString(BinaryReader binaryReader)
    {
        int length = ReadLength(binaryReader);
        byte[] str = binaryReader.ReadBytes(length);
        return System.Text.Encoding.UTF8.GetString(str);
    }

    public static byte[] ReadByteArray(BinaryReader binaryReader)
    {
        int length = ReadLength(binaryReader);
        byte[] bytes = binaryReader.ReadBytes(length);

        return bytes;
    }

    public static float[] ReadFloatArrayBE(BinaryReader binaryReader)
    {
        int length = ReadLength(binaryReader);
        float[] floats = new float[length];
        for (int floatI = 0; floatI < length; floatI++)
        {
            floats[floatI] = BigEndianHelper.ReadSingleBE(binaryReader);
        }

        return floats;
    }

    public static long[] ReadInt64ArrayBE(BinaryReader binaryReader)
    {
        int length = ReadLength(binaryReader);
        long[] longs = new long[length];
        for (long longI = 0; longI < length; longI++)
        {
            longs[longI] = BigEndianHelper.ReadInt64BE(binaryReader);
        }

        return longs;
    }

    public static int[] ReadInt32ArrayBE(BinaryReader binaryReader)
    {
        int length = ReadLength(binaryReader);
        int[] ints = new int[length];
        for (int intI = 0; intI < length; intI++)
        {
            ints[intI] = BigEndianHelper.ReadInt32BE(binaryReader);
        }

        return ints;
    }

}
