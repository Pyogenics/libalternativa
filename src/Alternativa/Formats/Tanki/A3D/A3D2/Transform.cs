using System;
using System.IO;
using System.Numerics;

namespace libalternativa.Alternativa.Formats.Tanki.A3D.A3D2;

class Transform : IModelDataObject
{
    public Vector3 Position { get; private set; }
    public Vector4 Rotation { get; private set; }
    public Vector3 Scale { get; private set; }

    public void Read(BinaryReader binaryReader)
    {
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
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return String.Format("[Transform Position={0} Rotation={1} Scale={2}]", Position, Rotation, Scale);
    }
}
