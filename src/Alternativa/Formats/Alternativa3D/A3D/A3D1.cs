using System;
using System.IO;
using libalternativa.Alternativa.Formats.Alternativa3D.A3D;
using libalternativa.Alternativa.Protocol;

namespace libalternativa.Alternativa.Formats.Alternativa3D.A3D;

class A3D1 : IProtocolObject
{
    public Version1.Box[] Boxes { get; private set; } = Array.Empty<Version1.Box>();
    public Version1.Geometry[] Geometries { get; private set; } = Array.Empty<Version1.Geometry>();
    public Version1.Image[] Images { get; private set; } = Array.Empty<Version1.Image>();
    public Version1.Map[] Maps { get; private set; } = Array.Empty<Version1.Map>();
    public Version1.Material[] Materials { get; private set; } = Array.Empty<Version1.Material>();
    public Version1.Object[] Objects { get; private set; } = Array.Empty<Version1.Object>();

    public void Decode(BinaryReader binaryReader, OptionalMask optionalMask)
    {
        if (optionalMask.GetOptional())
            Boxes = ArrayHelper.ReadObjectArray<Version1.Box>(binaryReader, optionalMask);
        if (optionalMask.GetOptional())
            Geometries = ArrayHelper.ReadObjectArray<Version1.Geometry>(binaryReader, optionalMask);
        if (optionalMask.GetOptional())
            Images = ArrayHelper.ReadObjectArray<Version1.Image>(binaryReader, optionalMask);
        if (optionalMask.GetOptional())
            Maps = ArrayHelper.ReadObjectArray<Version1.Map>(binaryReader, optionalMask);
        if (optionalMask.GetOptional())
            Materials = ArrayHelper.ReadObjectArray<Version1.Material>(binaryReader, optionalMask);
        if (optionalMask.GetOptional())
            Objects = ArrayHelper.ReadObjectArray<Version1.Object>(binaryReader, optionalMask);
    }

    public void Encode(BinaryWriter binaryWriter, OptionalMask optionalMask)
    {
        throw new System.NotImplementedException();
    }
}