# Enumeration

Compares stuff related to `IEnumerable<T>`.

NOTE: `EmptyEnumerableBench` - both cases generate the same assembly, everything is optimized out.

## EmptyEnumerableBench

``` ini

BenchmarkDotNet=v0.11.1, OS=Windows 10.0.17134.285 (1803/April2018Update/Redstone4)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.1.402
  [Host]     : .NET Core 2.1.4 (CoreCLR 4.6.26814.03, CoreFX 4.6.26814.02), 64bit RyuJIT
  DefaultJob : .NET Core 2.1.4 (CoreCLR 4.6.26814.03, CoreFX 4.6.26814.02), 64bit RyuJIT


```
|           Method |      Mean |     Error |    StdDev | Scaled |
|----------------- |----------:|----------:|----------:|-------:|
|            Array | 2.3652 ns | 0.0035 ns | 0.0031 ns |   1.00 |
| WithoutInterface | 0.0898 ns | 0.0023 ns | 0.0020 ns |   0.04 |
|   WithInterfaces | 0.0942 ns | 0.0013 ns | 0.0011 ns |   0.04 |

## NonEmptyEnumerableBench

``` ini

BenchmarkDotNet=v0.11.1, OS=Windows 10.0.17134.285 (1803/April2018Update/Redstone4)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.1.402
  [Host]     : .NET Core 2.1.4 (CoreCLR 4.6.26814.03, CoreFX 4.6.26814.02), 64bit RyuJIT
  DefaultJob : .NET Core 2.1.4 (CoreCLR 4.6.26814.03, CoreFX 4.6.26814.02), 64bit RyuJIT


```
|           Method |     Mean |     Error |    StdDev | Scaled |
|----------------- |---------:|----------:|----------:|-------:|
|            Array | 6.011 ns | 0.0142 ns | 0.0133 ns |   1.00 |
| WithoutInterface | 3.311 ns | 0.0092 ns | 0.0086 ns |   0.55 |
|   WithInterfaces | 3.313 ns | 0.0056 ns | 0.0049 ns |   0.55 |

