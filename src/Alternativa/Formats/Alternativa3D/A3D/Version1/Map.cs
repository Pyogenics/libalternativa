using System.IO;
using libalternativa.Alternativa.Protocol;
using libalternativa.Utils;

namespace libalternativa.Alternativa.Formats.Alternativa3D.A3D.Version1;

class Map : IProtocolObject
{
    public int Channel { get; private set; }
    public int ID { get; private set; }    
    public int ImageID { get; private set; }
    public float UOffset { get; private set; }
    public float UScale { get; private set; }
    public float VOffset { get; private set; }
    public float VScale { get; private set; }

    public void Decode(BinaryReader binaryReader, OptionalMask optionalMask)
    {
        Channel = BigEndianHelper.ReadInt16BE(binaryReader);
        if (optionalMask.GetOptional())
            ID = BigEndianHelper.ReadInt32BE(binaryReader);
        if (optionalMask.GetOptional())
            ImageID = BigEndianHelper.ReadInt32BE(binaryReader);
        if (optionalMask.GetOptional())
            UOffset = BigEndianHelper.ReadSingleBE(binaryReader);
        if (optionalMask.GetOptional())
            UScale = BigEndianHelper.ReadSingleBE(binaryReader);
        if (optionalMask.GetOptional())
            VOffset = BigEndianHelper.ReadSingleBE(binaryReader);
        if (optionalMask.GetOptional())
            VScale = BigEndianHelper.ReadSingleBE(binaryReader);
    }

    public void Encode(BinaryWriter binaryWriter, OptionalMask optionalMask)
    {
        throw new System.NotImplementedException();
    }
}