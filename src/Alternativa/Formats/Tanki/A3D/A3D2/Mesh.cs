using System;
using System.IO;

namespace libalternativa.Alternativa.Formats.Tanki.A3D.A3D2;

class Mesh : IModelDataObject
{
    public VertexBuffer[] VertexBuffers { get; private set; } = Array.Empty<VertexBuffer>();
    public Submesh[] Submeshes { get; private set; } = Array.Empty<Submesh>();

    public void Read(BinaryReader binaryReader)
    {
        int vertexCount = binaryReader.ReadInt32();
        int vertexBufferCount = binaryReader.ReadInt32();
        VertexBuffers = new VertexBuffer[vertexBufferCount];
        for (int vertexBufferI = 0; vertexBufferI < vertexBufferCount; vertexBufferI++)
        {
            VertexBuffer vertexBuffer = new();
            vertexBuffer.Read(binaryReader, vertexCount);
            VertexBuffers[vertexBufferI] = vertexBuffer;
        }

        int submeshCount = binaryReader.ReadInt32();
        Submeshes = new Submesh[submeshCount];
        for (int submeshI = 0; submeshI < submeshCount; submeshI++)
        {
            Submesh submesh = new();
            submesh.Read(binaryReader);
            Submeshes[submeshI] = submesh;
        }
    }

    public void Write(BinaryWriter binaryWriter)
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return String.Format("[Mesh VertexBuffers={0} Submeshes={1}]", VertexBuffers.Length, Submeshes.Length);
    }

}
