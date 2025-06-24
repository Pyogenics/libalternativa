using System;
using System.IO;
using libalternativa.Alternativa.Formats.Tanki.BattleMap;
using libalternativa.Alternativa.Protocol;

using FileStream fileStream = File.Open(args[0], FileMode.Open);
using BinaryReader binaryReader = new(fileStream);
byte[] packet = PacketHelper.UnwrapPacket(binaryReader);

using MemoryStream memoryStream = new(packet);
using BinaryReader packetReader = new(memoryStream);
// using FileStream o = new("packet.bin", FileMode.Create);
// o.Write(packet);
OptionalMask optionalMask = new();
optionalMask.Read(packetReader);
Console.WriteLine(optionalMask);
BattleMap map = new();
map.Decode(packetReader, optionalMask);
Console.WriteLine(map);