using System.IO;
using System.Numerics;
using libalternativa.Alternativa.Protocol;
using libalternativa.Utils;

namespace libalternativa.Alternativa.Formats.Alternativa3D.A3D.Version1;

class Transform : IProtocolObject
{
    public Matrix4x4 Matrix { get; private set; }

    public void Decode(BinaryReader binaryReader, OptionalMask optionalMask)
    {
        if (optionalMask.GetOptional())
        {
            Matrix = new()
            {
                M11 = BigEndianHelper.ReadSingleBE(binaryReader),
                M12 = BigEndianHelper.ReadSingleBE(binaryReader),
                M13 = BigEndianHelper.ReadSingleBE(binaryReader),
                M14 = BigEndianHelper.ReadSingleBE(binaryReader),
                M21 = BigEndianHelper.ReadSingleBE(binaryReader),
                M22 = BigEndianHelper.ReadSingleBE(binaryReader),
                M23 = BigEndianHelper.ReadSingleBE(binaryReader),
                M24 = BigEndianHelper.ReadSingleBE(binaryReader),
                M31 = BigEndianHelper.ReadSingleBE(binaryReader),
                M32 = BigEndianHelper.ReadSingleBE(binaryReader),
                M33 = BigEndianHelper.ReadSingleBE(binaryReader),
                M34 = BigEndianHelper.ReadSingleBE(binaryReader)
            };
        }
    }

    public void Encode(BinaryWriter binaryWriter, OptionalMask optionalMask)
    {
        throw new System.NotImplementedException();
    }
}