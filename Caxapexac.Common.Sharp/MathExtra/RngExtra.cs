using System;
using System.Collections.Generic;
using Caxapexac.Common.Sharp.Extensions;


namespace Caxapexac.Common.Sharp.MathExtra
{
    public static class RngExtra
    {
        public static Random GetRandom()
        {
            return new Random(Guid.NewGuid().GetHashCode());
        }

        public static List<int> GetRandomValue(int min, int max, int count)
        {
            Random rand = GetRandom();
            List<int> randValues = new List<int>();

            while (randValues.Count < count)
            {
                int next = rand.Next(min, max);
                randValues.Add(next);
            }

            return randValues;
        }

        public static HashSet<int> GetUniqueRandomValue(int min, int max, int count, List<int> exception = null)
        {
            Random rand = GetRandom();
            count = count.Clamp(0, max);
            HashSet<int> randValues = new HashSet<int>();
            while (randValues.Count < count)
            {
                //rand.Next max value is exclusive
                int next = rand.Next(min, max);
                if (exception == null || !exception.Contains(next))
                {
                    randValues.Add(next);
                }
            }

            return randValues;
        }

        public static int[] GetUniqueRandomValueArr(int min, int max, int count, List<int> exception = null)
        {
            HashSet<int> rands = GetUniqueRandomValue(min, max, count, exception);
            int[] randArr = new int[count];
            int i = 0;
            foreach (int rand in rands)
            {
                randArr[i] = rand;
                ++i;
            }
            return randArr;
        }
    }
}