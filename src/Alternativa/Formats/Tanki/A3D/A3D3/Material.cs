using System;
using System.IO;
using System.Numerics;

namespace libalternativa.Alternativa.Formats.Tanki.A3D.A3D3;

class Material : IModelDataObject
{
    public string Name = "";
    public Vector3 Color = new();
    public string DiffuseMap = "";

    public void Read(BinaryReader binaryReader)
    {
        Name = IOHelper.ReadLengthPrefixedString(binaryReader);
        Color.X = binaryReader.ReadSingle();
        Color.Y = binaryReader.ReadSingle();
        Color.Z = binaryReader.ReadSingle();
        DiffuseMap = IOHelper.ReadLengthPrefixedString(binaryReader);
    }

    public void Write(BinaryWriter binaryWriter)
    {
        throw new System.NotImplementedException();
    }

    public override string ToString()
    {
        return String.Format("[Material Name='{0}' Color={1} DiffuseMap='{2}']", Name, Color, DiffuseMap);
    }
}