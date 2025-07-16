using System;
using System.IO;
using System.Numerics;

namespace libalternativa.Alternativa.Formats.Tanki.A3D.A3D3;

class Transform : IModelDataObject
{
    public string Name { get; private set; } = "";
    public Vector3 Position { get; private set; }
    public Vector4 Rotation { get; private set; }
    public Vector3 Scale { get; private set; }

    public void Read(BinaryReader binaryReader)
    {
        Name = IOHelper.ReadLengthPrefixedString(binaryReader);
        Position = new()
        {
            X = binaryReader.ReadSingle(),
            Y = binaryReader.ReadSingle(),
            Z = binaryReader.ReadSingle()
        };
        Rotation = new()
        {
            X = binaryReader.ReadSingle(),
            Y = binaryReader.ReadSingle(),
            Z = binaryReader.ReadSingle(),
            W = binaryReader.ReadSingle()
        };
        Scale = new()
        {
            X = binaryReader.ReadSingle(),
            Y = binaryReader.ReadSingle(),
            Z = binaryReader.ReadSingle()
        };
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