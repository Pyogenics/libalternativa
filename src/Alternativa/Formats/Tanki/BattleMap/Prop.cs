using System;
using System.IO;
using System.Numerics;
using libalternativa.Alternativa.Protocol;
using libalternativa.Utils;

namespace libalternativa.Alternativa.Formats.Tanki.BattleMap;

class Prop : IProtocolObject
{
    public string GroupName { get; private set; } = "";
    public int ID { get; private set; }
    public string LibraryName { get; private set; } = "";
    public int MaterialID { get; private set; }
    public string Name { get; private set; } = "";
    public Vector3 Position { get; private set; }
    public Vector3 Rotation { get; private set; }
    public Vector3 Scale { get; private set; }

    public void Decode(BinaryReader binaryReader, OptionalMask optionalMask)
    {
        if (optionalMask.GetOptional())
            GroupName = ArrayHelper.ReadString(binaryReader);
        ID = BigEndianHelper.ReadInt32BE(binaryReader);
        LibraryName = ArrayHelper.ReadString(binaryReader);
        MaterialID = BigEndianHelper.ReadInt32BE(binaryReader);
        Name = ArrayHelper.ReadString(binaryReader);
        Position = new()
        {
            X = BigEndianHelper.ReadSingleBE(binaryReader),
            Y = BigEndianHelper.ReadSingleBE(binaryReader),
            Z = BigEndianHelper.ReadSingleBE(binaryReader)
        };
        if (optionalMask.GetOptional())
        {
            Rotation = new()
            {
                X = BigEndianHelper.ReadSingleBE(binaryReader),
                Y = BigEndianHelper.ReadSingleBE(binaryReader),
                Z = BigEndianHelper.ReadSingleBE(binaryReader)
            };
        }
        if (optionalMask.GetOptional())
        {
            Scale = new()
            {
                X = BigEndianHelper.ReadSingleBE(binaryReader),
                Y = BigEndianHelper.ReadSingleBE(binaryReader),
                Z = BigEndianHelper.ReadSingleBE(binaryReader)
            };
        }
    }

    public void Encode(BinaryWriter binaryWriter, OptionalMask optionalMask)
    {
        throw new System.NotImplementedException();
    }

    public override string ToString()
    {
        return String.Format("[Prop ID={0} LibraryName='{1}' GroupName='{2}' Name='{3}' MaterialID={4} Position={5} Rotation={6} Scale={7}]", ID, LibraryName, GroupName, Name, MaterialID, Position, Rotation, Scale);
    }
}
