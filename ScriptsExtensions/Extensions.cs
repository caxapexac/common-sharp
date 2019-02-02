using System;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Client.Scripts.Algorithms.Legacy
{
    //EventSystem.current.IsPointerOverGameObject() - проверить кнопку в гуе
    
    public static class Extensions
    {
        public static void LookAt2D(this Transform me, Vector2 target)
        {
            Vector2 dir = target - (Vector2)me.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            me.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        public static void LookAt2D(this Transform me, Transform target)
        {
            me.LookAt2D(target.position);
        }

        public static void LookAt2D(this Transform me, GameObject target)
        {
            me.LookAt2D(target.transform.position);
        }

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
    }
}