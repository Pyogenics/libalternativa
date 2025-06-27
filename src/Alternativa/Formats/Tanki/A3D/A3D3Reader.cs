using System;
using System.IO;

namespace libalternativa.Alternativa.Formats.Tanki.A3D;

class A3D3Reader
{
    private const int A3D_SIGNATURE = 0x00443341;
    private const int ROOT_BLOCK_SIGNATURE = 1;
    private const int MATERIAL_BLOCK_SIGNATURE = 4;
    private const int MESH_BLOCK_SIGNATURE = 2;
    private const int TRANSFORM_BLOCK_SIGNATURE = 3;
    private const int OBJECT_BLOCK_SIGNATURE = 5;

    public A3D3.Material[] Materials = Array.Empty<A3D3.Material>();
    public A3D3.Mesh[] Meshes = Array.Empty<A3D3.Mesh>();
    public A3D3.Transform[] Transforms = Array.Empty<A3D3.Transform>();
    public A3D3.Object[] Objects = Array.Empty<A3D3.Object>();

    public void Read(BinaryReader binaryReader)
    {
        // Check signature and version
        int signature = binaryReader.ReadInt32();
        if (signature != A3D_SIGNATURE) throw new Exception("Invalid A3D signature");

        int version = binaryReader.ReadInt32();
        if (version != 3) throw new Exception("Invalid A3D version, this reader is for version 3 format files");

        // Read root block
        int blockSignature = binaryReader.ReadInt32();
        int blockLength = binaryReader.ReadInt32();
        if (blockSignature != ROOT_BLOCK_SIGNATURE) throw new Exception("Invalid A3D root block signature");

        using MemoryStream blockStream = new(binaryReader.ReadBytes(blockLength));
        using BinaryReader blockReader = new(blockStream);

        ReadMaterialBlock(blockReader);
        ReadMeshBlock(blockReader);
        ReadTransformBlock(blockReader);
        ReadObjectBlock(blockReader);
    }

    private void ReadMaterialBlock(BinaryReader binaryReader)
    {
        // Check signature
        int blockSignature = binaryReader.ReadInt32();
        int blockLength = binaryReader.ReadInt32();
        if (blockSignature != MATERIAL_BLOCK_SIGNATURE) throw new Exception("Invalid A3D material block signature");

        using MemoryStream blockStream = new(binaryReader.ReadBytes(blockLength));
        using BinaryReader blockReader = new(blockStream);

        int materialCount = blockReader.ReadInt32();
        Materials = new A3D3.Material[materialCount];
        for (int materialI = 0; materialI < materialCount; materialI++)
        {
            A3D3.Material material = new();
            material.Read(blockReader);
            Materials[materialI] = material;
        }

        // Data padding
        int paddingSize = IOHelper.CalculatePaddingSize(blockLength);
        binaryReader.ReadBytes(paddingSize);
    }

    private void ReadMeshBlock(BinaryReader binaryReader)
    {
        // Check signature
        int blockSignature = binaryReader.ReadInt32();
        int blockLength = binaryReader.ReadInt32();
        if (blockSignature != MESH_BLOCK_SIGNATURE) throw new Exception("Invalid A3D mesh block signature");

        using MemoryStream blockStream = new(binaryReader.ReadBytes(blockLength));
        using BinaryReader blockReader = new(blockStream);

        int meshCount = blockReader.ReadInt32();
        Meshes = new A3D3.Mesh[meshCount];
        for (int meshI = 0; meshI < meshCount; meshI++)
        {
            A3D3.Mesh mesh = new();
            mesh.Read(blockReader);
            Meshes[meshI] = mesh;
        }

        // Data padding
        int paddingSize = IOHelper.CalculatePaddingSize(blockLength);
        binaryReader.ReadBytes(paddingSize);
    }

    private void ReadTransformBlock(BinaryReader binaryReader)
    {
        // Check signature
        int blockSignature = binaryReader.ReadInt32();
        int blockLength = binaryReader.ReadInt32();
        if (blockSignature != TRANSFORM_BLOCK_SIGNATURE) throw new Exception("Invalid A3D transform block signature");

        using MemoryStream blockStream = new(binaryReader.ReadBytes(blockLength));
        using BinaryReader blockReader = new(blockStream);

        int transformCount = blockReader.ReadInt32();
        Transforms = new A3D3.Transform[transformCount];
        for (int transformI = 0; transformI < transformCount; transformI++)
        {
            A3D3.Transform transform = new();
            transform.Read(blockReader);
            Transforms[transformI] = transform;
        }

        // Data padding
        int paddingSize = IOHelper.CalculatePaddingSize(blockLength);
        binaryReader.ReadBytes(paddingSize);
    }

    private void ReadObjectBlock(BinaryReader binaryReader)
    {
        // Check signature
        int blockSignature = binaryReader.ReadInt32();
        int blockLength = binaryReader.ReadInt32();
        if (blockSignature != OBJECT_BLOCK_SIGNATURE) throw new Exception("Invalid A3D object block signature");

        using MemoryStream blockStream = new(binaryReader.ReadBytes(blockLength));
        using BinaryReader blockReader = new(blockStream);

        int objectCount = blockReader.ReadInt32();
        Objects = new A3D3.Object[objectCount];
        for (int objectI = 0; objectI < objectCount; objectI++)
        {
            A3D3.Object obj = new();
            obj.Read(blockReader);
            Objects[objectI] = obj;
        }

        // Data padding
        int paddingSize = IOHelper.CalculatePaddingSize(blockLength);
        binaryReader.ReadBytes(paddingSize);
    }
}
