using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using StrengthReduction;

namespace StrengthReductionBencher;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class StrengthReduceBenchmark
{
    private readonly byte[] _divisorsBytes =
        { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, byte.MaxValue - 1, byte.MaxValue };

    private readonly ushort[] _divisorsU16 =
        { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, ushort.MaxValue - 1, ushort.MaxValue };

    private readonly uint[] _divisorsU32 =
        { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, uint.MaxValue - 1, uint.MaxValue };

    private readonly ulong[] _divisorsU64 =
        { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, ulong.MaxValue - 1, ulong.MaxValue };

    private readonly byte[] _numeratorsBytes =
        { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

    private readonly ushort[] _numeratorsU16 =
        { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

    private readonly uint[] _numeratorsU32 =
        { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

    private readonly ulong[] _numeratorsU64 =
        { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

    [Benchmark(Baseline = true)]
    public void BenchBaselineByte()
    {
        foreach (var divisor in _divisorsBytes)
        foreach (var numerator in _numeratorsBytes)
        {
            var div = numerator / divisor;
            var rem = numerator % divisor;
        }
    }

    [Benchmark]
    public void BenchStrengthReduceByte()
    {
        foreach (var divisor in _divisorsBytes)
        {
            var reduced = new StrengthReduceU8(divisor);
            foreach (var numerator in _numeratorsBytes)
            {
                var reducedDiv = numerator / reduced;
                var reducedRem = numerator % reduced;
            }
        }
    }

    [Benchmark]
    public void BenchBaselineU16()
    {
        foreach (var divisor in _divisorsU16)
        foreach (var numerator in _numeratorsU16)
        {
            var div = numerator / divisor;
            var rem = numerator % divisor;
        }
    }

    [Benchmark]
    public void BenchStrengthReduceU16()
    {
        foreach (var divisor in _divisorsU16)
        {
            var reduced = new StrengthReduceU16(divisor);
            foreach (var numerator in _numeratorsU16)
            {
                var reducedDiv = numerator / reduced;
                var reducedRem = numerator % reduced;
            }
        }
    }
    
    [Benchmark]
    public void BenchBaselineU32()
    {
        foreach (var divisor in _divisorsU16)
        foreach (var numerator in _numeratorsU16)
        {
            var div = numerator / divisor;
            var rem = numerator % divisor;
        }
    }

    [Benchmark]
    public void BenchStrengthReduceU32()
    {
        foreach (var divisor in _divisorsU32)
        {
            var reduced = new StrengthReduceU32(divisor);
            foreach (var numerator in _numeratorsU32)
            {
                var reducedDiv = numerator / reduced;
                var reducedRem = numerator % reduced;
            }
        }
    }
    
    [Benchmark]
    public void BenchBaselineU64()
    {
        foreach (var divisor in _divisorsU64)
        foreach (var numerator in _numeratorsU64)
        {
            var div = numerator / divisor;
            var rem = numerator % divisor;
        }
    }

    [Benchmark]
    public void BenchStrengthReduceU64()
    {
        foreach (var divisor in _divisorsU64)
        {
            var reduced = new StrengthReduceU64(divisor);
            foreach (var numerator in _numeratorsU64)
            {
                var reducedDiv = numerator / reduced;
                var reducedRem = numerator % reduced;
            }
        }
    }

    [Benchmark]
    public void BenchBaselineOneByte()
    {
        var div = (byte)(_numeratorsBytes[20] / _divisorsBytes[20]);
        var rem = (byte)(_numeratorsBytes[20] % _divisorsBytes[20]);
    }

    [Benchmark]
    public void BenchStrengthReduceByteOneByte()
    {
        var reduced = new StrengthReduceU8(_divisorsBytes[20]);
        var reducedDiv = _numeratorsBytes[20] / reduced;
        var reducedRem = _numeratorsBytes[20] % reduced;
    }
    
    [Benchmark]
    public void BenchBaselineOneU16()
    {
        var div = (ushort)(_numeratorsU16[20] / _divisorsU16[20]);
        var rem = (ushort)(_numeratorsU16[20] % _divisorsU16[20]);
    }

    [Benchmark]
    public void BenchStrengthReduceU16OneU16()
    {
        var reduced = new StrengthReduceU16(_divisorsU16[20]);
        var reducedDiv = _numeratorsU16[20] / reduced;
        var reducedRem = _numeratorsU16[20] % reduced;
    }
    
    [Benchmark]
    public void BenchBaselineOneU32()
    {
        var div = _numeratorsU32[20] / _divisorsU32[20];
        var rem = _numeratorsU32[20] % _divisorsU32[20];
    }

    [Benchmark]
    public void BenchStrengthReduceU32OneU32()
    {
        var reduced = new StrengthReduceU32(_divisorsU32[20]);
        var reducedDiv = _numeratorsU32[20] / reduced;
        var reducedRem = _numeratorsU32[20] % reduced;
    }
    
    [Benchmark]
    public void BenchBaselineOneU64()
    {
        var div = _numeratorsU32[20] / _divisorsU32[20];
        var rem = _numeratorsU32[20] % _divisorsU32[20];
    }

    [Benchmark]
    public void BenchStrengthReduceU64OneU64()
    {
        var reduced = new StrengthReduceU64(_divisorsU64[20]);
        var reducedDiv = _numeratorsU64[20] / reduced;
        var reducedRem = _numeratorsU64[20] % reduced;
    }
}