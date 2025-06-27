using System;
using System.IO;
using System.Numerics;
using libalternativa.Alternativa.Protocol;
using libalternativa.Utils;

namespace libalternativa.Alternativa.Formats.Tanki.BattleMap;

class Prop : IProtocolObject
{
    public string GroupName = "";
    public int ID;
    public string LibraryName = "";
    public int MaterialID;
    public string Name = "";
    public Vector3 Position = new();
    public Vector3 Rotation = new();
    public Vector3 Scale = new();

    public void Decode(BinaryReader binaryReader, OptionalMask optionalMask)
    {
        if (optionalMask.GetOptional())
            GroupName = ArrayHelper.ReadString(binaryReader);
        ID = BigEndianHelper.ReadInt32BE(binaryReader);
        LibraryName = ArrayHelper.ReadString(binaryReader);
        MaterialID = BigEndianHelper.ReadInt32BE(binaryReader);
        Name = ArrayHelper.ReadString(binaryReader);
        Position.X = BigEndianHelper.ReadSingleBE(binaryReader);
        Position.Y = BigEndianHelper.ReadSingleBE(binaryReader);
        Position.Z = BigEndianHelper.ReadSingleBE(binaryReader);
        if (optionalMask.GetOptional())
        {
            Rotation.X = BigEndianHelper.ReadSingleBE(binaryReader);
            Rotation.Y = BigEndianHelper.ReadSingleBE(binaryReader);
            Rotation.Z = BigEndianHelper.ReadSingleBE(binaryReader);
        }
        if (optionalMask.GetOptional())
        {
            Scale.X = BigEndianHelper.ReadSingleBE(binaryReader);
            Scale.Y = BigEndianHelper.ReadSingleBE(binaryReader);
            Scale.Z = BigEndianHelper.ReadSingleBE(binaryReader);
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
