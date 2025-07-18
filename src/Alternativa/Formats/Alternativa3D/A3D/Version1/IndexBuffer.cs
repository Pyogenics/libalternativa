using libalternativa.Alternativa.Protocol;

namespace libalternativa.Alternativa.Formats.Alternativa3D.A3D.Version1;

class IndexBuffer : ProtocolObject
{
    [Optional]
    public byte[]? IndexData;

    public int IndexCount;
}