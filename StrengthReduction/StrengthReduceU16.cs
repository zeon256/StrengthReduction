using System.Numerics;
using System.Runtime.CompilerServices;

namespace StrengthReduction;

public readonly struct StrengthReduceU16 : IFormattable, IComparable<StrengthReduceU16>, IEquatable<StrengthReduceU16>
{
    private readonly ushort _divisor;
    private readonly uint _multiplier;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public StrengthReduceU16(ushort divisor)
    {
        // check if powers of 2
        if ((divisor & (divisor - 1)) == 0)
        {
            _multiplier = 0;
        }
        else
        {
            var divided = uint.MaxValue / divisor;
            _multiplier = ++divided;
        }

        _divisor = divisor;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator StrengthReduceU16(ushort divisor)
    {
        return new StrengthReduceU16(divisor);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(StrengthReduceU16 a, StrengthReduceU16 b)
    {
        return a._divisor == b._divisor;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(StrengthReduceU16 a, StrengthReduceU16 b)
    {
        return !(a == b);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ushort operator /(ushort a, StrengthReduceU16 div)
    {
        uint numerator = a;
        if (div._multiplier == 0) return (ushort)(numerator >> BitOperations.TrailingZeroCount(div._divisor));
        var mulHi = numerator * (div._multiplier >> 16);
        var mulLo = (numerator * (ushort)div._multiplier) >> 16;
        return (ushort)((mulHi + mulLo) >> 16);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ushort operator %(ushort a, StrengthReduceU16 rhs)
    {
        if (rhs._multiplier == 0) return (ushort)(a & (rhs._divisor - 1));

        var quotient = a / rhs;
        return (ushort)(a - quotient * rhs._divisor);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (ushort, ushort) DivRem(ushort numerator, StrengthReduceU16 denom)
    {
        return (numerator / denom, numerator % denom);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ushort Get()
    {
        return _divisor;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        return _divisor.ToString();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(StrengthReduceU16 other)
    {
        return _divisor.CompareTo(other._divisor);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(StrengthReduceU16 other)
    {
        return _divisor.Equals(other._divisor);
    }
}