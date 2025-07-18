using libalternativa.Alternativa.Protocol;

namespace libalternativa.Alternativa.Formats.Alternativa3D.A3D.Version1;

class VertexBuffer : ProtocolObject
{
    [Optional]
    public byte[]? Attributes;

    [Optional]
    public byte[]? VertexData;

    public ushort VertexCount;
}