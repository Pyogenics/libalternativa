# BattleMap (map.bin)
Binary based map file format that replaced JSON and XML based formats, it is exported out of the unity editor and stored as `map.bin`.

## Format
This file is wrapped and serialised using the Alternativa Protocol, it has no signature or header and is simply a protocol packet with optional mask.
```c
struct BattleMap
{
    OptionalMask optionalMask; // See Alternativa Protocol documentation
    Atlas atlases[];                                        // Optional
    Batch batches[];                                        // Optional
    CollisionGeometry collisionGeometry;                    // Required
    CollisionGeometry collisionGeometryOutsideGamingZone;   // Required
    Material materials[];                                   // Required
    SpawnPoint spawnPoints[];                               // Optional
    Prop staticGeometry[];                                  // Required
};
```
### Atlas
Defines an atlas file, atlas texture files store all the textures required by the map, they are stored next to the `map.bin` file.
```c
struct Atlas
{
    uint32_t height;    // Required
    string name;        // Required
    uint32_t padding;   // Required
    AtlasRect rects[];  // Required
    uint32_t width;     // Required
};
```
#### AtlasRect
Defines an individual texture in the atlas.
```c
struct AtlasRect
{
    uint32_t height;        // Required
    string libraryName;     // Required
    string name;            // Required
    uint32_t width;         // Required
    uint32_t x;             // Required
    uint32_t y;             // Required
};
```
### Batch
Defines a render batch, a group of geometry which shares the same material and can be rendered together.
```c
struct Batch
{
    uint32_t materialID;    // Required
    string name;            // Required
    vec3 position;          // Required
    string propIDs;         // Required
};
```
### CollisionGeometry
Stores physics information, collision meshes for the map.
```c
struct CollisionGeometry
{
    CollisionBox collisionBoxes[];              // Required
    CollisionPlane collisionPlanes[];           // Required
    CollisionTriangle collisionTriangles[];     // Required
};
```
#### CollisionBox
Primitive box physics collider.
```c
struct CollisionBox
{
    vec3 Position;  // Required
    vec3 Rotation;  // Required
    vec3 Scale;     // Required
};
```
#### CollisionPlane
Primitive plane physics collider.
```c
struct CollisionPlane
{
    double length;  // Required
    vec3 position;  // Required
    vec3 rotation;  // Required
    double width;   // Required
};
```
#### CollisionTriangle
Primitive triangle physics collider.
```c
struct CollisionTriangle
{
    double length;      // Required
    vec3 position;      // Required
    vec3 rotation;      // Required
    float vertices[3];  // Required
};
```
### Material
Defines a material used within the map.
```c
struct Material
{
    uint32_t ID;                            // Required
    string name;                            // Required
    ScalarParameter scalarParameters[];     // Optional
    string shader;                          // Required
    TextureParameter textureParameters[];   // Required
    Vector2Parameter vector2Parameters[];   // Optional
    Vector3Parameter vector3Parameters[];   // Optional
    Vector4Parameter vector4Parameters[];   // Optional
};
```
#### ScalarParameter
Defines a material parameter with one component.
```c
struct ScalarParameter
{
    string name;    // Required
    float value;    // Required
};
```
#### Vector2Parameter
Defines a material parameter with two components.
```c
struct Vector2Parameter
{
    string name;    // Required
    vec2 value;     // Required
};
```
#### Vector3Parameter
Defines a material parameter with three components.
```c
struct Vector3Parameter
{
    string name;    // Required
    vec3 value;     // Required
};
```
#### Vector4Parameter
Defines a material parameter with four components.
```c
struct Vector4Parameter
{
    string name;    // Required
    vec4 value;     // Required
};
```
### SpawnPoint
A point at which tanks can spawn, specific to different gamemodes.
```c
struct SpawnPoint
{
    vec3 position;  // Required
    vec3 rotation;  // Required
    uint32_t type;  // Required
};
```
#### type
Specifies which gamemode and team the spawn is for.
```c
enum SpawnType
{
    TUTORIAL_PLAYER = 0,
    TUTORIAL_BOT = 1,
    TEAM_A = 2,
    TEAM_B = 3,
    DM = 4,
    DOM = 5,
    DOM_TEAM_A = 6,
    DOM_TEAM_B = 7,
    RUGBY_TEAM_A = 8,
    RUGBY_TEAM_B = 9,
    SURVIVAL_TEAM_A = 10,
    SURVIVAL_TEAM_B = 11,
    SURVIVAL_NEUTRAL = 12,
    ASSAULT_ATTACKING = 13,
    ASSAULT_DEFENDING = 14,
    SGE_TEAM_A = 15,
    SGE_TEAM_B = 16,
    TJR_TEAM_A = 17,
    TJR_TEAM_B = 18,
};
```
### Prop
Defines a visual object within the map.
```c
struct Prop
{
    string groupName;       // Optional
    uint32_t ID;            // Required
    string libraryName;     // Required
    uint32_t materialID;    // Required
    string name;            // Required
    vec3 position;          // Required
    vec3 rotation;          // Optional
    vec3 scale;             // Optional
};
```