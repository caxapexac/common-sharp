using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedType.Global

namespace Caxapexac.Common.Sharp.Extensions
{
    public static class RandomListExtensions
    {
        private static readonly Random _random = new Random();

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
    }
}