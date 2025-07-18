using libalternativa.Alternativa.Protocol;

namespace libalternativa.Alternativa.Formats.Alternativa3D.A3D.Version1;

class Material : ProtocolObject
{
    [Optional]
    public int? DiffuseMapID;

    [Optional]
    public int? GlossinessMapID;

    [Optional]
    public int? ID;

    [Optional]
    public int? LightMapID;

    [Optional]
    public int? NormalMapID;

    [Optional]
    public int? OpacityMapID;

    [Optional]
    public int? SpecularMapID;
}