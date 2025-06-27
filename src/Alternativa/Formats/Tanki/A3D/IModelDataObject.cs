using System.IO;

namespace libalternativa.Alternativa.Formats.Tanki.A3D;

interface IModelDataObject
{
    void Read(BinaryReader binaryReader);
    void Write(BinaryWriter binaryWriter);
}