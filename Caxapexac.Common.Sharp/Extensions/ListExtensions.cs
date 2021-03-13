using System;
using System.Collections.Generic;

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedType.Global

namespace Caxapexac.Common.Sharp.Extensions
{
    public static class ListExtensions
    {
        public delegate void Iterator<T>(T item, int idx);


        public static bool IsNullOrEmpty<T>(this IList<T> self)
        {
            if (self == null) return true;
            return self.Count == 0;
        }

        public static void Loop<T>(this IList<T> self, Iterator<T> iter)
        {
            for (int i = 0; i < self.Count; ++i)
            {
                iter(self[i], i);
            }
        }

        public static T Last<T>(this IList<T> self)
        {
            return self.Count > 0 ? self[self.Count - 1] : default(T);
        }

        public static void Swap<T>(this IList<T> self, int indexA, int indexB)
        {
            T tmp = self[indexA];
            self[indexA] = self[indexB];
            self[indexB] = tmp;
        }

        public static bool IsEqual<T>(this IList<T> self, IList<T> other) where T : IEquatable<T>
        {
            if (self.Count != other.Count)
            {
                return false;
            }
            for (int i = 0; i < self.Count; ++i)
            {
                if (!self[i].Equals(other[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsContain<T>(this IList<T> self, IList<T> other, bool shouldSameSize = true)
        {
            if (shouldSameSize && self.Count != other.Count)
            {
                return false;
            }
            for (int i = 0; i < other.Count; ++i)
            {
                if (!self.Contains(other[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}