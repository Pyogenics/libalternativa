using System;
using System.Collections.Generic;
using System.IO;

namespace libalternativa.Alternativa.Protocol;

class OptionalMask
{
    private List<bool> optionals = new();
    private int position = 0;

    public void Read(BinaryReader binaryReader)
    {
        int flags = binaryReader.ReadByte();
        if ((flags & 0b10000000) == 0)
        {
            // Short mask, 5 optional bits in flags + upto 3 extra bytes
            for (int bitI = 7; bitI > 2; bitI--)
            {
                optionals.Add((flags & (1 << bitI)) == 0);
            }

            int byteCount = (flags & 0b01100000) >> 5;
            for (int byteI = 0; byteI < byteCount; byteI++)
            {
                int b = binaryReader.ReadByte();
                for (int bitI = 7; bitI > -1; bitI--)
                {
                    optionals.Add((b & (1 << bitI)) == 0);
                }
            }
        }
        else
        {
            // Long mask, 6 bits + upto 2 extra bytes to encode length of the mask in bytes
            int byteCount;
            if ((flags & 0b01000000) == 0)
            {
                byteCount = flags & 0b00111111;
            }
            else
            {
                byteCount = (flags & 0b00111111) << 16;
                byteCount += binaryReader.ReadByte() << 8;
                byteCount += binaryReader.ReadByte();
            }

            for (int byteI = 0; byteI < byteCount; byteI++)
            {
                int b = binaryReader.ReadByte();
                for (int bitI = 7; bitI > -1; bitI--)
                {
                    optionals.Add((b & (1 << bitI)) == 0);
                }
            }
        }
    }

    public bool GetOptional()
    {
        bool optional = optionals[position];
        position += 1;
        return optional;
    }

    public override string ToString()
    {
        return String.Format("[OptionalMask Optionals={0} Position={1}]", optionals.Count, position);
    }
}
