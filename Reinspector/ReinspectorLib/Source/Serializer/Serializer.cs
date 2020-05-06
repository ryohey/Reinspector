using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Reinspector
{
    public partial class Serializer
    {
        private void WriteVector(IList<byte> data, byte[] value)
        {
            Write(data, value.Length);
            Write(data, value);
        }

        private void Write(IList<byte> data, byte[] value)
        {
            foreach (var v in value)
            {
                data.Add(v);
            }
        }

        private void Write(IList<byte> data, string value)
        {
            var bin = System.Text.Encoding.UTF8.GetBytes(value as string);
            WriteVector(data, bin);
        }

        private void Write(IList<byte> data, bool value)
        {
            Write(data, BitConverter.GetBytes(value));
        }

        private void Write(IList<byte> data, int value)
        {
            Write(data, BitConverter.GetBytes(value));
        }

        private void Write(IList<byte> data, Array value)
        {
            Write(data, value.Length);
            foreach (var v in value)
            {
                WriteAny(data, v);
            }
        }
        
        private FieldInfo[] GetWritableFields(Type type)
        {
            return type.GetFields().Where(f => !f.IsStatic && !f.IsLiteral && !f.IsInitOnly && f.IsPublic).ToArray();
        }

        private void WriteObject(IList<byte> data, object obj)
        {
            foreach (var f in GetWritableFields(obj.GetType()))
            {
                WriteAny(data, f.GetValue(obj));
            }
        }

        private void WriteValue(IList<byte> data, object value)
        {
            if (value is bool)
            {
                Write(data, (bool)value);
            }
            else if (value is byte)
            {
                data.Add((byte)value);
            }
            else if (value is char)
            {
                Write(data, BitConverter.GetBytes((char)value));
            }
            else if (value is short)
            {
                Write(data, BitConverter.GetBytes((short)value));
            }
            else if (value is int)
            {
                Write(data, (int)value);
            }
            else if (value is long)
            {
                Write(data, BitConverter.GetBytes((long)value));
            }
            else if (value is ushort)
            {
                Write(data, BitConverter.GetBytes((ushort)value));
            }
            else if (value is uint)
            {
                Write(data, BitConverter.GetBytes((uint)value));
            }
            else if (value is ulong)
            {
                Write(data, BitConverter.GetBytes((ulong)value));
            }
            else if (value is float)
            {
                Write(data, BitConverter.GetBytes((float)value));
            }
            else if (value is double)
            {
                Write(data, BitConverter.GetBytes((double)value));
            }
            else
            {
                // struct
                WriteObject(data, value);
            }
        }

        // value can be null
        private void WriteRef(IList<byte> data, object value)
        {
            if (value == null)
            {
                Write(data, false);
                return;
            }
            Write(data, true);

            if (value is string)
            {
                Write(data, value as string);
            }
            else if (value is Array)
            {
                Write(data, value as Array);
            }
            else
            {
                WriteObject(data, value);
            }
        }

        private void WriteAny(IList<byte> data, object value)
        {
            if (value != null && value.GetType().IsValueType)
            {
                WriteValue(data, value);
            }
            else
            {
                WriteRef(data, value);
            }
        }

        public byte[] Serialize<T>(T obj)
        {
            var data = new List<byte>();
            WriteAny(data, obj);
            return data.ToArray();
        }
    }
}
