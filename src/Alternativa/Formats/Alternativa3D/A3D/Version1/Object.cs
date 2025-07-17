using System;
using System.IO;
using libalternativa.Alternativa.Protocol;
using libalternativa.Utils;

namespace libalternativa.Alternativa.Formats.Alternativa3D.A3D.Version1;

class Object : IProtocolObject
{
    public int BoundBoxID { get; private set; }
    public int GeometryID { get; private set; }
    public int ID { get; private set; }
    public string Name { get; private set; } = "";
    public int ParentID { get; private set; }
    public Surface[] Surfaces { get; private set; } = Array.Empty<Surface>();
    public Transform Transform { get; private set; } = new();
    public bool Visible { get; private set; }

    public void Decode(BinaryReader binaryReader, OptionalMask optionalMask)
    {
        if (optionalMask.GetOptional())
            BoundBoxID = BigEndianHelper.ReadInt32BE(binaryReader);
        if (optionalMask.GetOptional())
            GeometryID = BigEndianHelper.ReadInt32BE(binaryReader);
        if (optionalMask.GetOptional())
            ID = BigEndianHelper.ReadInt32BE(binaryReader);
        if (optionalMask.GetOptional())
            Name = ArrayHelper.ReadString(binaryReader);
        if (optionalMask.GetOptional())
            ParentID = BigEndianHelper.ReadInt32BE(binaryReader);
        if (optionalMask.GetOptional())
            Surfaces = ArrayHelper.ReadObjectArray<Surface>(binaryReader, optionalMask);
        if (optionalMask.GetOptional())
            Transform.Decode(binaryReader, optionalMask);
        if (optionalMask.GetOptional())
            Visible = binaryReader.ReadBoolean();
    }

    public void Encode(BinaryWriter binaryWriter, OptionalMask optionalMask)
    {
        throw new System.NotImplementedException();
    }
}