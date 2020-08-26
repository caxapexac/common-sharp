using System;


namespace Caxapexac.Common.Sharp.Runtime.Extensions
{
    public static class ComparableExtensions
    {
        public static bool InRange<T>(this T value, T closedLeft, T openRight) where T : IComparable
        {
            return value.CompareTo(closedLeft) >= 0 && value.CompareTo(openRight) < 0;
        }

        public static T Clamp<T>(this T self, T lower, T upper) where T : IComparable<T>
        {
            return self.CompareTo(lower) < 0 ? lower : self.CompareTo(upper) > 0 ? upper : self;
        }
    }
}