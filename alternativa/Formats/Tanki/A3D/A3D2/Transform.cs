using System;
using System.IO;
using System.Numerics;

namespace libalternativa.Alternativa.Formats.Tanki.A3D.A3D2;

class Transform : IModelDataObject
{
    public Vector3 Position;
    public Vector4 Rotation;
    public Vector3 Scale;

    public void Read(BinaryReader binaryReader)
    {
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
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return String.Format("[Transform Position={0} Rotation={1} Scale={2}]", Position, Rotation, Scale);
    }
}
