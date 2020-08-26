using System;
using System.Collections.Generic;
using System.Linq;


namespace Caxapexac.Common.Sharp.Runtime.Extensions
{
    public static class DictionaryExtensions
    {
        private static readonly Random _random = new Random();

        public static KeyValuePair<T, T2> GetRandom<T, T2>(this IDictionary<T, T2> self)
        {
            return self.ToList()[_random.Next(0, self.Count)];
        }

        public static IDictionary<T, T2> GetRandom<T, T2>(this IDictionary<T, T2> self, int size)
        {
            var randomItems = new Dictionary<T, T2>(size);
            var itemsCopy = self.ToList();

            while (itemsCopy.Count > 0 && randomItems.Count < size)
            {
                var randomItem = itemsCopy[_random.Next(0, itemsCopy.Count)];
                itemsCopy.Remove(randomItem);
                randomItems.Add(randomItem.Key, randomItem.Value);
            }

            return randomItems;
        }

        public static V GetOrDefault<K, V>(this IDictionary<K, V> self, K key, V defaultValue = default)
        {
            if (!self.ContainsKey(key)) self[key] = defaultValue;
            return self[key];
        }
    }
}