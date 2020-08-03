namespace Caxapexac.Common.Sharp.Runtime.Extensions
{
    public static class NumericExtensions
    {
        public static float LinearRemap(this float value,
            float valueRangeMin, float valueRangeMax,
            float newRangeMin, float newRangeMax)
        {
            return (value - valueRangeMin) / (valueRangeMax - valueRangeMin) * (newRangeMax - newRangeMin)
                + newRangeMin;
        }
    }
}