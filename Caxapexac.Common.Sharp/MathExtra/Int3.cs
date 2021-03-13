using System;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global


namespace Caxapexac.Common.Sharp.MathExtra
{
    public struct Int3 : IEquatable<Int3>
    {
        public static readonly Int3 Zero = new Int3(0);
        public static readonly Int3 One = new Int3(1, 1, 1);
        public static readonly Int3 Up = new Int3(0, 1);
        public static readonly Int3 Down = new Int3(0, -1);
        public static readonly Int3 Left = new Int3(-1);
        public static readonly Int3 Right = new Int3(1);
        public static readonly Int3 Forward = new Int3(0, 0, 1);
        public static readonly Int3 Back = new Int3(0, 0, -1);

        private int _x;
        private int _y;
        private int _z;

        public int X
        {
            get => _x;
            set => _x = value;
        }

        public int Y
        {
            get => _y;
            set => _y = value;
        }

        public int Z
        {
            get => _z;
            set => _z = value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Int3(int x = 0, int y = 0, int z = 0)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Vector3(Int3 v)
        {
            return new Vector3(v.X, v.Y, v.Z);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Int3(Vector3 v)
        {
            return new Int3((int)v.X, (int)v.Y, (int)v.Z);
        }

        // [MethodImpl(MethodImplOptions.AggressiveInlining)]
        // public static explicit operator Vector2Int(Vector3Int v)
        // {
        //     return new Vector2Int(v.X, v.Y);
        // }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Set(int x = 0, int y = 0, int z = 0)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        public float Magnitude()
        {
            return (float)Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public int SqrMagnitude()
        {
            return X * X + Y * Y + Z * Z;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Distance(Int3 other)
        {
            return (this - other).Magnitude();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Int3 Min(Int3 other)
        {
            return new Int3(Math.Min(X, other.X), Math.Min(Y, other.Y), Math.Min(Z, other.Z));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Int3 Max(Int3 other)
        {
            return new Int3(Math.Max(X, other.X), Math.Max(Y, other.Y), Math.Max(Z, other.Z));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Scale(Int3 scale)
        {
            X *= scale.X;
            Y *= scale.Y;
            Z *= scale.Z;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Clamp(Int3 min, Int3 max)
        {
            X = Math.Max(min.X, X);
            X = Math.Min(max.X, X);
            Y = Math.Max(min.Y, Y);
            Y = Math.Min(max.Y, Y);
            Z = Math.Max(min.Z, Z);
            Z = Math.Min(max.Z, Z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Int3 FloorToInt()
        {
            return new Int3((int)Math.Floor((double)X), (int)Math.Floor((double)Y), (int)Math.Floor((double)Z));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Int3 CeilToInt()
        {
            return new Int3((int)Math.Ceiling((double)X), (int)Math.Ceiling((double)Y), (int)Math.Ceiling((double)Z));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Int3 RoundToInt()
        {
            return new Int3((int)Math.Round((double)X), (int)Math.Round((double)Y), (int)Math.Round((double)Z));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int3 operator +(Int3 a, Int3 b)
        {
            return new Int3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int3 operator -(Int3 a, Int3 b)
        {
            return new Int3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int3 operator *(Int3 a, Int3 b)
        {
            return new Int3(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int3 operator -(Int3 a)
        {
            return new Int3(-a.X, -a.Y, -a.Z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int3 operator *(Int3 a, int b)
        {
            return new Int3(a.X * b, a.Y * b, a.Z * b);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int3 operator *(int a, Int3 b)
        {
            return new Int3(a * b.X, a * b.Y, a * b.Z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int3 operator /(Int3 a, int b)
        {
            return new Int3(a.X / b, a.Y / b, a.Z / b);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Int3 lhs, Int3 rhs)
        {
            return lhs.X == rhs.X && lhs.Y == rhs.Y && lhs.Z == rhs.Z;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Int3 lhs, Int3 rhs)
        {
            return !(lhs == rhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object other)
        {
            return other is Int3 other1 && Equals(other1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Int3 other)
        {
            return this == other;
        }

        public override int GetHashCode()
        {
            int hashCode1 = Y.GetHashCode();
            int hashCode2 = Z.GetHashCode();
            return X.GetHashCode() ^ hashCode1 << 4 ^ hashCode1 >> 28 ^ hashCode2 >> 4 ^ hashCode2 << 28;
        }

        public override string ToString()
        {
            return ToString(null, CultureInfo.InvariantCulture.NumberFormat);
        }

        public string ToString(string format)
        {
            return ToString(format, CultureInfo.InvariantCulture.NumberFormat);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"({X.ToString(format, formatProvider)}, {Y.ToString(format, formatProvider)}, {Z.ToString(format, formatProvider)})";
        }
    }
}