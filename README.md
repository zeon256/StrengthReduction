# Strength Reduction
> C# port of Rust [strength_reduce](https://github.com/ejmahler/strength_reduce)

## Overview
This library implements integer division and modulo via "[arithmetic strength reduction](https://en.wikipedia.org/wiki/Strength_reduction)".

## Why?
Modern processors can do multiplication and shifts much faster than division, and "arithmetic strength reduction" is an algorithm to transform divisions into multiplications and shifts. Compilers already perform this optimization for divisors that are known at compile time; this library enables this optimization for divisors that are only known at runtime. [From strength_reduce README](https://github.com/ejmahler/strength_reduce)

## Available types
- `StrengthReduceU8`
- `StrengthReduceU16`
- `StrengthReduceU32`
- `StrengthReduceU64`


## Example usage
> Works the best when there is repeated division of the same divisor. For more example see `StrengthReductionTest` folder
```csharp
    [Test]
    public void TestByte()
    {
        const byte max = byte.MaxValue;
        byte[] divisors = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, max - 1, max };
        byte[] numerators = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        foreach (var divisor in divisors)
        {
            var reduced = new StrengthReduceU8(divisor);
            foreach (var numerator in numerators)
            {
                Console.WriteLine($"Testing {numerator} / {divisor}");
                var expectedDiv = (byte)(numerator / divisor);
                var expectedRem = (byte)(numerator % divisor);
                var reducedDiv = numerator / reduced;
                var reducedRem = numerator % reduced;
                var (reducedCombinedDiv, reducedCombinedRem) = StrengthReduceU8.DivRem(numerator, reduced);
                Assert.AreEqual(expectedDiv, reducedDiv);
                Assert.AreEqual(expectedRem, reducedRem);
                Assert.AreEqual(expectedDiv, reducedCombinedDiv);
                Assert.AreEqual(expectedRem, reducedCombinedRem);
            }
        }
    }
```

## Benchmarks
> Benchmark ran with BenchmarkDotNet

|                         Method |         Mean |      Error |     StdDev |
|------------------------------- |-------------:|-----------:|-----------:|
| BenchStrengthReduceByteOneByte |     2.860 ns |  0.0044 ns |  0.0039 ns |
|   BenchStrengthReduceU16OneU16 |     3.833 ns |  0.0208 ns |  0.0194 ns |
|            BenchBaselineOneU64 |     5.291 ns |  0.0099 ns |  0.0088 ns |
|            BenchBaselineOneU16 |     5.294 ns |  0.0300 ns |  0.0266 ns |
|           BenchBaselineOneByte |     5.297 ns |  0.0063 ns |  0.0059 ns |
|            BenchBaselineOneU32 |     5.302 ns |  0.0729 ns |  0.0682 ns |
|   BenchStrengthReduceU32OneU32 |     5.824 ns |  0.0607 ns |  0.0568 ns |
|   BenchStrengthReduceU64OneU64 |    64.970 ns |  1.2642 ns |  1.0557 ns |
|        BenchStrengthReduceByte |   164.748 ns |  1.1126 ns |  1.0408 ns |
|         BenchStrengthReduceU16 |   221.468 ns |  4.4146 ns |  9.1169 ns |
|         BenchStrengthReduceU32 |   248.601 ns |  3.8517 ns |  3.4144 ns |
|         BenchStrengthReduceU64 | 1,775.256 ns | 20.8042 ns | 19.4603 ns |
|              BenchBaselineByte | 3,152.957 ns | 20.2562 ns | 18.9477 ns |
|               BenchBaselineU16 | 3,195.399 ns |  4.2095 ns |  3.7316 ns |
|               BenchBaselineU64 | 3,196.124 ns |  2.2190 ns |  2.0757 ns |
|               BenchBaselineU32 | 3,202.035 ns |  4.4703 ns |  3.9628 ns |
