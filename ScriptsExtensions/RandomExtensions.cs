using System;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Client.Scripts.Algorithms.Legacy
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

		public static float RandomFixed(this int x)
		{
			x = (x << 13) ^ x;
			return (float)(1.0 - ((x * (x * x * 15731 + 789221) + 1376312589) & 2147483647) / 1073741824.0);
		}
		
        public static int WithRandomSign(this int value, float negativeProbability = 0.5f)
        {
            return Random.value < negativeProbability ? -value : value;
        }
		
				
		public static Vector3 OnUnitCircle(this Vector3 position, float radius)
        {
            return position + (Vector3)(Random.insideUnitCircle.normalized) * radius;
        }
	}
}