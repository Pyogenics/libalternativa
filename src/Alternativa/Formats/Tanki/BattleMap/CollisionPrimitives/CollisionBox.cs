using System;
using System.IO;
using System.Numerics;
using libalternativa.Alternativa.Protocol;
using libalternativa.Utils;

namespace libalternativa.Alternativa.Formats.Tanki.BattleMap.CollisionPrimitives;

class CollisionBox : IProtocolObject
{
    public Vector3 Position { get; private set; }
    public Vector3 Rotation { get; private set; }
    public Vector3 Scale { get; private set; }

    public void Decode(BinaryReader binaryReader, OptionalMask optionalMask)
    {
        Position = new()
        {
            X = BigEndianHelper.ReadSingleBE(binaryReader),
            Y = BigEndianHelper.ReadSingleBE(binaryReader),
            Z = BigEndianHelper.ReadSingleBE(binaryReader)
        };
        Rotation = new()
        {
            X = BigEndianHelper.ReadSingleBE(binaryReader),
            Y = BigEndianHelper.ReadSingleBE(binaryReader),
            Z = BigEndianHelper.ReadSingleBE(binaryReader)
        };
        Scale = new()
        {
            X = BigEndianHelper.ReadSingleBE(binaryReader),
            Y = BigEndianHelper.ReadSingleBE(binaryReader),
            Z = BigEndianHelper.ReadSingleBE(binaryReader)
        };
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