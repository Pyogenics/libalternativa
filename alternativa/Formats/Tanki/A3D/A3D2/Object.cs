using System;
using System.IO;

namespace libalternativa.Alternativa.Formats.Tanki.A3D.A3D2;

class Object : IModelDataObject
{
    public string Name = "";
    public int MeshID;
    public int TransformID;

    public void Read(BinaryReader binaryReader)
    {
        Name = IOHelper.ReadNullTerminatedString(binaryReader);
        MeshID = binaryReader.ReadInt32();
        TransformID = binaryReader.ReadInt32();
    }

    public void Write(BinaryWriter binaryWriter)
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return String.Format("[Object Name='{0}' MeshID={1} TransformID={2}]", Name, MeshID, TransformID);
    }
}
