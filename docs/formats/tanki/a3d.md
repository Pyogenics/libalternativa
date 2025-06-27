# A3D (Tanki Online)
Custom 3D model format used by Tanki Online HTML5 for HD maps and all tank models (including legacy) to replace the old 3ds format (non HD maps still use 3ds).

There are three versions of the A3D file format which are used for different types of objects in the game: version 1 files are no longer used, version 2 files are used for map geometry (props and terrain meshes etc...), version 3 files are used for tank models (turrets and hulls).

The format is able to store: basic material data, mesh data (including coordinate, UV, normals and colour vertex buffers), submesh/surface data (with material indices), transform data and hierarchy data.

# Format
## Padding
Padding is only used by version 3 models, it is calculated using:
```python
paddingSize = (((dataLength + 3) // 4) * 4) - dataLength
```
## Strings
Version 2 uses null terminated strings, e.g. the strings have no length and characters are read from the stream until a null is reached (`\0`). Version 3 uses an int32 length field which comes before the characters with no null terminator, this is followed by padding bytes (padding calculated from string length).
## Data blocks
The A3D file format is based around data blocks, data blocks are sections of the file which encode different data in the model such as meshes and materials.
```c
struct DataBlock
{
    int dataBlockSignature; // Identifies which datablock this is
    int dataBlockLength; // This field is used to compute padding in version 3 files, other versions don't use it
    // Data block specifc data goes here
};
```
## Version 1
TODO
## Version 2
```c
struct {
    char signature[4]; // "A3D\0"
    int version; // 2
    RootDataBlock root;
};
```
### Root block
This contains all model data blocks.
```c
struct RootDataBlock
{
    int rootBlockSignature;
    int rootBlockLength;
    MaterialBlock materialBlock;
    MeshBlock meshBlock;
    TransformBlock transformBlock;
    ObjectBlock objectBlock;
};
```
### Material block
```c
struct MaterialBlock
{
    int materialBlockSignature;
    int materialBlockLength;
    int materialCount;
    struct A3DMaterial
    {
        string name;
        float colorR;
        float colorG;
        float colorB;
        string diffuseMap;
    } materials[materialCount];
};
```
### Mesh block
```c
struct MeshBlock
{
    int meshBlockSignature;
    int meshBlockLength;
    int meshCount;
    struct Mesh
    {
        int vertexCount;
        int vertexBufferCount;
        struct VertexBuffer
        {
            int bufferType;
            float vertices[]; // vertex size * vertex count
        } vertexBuffers[vertexBufferCount];
        int submeshCount;
        struct Submesh
        {
            int faceCount;
            short indices[faceCount*3]; // array of 16 bit indices
            int smoothingGroups[faceCount];
            short materialID;
        } submeshes[submeshCount];
    } mesh[meshCount];
};
```
### Transform block
```c
struct TransformBlock
{
    int transformBlockSignature;
    int transformBlockLength;
    int transformCount;
    struct Transform {
        float positionX;
        float positionY;
        float positionZ;
        float rotationX;
        float rotationY;
        float rotationZ;
        float rotationW;
        float scaleX;
        float scaleY;
        float scaleZ;
    } transforms[transformCount];
    int transformIDs[transformCount]; // Each ID corresponds to a transform component at the same index, this ID is referenced by external data blocks
};
```
### Object block
```c
struct ObjectBlock
{
    int objectBlockSignature;
    int objectBlockLength;
    int objectCount;
    struct Object
    {
        string name;
        int meshID;
        int transformID;
    } objects[objectCount];
};
```
## Version 3
```c
struct {
    char signature[4]; // "A3D\0"
    int version; // 3
    RootDataBlock root;
};
```
### Root block
This contains all model data blocks.
```c
struct RootDataBlock
{
    int rootBlockSignature;
    int rootBlockLength;
    MaterialBlock materialBlock;
    MeshBlock meshBlock;
    TransformBlock transformBlock;
    ObjectBlock objectBlock;
};
```
### Material block
```c
struct A3DMaterialBlock
{
    int materialBlockSignature;
    int materialBlockLength;
    int materialCount;
    struct A3DMaterial
    {
        string name;
        float colorR;
        float colorG;
        float colorB;
        string diffuseMap;
    } materials[materialCount];
    byte padding[]; // depends on materialBlockLength
};
```
### Mesh block
```c
struct MeshBlock
{
    int meshBlockSignature;
    int meshBlockLength;
    int meshCount;
    struct Mesh
    {
        string name;
        float bboxMaxX;
        float bboxMaxY;
        float bboxMaxZ;
        float bboxMinX;
        float bboxMinY;
        float bboxMinZ;
        float unknown;
        int vertexCount;
        int vertexBufferCount;
        struct VertexBuffer
        {
            int bufferType;
            float vertices[]; // vertex size * vertex count
        } vertexBuffers[vertexBufferCount];
        int submeshCount;
        struct Submesh
        {
            int indexCount;
            short indices[indexCount]; // array of 16 bit indices
            byte padding[]; // dependent on indexCount*2
        } submeshes[submeshCount];
    } mesh[meshCount];
    byte padding[]; // depends on meshBlockLength
};
```
### Transform block
```c
struct TransformBlock
{
    int transformBlockSignature;
    int transformBlockLength;
    int transformCount;
    struct Transform {
        string name;
        float positionX;
        float positionY;
        float positionZ;
        float rotationX;
        float rotationY;
        float rotationZ;
        float rotationW;
        float scaleX;
        float scaleY;
        float scaleZ;
    } transforms[transformCount];
    int transformIDs[transformCount]; // Each ID corresponds to a transform component at the same index, this ID is referenced by external data blocks
    byte padding[]; // depends on transformBlockLength
};
```
### Object block
```c
struct ObjectBlock
{
    int objectBlockSignature;
    int objectBlockLength;
    int objectCount;
    struct Object
    {
        int meshID;
        int transformID;
        int materialCount;
        int materialIDs[materialCount];
    } objects[objectCount];
    byte padding[]; // depends on objectBlockLength
};
```
