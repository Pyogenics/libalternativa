using System;
using System.IO;

namespace libalternativa.Formats.Tanki.A3D;

class A3D2Mesh
{
    public A3DVertexBuffer[] VertexBuffers = Array.Empty<A3DVertexBuffer>();
    public A3D2Submesh[] Submeshes = Array.Empty<A3D2Submesh>();

    public void Read(BinaryReader binaryReader)
    {
        int vertexCount = binaryReader.ReadInt32();
        int vertexBufferCount = binaryReader.ReadInt32();
        VertexBuffers = new A3DVertexBuffer[vertexBufferCount];
        for (int vertexBufferI = 0; vertexBufferI < vertexBufferCount; vertexBufferI++)
        {
            A3DVertexBuffer vertexBuffer = new();
            vertexBuffer.Read(binaryReader, vertexCount);
            VertexBuffers[vertexBufferI] = vertexBuffer;
        }

        int submeshCount = binaryReader.ReadInt32();
        Submeshes = new A3D2Submesh[submeshCount];
        for (int submeshI = 0; submeshI < submeshCount; submeshI++)
        {
            A3D2Submesh submesh = new();
            submesh.Read(binaryReader);
            Submeshes[submeshI] = submesh;
        }
    }

    public override string ToString()
    {
        return String.Format("[A3D2Mesh VertexBuffers={0} Submeshes={1}]", VertexBuffers.Length, Submeshes.Length);
    }
}
