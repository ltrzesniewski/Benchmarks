## Summary

``` ini

BenchmarkDotNet=v0.10.14, OS=Windows 10.0.16299.371 (1709/FallCreatorsUpdate/Redstone3)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
  [Host]     : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0
  DefaultJob : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0


```
|       Method |      Mean |     Error |    StdDev | Scaled | ScaledSD |
|------------- |----------:|----------:|----------:|-------:|---------:|
|      Managed | 0.6530 ns | 0.0162 ns | 0.0152 ns |   1.00 |     0.00 |
|      PInvoke | 5.6099 ns | 0.0056 ns | 0.0049 ns |   8.60 |     0.19 |
|     Delegate | 8.3560 ns | 0.0139 ns | 0.0130 ns |  12.80 |     0.29 |
|        Calli | 5.4074 ns | 0.0055 ns | 0.0046 ns |   8.29 |     0.19 |
|       CppCli | 8.8193 ns | 0.0466 ns | 0.0436 ns |  13.51 |     0.31 |
| CppCliDirect | 5.6045 ns | 0.0278 ns | 0.0260 ns |   8.59 |     0.20 |
