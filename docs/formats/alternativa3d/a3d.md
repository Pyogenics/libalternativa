# A3D (Alternativa3D)
There are currently 2 major versions of the A3D format: A3D1 and A3D2 which are supported by the latest flash release of the Alternativa3D engine (8.32.0), this format is not related to the modern A3D format used in Tanki Online.

## A3D1
Oldest version of the format, uses the alternativa protocol serialisation format.
### Research materials
- [Alternativa3D engine parser](https://github.com/AlternativaPlatform/Alternativa3D/blob/master/src/alternativa/engine3d/loaders/ParserA3D.as)
### Format
```c
struct A3D1
{
    short version; // 1
    short unused;  // 0
    OptionalMask optionalMask;
    A3D1Box boxes[];            // Optional
    A3D1Geometry geometry[];    // Optional
    A3D1Image images[];         // Optional
    A3D1Map maps[];             // Optional
    A3D1Material materials[];   // Optional
    A3D1Object objects[];       // Optional
};
```
#### A3D1Box
```c
struct A3D1Box
{
    float bounds[];     // Optional
    int id;             // Optional
};
```
#### A3D1Geometry
```c
struct A3D1Geometry
{
    int id;                             // Optional
    A3D1IndexBuffer indexBuffer;        // Optional
    A3D1VertexBuffer vertexBuffers[];   // Optional
};
```
#### A3D1Image
```c
struct A3D1Image
{
    int id;         // Optional
    char url[];     // Optional
};
```
#### A3D1Map
```c
struct A3D1Map
{
    short channel;  // Required
    int id;         // Optional
    int imageID;    // Optional
    float uOffset;  // Optional
    float uScale;   // Optional
    float vOffset;  // Optional
    float vScale;   // Optional
};
```
#### A3D1Material
```c
struct A3D1Material
{
    int diffuseMapID;       // Optional
    int glossinessMapID;    // Optional
    int id;                 // Optional
    int lightMapID;         // Optional
    int normalMapID;        // Optional
    int opacityMapID;       // Optional
    int specularMapID;      // Optional
};
```
#### A3D1Object
```c
struct A3D1Object
{
    int boundBoxID;             // Optional
    int geometryID;             // Optional
    int id;                     // Optional
    char name[];                // Optional
    int parentID;               // Optional
    A3D1Surface surfaces[];     // Optional
    A3D1Transform transform;    // Optional
    bool visible;               // Optional
};
```
#### A3D1Transform
```c
struct A3D1Transform
{
    A3DMatrix matrix;   // Optional
};
```
#### A3D1IndexBuffer
```c
struct A3D1IndexBuffer
{
    char byteBuffer[];  // Optional
    int indexCount;     // Required
};
```
#### A3D1VertexBuffer
```c
struct A3D1VertexBuffer
{
    char attributes[];  // Optional
    char byteBuffer[];  // Optional
    short vertexCount;  // Required
};
```
##### attributes
The `attributes` field specifies the format of each vertex inside the `byteBuffer`, there can be any amount of attributes in any order. It is read as 1 byte integers which each correspond to one of the vertex types:
```
0 - position
1 - normal
2 - tangent
3 - joint
4 - UV1
5 - UV2
```
#### A3D1Surface
```c
struct A3D1Surface
{
    int indexBegin;     // Required
    int materialID;     // Optional
    int numTriangles;   // Required
};
```

## A3D2
Newest version supported by the opensource flash Alternativa3D engine, also uses the alternativa protocol serialisation format (like A3D1). This version of the format adds zlib compression support, light objects, animation, skinning, sprites and decals as well as reducing amount of optional flags per model by properly using optional fields (only marking select fields as optional instead of most of them).

There are 4 minor versions of this format:

| Version | Notes                                   |
|---------|-----------------------------------------|
| 2.0     |                                         |
| 2.4     | aka A3DExtra1, adds A3D2Layer           |
| 2.5     | aka A3DExtra2, adds A3D2Camera, A3D2LOD |
| 2.6     | Package compression is mandatory        |

### Research materials
- [Alternativa3D engine parser](https://github.com/AlternativaPlatform/Alternativa3D/blob/master/src/alternativa/engine3d/loaders/ParserA3D.as)
- [Official design document]()
### Format
```c
struct A3D2
{
    A3D2Package package;
};
```
#### A3D2Package
The A3D2 is wrapped in a compressable block called the package, it is placed at the very start of the file and begins with a length field, this is followed by a stream of bytes (size of the length field) which contains the A3D2 data (could be zlib compressed, this is encoded in the length field).
##### Short package
```
0G000000 00000000
```
| G | Description                    |
|---|--------------------------------|
| 0 | Package data is not compressed |
| 1 | Package data is compressed     |

Length of the package is contained in the last 6 bits of the first byte + the next byte, resulting in a maximum length of 16,384 bytes.
##### Long package
```
10000000 00000000 00000000 00000000
```
Length of the package is contained in the last 7 bits of the first byte + the next 3 bytes, resulting in a maximum length of 2147483648 bytes. Compression is assumed to be true.
##### Data
The uncompressed package data stores the actual file data:
```c
struct A3D2Package
{
    OptionalMask optionalMask;
    A3D2AmbientLight ambientLights[];           // Optional
    A3D2AnimationClip animationClips[];         // Optional
    A3D2AnimationTrack animationTracks[];       // Optional
    A3D2Box boxes[];                            // Optional
    A3D2CubeMap cubeMaps[];                     // Optional
    A3D2Decal decals[];                         // Optional
    A3D2DirectionalLight directionalLights[];   // Optional
    A3D2Image images[];                         // Optional
    A3D2IndexBuffer indexBuffers[];             // Optional
    A3D2Joint joints[];                         // Optional
    A3D2Map maps[];                             // Optional
    A3D2Material materials[];                   // Optional
    A3D2Mesh meshes[];                          // Optional
    A3D2Object objects[];                       // Optional
    A3D2OmniLight omniLights[];                 // Optional
    A3D2SpotLight spotLights[];                 // Optional
    A3D2Sprite sprites[];                       // Optional
    A3D2Skin skins[];                           // Optional
    A3D2VertexBuffer vertexBuffers[];           // Optional
    A3D2Layer layers[];                         // Optional, 2.4 only
    A3D2Camera cameras[];                       // Optional, 2.5 only
    A3D2LOD LODs[];                             // Optional, 2.5 only
};
```
#### A3D2AmbientLight
#### A3D2AnimationClip
#### A3D2AnimationTrack
#### A3D2Box
#### A3D2CubeMap
#### A3D2Decal
#### A3D2DirectionalLight
#### A3D2Image
#### A3D2IndexBuffer
#### A3D2Joint
#### A3D2Map
#### A3D2Material
#### A3D2Mesh
#### A3D2Object
#### A3D2OmniLight
#### A3D2SpotLight
#### A3D2Sprite
#### A3D2Skin
#### A3D2VertexBuffer
#### A3D2Layer
#### A3D2Camera
#### A3D2LOD
