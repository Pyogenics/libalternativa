using System;
using System.IO;
using System.Numerics;
using libalternativa.Alternativa.Protocol;
using libalternativa.Utils;

namespace libalternativa.Alternativa.Formats.Tanki.BattleMap.MaterialParameters;

class Vector3Parameter : IProtocolObject
{
    public string Name { get; set; } = "";
    public Vector3 Value { get; private set; }

    public void Decode(BinaryReader binaryReader, OptionalMask optionalMask)
    {
        Name = ArrayHelper.ReadString(binaryReader);
        Value = new()
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
        return String.Format("[Vector4Parameter Name='{0}' Value={1}]", Name, Value);
    }
}
