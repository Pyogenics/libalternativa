using System;
using System.IO;

namespace libalternativa.Alternativa.Formats.Tanki.A3D.A3D3;

class Submesh : IModelDataObject
{
    public int IndexCount { get; private set; }
    public int[] Indices { get; private set; } = Array.Empty<int>();

    public void Read(BinaryReader binaryReader)
    {
        IndexCount = binaryReader.ReadInt32();
        Indices = new int[IndexCount];
        for (int indexI = 0; indexI < IndexCount; indexI++)
        {
            int index = binaryReader.ReadInt16();
            Indices[indexI] = index;
        }

        // Padding
        int paddingSize = IOHelper.CalculatePaddingSize(IndexCount * 2); // 2 bytes per index
        binaryReader.ReadBytes(paddingSize);
    }

    public void Write(BinaryWriter binaryWriter)
    {
        throw new System.NotImplementedException();
    }

    public override string ToString()
    {
        return String.Format("[Submesh IndexCount={0} Indices={1}]", IndexCount, Indices.Length);
    }
}