// ----------------------------------------------------------------------------
// The MIT License
// LeopotamGroupLibrary https://github.com/Leopotam/LeopotamGroupLibraryUnity
// Copyright (c) 2012-2019 Leopotam <leopotam@gmail.com>
// ----------------------------------------------------------------------------

using System;
using System.Runtime.InteropServices;
using UnityEngine;


namespace Caxapexac.Common.Sharp.Runtime.MathExtra {
    /// <summary>
    /// Holder of extensions / helpers.
    /// </summary>
    public static class MathFast {
        /// <summary>
        /// PI approximation.
        /// </summary>
        public const float Pi = 3.141592654f;

        public static float Min (float a, float b) {
            return a > b ? b : a;
        }

        public static int Min (int a, int b) {
            return a > b ? b : a;
        }

        public static float Max (float a, float b) {
            return a > b ? a : b;
        }

        public static int Max (int a, int b) {
            return a > b ? a : b;
        }

        /// <summary>
        /// PI/2 approximation.
        /// </summary>
        public const float PiDiv2 = 3.141592654f * 0.5f;

        /// <summary>
        /// PI*2 approximation.
        /// </summary>
        public const float Pi2 = Pi * 2f;

        /// <summary>
        /// Radians to Degrees conversion multiplier.
        /// </summary>
        public const float Rad2Deg = 180f / Pi;

        /// <summary>
        /// Degrees to Radians conversion multiplier.
        /// </summary>
        public const float Deg2Rad = Pi / 180f;

        private const int SinCosIndexMask = ~(-1 << 12);

        private static readonly float[] _sinCache;

        private static readonly float[] _cosCache;

        private const float SinCosIndexFactor = SinCosCacheSize / Pi2;

        private const int SinCosCacheSize = SinCosIndexMask + 1;

        private const int Atan2Size = 1024;

        private const int Atan2NegSize = -Atan2Size;

        private static float[] _atan2CachePpy = new float[Atan2Size + 1];

        private static float[] _atan2CachePpx = new float[Atan2Size + 1];

        private static float[] _atan2CachePny = new float[Atan2Size + 1];

        private static float[] _atan2CachePnx = new float[Atan2Size + 1];

        private static float[] _atan2CacheNpy = new float[Atan2Size + 1];

        private static float[] _atan2CacheNpx = new float[Atan2Size + 1];

        private static float[] _atan2CacheNny = new float[Atan2Size + 1];

        private static float[] _atan2CacheNnx = new float[Atan2Size + 1];

        [StructLayout (LayoutKind.Explicit)]
        private struct FloatInt {
            [FieldOffset (0)]
            public float Float;

            [FieldOffset (0)]
            public int Int;
        }

        [StructLayout (LayoutKind.Explicit)]
        private struct DoubleInt64 {
            [FieldOffset (0)]
            public double Double;

            [FieldOffset (0)]
            public Int64 Int64;
        }

        static MathFast () {
            // Sin/Cos
            _sinCache = new float[SinCosCacheSize];
            _cosCache = new float[SinCosCacheSize];
            int i;
            for (i = 0; i < SinCosCacheSize; i++) {
                _sinCache[i] = (float) System.Math.Sin ((i + 0.5f) / SinCosCacheSize * Pi2);
                _cosCache[i] = (float) System.Math.Cos ((i + 0.5f) / SinCosCacheSize * Pi2);
            }

            var factor = SinCosCacheSize / 360f;
            for (i = 0; i < 360; i += 90) {
                _sinCache[(int) (i * factor) & SinCosIndexMask] = (float) System.Math.Sin (i * Pi / 180f);
                _cosCache[(int) (i * factor) & SinCosIndexMask] = (float) System.Math.Cos (i * Pi / 180f);
            }

            // Atan2
            var invAtan2Size = 1f / Atan2Size;
            for (i = 0; i <= Atan2Size; i++) {
                _atan2CachePpy[i] = (float) System.Math.Atan (i * invAtan2Size);
                _atan2CachePpx[i] = PiDiv2 - _atan2CachePpy[i];
                _atan2CachePny[i] = -_atan2CachePpy[i];
                _atan2CachePnx[i] = _atan2CachePpy[i] - PiDiv2;
                _atan2CacheNpy[i] = Pi - _atan2CachePpy[i];
                _atan2CacheNpx[i] = _atan2CachePpy[i] + PiDiv2;
                _atan2CacheNny[i] = _atan2CachePpy[i] - Pi;
                _atan2CacheNnx[i] = -PiDiv2 - _atan2CachePpy[i];
            }
        }

