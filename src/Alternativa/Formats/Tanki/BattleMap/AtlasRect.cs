using System;
using System.IO;
using libalternativa.Alternativa.Protocol;
using libalternativa.Utils;

namespace libalternativa.Alternativa.Formats.Tanki.BattleMap;

class AtlasRect : IProtocolObject
{
    public int Height;
    public string LibraryName = "";
    public string Name = "";
    public int Width;
    public int x;
    public int y;

    public void Decode(BinaryReader binaryReader, OptionalMask optionalMask)
    {
        Height = BigEndianHelper.ReadInt32BE(binaryReader);
        LibraryName = ArrayHelper.ReadString(binaryReader);
        Name = ArrayHelper.ReadString(binaryReader);
        Width =  BigEndianHelper.ReadInt32BE(binaryReader);
        x =  BigEndianHelper.ReadInt32BE(binaryReader);
        y =  BigEndianHelper.ReadInt32BE(binaryReader);
    }

    public void Encode(BinaryWriter binaryWriter, OptionalMask optionalMask)
    {
        throw new System.NotImplementedException();
    }

    public override string ToString()
    {
        return String.Format("[AtlasRect Name='{0}' LibraryName='{1}' Width={2} Height={3} x={4} y={5}]", Name, LibraryName, Width, Height, x, y);
    }
}
