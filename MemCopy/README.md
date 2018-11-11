# Memory copy

Compares ways of copying memory.

## SpanCopyBench on .NET Core 2.2.0-preview3

``` ini

BenchmarkDotNet=v0.11.2, OS=Windows 10.0.17134.376 (1803/April2018Update/Redstone4)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.100-preview3-009430
  [Host]     : .NET Core 2.2.0-preview3-27014-02 (CoreCLR 4.6.27014.03, CoreFX 4.6.27014.02), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.0-preview3-27014-02 (CoreCLR 4.6.27014.03, CoreFX 4.6.27014.02), 64bit RyuJIT


```
|            Method | ByteCount |      Mean |     Error |    StdDev | Ratio |
|------------------ |---------- |----------:|----------:|----------:|------:|
|       **Span_CopyTo** |        **10** |  **9.433 ns** | **0.0156 ns** | **0.0139 ns** |  **1.00** |
| Buffer_MemoryCopy |        10 |  3.322 ns | 0.0158 ns | 0.0148 ns |  0.35 |
|                   |           |           |           |           |       |
|       **Span_CopyTo** |       **100** | **10.502 ns** | **0.0717 ns** | **0.0671 ns** |  **1.00** |
| Buffer_MemoryCopy |       100 |  7.045 ns | 0.0198 ns | 0.0185 ns |  0.67 |
|                   |           |           |           |           |       |
|       **Span_CopyTo** |      **1000** | **33.813 ns** | **0.1070 ns** | **0.0893 ns** |  **1.00** |
| Buffer_MemoryCopy |      1000 | 39.270 ns | 0.2275 ns | 0.2128 ns |  1.16 |

## SpanCopyBench on .NET Core 3.0.0-preview-27109-05

``` ini

BenchmarkDotNet=v0.11.2, OS=Windows 10.0.17134.376 (1803/April2018Update/Redstone4)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.0.100-preview-009744
  [Host]     : .NET Core 3.0.0-preview-27109-05 (CoreCLR 4.6.27102.02, CoreFX 4.7.18.55201), 64bit RyuJIT
  DefaultJob : .NET Core 3.0.0-preview-27109-05 (CoreCLR 4.6.27102.02, CoreFX 4.7.18.55201), 64bit RyuJIT


```
|            Method | ByteCount |      Mean |     Error |    StdDev | Ratio | RatioSD |
|------------------ |---------- |----------:|----------:|----------:|------:|--------:|
|       **Span_CopyTo** |        **10** |  **2.538 ns** | **0.0399 ns** | **0.0373 ns** |  **1.00** |    **0.00** |
| Buffer_MemoryCopy |        10 |  2.686 ns | 0.0096 ns | 0.0090 ns |  1.06 |    0.02 |
|                   |           |           |           |           |       |         |
|       **Span_CopyTo** |       **100** |  **5.086 ns** | **0.0263 ns** | **0.0246 ns** |  **1.00** |    **0.00** |
| Buffer_MemoryCopy |       100 |  5.915 ns | 0.0157 ns | 0.0147 ns |  1.16 |    0.01 |
|                   |           |           |           |           |       |         |
|       **Span_CopyTo** |      **1000** | **31.702 ns** | **0.0311 ns** | **0.0259 ns** |  **1.00** |    **0.00** |
| Buffer_MemoryCopy |      1000 | 32.033 ns | 0.0594 ns | 0.0556 ns |  1.01 |    0.00 |