        /// <summary>
        /// Absolute value of provided data.
        /// </summary>
        /// <param name="v">Raw data.</param>
        public static float Abs (float v) {
            return v < 0f ? -v : v;
        }

        /// <summary>
        /// /// Absolute value of provided data.
        /// </summary>
        /// <param name="v">Raw data.</param>
        public static int Abs (int v) {
            return v < 0f ? -v : v;
        }

        /// <summary>
        /// Fast Vector2 normalization with 0.001 threshold error.
        /// </summary>
        /// <returns>Normalized Vector2.</returns>
        public static Vector2 NormalizedFast (this Vector2 v) {
            var wrapper = new FloatInt ();
            wrapper.Float = v.x * v.x + v.y * v.y;
            wrapper.Int = 0x5f3759df - (wrapper.Int >> 1);
            v.x *= wrapper.Float;
            v.y *= wrapper.Float;
            return v;
        }

        /// <summary>
        /// Fast Vector3 normalization with 0.001 threshold error.
        /// </summary>
        /// <returns>Normalized Vector3.</returns>
        public static Vector3 NormalizedFast (this Vector3 v) {
            var wrapper = new FloatInt ();
            wrapper.Float = v.x * v.x + v.y * v.y + v.z * v.z;
            wrapper.Int = 0x5f3759df - (wrapper.Int >> 1);
            v.x *= wrapper.Float;
            v.y *= wrapper.Float;
            v.z *= wrapper.Float;
            return v;
        }

        /// <summary>
        /// Fast Sin with 0.0003 threshold error.
        /// </summary>
        /// <param name="v">Angle in radians.</param>
        public static float Sin (float v) {
            return _sinCache[(int) (v * SinCosIndexFactor) & SinCosIndexMask];
        }

        /// <summary>
        /// Fast Cos with 0.0003 threshold error.
        /// </summary>
        /// <param name="v">Angle in radians.</param>
        public static float Cos (float v) {
            return _cosCache[(int) (v * SinCosIndexFactor) & SinCosIndexMask];
        }

        /// <summary>
        /// Fast Atan2 with 0.02 threshold error.
        /// </summary>
        public static float Atan2 (float y, float x) {
            if (x >= 0) {
                if (y >= 0) {
                    if (x >= y) {
                        return _atan2CachePpy[(int) (Atan2Size * y / x + 0.5)];
                    } else {
                        return _atan2CachePpx[(int) (Atan2Size * x / y + 0.5)];
                    }
                } else {
                    if (x >= -y) {
                        return _atan2CachePny[(int) (Atan2NegSize * y / x + 0.5)];
                    } else {
                        return _atan2CachePnx[(int) (Atan2NegSize * x / y + 0.5)];
                    }
                }
            } else {
                if (y >= 0) {
                    if (-x >= y) {
                        return _atan2CacheNpy[(int) (Atan2NegSize * y / x + 0.5)];
                    } else {
                        return _atan2CacheNpx[(int) (Atan2NegSize * x / y + 0.5)];
                    }
                } else {
                    if (x <= y) {
                        return _atan2CacheNny[(int) (Atan2Size * y / x + 0.5)];
                    } else {
                        return _atan2CacheNnx[(int) (Atan2Size * x / y + 0.5)];
                    }
                }
            }
        }

