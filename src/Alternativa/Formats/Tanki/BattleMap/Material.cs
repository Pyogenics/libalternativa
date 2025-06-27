using System;
using System.IO;
using libalternativa.Alternativa.Formats.Tanki.BattleMap.MaterialParameters;
using libalternativa.Alternativa.Protocol;
using libalternativa.Utils;

namespace libalternativa.Alternativa.Formats.Tanki.BattleMap;

class Material : IProtocolObject
{
    public int ID;
    public string Name = "";
    public ScalarParameter[] ScalarParameters = Array.Empty<ScalarParameter>();
    public string Shader = "";
    public TextureParameter[] TextureParameters = Array.Empty<TextureParameter>();
    public Vector2Parameter[] Vector2Parameters = Array.Empty<Vector2Parameter>();
    public Vector3Parameter[] Vector3Parameters = Array.Empty<Vector3Parameter>();
    public Vector4Parameter[] Vector4Parameters = Array.Empty<Vector4Parameter>();

    public void Decode(BinaryReader binaryReader, OptionalMask optionalMask)
    {
        ID = BigEndianHelper.ReadInt32BE(binaryReader);
        Name = ArrayHelper.ReadString(binaryReader);
        if (optionalMask.GetOptional())
            ScalarParameters = ArrayHelper.ReadObjectArray<ScalarParameter>(binaryReader, optionalMask);
        Shader = ArrayHelper.ReadString(binaryReader);
        TextureParameters = ArrayHelper.ReadObjectArray<TextureParameter>(binaryReader, optionalMask);
        if (optionalMask.GetOptional())
        {
            Vector2Parameters = ArrayHelper.ReadObjectArray<Vector2Parameter>(binaryReader, optionalMask);
        }
        if (optionalMask.GetOptional())
            Vector3Parameters = ArrayHelper.ReadObjectArray<Vector3Parameter>(binaryReader, optionalMask);
        if (optionalMask.GetOptional())
            Vector4Parameters = ArrayHelper.ReadObjectArray<Vector4Parameter>(binaryReader, optionalMask);
    }

    public void Encode(BinaryWriter binaryWriter, OptionalMask optionalMask)
    {
        throw new System.NotImplementedException();
    }

    public override string ToString()
    {
        return String.Format("[Material Name='{0}' ID={1} Shader='{2}' ScalarParameters={3} TextureParameters={4} Vector2Parameters={5} Vector3Parameters={6} Vector4Parameters={7}]", Name, ID, Shader, ScalarParameters.Length, TextureParameters.Length, Vector2Parameters.Length, Vector3Parameters.Length, Vector4Parameters.Length);
    }
}
