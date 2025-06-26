using System;
using System.IO;

namespace libalternativa.Alternativa.Formats.Tanki.A3D;

class A3D2Reader
{
    private const int A3D_SIGNATURE = 0x00443341;
    private const int ROOT_BLOCK_SIGNATURE = 1;
    private const int MATERIAL_BLOCK_SIGNATURE = 4;
    private const int MESH_BLOCK_SIGNATURE = 2;
    private const int TRANSFORM_BLOCK_SIGNATURE = 3;
    private const int OBJECT_BLOCK_SIGNATURE = 5;

    public A3D2.Material[] Materials = Array.Empty<A3D2.Material>();
    public A3D2.Mesh[] Meshes = Array.Empty<A3D2.Mesh>();
    public A3D2.Transform[] Transforms = Array.Empty<A3D2.Transform>();
    public int[] TransformParentIDs = Array.Empty<int>();
    public A3D2.Object[] Objects = Array.Empty<A3D2.Object>();

    public void Read(BinaryReader binaryReader)
    {
        // Check signature and version
        int signature = binaryReader.ReadInt32();
        if (signature != A3D_SIGNATURE) throw new Exception("Invalid A3D signature");

        int version = binaryReader.ReadInt32();
        if (version != 2) throw new Exception("Invalid A3D version, this reader is for version 2 format files");

        // Read root block
        int blockSignature = binaryReader.ReadInt32();
        binaryReader.ReadBytes(4); // Unused in version 2
        if (blockSignature != ROOT_BLOCK_SIGNATURE) throw new Exception("Invalid A3D root block signature");

        ReadMaterialBlock(binaryReader);
        ReadMeshBlock(binaryReader);
        ReadTransformBlock(binaryReader);
        ReadObjectBlock(binaryReader);
    }

    private void ReadMaterialBlock(BinaryReader binaryReader)
    {
        // Check signature
        int blockSignature = binaryReader.ReadInt32();
        binaryReader.ReadBytes(4); // Unused in version 2
        if (blockSignature != MATERIAL_BLOCK_SIGNATURE) throw new Exception("Invalid A3D material block signature");

        int materialCount = binaryReader.ReadInt32();
        Materials = new A3D2.Material[materialCount];
        for (int materialI = 0; materialI < materialCount; materialI++)
        {
            A3D2.Material material = new();
            material.Read(binaryReader);
            Materials[materialI] = material;
        }
    }

    private void ReadMeshBlock(BinaryReader binaryReader)
    {
        int blockSignature = binaryReader.ReadInt32();
        binaryReader.ReadBytes(4); // Unused in version 2
        if (blockSignature != MESH_BLOCK_SIGNATURE) throw new Exception("Invalid A3D mesh block signature");

        int meshCount = binaryReader.ReadInt32();
        Meshes = new A3D2.Mesh[meshCount];
        for (int meshI = 0; meshI < meshCount; meshI++)
        {
            A3D2.Mesh mesh = new();
            mesh.Read(binaryReader);
            Meshes[meshI] = mesh;
        }
    }

    private void ReadTransformBlock(BinaryReader binaryReader)
    {
        int blockSignature = binaryReader.ReadInt32();
        binaryReader.ReadBytes(4); // Unused in version 2
        if (blockSignature != TRANSFORM_BLOCK_SIGNATURE) throw new Exception("Invalid A3D transform block signature");

        int transformCount = binaryReader.ReadInt32();
        Transforms = new A3D2.Transform[transformCount];
        for (int transformI = 0; transformI < transformCount; transformI++)
        {
            A3D2.Transform transform = new();
            transform.Read(binaryReader);
            Transforms[transformI] = transform;
        }

        TransformParentIDs = new int[transformCount];
        for (int transformParentI = 0; transformParentI < transformCount; transformParentI++)
        {
            int parentID = binaryReader.ReadInt32();
            TransformParentIDs[transformParentI] = parentID;
        }
    }

    private void ReadObjectBlock(BinaryReader binaryReader)
    {
        int blockSignature = binaryReader.ReadInt32();
        binaryReader.ReadBytes(4); // Unused in version 2
        if (blockSignature != OBJECT_BLOCK_SIGNATURE) throw new Exception("Invalid A3D object block signature");

        int objectCount = binaryReader.ReadInt32();
        Objects = new A3D2.Object[objectCount];
        for (int objectI = 0; objectI < objectCount; objectI++)
        {
            A3D2.Object obj = new();
            obj.Read(binaryReader);
            Objects[objectI] = obj;
        }
    }
}
