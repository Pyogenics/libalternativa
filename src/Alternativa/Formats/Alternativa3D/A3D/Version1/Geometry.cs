using libalternativa.Alternativa.Protocol;

namespace libalternativa.Alternativa.Formats.Alternativa3D.A3D.Version1;

class Geometry : ProtocolObject
{
    [Optional]
    public int? ID;

    [Optional]
    public IndexBuffer? IndexBuffer;

    [Optional]
    public VertexBuffer[]? VertexBuffers;
}