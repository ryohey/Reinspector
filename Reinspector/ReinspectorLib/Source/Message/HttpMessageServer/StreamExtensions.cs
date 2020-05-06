using System.Collections.Generic;
using System.IO;

namespace Reinspector
{
    public static class StreamExtensions
    {
        // https://stackoverflow.com/a/45343277
        public static byte[] ReadAllBytes(this Stream stream)
        {
            var bytes = new List<byte>();

            int b;
            while ((b = stream.ReadByte()) != -1)
            {
                bytes.Add((byte)b);
            }

            return bytes.ToArray();
        }
    }
}
