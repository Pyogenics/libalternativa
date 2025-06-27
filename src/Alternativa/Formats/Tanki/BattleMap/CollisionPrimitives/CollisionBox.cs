using System;
using System.IO;
using System.Numerics;
using libalternativa.Alternativa.Protocol;
using libalternativa.Utils;

namespace libalternativa.Alternativa.Formats.Tanki.BattleMap.CollisionPrimitives;

class CollisionBox : IProtocolObject
{
    public Vector3 Position = new();
    public Vector3 Rotation = new();
    public Vector3 Scale = new();

    public void Decode(BinaryReader binaryReader, OptionalMask optionalMask)
    {
        Position.X = BigEndianHelper.ReadSingleBE(binaryReader);
        Position.Y = BigEndianHelper.ReadSingleBE(binaryReader);
        Position.Z = BigEndianHelper.ReadSingleBE(binaryReader);

        Rotation.X = BigEndianHelper.ReadSingleBE(binaryReader);
        Rotation.Y = BigEndianHelper.ReadSingleBE(binaryReader);
        Rotation.Z = BigEndianHelper.ReadSingleBE(binaryReader);

        Scale.X = BigEndianHelper.ReadSingleBE(binaryReader);
        Scale.Y = BigEndianHelper.ReadSingleBE(binaryReader);
        Scale.Z = BigEndianHelper.ReadSingleBE(binaryReader);
    }

    public void Encode(BinaryWriter binaryWriter, OptionalMask optionalMask)
    {
        throw new System.NotImplementedException();
    }

    public override string ToString()
    {
        return String.Format("[CollisionBox Position={0} Rotation={1} Scale={2}]", Position, Rotation, Scale);
    }
}