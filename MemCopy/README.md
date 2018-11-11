# Memory copy

Compares ways of copying memory.

## SpanCopyBench

``` ini

BenchmarkDotNet=v0.11.2, OS=Windows 10.0.17134.376 (1803/April2018Update/Redstone4)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.1.403
  [Host]     : .NET Core 2.1.5 (CoreCLR 4.6.26919.02, CoreFX 4.6.26919.02), 64bit RyuJIT
  DefaultJob : .NET Core 2.1.5 (CoreCLR 4.6.26919.02, CoreFX 4.6.26919.02), 64bit RyuJIT


```
|            Method | ByteCount |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |
|------------------ |---------- |----------:|----------:|----------:|----------:|------:|--------:|
|       **Span_CopyTo** |        **10** |  **9.282 ns** | **0.0117 ns** | **0.0097 ns** |  **9.279 ns** |  **1.00** |    **0.00** |
| Buffer_MemoryCopy |        10 |  3.351 ns | 0.0084 ns | 0.0075 ns |  3.350 ns |  0.36 |    0.00 |
|                   |           |           |           |           |           |       |         |
|       **Span_CopyTo** |       **100** | **10.749 ns** | **0.0504 ns** | **0.0447 ns** | **10.730 ns** |  **1.00** |    **0.00** |
| Buffer_MemoryCopy |       100 |  6.067 ns | 0.0383 ns | 0.0340 ns |  6.057 ns |  0.56 |    0.00 |
|                   |           |           |           |           |           |       |         |
|       **Span_CopyTo** |      **1000** | **35.572 ns** | **0.7326 ns** | **1.5612 ns** | **36.631 ns** |  **1.00** |    **0.00** |
| Buffer_MemoryCopy |      1000 | 37.179 ns | 0.0453 ns | 0.0424 ns | 37.195 ns |  1.06 |    0.05 |

