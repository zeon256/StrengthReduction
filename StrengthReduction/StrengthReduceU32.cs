using System.Numerics;
using System.Runtime.CompilerServices;

namespace StrengthReduction;

public readonly struct StrengthReduceU32 : IFormattable, IComparable<StrengthReduceU32>, IEquatable<StrengthReduceU32>
{
    private readonly uint _divisor;
    private readonly ulong _multiplier;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public StrengthReduceU32(uint divisor)
    {
        // check if powers of 2
        if ((divisor & (divisor - 1)) == 0)
        {
            _multiplier = 0;
        }
        else
        {
            var divided = ulong.MaxValue / divisor;
            _multiplier = ++divided;
        }

        _divisor = divisor;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(StrengthReduceU32 a, StrengthReduceU32 b)
    {
        return a._divisor == b._divisor;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(StrengthReduceU32 a, StrengthReduceU32 b)
    {
        return !(a == b);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator StrengthReduceU32(uint divisor)
    {
        return new StrengthReduceU32(divisor);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint operator /(uint a, StrengthReduceU32 rhs)
    {
        ulong numerator = a;
        if (rhs._multiplier == 0) return (uint)(numerator >> BitOperations.TrailingZeroCount(rhs._divisor));
        var mulHi = numerator * (rhs._multiplier >> 32);
        var mulLo = (numerator * (uint)rhs._multiplier) >> 32;
        return (uint)((mulHi + mulLo) >> 32);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static uint operator %(uint a, StrengthReduceU32 rhs)
    {
        if (rhs._multiplier == 0) return a & (rhs._divisor - 1);

        var quotient = a / rhs;
        return a - quotient * rhs._divisor;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (uint, uint) DivRem(uint numerator, StrengthReduceU32 denom)
    {
        return (numerator / denom, numerator % denom);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public uint Get()
    {
        return _divisor;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        return _divisor.ToString();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(StrengthReduceU32 other)
    {
        return _divisor.CompareTo(other._divisor);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Equals(StrengthReduceU32 other)
    {
        return _divisor.Equals(other._divisor);
    }
}