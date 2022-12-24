# Strength Reduction
> C# port of Rust [strength_reduce](https://github.com/ejmahler/strength_reduce)

## Overview
This library implements integer division and modulo via "[arithmetic strength reduction](https://en.wikipedia.org/wiki/Strength_reduction)".

## Benchmarks
```
|                         Method |         Mean |      Error |     StdDev | Ratio | RatioSD | Rank | Allocated | Alloc Ratio |
|------------------------------- |-------------:|-----------:|-----------:|------:|--------:|-----:|----------:|------------:|
| BenchStrengthReduceByteOneByte |     2.822 ns |  0.0236 ns |  0.0220 ns | 0.001 |    0.00 |    1 |         - |          NA |
|   BenchStrengthReduceU16OneU16 |     3.776 ns |  0.0288 ns |  0.0270 ns | 0.001 |    0.00 |    2 |         - |          NA |
|            BenchBaselineOneU32 |     5.155 ns |  0.0383 ns |  0.0358 ns | 0.002 |    0.00 |    3 |         - |          NA |
|            BenchBaselineOneU64 |     5.275 ns |  0.0221 ns |  0.0206 ns | 0.002 |    0.00 |    4 |         - |          NA |
|           BenchBaselineOneByte |     5.283 ns |  0.0420 ns |  0.0393 ns | 0.002 |    0.00 |    4 |         - |          NA |
|            BenchBaselineOneU16 |     5.289 ns |  0.0321 ns |  0.0300 ns | 0.002 |    0.00 |    4 |         - |          NA |
|   BenchStrengthReduceU32OneU32 |     5.775 ns |  0.0238 ns |  0.0223 ns | 0.002 |    0.00 |    5 |         - |          NA |
|   BenchStrengthReduceU64OneU64 |    72.487 ns |  1.1491 ns |  1.0748 ns | 0.023 |    0.00 |    6 |         - |          NA |
|        BenchStrengthReduceByte |   169.297 ns |  2.4841 ns |  2.2021 ns | 0.053 |    0.00 |    7 |         - |          NA |
|         BenchStrengthReduceU16 |   211.737 ns |  1.9675 ns |  1.8404 ns | 0.066 |    0.00 |    8 |         - |          NA |
|         BenchStrengthReduceU32 |   238.931 ns |  3.0642 ns |  2.8662 ns | 0.075 |    0.00 |    9 |         - |          NA |
|         BenchStrengthReduceU64 | 1,723.710 ns | 13.8923 ns | 12.3152 ns | 0.541 |    0.01 |   10 |         - |          NA |
|               BenchBaselineU64 | 3,137.604 ns |  8.6419 ns |  8.0836 ns | 0.984 |    0.01 |   11 |         - |          NA |
|              BenchBaselineByte | 3,187.400 ns | 36.5770 ns | 34.2142 ns | 1.000 |    0.00 |   12 |         - |          NA |
|               BenchBaselineU16 | 3,187.574 ns |  8.8402 ns |  7.8366 ns | 1.000 |    0.01 |   12 |         - |          NA |
|               BenchBaselineU32 | 3,204.308 ns | 36.1097 ns | 33.7771 ns | 1.005 |    0.02 |   12 |         - |          NA |
```