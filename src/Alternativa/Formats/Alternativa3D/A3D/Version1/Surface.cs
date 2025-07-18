using libalternativa.Alternativa.Protocol;

namespace libalternativa.Alternativa.Formats.Alternativa3D.A3D.Version1;

class Surface : ProtocolObject
{
    public int IndexBegin;

    [Optional]
    public int? MaterialID;

    public int TriangleCount;
}