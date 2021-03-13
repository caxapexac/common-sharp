using System.Collections.Generic;
using System.Linq;

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedType.Global

namespace Caxapexac.Common.Sharp.Extensions
{
    public static class EnumerableExtensions
    {
        public delegate U Mapper<T, U>(T t);


        public delegate T Reducer<T, U>(T prev, U current);


        public static List<U> Map<T, U>(this IEnumerable<T> self, Mapper<T, U> mapper)
        {
            List<U> newList = new List<U>();
            foreach (T itm in self)
            {
                newList.Add(mapper(itm));
            }
            return newList;
        }

        public static T Fold<T, U>(this IEnumerable<U> l, T self, Reducer<T, U> reducer)
        {
            T cur = self;
            foreach (U itm in l)
            {
                cur = reducer(cur, itm);
            }
            return cur;
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> self)
        {
            if (self == null) return true;
            return !self.Any();
        }

        public static List<T> Clone<T>(this IEnumerable<T> self)
        {
            return new List<T>(self);
        }
    }
}