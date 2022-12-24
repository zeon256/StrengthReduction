using BenchmarkDotNet.Running; 

namespace StrengthReductionBencher;

internal class Program
{
    private static void Main(string[] args)
    {
        BenchmarkRunner.Run<StrengthReduceBenchmark>();
    }
}