using System;
using System.IO;
using System.IO.Compression;

namespace libalternativa.Alternativa.Protocol;

class PacketHelper
{
    public static byte[] UnwrapPacket(BinaryReader binaryReader)
    {
        int flags = binaryReader.ReadByte();
        int packetLength;
        if ((flags & 0b10000000) == 0)
        {
            // Short packet, last 6 bits of flags + 1 extra byte
            packetLength = binaryReader.ReadByte();
            packetLength += (flags & 0b00111111) << 8;
        }
        else
        {
            // Long packet, last 6 bits of flags + 3 extra bytes
            packetLength = (flags & 0b00111111) << 24;
            packetLength += binaryReader.ReadByte() << 16;
            packetLength += binaryReader.ReadByte() << 8;
            packetLength += binaryReader.ReadByte();
        }

        byte[] data = binaryReader.ReadBytes(packetLength);
        if ((flags & 0b01000000) > 0)
        {
            // Compressed packet
            using MemoryStream compressedStream = new(data);
            using DeflateStream deflateStream = new(compressedStream, CompressionMode.Decompress);
            using MemoryStream rawStream = new();
            deflateStream.CopyTo(rawStream);
            data = rawStream.ToArray();
        }

        return data;
    }
}
