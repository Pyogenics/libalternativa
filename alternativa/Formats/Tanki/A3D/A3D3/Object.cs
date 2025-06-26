using System;
using System.IO;

namespace libalternativa.Alternativa.Formats.Tanki.A3D.A3D3;

class Object : IModelDataObject
{
    public int MeshID;
    public int TransformID;
    public int MaterialCount;
    public int[] MaterialIDs = Array.Empty<int>();

    public void Read(BinaryReader binaryReader)
    {
        MeshID = binaryReader.ReadInt32();
        TransformID = binaryReader.ReadInt32();
        MaterialCount = binaryReader.ReadInt32();
        MaterialIDs = new int[MaterialCount];
        for (int materialI = 0; materialI < MaterialCount; materialI++)
        {
            MaterialIDs[materialI] = binaryReader.ReadInt32();
        }
    }

    public void Write(BinaryWriter binaryWriter)
    {
        throw new System.NotImplementedException();
    }

    public override string ToString()
    {
        return String.Format("[Object MeshID={0} TransformID={1} MaterialCount={2} MaterialIDs={3}]", MeshID, TransformID, MaterialCount, MaterialIDs.Length);
    }
}