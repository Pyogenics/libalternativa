using System.IO;

namespace libalternativa.Alternativa.Protocol;

interface IProtocolObject
{
    void Decode(BinaryReader binaryReader, OptionalMask optionalMask);
    void Encode(BinaryWriter binaryWriter, OptionalMask optionalMask);
}