using libalternativa.Alternativa.Protocol;

namespace libalternativa.Alternativa.Formats.Alternativa3D.A3D.Version1;

class Image : ProtocolObject
{
    [Optional]
    public int? ID;

    [Optional]
    public string? Url;
}