using System;

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedType.Global

namespace Caxapexac.Common.Sharp.Extensions
{
    public static class RandomArrayExtensions
    {
        private static readonly Random _random = new Random();

        public static T GetRandom<T>(this T[] self)
        {
            return self[_random.Next(0, self.Length)];
        }
    }
}