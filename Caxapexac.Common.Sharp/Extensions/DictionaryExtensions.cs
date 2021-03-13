using System.Collections.Generic;

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedType.Global

namespace Caxapexac.Common.Sharp.Extensions
{
    public static class DictionaryExtensions
    {
        public static V GetOrDefault<K, V>(this IDictionary<K, V> self, K key, V defaultValue = default)
        {
            if (!self.ContainsKey(key)) self[key] = defaultValue;
            return self[key];
        }
    }
}