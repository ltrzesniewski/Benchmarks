# Memory copy

Compares ways of copying memory.

## SpanCopyBench

``` ini

BenchmarkDotNet=v0.11.2, OS=Windows 10.0.17134.376 (1803/April2018Update/Redstone4)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.0.100-preview-009744
  [Host]     : .NET Core 2.1.5 (CoreCLR 4.6.26919.02, CoreFX 4.6.26919.02), 64bit RyuJIT
  Job-FKUZRZ : .NET Core 2.1.5 (CoreCLR 4.6.26919.02, CoreFX 4.6.26919.02), 64bit RyuJIT
  Job-ZILJCX : .NET Core 3.0.0-preview-27109-05 (CoreCLR 4.6.27102.02, CoreFX 4.7.18.55201), 64bit RyuJIT


```
|            Method |     Toolchain | ByteCount |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |
|------------------ |-------------- |---------- |----------:|----------:|----------:|----------:|------:|--------:|
|       **Span_CopyTo** | **.NET Core 2.1** |        **10** | **13.281 ns** | **0.0565 ns** | **0.0529 ns** | **13.256 ns** |  **1.00** |    **0.00** |
| Buffer_MemoryCopy | .NET Core 2.1 |        10 |  3.272 ns | 0.0083 ns | 0.0069 ns |  3.273 ns |  0.25 |    0.00 |
|                   |               |           |           |           |           |           |       |         |
|       Span_CopyTo | .NET Core 3.0 |        10 |  2.405 ns | 0.0340 ns | 0.0301 ns |  2.409 ns |  1.00 |    0.00 |
| Buffer_MemoryCopy | .NET Core 3.0 |        10 |  2.851 ns | 0.0100 ns | 0.0089 ns |  2.853 ns |  1.19 |    0.01 |
|                   |               |           |           |           |           |           |       |         |
|       **Span_CopyTo** | **.NET Core 2.1** |       **100** | **10.771 ns** | **0.0516 ns** | **0.0458 ns** | **10.780 ns** |  **1.00** |    **0.00** |
| Buffer_MemoryCopy | .NET Core 2.1 |       100 |  6.071 ns | 0.0233 ns | 0.0206 ns |  6.072 ns |  0.56 |    0.00 |
|                   |               |           |           |           |           |           |       |         |
|       Span_CopyTo | .NET Core 3.0 |       100 |  4.525 ns | 0.2472 ns | 0.5373 ns |  4.210 ns |  1.00 |    0.00 |
| Buffer_MemoryCopy | .NET Core 3.0 |       100 |  5.929 ns | 0.0081 ns | 0.0068 ns |  5.927 ns |  1.08 |    0.01 |
|                   |               |           |           |           |           |           |       |         |
|       **Span_CopyTo** | **.NET Core 2.1** |      **1000** | **34.362 ns** | **0.7061 ns** | **1.5500 ns** | **33.241 ns** |  **1.00** |    **0.00** |
| Buffer_MemoryCopy | .NET Core 2.1 |      1000 | 37.353 ns | 0.1848 ns | 0.1728 ns | 37.323 ns |  1.09 |    0.05 |
|                   |               |           |           |           |           |           |       |         |
|       Span_CopyTo | .NET Core 3.0 |      1000 | 31.971 ns | 0.1400 ns | 0.1310 ns | 32.003 ns |  1.00 |    0.00 |
| Buffer_MemoryCopy | .NET Core 3.0 |      1000 | 32.044 ns | 0.0611 ns | 0.0571 ns | 32.053 ns |  1.00 |    0.00 |

