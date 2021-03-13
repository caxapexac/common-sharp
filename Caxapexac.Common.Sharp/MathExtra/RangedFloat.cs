using System;


namespace Caxapexac.Common.Sharp.MathExtra
{
    [Serializable]
    public struct RangedFloat
    {
        public float Min;
        public float Max;

        public RangedFloat(float min, float max)
        {
            Min = min;
            Max = max;
        }
    }
}