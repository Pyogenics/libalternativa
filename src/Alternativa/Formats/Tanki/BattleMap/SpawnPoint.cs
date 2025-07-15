using System;
using System.IO;
using System.Numerics;
using libalternativa.Alternativa.Protocol;
using libalternativa.Utils;

namespace libalternativa.Alternativa.Formats.Tanki.BattleMap;

class SpawnPoint : IProtocolObject
{
    public Vector3 Position { get; private set; }
    public Vector3 Rotation { get; private set; }
    public int Type { get; private set; }

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
        Type = BigEndianHelper.ReadInt32BE(binaryReader);
    }

    public void Encode(BinaryWriter binaryWriter, OptionalMask optionalMask)
    {
        throw new System.NotImplementedException();
    }

    public override string ToString()
    {
        return String.Format("[SpawnPoint Position={0} Rotation={1} Type={2}]", Position, Rotation, Type);
    }
}
