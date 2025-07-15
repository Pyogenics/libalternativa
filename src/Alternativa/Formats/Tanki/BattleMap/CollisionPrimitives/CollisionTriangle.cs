using System;
using System.IO;
using System.Numerics;
using libalternativa.Alternativa.Protocol;
using libalternativa.Utils;

namespace libalternativa.Alternativa.Formats.Tanki.BattleMap.CollisionPrimitives;

class CollisionTriangle : IProtocolObject
{
    public double Length { get; private set; }
    public Vector3 Position { get; private set; }
    public Vector3 Rotation { get; private set; }
    public Vector3[] Vertices { get; } = new Vector3[3];

    public void Decode(BinaryReader binaryReader, OptionalMask optionalMask)
    {
        Length = BigEndianHelper.ReadDoubleBE(binaryReader);
        Position = new()
        {
            X = BigEndianHelper.ReadSingleBE(binaryReader),
            Y = BigEndianHelper.ReadSingleBE(binaryReader),
            Z = BigEndianHelper.ReadSingleBE(binaryReader)
        };
        Rotation = new()
        {
            X = BigEndianHelper.ReadSingleBE(binaryReader),
            Y = BigEndianHelper.ReadSingleBE(binaryReader),
            Z = BigEndianHelper.ReadSingleBE(binaryReader)
        };
        for (int vertexI = 0; vertexI < 3; vertexI++)
        {
            Vector3 vertex = new();
            vertex.X = BigEndianHelper.ReadSingleBE(binaryReader);
            vertex.Y = BigEndianHelper.ReadSingleBE(binaryReader);
            vertex.Z = BigEndianHelper.ReadSingleBE(binaryReader);
            Vertices[vertexI] = vertex;
        }
    }

    public void Encode(BinaryWriter binaryWriter, OptionalMask optionalMask)
    {
        throw new System.NotImplementedException();
    }

    public override string ToString()
    {
        return String.Format("[CollisionTriangle Length={0} Position={1} Rotation={2} Vertices={3}]", Length, Position, Rotation, Vertices.Length);
    }
}