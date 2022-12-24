using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using StrengthReduction;

namespace StrengthReductionBencher;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class StrengthReduceBenchmark
{
    private const byte Max = byte.MaxValue;

    private readonly byte[] _divisors =
        { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, Max - 1, Max };

    private readonly byte[] _numerators = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

    [Benchmark(Baseline = true)]
    public void BenchBaseline()
    {
        foreach (var divisor in _divisors)
        foreach (var numerator in _numerators)
        {
            var div = numerator / divisor;
            var rem = numerator % divisor;
        }
    }

    [Benchmark]
    public void BenchStrengthReduceByte()
    {
        foreach (var divisor in _divisors)
        {
            var reduced = new StrengthReduceByte(divisor);
            foreach (var numerator in _numerators)
            {
                var reducedDiv = numerator / reduced;
                var reducedRem = numerator % reduced;
            }
        }
    }

    [Benchmark]
    public void BenchBaselineOne()
    {
        var div = (byte)(_numerators[20] / _divisors[20]);
        var rem = (byte)(_numerators[20] % _divisors[20]);
    }

    [Benchmark]
    public void BenchStrengthReduceByteOne()
    {
        var reduced = new StrengthReduceByte(_divisors[20]);
        var reducedDiv = _numerators[20] / reduced;
        var reducedRem = _numerators[20] % reduced;
    }
}