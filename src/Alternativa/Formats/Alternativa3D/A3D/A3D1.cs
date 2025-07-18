using libalternativa.Alternativa.Protocol;

namespace libalternativa.Alternativa.Formats.Alternativa3D.A3D;

class A3D1 : ProtocolObject
{
    [Optional]
    public Version1.Box[]? Boxes;

    [Optional]
    public Version1.Geometry[]? Geometries;

    [Optional]
    public Version1.Image[]? Images;

    [Optional]
    public Version1.Map[]? Maps;

    [Optional]
    public Version1.Material[]? Materials;

    [Optional]
    public Version1.Object[]? Objects;
}