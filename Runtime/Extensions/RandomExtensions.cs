using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Caxapexac.Common.Sharp.Runtime.Extensions
{
    public static class RandomExtensions
    {
        /// <summary>
        /// Gives you random enum value from T
        /// </summary>
        /// <returns></returns>
        public static T RandomEnum<T>() where T : struct, IConvertible
        {
            Array values = Enum.GetValues(typeof(T));
            return (T)values.GetValue((int)Mathf.Round(Random.value * (values.Length - 1)));
        }

        public static Color RandomColor
        {
            get => new Color(Random.Range(.1f, .9f), Random.Range(.1f, .9f), Random.Range(.1f, .9f));
        }

        public static Color RandomBright
        {
            get => new Color(Random.Range(.4f, 1), Random.Range(.4f, 1), Random.Range(.4f, 1));
        }

        public static Color RandomDim
        {
            get => new Color(Random.Range(.4f, .6f), Random.Range(.4f, .8f), Random.Range(.4f, .8f));
        }

        public static Vector3 OnUnitCircle(this Random self, Vector3 offset, float radius)
        {
            return offset + (Vector3)(Random.insideUnitCircle.normalized) * radius;
        }
    }
}