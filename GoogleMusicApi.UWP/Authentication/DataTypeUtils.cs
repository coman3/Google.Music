using System;
using System.Linq;

namespace GoogleMusicApi.UWP.Authentication
{
    internal static class DataTypeUtils
    {
        public static byte[] CombineBytes(params byte[][] arrays)
        {
            var rv = new byte[arrays.Sum(a => a.Length)];
            var offset = 0;
            foreach (var array in arrays)
            {
                Buffer.BlockCopy(array, 0, rv, offset, array.Length);
                offset += array.Length;
            }
            return rv;
        }

        public static string ToUrlSafeBase64(this byte[] byteArray)
        {
            return Convert.ToBase64String(byteArray).Replace('+', '-').Replace('/', '_');
        }
    }
}