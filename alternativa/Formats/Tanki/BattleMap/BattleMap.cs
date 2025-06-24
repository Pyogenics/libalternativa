using System;
using System.IO;
using libalternativa.Alternativa.Protocol;

namespace libalternativa.Alternativa.Formats.Tanki.BattleMap;

class BattleMap : IProtocolObject
{
    public Atlas[] Atlases = Array.Empty<Atlas>();
    public Batch[] Batches = Array.Empty<Batch>();
    public CollisionGeometry CollisionGeometry = new();
    public CollisionGeometry CollisionGeometryOutsideGamingZone = new();
    public Material[] Materials = Array.Empty<Material>();
    public SpawnPoint[] SpawnPoints = Array.Empty<SpawnPoint>();
    public Prop[] StaticGeometry = Array.Empty<Prop>();

    public void Decode(BinaryReader binaryReader, OptionalMask optionalMask)
    {
        if (optionalMask.GetOptional())
            Atlases = ArrayHelper.ReadObjectArray<Atlas>(binaryReader, optionalMask);
        if (optionalMask.GetOptional())
            Batches = ArrayHelper.ReadObjectArray<Batch>(binaryReader, optionalMask);
        CollisionGeometry.Decode(binaryReader, optionalMask);
        CollisionGeometryOutsideGamingZone.Decode(binaryReader, optionalMask);
        Materials = ArrayHelper.ReadObjectArray<Material>(binaryReader, optionalMask);
        if (optionalMask.GetOptional())
            SpawnPoints = ArrayHelper.ReadObjectArray<SpawnPoint>(binaryReader, optionalMask);
        StaticGeometry = ArrayHelper.ReadObjectArray<Prop>(binaryReader, optionalMask);
    }

    public void Encode(BinaryWriter binaryWriter, OptionalMask optionalMask)
    {
        throw new System.NotImplementedException();
    }

    public override string ToString()
    {
        return String.Format("[BattleMap Atlases={0} Batches={1} CollisionGeometry={2} CollisionGeometryOutsideGamingZone={3} Materials={4} SpawnPoints={5} StaticGeometry={6}]", Atlases.Length, Batches.Length, CollisionGeometry, CollisionGeometryOutsideGamingZone, Materials.Length, SpawnPoints.Length, StaticGeometry.Length);
    }
}