using System.IO;
using libalternativa.Alternativa.Protocol;
using libalternativa.Utils;

namespace libalternativa.Alternativa.Formats.Alternativa3D.A3D.Version1;

class Surface : IProtocolObject
{
    public int IndexBegin { get; private set; }
    public int MaterialID { get; private set; }
    public int TriangleCount { get; private set; }

    public void Decode(BinaryReader binaryReader, OptionalMask optionalMask)
    {
        IndexBegin = BigEndianHelper.ReadInt32BE(binaryReader);
        if (optionalMask.GetOptional())
            MaterialID = BigEndianHelper.ReadInt32BE(binaryReader);
        TriangleCount = BigEndianHelper.ReadInt32BE(binaryReader);
    }

    public void Encode(BinaryWriter binaryWriter, OptionalMask optionalMask)
    {
        throw new System.NotImplementedException();
    }
}