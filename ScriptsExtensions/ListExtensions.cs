using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;


namespace Client.Scripts.Algorithms.ScriptsExtensions
{
    public static class ListExtensions
    {
        public static List<T> Clone<T>(this List<T> list)
        {
            return new List<T>(list);
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = Random.Range(0, n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static T RandomItem<T>(this IList<T> list)
        {
            if (list.Count == 0)
                throw new IndexOutOfRangeException("Cannot select a random item from an empty list");
            return list[UnityEngine.Random.Range(0, list.Count)];
        }

        public static T RemoveRandom<T>(this IList<T> list)
        {
            if (list.Count == 0)
                throw new IndexOutOfRangeException("Cannot remove a random item from an empty list");
            int index = Random.Range(0, list.Count);
            T item = list[index];
            list.RemoveAt(index);
            return item;
        }

        public static T[] ForEach<T>(this T[] array, Action<T> callback)
        {
            if (callback != null)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    callback(array[i]);
                }
            }

            return array;
        }
    }
}