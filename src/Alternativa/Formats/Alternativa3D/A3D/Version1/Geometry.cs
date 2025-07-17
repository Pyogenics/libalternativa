using System;
using System.IO;
using libalternativa.Alternativa.Protocol;
using libalternativa.Utils;

namespace libalternativa.Alternativa.Formats.Alternativa3D.A3D.Version1;

class Geometry : IProtocolObject
{
    public int ID { get; private set; }
    public IndexBuffer IndexBuffer { get; private set; } = new();
    public VertexBuffer[] VertexBuffers { get; private set; } = Array.Empty<VertexBuffer>();

    public void Decode(BinaryReader binaryReader, OptionalMask optionalMask)
    {
        if (optionalMask.GetOptional())
            ID = BigEndianHelper.ReadInt32BE(binaryReader);
        if (optionalMask.GetOptional())
            IndexBuffer.Decode(binaryReader, optionalMask);
        if (optionalMask.GetOptional())
            VertexBuffers = ArrayHelper.ReadObjectArray<VertexBuffer>(binaryReader, optionalMask);
    }

    public void Encode(BinaryWriter binaryWriter, OptionalMask optionalMask)
    {
        throw new System.NotImplementedException();
    }
}