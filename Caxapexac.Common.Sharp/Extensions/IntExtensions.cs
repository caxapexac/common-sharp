using System;
using System.Collections.Generic;

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedType.Global

namespace Caxapexac.Common.Sharp.Extensions
{
    public static class IntExt
    {
        public static int GetNearestPoint(this int self, IList<int> list)
        {
            int nearest = list[0];
            foreach (var t in list)
            {
                if (Math.Abs(t - self) < Math.Abs(nearest - self)) nearest = t;
            }
            return nearest;
        }

        public static bool IsWithin(this int self, int lower, int upper)
        {
            return (self >= lower && self <= upper);
        }

        public static int PrevPowerOfTwo(this int self)
        {
            if (self.IsPowerOfTwo()) return self;

            self |= self >> 1;
            self |= self >> 2;
            self |= self >> 4;
            self |= self >> 8;
            self |= self >> 16;

            return self - (self >> 1);
        }

        public static bool IsPowerOfTwo(this int self)
        {
            return (self != 0) && ((self & (self - 1)) == 0);
        }

        public static float RandomFixed(this int self)
        {
            self = (self << 13) ^ self;
            return (float)(1.0 - ((self * (self * self * 15731 + 789221) + 1376312589) & 2147483647) / 1073741824.0);
        }

        public static string ToRoman(this int i)
        {
            if (i > 999) return "M" + ToRoman(i - 1000);
            if (i > 899) return "CM" + ToRoman(i - 900);
            if (i > 499) return "D" + ToRoman(i - 500);
            if (i > 399) return "CD" + ToRoman(i - 400);
            if (i > 99) return "C" + ToRoman(i - 100);
            if (i > 89) return "XC" + ToRoman(i - 90);
            if (i > 49) return "L" + ToRoman(i - 50);
            if (i > 39) return "XL" + ToRoman(i - 40);
            if (i > 9) return "X" + ToRoman(i - 10);
            if (i > 8) return "IX" + ToRoman(i - 9);
            if (i > 4) return "V" + ToRoman(i - 5);
            if (i > 3) return "IV" + ToRoman(i - 4);
            if (i > 0) return "I" + ToRoman(i - 1);
            return "";
        }
    }
}