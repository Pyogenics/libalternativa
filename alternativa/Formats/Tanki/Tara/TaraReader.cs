using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using libalternativa.Utils;

namespace libalternativa.Alternativa.Formats.Tanki.Tara;

class TaraReader
{
    public int FileCount;
    private Dictionary<string, byte[]> files = new();

    public void Read(BinaryReader binaryReader)
    {
        // Read file table
        FileCount = BigEndianHelper.ReadInt32BE(binaryReader);

        string[] filenames = new string[FileCount];
        int[] fileLengths = new int[FileCount];

        for (int fileI = 0; fileI < FileCount; fileI++)
        {
            int strLength = BigEndianHelper.ReadInt16BE(binaryReader);
            byte[] str = binaryReader.ReadBytes(strLength);

            filenames[fileI] = Encoding.UTF8.GetString(str);
            fileLengths[fileI] = BigEndianHelper.ReadInt32BE(binaryReader);
        }

        // Read files
        for (int fileI = 0; fileI < FileCount; fileI++)
        {
            string filename = filenames[fileI];
            int fileLength = fileLengths[fileI];
            byte[] fileData = binaryReader.ReadBytes(fileLength);

            files.Add(filename, fileData);
        }
    }

    public byte[] GetFile(string filename)
    {
        return files[filename];
    }
}
