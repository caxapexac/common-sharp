using System;

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedType.Global

namespace Caxapexac.Common.Sharp.Extensions
{
    public static class RandomExtensions
    {
        public static double NextDoubleRange(this Random random, double min, double max)
        {
            return random.NextDouble() * (max - min) + min;
        }

        /// <summary>
        /// Gives you random enum value from T
        /// </summary>
        /// <returns></returns>
        public static T NextEnum<T>(this Random self) where T : struct, IConvertible
        {
            Array values = Enum.GetValues(typeof(T));
            return (T)values.GetValue((int)Math.Round(self.NextDouble() * (values.Length - 1)));
        }
    }
}