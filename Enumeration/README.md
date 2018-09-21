# Enumeration

Compares stuff related to IEnumerable<T>

## EmptyEnumerableBench

``` ini

BenchmarkDotNet=v0.11.1, OS=Windows 10.0.17134.285 (1803/April2018Update/Redstone4)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.1.402
  [Host]     : .NET Core 2.1.4 (CoreCLR 4.6.26814.03, CoreFX 4.6.26814.02), 64bit RyuJIT
  DefaultJob : .NET Core 2.1.4 (CoreCLR 4.6.26814.03, CoreFX 4.6.26814.02), 64bit RyuJIT


```
|           Method |      Mean |     Error |    StdDev | Scaled | ScaledSD |
|----------------- |----------:|----------:|----------:|-------:|---------:|
| WithoutInterface | 0.1238 ns | 0.0077 ns | 0.0072 ns |   1.00 |     0.00 |
|   WithInterfaces | 0.0976 ns | 0.0059 ns | 0.0055 ns |   0.79 |     0.06 |

