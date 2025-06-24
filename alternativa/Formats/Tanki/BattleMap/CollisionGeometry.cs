using System;
using System.IO;
using libalternativa.Alternativa.Formats.Tanki.BattleMap.CollisionPrimitives;
using libalternativa.Alternativa.Protocol;

namespace libalternativa.Alternativa.Formats.Tanki.BattleMap;

class CollisionGeometry : IProtocolObject
{
    public CollisionBox[] Boxes = Array.Empty<CollisionBox>();
    public CollisionPlane[] Planes = Array.Empty<CollisionPlane>();
    public CollisionTriangle[] Triangles = Array.Empty<CollisionTriangle>();

    public void Decode(BinaryReader binaryReader, OptionalMask optionalMask)
    {
        Boxes = ArrayHelper.ReadObjectArray<CollisionBox>(binaryReader, optionalMask);
        Planes = ArrayHelper.ReadObjectArray<CollisionPlane>(binaryReader, optionalMask);
        Triangles = ArrayHelper.ReadObjectArray<CollisionTriangle>(binaryReader, optionalMask);
    }

    public void Encode(BinaryWriter binaryWriter, OptionalMask optionalMask)
    {
        throw new System.NotImplementedException();
    }

    public override string ToString()
    {
        return String.Format("[CollisionGeometry Boxes={0} Planes={1} Triangles={2}]", Boxes.Length, Planes.Length, Triangles.Length);
    }
}
