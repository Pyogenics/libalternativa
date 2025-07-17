using System;
using System.IO;
using libalternativa.Alternativa.Protocol;
using libalternativa.Utils;

namespace libalternativa.Alternativa.Formats.Alternativa3D.A3D.Version1;

class VertexBuffer : IProtocolObject
{
    public byte[] Attributes { get; private set; } = Array.Empty<byte>();
    public byte[] VertexData { get; private set; } = Array.Empty<byte>();
    public int VertexCount { get; private set; }

    public void Decode(BinaryReader binaryReader, OptionalMask optionalMask)
    {
        if (optionalMask.GetOptional())
            Attributes = ArrayHelper.ReadByteArray(binaryReader);
        if (optionalMask.GetOptional())
            VertexData = ArrayHelper.ReadByteArray(binaryReader);
        VertexCount = BigEndianHelper.ReadInt16BE(binaryReader);
    }

    public void Encode(BinaryWriter binaryWriter, OptionalMask optionalMask)
    {
        throw new System.NotImplementedException();
    }
}