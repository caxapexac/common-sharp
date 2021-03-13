using System;

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedType.Global

namespace Caxapexac.Common.Sharp.Extensions
{
    public static class RandomIntExtensions
    {
        private static readonly Random _random = new Random();

        public static int WithRandomSign(this int self, float negativeProbability = 0.5f)
        {
            return _random.NextDouble() < negativeProbability ? -self : self;
        }
    }
}