using System;
using System.IO;

namespace libalternativa.Alternativa.Formats.Tanki.A3D.A3D2;

class Submesh : IModelDataObject
{
    public int FaceCount;
    public int[] Indices { get; private set; } = Array.Empty<int>();
    public int[] SmoothingGroups { get; private set; } = Array.Empty<int>();
    public int MaterialID { get; private set; }

    public void Read(BinaryReader binaryReader)
    {
        FaceCount = binaryReader.ReadInt32();
        Indices = new int[FaceCount * 3];
        for (int indexI = 0; indexI < FaceCount * 3; indexI++)
        {
            int index = binaryReader.ReadUInt16();
            Indices[indexI] = index;
        }

        SmoothingGroups = new int[FaceCount];
        for (int smoothingGroupI = 0; smoothingGroupI < FaceCount; smoothingGroupI++)
        {
            int smoothingGroup = binaryReader.ReadInt32();
            SmoothingGroups[smoothingGroupI] = smoothingGroup;
        }

        MaterialID = binaryReader.ReadInt16();
    }

    public void Write(BinaryWriter binaryWriter)
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return String.Format("[Submesh FaceCount={0} Indices={1} SmoothingGroups={2} MaterialID={3}]", FaceCount, Indices.Length, SmoothingGroups.Length, MaterialID);
    }
}