using System;
using System.IO;
using System.Numerics;

namespace libalternativa.Formats.Tanki.A3D;

class A3D2Material
{
    public string Name = "";
    public Vector3 Color;
    public string DiffuseMap = "";

    public void Read(BinaryReader binaryReader)
    {
        Name = A3DUtils.ReadNullTerminatedString(binaryReader);
        float colorR = binaryReader.ReadSingle();
        float colorG = binaryReader.ReadSingle();
        float colorB = binaryReader.ReadSingle();
        Color = new(colorR, colorG, colorB);
        DiffuseMap = A3DUtils.ReadNullTerminatedString(binaryReader);
    }

    public override string ToString()
    {
        return String.Format("[A3D2Material Name='{0}' Color={1} DiffuseMap='{2}']", Name, Color, DiffuseMap);
    }
}
