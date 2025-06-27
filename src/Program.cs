using System;
using System.IO;
using libalternativa.Alternativa.Formats.Tanki.A3D;
using libalternativa.Alternativa.Formats.Tanki.Tara;

using FileStream fileStream = File.Open(args[0], FileMode.Open);
using BinaryReader binaryReader = new(fileStream);
TaraReader taraReader = new();
taraReader.Read(binaryReader);
byte[] d = taraReader.GetFile("images.xml");
string imagesxml = System.Text.Encoding.UTF8.GetString(d);
Console.WriteLine(imagesxml);