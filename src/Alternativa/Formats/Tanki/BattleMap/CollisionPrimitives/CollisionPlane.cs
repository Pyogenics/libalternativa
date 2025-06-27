using System;
using System.IO;
using System.Numerics;
using libalternativa.Alternativa.Protocol;
using libalternativa.Utils;

namespace libalternativa.Alternativa.Formats.Tanki.BattleMap.CollisionPrimitives;

class CollisionPlane : IProtocolObject
{
    public double Length;
    public Vector3 Position = new();
    public Vector3 Rotation = new();
    public double Width;

    public void Decode(BinaryReader binaryReader, OptionalMask optionalMask)
    {
        Length = BigEndianHelper.ReadDoubleBE(binaryReader);

        Position.X = BigEndianHelper.ReadSingleBE(binaryReader);
        Position.Y = BigEndianHelper.ReadSingleBE(binaryReader);
        Position.Z = BigEndianHelper.ReadSingleBE(binaryReader);

        Rotation.X = BigEndianHelper.ReadSingleBE(binaryReader);
        Rotation.Y = BigEndianHelper.ReadSingleBE(binaryReader);
        Rotation.Z = BigEndianHelper.ReadSingleBE(binaryReader);

        Width = BigEndianHelper.ReadDoubleBE(binaryReader);
    }

    public void Encode(BinaryWriter binaryWriter, OptionalMask optionalMask)
    {
        throw new System.NotImplementedException();
    }

    public override string ToString()
    {
        return String.Format("[CollisionPlane Position={0} Rotation={1} Length={2} Width={3}]", Position, Rotation, Length, Width);
    }
}