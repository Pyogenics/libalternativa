using System.IO;
using libalternativa.Formats.Tanki.A3D;

using FileStream fileStream = File.Open(args[0], FileMode.Open);
using BinaryReader binaryReader = new(fileStream);
A3D2Reader reader = new();
reader.Read(binaryReader);
