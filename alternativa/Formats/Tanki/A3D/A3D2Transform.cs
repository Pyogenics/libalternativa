using System;
using System.IO;
using System.Numerics;

namespace libalternativa.Formats.Tanki.A3D;

class A3D2Transform
{
    public Vector3 Position;
    public Vector4 Rotation;
    public Vector3 Scale;

    public void Read(BinaryReader binaryReader)
    {
        float positionX = binaryReader.ReadSingle();
        float positionY = binaryReader.ReadSingle();
        float positionZ = binaryReader.ReadSingle();
        Position = new(positionX, positionY, positionZ);
        float rotationX = binaryReader.ReadSingle();
        float rotationY = binaryReader.ReadSingle();
        float rotationZ = binaryReader.ReadSingle();
        float rotationW = binaryReader.ReadSingle();
        Rotation = new(rotationX, rotationY, rotationZ, rotationW);
        float scaleX = binaryReader.ReadSingle();
        float scaleY = binaryReader.ReadSingle();
        float scaleZ = binaryReader.ReadSingle();
        Scale = new(scaleX, scaleY, scaleZ);
    }

    public override string ToString()
    {
        return String.Format("[A3D2Transform Position={0} Rotation={1} Scale={2}]", Position, Rotation, Scale);
    }
}
