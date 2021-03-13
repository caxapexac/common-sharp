using System;

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedType.Global

namespace Caxapexac.Common.Sharp.Extensions
{
    public static class ComparableExtensions
    {
        public static bool InRange<T>(this T self, T closedLeft, T openRight) where T : IComparable
        {
            return self.CompareTo(closedLeft) >= 0 && self.CompareTo(openRight) < 0;
        }

        public static T Clamp<T>(this T self, T lower, T upper) where T : IComparable<T>
        {
            return self.CompareTo(lower) < 0 ? lower : self.CompareTo(upper) > 0 ? upper : self;
        }
    }
}