using System.IO;
using libalternativa.Alternativa.Protocol;
using libalternativa.Utils;

namespace libalternativa.Alternativa.Formats.Alternativa3D.A3D.Version1;

class Material : IProtocolObject
{
    public int DiffuseMapID { get; private set; }
    public int GlossinessMapID { get; private set; }
    public int ID { get; private set; }
    public int LightMapID { get; private set; }
    public int NormalMapID { get; private set; }
    public int OpacityMapID { get; private set; }
    public int SpecularMapID { get; private set; }

    public void Decode(BinaryReader binaryReader, OptionalMask optionalMask)
    {
        if (optionalMask.GetOptional())
            DiffuseMapID = BigEndianHelper.ReadInt32BE(binaryReader);
        if (optionalMask.GetOptional())
            GlossinessMapID = BigEndianHelper.ReadInt32BE(binaryReader);
        if (optionalMask.GetOptional())
            ID = BigEndianHelper.ReadInt32BE(binaryReader);
        if (optionalMask.GetOptional())
            LightMapID = BigEndianHelper.ReadInt32BE(binaryReader);
        if (optionalMask.GetOptional())
            NormalMapID = BigEndianHelper.ReadInt32BE(binaryReader);
        if (optionalMask.GetOptional())
            OpacityMapID = BigEndianHelper.ReadInt32BE(binaryReader);
        if (optionalMask.GetOptional())
            SpecularMapID = BigEndianHelper.ReadInt32BE(binaryReader);
    }

    public void Encode(BinaryWriter binaryWriter, OptionalMask optionalMask)
    {
        throw new System.NotImplementedException();
    }
}