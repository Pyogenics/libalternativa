using System;
using System.IO;

namespace libalternativa.Alternativa.Formats.Tanki.A3D;

class A3DVertexBuffer
{
    public const int VERTEXTYPE_COORDINATE = 1;
    public const int VERTEXTYPE_UV1 = 2;
    public const int VERTEXTYPE_NORMAL1 = 3;
    public const int VERTEXTYPE_UV2 = 4;
    public const int VERTEXTYPE_COLOR = 5;
    public const int VERTEXTYPE_NORMAL2 = 6;

    public int BufferType;
    public int VertexSize;
    public float[] VertexData = Array.Empty<float>();

    public void Read(BinaryReader binaryReader, int vertexCount)
    {
        BufferType = binaryReader.ReadInt32();
        VertexSize = GetVertexSize(BufferType);
        VertexData = new float[VertexSize * vertexCount];
        for (int vertexComponentI = 0; vertexComponentI < VertexSize * vertexCount; vertexComponentI++)
        {
            float vertex = binaryReader.ReadSingle();
            VertexData[vertexComponentI] = vertex;
        }
    }

    public static int GetVertexSize(int bufferType)
    {
        int vertexSize;
        switch (bufferType)
        {
            case VERTEXTYPE_UV1:
            case VERTEXTYPE_UV2:
                vertexSize = 2;
                break;
            case VERTEXTYPE_COORDINATE:
            case VERTEXTYPE_NORMAL1:
            case VERTEXTYPE_NORMAL2:
                vertexSize = 3;
                break;
            case VERTEXTYPE_COLOR:
                vertexSize = 4;
                break;
            default: throw new Exception("Unknown A3DVertexBuffer buffer type: " + bufferType);
        }
        return vertexSize;
    }

    public override string ToString()
    {
        return String.Format("[A3DVertexBuffer BufferType={0} VertexSize={1} VertexData={2}]", BufferType, VertexSize, VertexData.Length);
    }
}
