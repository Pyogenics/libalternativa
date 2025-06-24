using System;
using System.IO;
using libalternativa.Alternativa.Protocol;
using libalternativa.Utils;

namespace libalternativa.Alternativa.Formats.Tanki.BattleMap.MaterialParameters;

class ScalarParameter : IProtocolObject
{
    public string Name = "";
    public float Value;

    public void Decode(BinaryReader binaryReader, OptionalMask optionalMask)
    {
        Name = ArrayHelper.ReadString(binaryReader);
        Value = BigEndianHelper.ReadSingleBE(binaryReader);
    }

    public void Encode(BinaryWriter binaryWriter, OptionalMask optionalMask)
    {
        throw new System.NotImplementedException();
    }

    public override string ToString()
    {
        return String.Format("[ScalarParameter Name='{0}' Value={1}]", Name, Value);
    }
}
