using System;
using System.IO;
using System.Security.Cryptography;


namespace Client.Scripts.Algorithms.Scripts
{
    public class Hashing
    {
        private const int XPrime = 1619;
        private const int YPrime = 31337;
        private const int ZPrime = 6971;
        private const int WPrime = 1013;

        private static int Hash2D(int seed, int x, int y)
        {
            int hash = seed;
            hash ^= XPrime * x;
            hash ^= YPrime * y;

            hash = hash * hash * hash * 60493;
            hash = (hash >> 13) ^ hash;

            return hash;
        }

        private static int Hash3D(int seed, int x, int y, int z)
        {
            int hash = seed;
            hash ^= XPrime * x;
            hash ^= YPrime * y;
            hash ^= ZPrime * z;

            hash = hash * hash * hash * 60493;
            hash = (hash >> 13) ^ hash;

            return hash;
        }

        private static int Hash4D(int seed, int x, int y, int z, int w)
        {
            int hash = seed;
            hash ^= XPrime * x;
            hash ^= YPrime * y;
            hash ^= ZPrime * z;
            hash ^= WPrime * w;

            hash = hash * hash * hash * 60493;
            hash = (hash >> 13) ^ hash;

            return hash;
        }

        private static string CalculateMd5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }
    }
}