        /// <summary>
        /// Clamp data value to [min;max] range (inclusive).
        /// Not faster than Mathf.Clamp, but performance very close.
        /// </summary>
        /// <param name="data">Data to clamp.</param>
        /// <param name="min">Min range border.</param>
        /// <param name="max">Max range border.</param>
        public static float Clamp (float data, float min, float max) {
            if (data < min) {
                return min;
            } else {
                if (data > max) {
                    return max;
                }
                return data;
            }
        }

        /// <summary>
        /// Clamp data value to [min;max] range (inclusive).
        /// Not faster than Mathf.Clamp, but performance very close.
        /// </summary>
        /// <param name="data">Data to clamp.</param>
        /// <param name="min">Min range border.</param>
        /// <param name="max">Max range border.</param>
        public static int Clamp (int data, int min, int max) {
            if (data < min) {
                return min;
            } else {
                if (data > max) {
                    return max;
                }
                return data;
            }
        }

        /// <summary>
        /// Clamp data value to [0;1] range (inclusive).
        /// Not faster than Mathf.Clamp01, but performance very close.
        /// </summary>
        /// <param name="data">Data to clamp.</param>
        public static float Clamp01 (float data) {
            if (data < 0f) {
                return 0f;
            } else {
                if (data > 1f) {
                    return 1f;
                }
                return data;
            }
        }

        /// <summary>
        /// Return E raised to specified power.
        /// 2x times faster than System.Math.Exp, but gives 1% error.
        /// </summary>
        /// <param name="power">Target power.</param>
        public static float Exp (float power) {
            var c = new DoubleInt64 ();
            c.Int64 = (Int64) (1512775 * power + 1072632447) << 32;
            return (float) c.Double;
        }

        /// <summary>
        /// Linear interpolation between "a"-"b" in factor "t". Factor will be automatically clipped to [0;1] range.
        /// </summary>
        /// <param name="a">Interpolate From.</param>
        /// <param name="b">Interpolate To.</param>
        /// <param name="t">Factor of interpolation.</param>
        public static float Lerp (float a, float b, float t) {
            if (t <= 0f) {
                return a;
            } else {
                if (t >= 1f) {
                    return b;
                }
                return a + (b - a) * t;
            }
        }

        /// <summary>
        /// Linear interpolation between "a"-"b" in factor "t". Factor will not be automatically clipped to [0;1] range.
        /// Not faster than Mathf.LerpUnclamped, but performance very close.
        /// </summary>
        /// <param name="a">Interpolate From.</param>
        /// <param name="b">Interpolate To.</param>
        /// <param name="t">Factor of interpolation.</param>
        public static float LerpUnclamped (float a, float b, float t) {
            return a + (b - a) * t;
        }

        /// <summary>
        /// Return data raised to specified power.
        /// 4x times faster than System.Math.Pow, 6x times faster than System.Math.Pow, but gives 3% error.
        /// </summary>
        /// <param name="data">Data to raise.</param>
        /// <param name="power">Target power.</param>
        public static float PowInaccurate (float data, float power) {
            var c = new DoubleInt64 ();
            c.Double = data;
            c.Int64 = (Int64) (power * ((c.Int64 >> 32) - 1072632447) + 1072632447) << 32;
            return (float) c.Double;
        }

        /// <summary>
        /// Return data raised to specified power. Not faster than Mathf.Pow, but performance very close.
        /// </summary>
        /// <param name="data">Data to raise.</param>
        /// <param name="power">Target power.</param>
        public static float Pow (float data, float power) {
            return (float) System.Math.Pow (data, power);
        }

        /// <summary>
        /// Return largest integer smaller to or equal to data.
        /// </summary>
        /// <param name="data">Data to floor.</param>
        public static float Floor (float data) {
            return data >= 0f ? (int) data : (int) data - 1;
        }

        /// <summary>
        /// Return largest integer smaller to or equal to data.
        /// </summary>
        /// <param name="data">Data to floor.</param>
        public static int FloorToInt (float data) {
            return data >= 0f ? (int) data : (int) data - 1;
        }
    }
}