using libalternativa.Alternativa.Protocol;

namespace libalternativa.Alternativa.Formats.Alternativa3D.A3D.Version1;

class Map : ProtocolObject
{
    public short Channel;

    [Optional]
    public int? ID;

    [Optional]
    public int? ImageID;
    
    [Optional]
    public float? UOffset;

    [Optional]
    public float? UScale;

    [Optional]
    public float? VOffset;

    [Optional]
    public float? VScale;
}