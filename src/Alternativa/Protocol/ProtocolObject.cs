using System;
using System.IO;
using System.Reflection;
using libalternativa.Utils;

namespace libalternativa.Alternativa.Protocol;

[AttributeUsage(AttributeTargets.Field)]
public class Optional : Attribute;

abstract class ProtocolObject
{
    public virtual void Decode(BinaryReader binaryReader, OptionalMask optionalMask)
    {
        Type type = GetType();
        FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
        foreach (FieldInfo field in fields)
        {
            if (field.GetCustomAttribute<Optional>() != null)
            {
                // Optional field
                if (!optionalMask.GetOptional()) continue;
                object value = ReadField(binaryReader, optionalMask, field.FieldType);
                field.SetValue(this, value);
            }
            else
            {
                // Required field
                object value = ReadField(binaryReader, optionalMask, field.FieldType);
                field.SetValue(this, value);
            }
        }
    }

    public virtual void Encode(BinaryWriter binaryWriter, OptionalMask optionalMask)
    {
        throw new NotImplementedException("Alternativa Protocol encoding not implemented");
    }

    private object ReadField(BinaryReader binaryReader, OptionalMask optionalMask, Type type)
    {
        // Handle nullables
        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
        {
            Type? nullableType = Nullable.GetUnderlyingType(type);
            if (nullableType == null) throw new Exception("ProtocolObject nullable underlying type cannot be null whilst decoding");
            type = nullableType;
        }

        if (type == typeof(long)) return BigEndianHelper.ReadInt64BE(binaryReader);
        if (type == typeof(long[])) return ArrayHelper.ReadInt64ArrayBE(binaryReader);

        else if (type == typeof(int)) return BigEndianHelper.ReadInt32BE(binaryReader);
        else if (type == typeof(int[])) return ArrayHelper.ReadInt32ArrayBE(binaryReader);

        else if (type == typeof(short)) return BigEndianHelper.ReadInt16BE(binaryReader);
        // else if (type == typeof(short[]))
        else if (type == typeof(ushort)) return BigEndianHelper.ReadUInt16BE(binaryReader);
        // else if (type == typeof(ushort[]))

        else if (type == typeof(byte)) return binaryReader.ReadByte();
        else if (type == typeof(byte[])) return ArrayHelper.ReadByteArray(binaryReader);

        else if (type == typeof(bool)) return binaryReader.ReadBoolean();
        // else if (type == typeof(bool[]))

        else if (type == typeof(float)) return BigEndianHelper.ReadSingleBE(binaryReader);
        else if (type == typeof(float[])) return ArrayHelper.ReadFloatArrayBE(binaryReader);

        else if (type == typeof(double)) return BigEndianHelper.ReadDoubleBE(binaryReader);
        // else if (type == typeof(double[]))

        // else if (type == typeof(char))
        else if (type == typeof(string)) return ArrayHelper.ReadString(binaryReader);

        else if (typeof(ProtocolObject).IsAssignableFrom(type))
        {
            // This field is a ProtocolObject
            object? value = Activator.CreateInstance(type);
            if (value == null) throw new Exception("ProtocolObject instance cannot be null whilst decoding");

            ProtocolObject protocolObject = (ProtocolObject)value;
            protocolObject.Decode(binaryReader, optionalMask);

            return protocolObject;
        }
        else if (type.IsArray)
        {
            // This field should be an array of ProtocolObjects
            Type? elementType = type.GetElementType();
            if (elementType == null) throw new Exception("Array element type cannot be null whilst decoding");
            if (!typeof(ProtocolObject).IsAssignableFrom(elementType)) new Exception("Invalid array element type in ProtocolObject: " + type);

            int length = ArrayHelper.ReadLength(binaryReader);
            Array protocolObjects = Array.CreateInstance(elementType, length);
            for (int protocolObjectI = 0; protocolObjectI < length; protocolObjectI++)
            {
                object? obj = Activator.CreateInstance(elementType);
                if (obj == null) throw new Exception("ProtocolObject instance cannot be null whilst decoding");

                ProtocolObject protocolObject = (ProtocolObject)obj;
                protocolObject.Decode(binaryReader, optionalMask);
                protocolObjects.SetValue(protocolObject, protocolObjectI);
            }

            return protocolObjects;
        }

        //XXX: Maybe we should just ignore and return null?
        else throw new Exception("Invalid type in ProtocolObject: " + type);
    }
}
