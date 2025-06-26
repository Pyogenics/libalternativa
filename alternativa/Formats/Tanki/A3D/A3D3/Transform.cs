using System;
using System.IO;
using System.Numerics;

namespace libalternativa.Alternativa.Formats.Tanki.A3D.A3D3;

class Transform : IModelDataObject
{
    public string Name = "";
    public Vector3 Position = new();
    public Vector4 Rotation = new();
    public Vector3 Scale = new();

    public void Read(BinaryReader binaryReader)
    {
        Name = IOHelper.ReadLengthPrefixedString(binaryReader);

        Position.X = binaryReader.ReadSingle();
        Position.Y = binaryReader.ReadSingle();
        Position.Z = binaryReader.ReadSingle();

        Rotation.X = binaryReader.ReadSingle();
        Rotation.Y = binaryReader.ReadSingle();
        Rotation.Z = binaryReader.ReadSingle();
        Rotation.W = binaryReader.ReadSingle();

        Scale.X = binaryReader.ReadSingle();
        Scale.Y = binaryReader.ReadSingle();
        Scale.Z = binaryReader.ReadSingle();
    }

    public void Write(BinaryWriter binaryWriter)
    {
        throw new System.NotImplementedException();
    }

    public override string ToString()
    {
        return String.Format("[Transform Name='{0}' Position={1} Rotation={2} Scale={3}]", Name, Position, Rotation, Scale);
    }
}