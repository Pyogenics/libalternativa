using System;
using System.IO;
using libalternativa.Alternativa.Protocol;
using libalternativa.Utils;

namespace libalternativa.Alternativa.Formats.Alternativa3D.A3D.Version1;

class Box : IProtocolObject
{
    public float[] Bounds { get; private set; } = Array.Empty<float>();
    public int ID { get; private set; }

    public void Decode(BinaryReader binaryReader, OptionalMask optionalMask)
    {
        if (optionalMask.GetOptional())
            Bounds = ArrayHelper.ReadFloatArrayBE(binaryReader);
        if (optionalMask.GetOptional())
            ID = BigEndianHelper.ReadInt32BE(binaryReader);
    }

    public void Encode(BinaryWriter binaryWriter, OptionalMask optionalMask)
    {
        throw new System.NotImplementedException();
    }

    public override string ToString()
    {
        return String.Format("[Box Bounds={0} ID={1}]", Bounds, ID);
    }
}