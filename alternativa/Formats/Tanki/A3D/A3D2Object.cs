using System;
using System.IO;

namespace libalternativa.Alternativa.Formats.Tanki.A3D;

class A3D2Object
{
    public string Name = "";
    public int MeshID;
    public int TransformID;

    public void Read(BinaryReader binaryReader)
    {
        Name = A3DUtils.ReadNullTerminatedString(binaryReader);
        MeshID = binaryReader.ReadInt32();
        TransformID = binaryReader.ReadInt32();
    }

    public override string ToString()
    {
        return String.Format("[A3D2Object Name='{0}' MeshID={1} TransformID={2}]", Name, MeshID, TransformID);
    }
}
