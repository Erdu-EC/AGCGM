using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AGCGM.Internal.Tools
{
    internal static class Convert
    {
        public static int ToInt(this byte[] bin)
        {
            int total = 0, offset = bin.Length * 8;

            foreach (int item in bin) total += item << (offset -= 8);

            return total;
        }

        public static byte[] ToBytes(this int number, int max_bytes) => ToBytes((uint)number, max_bytes);

        public static byte[] ToBytes(this uint number, int max_bytes)
        {
            List<byte> data = new List<byte>();

            //Obteniendo bytes
            for (int i = 0, offset = 0; i < max_bytes; i++)
            {
                data.Insert(0, (byte)((number >> offset) & 255));
                offset += 8;
            }

            //Devolviendo arreglo
            return data.ToArray();
        }
    }
}
