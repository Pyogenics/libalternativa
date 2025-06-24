using System;
using System.IO;
using System.Numerics;

namespace libalternativa.Alternativa.Formats.Tanki.A3D;

class A3D2Material
{
    public string Name = "";
    public Vector3 Color = new();
    public string DiffuseMap = "";

    public void Read(BinaryReader binaryReader)
    {
        Name = A3DUtils.ReadNullTerminatedString(binaryReader);
        Color.X = binaryReader.ReadSingle();
        Color.Y = binaryReader.ReadSingle();
        Color.Z = binaryReader.ReadSingle();
        DiffuseMap = A3DUtils.ReadNullTerminatedString(binaryReader);
    }

    public override string ToString()
    {
        return String.Format("[A3D2Material Name='{0}' Color={1} DiffuseMap='{2}']", Name, Color, DiffuseMap);
    }
}
