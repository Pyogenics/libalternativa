using System;
using System.IO;
using System.Numerics;

namespace libalternativa.Alternativa.Formats.Tanki.A3D.A3D3;

class Material : IModelDataObject
{
    public string Name { get; private set; } = "";
    public Vector3 Color { get; private set; }
    public string DiffuseMap { get; private set; } = "";

    public void Read(BinaryReader binaryReader)
    {
        Name = IOHelper.ReadLengthPrefixedString(binaryReader);
        Color = new()
        {
            X = binaryReader.ReadSingle(),
            Y = binaryReader.ReadSingle(),
            Z = binaryReader.ReadSingle()
        };
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