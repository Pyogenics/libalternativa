using System;
using System.IO;
using System.Numerics;
using libalternativa.Alternativa.Protocol;
using libalternativa.Utils;

namespace libalternativa.Alternativa.Formats.Tanki.BattleMap;

class Batch : IProtocolObject
{
    public int MaterialID { get; private set; }
    public string Name { get; private set; } = "";
    public Vector3 Position { get; private set; }
    public string PropIDs { get; private set; } = "";

    public void Decode(BinaryReader binaryReader, OptionalMask optionalMask)
    {
        MaterialID = BigEndianHelper.ReadInt32BE(binaryReader);
        Name = ArrayHelper.ReadString(binaryReader);
        Position = new()
        {
            X = BigEndianHelper.ReadSingleBE(binaryReader),
            Y = BigEndianHelper.ReadSingleBE(binaryReader),
            Z = BigEndianHelper.ReadSingleBE(binaryReader)
        };
        PropIDs = ArrayHelper.ReadString(binaryReader);
    }

    public void Encode(BinaryWriter binaryWriter, OptionalMask optionalMask)
    {
        throw new System.NotImplementedException();
    }

    public override string ToString()
    {
        return String.Format("[Batch Name='{0}' MaterialID={1} Position={2} PropIDs={3}]", Name, MaterialID, Position, PropIDs.Length);
    }
}
