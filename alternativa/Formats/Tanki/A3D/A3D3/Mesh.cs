using System;
using System.IO;
using System.Numerics;

namespace libalternativa.Alternativa.Formats.Tanki.A3D.A3D3;

class Mesh : IModelDataObject
{
    public string Name = "";
    public Vector3 BBoxMax = new();
    public Vector3 BBoxMin = new();
    public float Unknown;
    public VertexBuffer[] VertexBuffers = Array.Empty<VertexBuffer>();
    public Submesh[] Submeshes = Array.Empty<Submesh>();

    public void Read(BinaryReader binaryReader)
    {
        Name = IOHelper.ReadLengthPrefixedString(binaryReader);

        BBoxMax.X = binaryReader.ReadSingle();
        BBoxMax.Y = binaryReader.ReadSingle();
        BBoxMax.Z = binaryReader.ReadSingle();
        BBoxMin.X = binaryReader.ReadSingle();
        BBoxMin.Y = binaryReader.ReadSingle();
        BBoxMin.Z = binaryReader.ReadSingle();
        Unknown = binaryReader.ReadSingle(); // Unknown float value, related to bbox?

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
        throw new System.NotImplementedException();
    }
    
    public override string ToString()
    {
        return String.Format("[Mesh Name='{0}' BBoxMax={1} BBoxMin={2} VertexBuffers={3} Submeshes={4} Unknown={5}]", Name, BBoxMax, BBoxMin, VertexBuffers.Length, Submeshes.Length, Unknown);
    }
}
