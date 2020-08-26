// ----------------------------------------------------------------------------
// The MIT License
// LeopotamGroupLibrary https://github.com/Leopotam/LeopotamGroupLibraryUnity
// Copyright (c) 2012-2019 Leopotam <leopotam@gmail.com>
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace Caxapexac.Common.Sharp.Runtime.Extensions
{
    /// <summary>
    /// Math extensions.
    /// </summary>
    public static class ToStringExtensions
    {
        private static readonly StringBuilder _floatToStrBuf = new StringBuilder(64);

        private static readonly string[] _shortNumberOrders = {"", "k", "M", "G", "T", "P", "E"};

        private static readonly float _invLog1K = 1 / (float)System.Math.Log(1000);

        /// <summary>
        /// Convert number to string with "kilo-million-billion" suffix with rounding.
        /// </summary>
        /// <param name="self">Source number.</param>
        /// <param name="digitsAfterPoint">Digits after floating point.</param>
        public static string ToStringWithSuffix(this int self, int digitsAfterPoint = 2)
        {
            return ToStringWithSuffix((long)self, digitsAfterPoint);
        }

        /// <summary>
        /// Convert number to string with "kilo-million-billion" suffix with rounding.
        /// </summary>
        /// <param name="self">Source number.</param>
        /// <param name="digitsAfterPoint">Digits after floating point.</param>
        public static string ToStringWithSuffix(this long self, int digitsAfterPoint = 2)
        {
            int sign;
            if (self < 0)
            {
                self = -self;
                sign = -1;
            }
            else
            {
                sign = 1;
            }

            var i = self > 0 ? (int)(System.Math.Floor(System.Math.Log(self) * _invLog1K)) : 0;
            if (i >= _shortNumberOrders.Length)
            {
                i = _shortNumberOrders.Length - 1;
            }
            var mask = digitsAfterPoint == 2 ? "0.##" : "0." + new string('#', digitsAfterPoint);
            return (sign * self / System.Math.Pow(1000, i)).ToString(mask, NumberFormatInfo.InvariantInfo) + _shortNumberOrders[i];
        }

        /// <summary>
        /// Convert float number to string. Fast, no support for scientific format.
        /// </summary>
        /// <returns>Normalized string.</returns>
        /// <param name="self">Data.</param>
        public static string ToStringFast(this float self)
        {
            lock (_floatToStrBuf)
            {
                const int precMul = 100000;
                _floatToStrBuf.Length = 0;
                var isNeg = self < 0f;
                if (isNeg)
                {
                    self = -self;
                }
                var v0 = (uint)self;
                var diff = (self - v0) * precMul;
                var v1 = (uint)diff;
                diff -= v1;
                if (diff > 0.5f)
                {
                    v1++;
                    if (v1 >= precMul)
                    {
                        v1 = 0;
                        v0++;
                    }
                }
                else
                {
                    if (diff == 0.5f && (v1 == 0 || (v1 & 1) != 0))
                    {
                        v1++;
                    }
                }
                if (v1 > 0)
                {
                    var count = 5;
                    while ((v1 % 10) == 0)
                    {
                        count--;
                        v1 /= 10;
                    }

                    do
                    {
                        count--;
                        _floatToStrBuf.Append((char)((v1 % 10) + '0'));
                        v1 /= 10;
                    } while (v1 > 0);
                    while (count > 0)
                    {
                        count--;
                        _floatToStrBuf.Append('0');
                    }
                    _floatToStrBuf.Append('.');
                }
                do
                {
                    _floatToStrBuf.Append((char)((v0 % 10) + '0'));
                    v0 /= 10;
                } while (v0 > 0);
                if (isNeg)
                {
                    _floatToStrBuf.Append('-');
                }
                var i0 = 0;
                var i1 = _floatToStrBuf.Length - 1;
                char c;
                while (i1 > i0)
                {
                    c = _floatToStrBuf[i0];
                    _floatToStrBuf[i0] = _floatToStrBuf[i1];
                    _floatToStrBuf[i1] = c;
                    i0++;
                    i1--;
                }

                return _floatToStrBuf.ToString();
            }
        }

        public static string ToFirstUpperChar(this string self)
        {
            return self.First().ToString().ToUpper() + self.Substring(1).ToLower();
        }

        public static string ToUnderscore(this string self)
        {
            return self.Replace(" ", "_");
        }

        public static string ToUnderscoreLower(this string self)
        {
            return self.ToUnderscore().ToLower();
        }

        public static string ToCamelCase(this string self)
        {
            return Regex.Replace(self, "([a-z](?=[A-Z])|[A-Z](?=[A-Z][a-z]))", "$1 ").Trim();
        }

        public static string Capitalize(this string self, char separator = ' ', string replaceWith = " ")
        {
            string capitalized = "";
            string[] splits = self.Split(separator);
            for (int i = 0; i < splits.Length; i++)
            {
                String s = splits[i];
                capitalized += $"{s[0].ToString().ToUpper()}{s.Substring(1)}";
                if (i < splits.Length - 1) capitalized += replaceWith;
            }
            return capitalized;
        }


        public enum Colors
        {
            Aqua,
            Black,
            Blue,
            Brown,
            Cyan,
            Darkblue,
            Fuchsia,
            Green,
            Grey,
            Lightblue,
            Lime,
            Magenta,
            Maroon,
            Navy,
            Olive,
            Purple,
            Red,
            Silver,
            Teal,
            White,
            Yellow
        }


        public static string Colored(this string message, Colors color)
        {
            return $"<color={color}>{message}</color>";
        }

        public static string Sized(this string message, int size)
        {
            return $"<size={size}>{message}</size>";
        }

        public static string Bold(this string message)
        {
            return $"<b>{message}</b>";
        }

        public static string Italics(this string message)
        {
            return $"<i>{message}</i>";
        }
    }
}