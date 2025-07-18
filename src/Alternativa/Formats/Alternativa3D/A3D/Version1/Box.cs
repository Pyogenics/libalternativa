using System;
using libalternativa.Alternativa.Protocol;

namespace libalternativa.Alternativa.Formats.Alternativa3D.A3D.Version1;

class Box : ProtocolObject
{
    [Optional]
    public float[]? Bounds;

    [Optional]
    public int? ID;

    public override string ToString()
    {
        return String.Format("[Box Bounds={0} ID={1}]", Bounds, ID);
    }
}