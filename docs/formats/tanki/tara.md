# Tara
Tanki Online resource archive, simple format that packs multiple files (without compression) into one archive. These files were utilised to store the game's prop libraries.

## Format
The file utilises big endian encoding throughout.
### File table
The file has no proper header or signature, it just starts with a table of files contained withing the archive.
```c
struct FileTable
{
    int fileCount;
    struct FileInfo {
        uint16_t filenameLength;
        char filename[filenameLength];
        uint32_t fileLength;
    } fileInfo[fileCount];
}
```
### File blob
The file table is immediately followed by all the packed files stacked back to back with each other:
```
<file1 data><file2 data><file3 data>
```