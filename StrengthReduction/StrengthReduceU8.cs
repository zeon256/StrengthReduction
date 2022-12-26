using System.Numerics;
using System.Runtime.CompilerServices;

namespace StrengthReduction;

public readonly struct StrengthReduceU8 : IFormattable, IComparable<StrengthReduceU8>, IEquatable<StrengthReduceU8>
{
    private readonly byte _divisor;
    private readonly ushort _multiplier;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public StrengthReduceU8(byte divisor)
    {
        // check if powers of 2
        if ((divisor & (divisor - 1)) == 0)
        {
            _multiplier = 0;
        }
        else
        {
            var divided = (ushort)(ushort.MaxValue / divisor);
            _multiplier = ++divided;
        }

        _divisor = divisor;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator StrengthReduceU8(byte divisor)
    {
        return new StrengthReduceU8(divisor);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(StrengthReduceU8 a, StrengthReduceU8 b)
    {
        return a._divisor == b._divisor;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(StrengthReduceU8 a, StrengthReduceU8 b)
    {
        return !(a == b);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte operator /(byte a, StrengthReduceU8 rhs)
    {
        ushort numerator = a;
        if (rhs._multiplier == 0) return (byte)(ushort)(numerator >> BitOperations.TrailingZeroCount(rhs._divisor));
        var mulHi = (ushort)(numerator * (rhs._multiplier >> 8));
        var mulLo = (ushort)((numerator * (byte)rhs._multiplier) >> 8);
        return (byte)((mulHi + mulLo) >> 8);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte operator %(byte a, StrengthReduceU8 rhs)
    {
        if (rhs._multiplier == 0) return (byte)(a & (rhs._divisor - 1));

        var prod = (uint)(ushort)unchecked(rhs._multiplier * a);
        uint divisor = rhs._divisor;
        var shifted = (prod * divisor) >> 16;
        return (byte)shifted;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (byte, byte) DivRem(byte numerator, StrengthReduceU8 denom)
    {
        return (numerator / denom, numerator % denom);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte Get()
    {
        return _divisor;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        return _divisor.ToString();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(StrengthReduceU8 other)
    {
        return _divisor.CompareTo(other._divisor);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(StrengthReduceU8 other)
    {
        return _divisor.Equals(other._divisor);
    }
}