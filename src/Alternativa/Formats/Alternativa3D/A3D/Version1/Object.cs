using libalternativa.Alternativa.Protocol;

namespace libalternativa.Alternativa.Formats.Alternativa3D.A3D.Version1;

class Object : ProtocolObject
{
    [Optional]
    public int? BoundBoxID;

    [Optional]
    public int? GeometryID;

    [Optional]
    public int? ID;

    [Optional]
    public string? Name;

    [Optional]
    public int? ParentID;

    [Optional]
    public Surface[]? Surfaces;

    [Optional]
    public Transform? Transform;

    [Optional]
    public bool? Visible;
}