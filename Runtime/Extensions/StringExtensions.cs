using System;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;


namespace Caxapexac.Common.Sharp.Runtime.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string self)
        {
            return string.IsNullOrEmpty(self);
        }

        public static int ParseInt(this string self)
        {
            return string.IsNullOrEmpty(self) ? 0 : int.Parse(self, CultureInfo.InvariantCulture);
        }

        public static float ParseFloat(this string self)
        {
            return string.IsNullOrEmpty(self) ? 0f : float.Parse(self, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Fast convert string to float. Fast, no GC allocation, no support for scientific format.
        /// </summary>
        /// <returns>Float number.</returns>
        /// <param name="self">Raw string.</param>
        public static float ParseFloatUnchecked(this string self)
        {
            var retVal1 = 0f;
            var retVal2 = 0f;
            var sign = 1f;
            if (self != null)
            {
                var dir = 10f;
                int i;
                var iMax = self.Length;
                char c;
                for (i = 0; i < iMax; i++)
                {
                    c = self[i];
                    if (c >= '0' && c <= '9')
                    {
                        retVal1 *= dir;
                        retVal1 += (c - '0');
                    }
                    else
                    {
                        if (c == '.')
                        {
                            break;
                        }
                        else
                        {
                            if (c == '-')
                            {
                                sign = -1f;
                            }
                        }
                    }
                }
                i++;
                dir = 0.1f;
                for (; i < iMax; i++)
                {
                    c = self[i];
                    if (c >= '0' && c <= '9')
                    {
                        retVal2 += (c - '0') * dir;
                        dir *= 0.1f;
                    }
                }
            }
            return sign * (retVal1 + retVal2);
        }

        public static bool ParseBool(this string self)
        {
            if (string.IsNullOrEmpty(self)) return false;
            return self.Equals("1") || self.ToLower().Equals("true");
        }

        public static DateTime ParseDateTime(this string self)
        {
            return string.IsNullOrEmpty(self) ? DateTime.Now : new DateTime(long.Parse(self));
        }

        public static string GetMd5HashCode(this string self)
        {
            // step 1, calculate MD5 hash from input
            using (var md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(self);
                byte[] hash = md5.ComputeHash(inputBytes);

                // step 2, convert byte array to hex string
                var sb = new StringBuilder();
                foreach (var t in hash)
                {
                    sb.Append(t.ToString("X2"));
                }
                var res = sb.ToString().ToLower();
                return res;
            }
        }

        /// <summary>
        /// Get universal hash code for short string.
        /// </summary>
        /// <param name="self">String for hashing.</param>
        public static int GetStableHashCode(this string self)
        {
            if (self == null)
            {
                throw new ArgumentException();
            }
            return GetStableHashCode(self, 0, self.Length);
        }

        /// <summary>
        /// Get universal hash code for part of short string.
        /// </summary>
        /// <param name="self">String for hashing.</param>
        /// <param name="offset">Start hashing from this offset.</param>
        /// <param name="len">Length of part for hashing.</param>
        public static int GetStableHashCode(this string self, int offset, int len)
        {
            if (self == null || offset < 0 || offset >= self.Length || len < 0 || offset + len > self.Length)
            {
                throw new ArgumentException();
            }
            if (len == 0)
            {
                return 0;
            }
            var seed = 173;
            for (int i = offset, iMax = offset + len; i < iMax; i++)
            {
                seed = 37 * seed + self[i];
            }
            return seed;
        }

        public static string Reverse(this string self)
        {
            char[] array = self.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }

        public static int CountChar(this string str, char ch)
        {
            return str.Count(t => t == ch);
        }
    }
}