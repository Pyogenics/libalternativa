using System.IO;
using libalternativa.Alternativa.Protocol;
using libalternativa.Utils;

namespace libalternativa.Alternativa.Formats.Alternativa3D.A3D.Version1;

class Image : IProtocolObject
{
    public int ID { get; private set; }
    public string Url { get; private set; } = "";

    public void Decode(BinaryReader binaryReader, OptionalMask optionalMask)
    {
        if (optionalMask.GetOptional())
            ID = BigEndianHelper.ReadInt32BE(binaryReader);
        if (optionalMask.GetOptional())
            Url = ArrayHelper.ReadString(binaryReader);
    }

    public void Encode(BinaryWriter binaryWriter, OptionalMask optionalMask)
    {
        throw new System.NotImplementedException();
    }
}