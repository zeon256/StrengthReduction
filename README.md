# Strength Reduction
> C# port of Rust [strength_reduce](https://github.com/ejmahler/strength_reduce)

## Overview
This library implements integer division and modulo via "[arithmetic strength reduction](https://en.wikipedia.org/wiki/Strength_reduction)".

## Why?
Modern processors can do multiplication and shifts much faster than division, and "arithmetic strength reduction" is an algorithm to transform divisions into multiplications and shifts. Compilers already perform this optimization for divisors that are known at compile time; this library enables this optimization for divisors that are only known at runtime. [From strength_reduce README](https://github.com/ejmahler/strength_reduce)

## Benchmarks
|                         Method |         Mean |      Error |     StdDev |
|------------------------------- |-------------:|-----------:|-----------:|
| BenchStrengthReduceByteOneByte |     2.822 ns |  0.0236 ns |  0.0220 ns |
|   BenchStrengthReduceU16OneU16 |     3.776 ns |  0.0288 ns |  0.0270 ns |
|            BenchBaselineOneU32 |     5.155 ns |  0.0383 ns |  0.0358 ns |
|            BenchBaselineOneU64 |     5.275 ns |  0.0221 ns |  0.0206 ns |
|           BenchBaselineOneByte |     5.283 ns |  0.0420 ns |  0.0393 ns |
|            BenchBaselineOneU16 |     5.289 ns |  0.0321 ns |  0.0300 ns |
|   BenchStrengthReduceU32OneU32 |     5.775 ns |  0.0238 ns |  0.0223 ns |
|   BenchStrengthReduceU64OneU64 |    72.487 ns |  1.1491 ns |  1.0748 ns |
|        BenchStrengthReduceByte |   169.297 ns |  2.4841 ns |  2.2021 ns |
|         BenchStrengthReduceU16 |   211.737 ns |  1.9675 ns |  1.8404 ns |
|         BenchStrengthReduceU32 |   238.931 ns |  3.0642 ns |  2.8662 ns |
|         BenchStrengthReduceU64 | 1,723.710 ns | 13.8923 ns | 12.3152 ns |
|               BenchBaselineU64 | 3,137.604 ns |  8.6419 ns |  8.0836 ns |
|              BenchBaselineByte | 3,187.400 ns | 36.5770 ns | 34.2142 ns |
|               BenchBaselineU16 | 3,187.574 ns |  8.8402 ns |  7.8366 ns |
|               BenchBaselineU32 | 3,204.308 ns | 36.1097 ns | 33.7771 ns |
