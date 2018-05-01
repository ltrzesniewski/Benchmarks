# Native interop

Compares ways to call into native code.

## Summary: NativeInteropBench

``` ini

BenchmarkDotNet=v0.10.14, OS=Windows 10.0.16299.371 (1709/FallCreatorsUpdate/Redstone3)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
  [Host]     : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0
  DefaultJob : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0


```
|       Method |      Mean |     Error |    StdDev | Scaled | ScaledSD |
|------------- |----------:|----------:|----------:|-------:|---------:|
|      Managed | 0.6480 ns | 0.0025 ns | 0.0021 ns |   1.00 |     0.00 |
|      PInvoke | 5.6129 ns | 0.0070 ns | 0.0062 ns |   8.66 |     0.03 |
|     Delegate | 8.3412 ns | 0.0034 ns | 0.0028 ns |  12.87 |     0.04 |
|        Calli | 5.4149 ns | 0.0264 ns | 0.0247 ns |   8.36 |     0.05 |
|       CppCli | 8.8202 ns | 0.0042 ns | 0.0035 ns |  13.61 |     0.04 |
| CppCliDirect | 5.5917 ns | 0.0199 ns | 0.0177 ns |   8.63 |     0.04 |

