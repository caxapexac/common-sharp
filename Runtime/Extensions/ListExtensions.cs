using System;
using System.Collections.Generic;
using System.Linq;


namespace Caxapexac.Common.Sharp.Runtime.Extensions
{
    public static class ListExtensions
    {
        private static readonly Random _random = new Random();


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

        public static T GetRandom<T>(this IList<T> self)
        {
            return self[_random.Next(0, self.Count)];
        }

        public static List<T> GetRandom<T>(this IList<T> self, int size)
        {
            var randomItems = new List<T>(size);
            var itemsCopy = self.ToList();

            while (itemsCopy.Count > 0 && randomItems.Count < size)
            {
                var randomItem = itemsCopy[_random.Next(0, itemsCopy.Count)];
                itemsCopy.Remove(randomItem);
                randomItems.Add(randomItem);
            }

            if (randomItems.Count >= size) return randomItems;

            while (self.Count > 0 && randomItems.Count < size)
            {
                var randomItem = self[_random.Next(0, self.Count)];
                randomItems.Add(randomItem);
            }

            return randomItems;
        }

        public static void Shuffle<T>(this IList<T> self)
        {
            var itemsCount = self.Count;

            while (itemsCount > 1)
            {
                itemsCount--;
                var index = _random.Next(itemsCount + 1);
                var value = self[index];
                self[index] = self[itemsCount];
                self[itemsCount] = value;
            }
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