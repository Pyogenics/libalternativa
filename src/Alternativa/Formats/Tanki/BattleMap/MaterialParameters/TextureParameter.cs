using System;
using System.IO;
using libalternativa.Alternativa.Protocol;

namespace libalternativa.Alternativa.Formats.Tanki.BattleMap.MaterialParameters;

class TextureParameter : IProtocolObject
{
    public string LibraryName { get; private set; } = "";
    public string Name { get; private set; } = "";
    public string TextureName { get; private set; } = "";

    public void Decode(BinaryReader binaryReader, OptionalMask optionalMask)
    {
        if (optionalMask.GetOptional())
            LibraryName = ArrayHelper.ReadString(binaryReader);
        Name = ArrayHelper.ReadString(binaryReader);
        TextureName = ArrayHelper.ReadString(binaryReader);
    }

    public void Encode(BinaryWriter binaryWriter, OptionalMask optionalMask)
    {
        throw new System.NotImplementedException();
    }

    public override string ToString()
    {
        return String.Format("[TextureParameter Name='{0}' LibraryName='{1}' TextureName='{2}']", Name, LibraryName, TextureName);
    }
}
