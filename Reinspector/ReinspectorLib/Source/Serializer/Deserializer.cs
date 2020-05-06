using System;
using System.Text;

namespace Reinspector
{
    public partial class Serializer
    {
        private bool ReadBool(byte[] data, ref int offset)
        {
            var value = BitConverter.ToBoolean(data, offset);
            offset += 1;
            return value;
        }

        private int ReadInt(byte[] data, ref int offset)
        {
            var value = BitConverter.ToInt32(data, offset);
            offset += 4;
            return value;
        }

        private string ReadString(byte[] data, ref int offset)
        {
            var size = ReadInt(data, ref offset);
            var str = Encoding.UTF8.GetString(data, offset, size);
            offset += size;
            return str;
        }

        private object ReadArray(byte[] data, ref int offset, Type type)
        {
            var size = ReadInt(data, ref offset);
            var arr = Array.CreateInstance(type, size);
            for (var i = 0; i < size; i++)
            {
                var value = ReadAny(data, ref offset, type);
                arr.SetValue(Convert.ChangeType(value, type), i);
            }
            return arr;
        }

        private object ReadObject(byte[] data, ref int offset, Type type)
        {
            var obj = Activator.CreateInstance(type);
            foreach (var f in GetWritableFields(type))
            {
                var value = ReadAny(data, ref offset, f.FieldType);
                f.SetValue(obj, value);
            }
            return obj;
        }

        private object ReadValue(byte[] data, ref int offset, Type type)
        {
            if (type == typeof(bool))
            {
                return ReadBool(data, ref offset);
            }
            else if (type == typeof(byte))
            {
                var value = data[offset];
                offset += 1;
                return value;
            }
            else if (type == typeof(char))
            {
                var value = BitConverter.ToChar(data, offset);
                offset += 2;
                return value;
            }
            else if (type == typeof(short))
            {
                var value = BitConverter.ToInt16(data, offset);
                offset += 2;
                return value;
            }
            else if (type == typeof(int))
            {
                return ReadInt(data, ref offset);
            }
            else if (type == typeof(long))
            {
                var value = BitConverter.ToInt64(data, offset);
                offset += 8;
                return value;
            }
            else if (type == typeof(ushort))
            {
                var value = BitConverter.ToUInt16(data, offset);
                offset += 2;
                return value;
            }
            else if (type == typeof(uint))
            {
                var value = BitConverter.ToUInt32(data, offset);
                offset += 4;
                return value;
            }
            else if (type == typeof(ulong))
            {
                var value = BitConverter.ToUInt64(data, offset);
                offset += 8;
                return value;
            }
            else if (type == typeof(float))
            {
                var value = BitConverter.ToSingle(data, offset);
                offset += 4;
                return value;
            }
            else if (type == typeof(double))
            {
                var value = BitConverter.ToDouble(data, offset);
                offset += 8;
                return value;
            }
            else
            {
                // struct
                return ReadObject(data, ref offset, type);
            }
        }

        private object ReadRef(byte[] data, ref int offset, Type type)
        {
            var isNotNull = ReadBool(data, ref offset);
            if (!isNotNull)
            {
                return null;
            }

            if (type == typeof(string))
            {
                return ReadString(data, ref offset);
            }
            else if (type.IsArray)
            {
                return ReadArray(data, ref offset, type.GetElementType());
            }
            else
            {
                return ReadObject(data, ref offset, type);
            }
        }

        private object ReadAny(byte[] data, ref int offset, Type type)
        {
            if (type.IsValueType)
            {
                return ReadValue(data, ref offset, type);
            }
            else
            {
                return ReadRef(data, ref offset, type);
            }
        }

        public T Deserialize<T>(byte[] data)
        {
            var offset = 0;
            var type = typeof(T);
            return (T)ReadAny(data, ref offset, type);
        }
    }
}
