using System;
using System.IO;
using libalternativa.Alternativa.Formats.Tanki.A3D;


using FileStream fileStream = File.Open(args[0], FileMode.Open);
using BinaryReader binaryReader = new(fileStream);
A3D3Reader model = new();
model.Read(binaryReader);