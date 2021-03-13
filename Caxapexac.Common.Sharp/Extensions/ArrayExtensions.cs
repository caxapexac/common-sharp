using System;

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedType.Global


namespace Caxapexac.Common.Sharp.Extensions
{
    public static class ArrayExtensions
    {
        public static bool IsNullOrEmpty<T>(this T[] self)
        {
            if (self == null) return true;
            return self.Length == 0;
        }

        public static int IndexOf<T>(this T[] self, T item)
        {
            for (int i = 0; i < self.Length; i++)
            {
                if (self[i].Equals(item)) return i;
            }
            return -1;
        }

        public static T[] ForEach<T>(this T[] self, Action<T> callback)
        {
            if (callback == null) return self;
            foreach (var item in self)
            {
                callback(item);
            }
            return self;
        }

        public static void Fill<T>(this T[] self, T value, int length)
        {
            if (self == null || self.Length < length)
            {
                throw new ArgumentException();
            }
            if (length <= 0) return;
            self[0] = value;
            var lenHalf = length >> 1;
            int i;
            for (i = 1; i < lenHalf; i <<= 1)
            {
                Array.Copy(self, 0, self, i, i);
            }
            Array.Copy(self, 0, self, i, length - i);
        }

        public static T[] InsertAt<T>(this T[] self, int index)
        {
            if (index < 0 || index >= self.Length) throw new IndexOutOfRangeException();
            T[] newArray = new T[self.Length + 1];
            int index1 = 0;
            for (int index2 = 0; index2 < newArray.Length; ++index2)
            {
                if (index2 == index) continue;
                newArray[index2] = self[index1];
                ++index1;
            }
            return newArray;
        }

        public static T[] RemoveAt<T>(this T[] self, int index)
        {
            if (index < 0 || index >= self.Length) throw new IndexOutOfRangeException();
            T[] newArray = new T[self.Length - 1];
            int index1 = 0;
            for (int index2 = 0; index2 < self.Length; ++index2)
            {
                if (index2 == index) continue;
                newArray[index1] = self[index2];
                ++index1;
            }
            return newArray;
        }

        public static void Swap<T>(this T[] self, int a, int b)
        {
            T x = self[a];
            self[a] = self[b];
            self[b] = x;
        }
    }
}