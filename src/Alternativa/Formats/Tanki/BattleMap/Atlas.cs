using System;
using System.IO;
using libalternativa.Alternativa.Protocol;
using libalternativa.Utils;

namespace libalternativa.Alternativa.Formats.Tanki.BattleMap;

class Atlas : IProtocolObject
{
    public int Height { get; private set; }
    public string Name { get; private set; } = "";
    public int Padding { get; private set; }
    public AtlasRect[] Rects { get; private set; } = Array.Empty<AtlasRect>();
    public int Width { get; private set; }

    public void Decode(BinaryReader binaryReader, OptionalMask optionalMask)
    {
        Height = BigEndianHelper.ReadInt32BE(binaryReader);
        Name = ArrayHelper.ReadString(binaryReader);
        Padding = BigEndianHelper.ReadInt32BE(binaryReader);
        Rects = ArrayHelper.ReadObjectArray<AtlasRect>(binaryReader, optionalMask);
        Width = BigEndianHelper.ReadInt32BE(binaryReader);
    }

    public void Encode(BinaryWriter binaryWriter, OptionalMask optionalMask)
    {
        throw new System.NotImplementedException();
    }

    public override string ToString()
    {
        return String.Format("[Atlas Name='{0}' Width={1} Height={2} Padding={3} Rects={4}]", Name, Width, Height, Padding, Rects.Length);
    }
}
