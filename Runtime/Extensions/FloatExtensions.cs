using System.Collections.Generic;
using UnityEngine;


namespace Caxapexac.Common.Sharp.Runtime.Extensions
{
    public static class FloatExtensions
    {
        public static float GetNearestPoint(this float self, IList<float> lists)
        {
            float nearest = lists[0];
            foreach (var t in lists)
            {
                if (Mathf.Abs(t - self) < Mathf.Abs(nearest - self)) nearest = t;
            }

            return nearest;
        }

        public static Vector2 ToVector2(this float[] self)
        {
            return new Vector2(self[0], self[1]);
        }

        public static Color ToColor(this float[] self)
        {
            return new Color(self[0], self[1], self[2], self[3]);
        }

        public static float LinearRemap(this float self, float valueRangeMin, float valueRangeMax, float newRangeMin, float newRangeMax)
        {
            return (self - valueRangeMin) / (valueRangeMax - valueRangeMin) * (newRangeMax - newRangeMin) + newRangeMin;
        }

        public static float NotInRange(this float self, float min, float max)
        {
            if (min > max)
            {
                var x = min;
                min = max;
                max = x;
            }
            if (self < min || self > max) return self;
            float mid = (max - min) / 2;
            if (self > min) return self + mid < max ? min : max;
            return self - mid > min ? max : min;
        }

        public static int NotInRange(this int self, int min, int max)
        {
            return (int)((float)self).NotInRange(min, max);
        }

        public static float ClosestPoint(this float self, float pointA, float pointB)
        {
            if (pointA > pointB)
            {
                var x = pointA;
                pointA = pointB;
                pointB = x;
            }
            float middle = (pointB - pointA) / 2;
            float withOffset = self.NotInRange(pointA, pointB) + middle;
            return (withOffset >= pointB) ? pointB : pointA;
        }
    }
}