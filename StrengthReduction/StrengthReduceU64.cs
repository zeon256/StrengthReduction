using System.Numerics;
using System.Runtime.CompilerServices;

namespace StrengthReduction;

public readonly struct StrengthReduceU64
{
    private readonly ulong _divisor;
    private readonly UInt128 _multiplier;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public StrengthReduceU64(ulong divisor)
    {
        // check if powers of 2
        if ((divisor & (divisor - 1)) == 0)
        {
            _multiplier = 0;
        }
        else
        {
            var divided = UInt128.MaxValue / divisor;
            _multiplier = ++divided;
        }

        _divisor = divisor;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong operator /(ulong a, StrengthReduceU64 rhs)
    {
        UInt128 numerator = a;
        if (rhs._multiplier == 0) return (ulong)(numerator >> BitOperations.TrailingZeroCount(rhs._divisor));
        var mulHi = (UInt128)(numerator * (rhs._multiplier >> 64));
        var mulLo = (UInt128)(numerator * (ulong)rhs._multiplier) >> 64;
        return (ulong)((mulHi + mulLo) >> 64);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong operator %(ulong a, StrengthReduceU64 rhs)
    {
        if (rhs._multiplier == 0) return a & (rhs._divisor - 1);

        var quotient = a / rhs;
        return a - quotient * rhs._divisor;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static (ulong, ulong) DivRem(ulong numerator, StrengthReduceU64 denom)
    {
        return (numerator / denom, numerator % denom);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ulong Get()
    {
        return _divisor;
    }
}