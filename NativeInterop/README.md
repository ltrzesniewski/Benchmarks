# Native Interop

Compares ways to call into native code.

## NativeInteropNetFwkBench

``` ini

BenchmarkDotNet=v0.10.14, OS=Windows 10.0.16299.371 (1709/FallCreatorsUpdate/Redstone3)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
  [Host]     : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0
  DefaultJob : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0


```
|       Method |      Mean |     Error |    StdDev | Scaled | ScaledSD |
|------------- |----------:|----------:|----------:|-------:|---------:|
|      Managed | 0.6482 ns | 0.0063 ns | 0.0056 ns |   1.00 |     0.00 |
|      PInvoke | 5.6140 ns | 0.0092 ns | 0.0086 ns |   8.66 |     0.07 |
|     Delegate | 8.3906 ns | 0.0634 ns | 0.0593 ns |  12.95 |     0.14 |
|        Calli | 5.4318 ns | 0.0257 ns | 0.0241 ns |   8.38 |     0.08 |
|       CppCli | 8.8608 ns | 0.0554 ns | 0.0518 ns |  13.67 |     0.14 |
| CppCliDirect | 5.5873 ns | 0.0046 ns | 0.0038 ns |   8.62 |     0.07 |

## NativeInteropNetCoreBench

``` ini

BenchmarkDotNet=v0.10.14, OS=Windows 10.0.16299.371 (1709/FallCreatorsUpdate/Redstone3)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.1.104
  [Host]     : .NET Core 2.0.6 (CoreCLR 4.6.26212.01, CoreFX 4.6.26212.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.0.6 (CoreCLR 4.6.26212.01, CoreFX 4.6.26212.01), 64bit RyuJIT


```
|   Method |       Mean |     Error |    StdDev | Scaled | ScaledSD |
|--------- |-----------:|----------:|----------:|-------:|---------:|
|  Managed |  0.6622 ns | 0.0033 ns | 0.0029 ns |   1.00 |     0.00 |
|  PInvoke |  5.5982 ns | 0.0029 ns | 0.0024 ns |   8.45 |     0.04 |
| Delegate | 12.3860 ns | 0.0165 ns | 0.0129 ns |  18.70 |     0.08 |
|    Calli |  5.6240 ns | 0.0180 ns | 0.0160 ns |   8.49 |     0.04 |

## NativeInteropStringNetFwkBench

``` ini

BenchmarkDotNet=v0.10.14, OS=Windows 10.0.16299.371 (1709/FallCreatorsUpdate/Redstone3)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
  [Host]     : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0
  DefaultJob : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0


```
|                  Method |              Mean |           Error |          StdDev |        Scaled |   ScaledSD |
|------------------------ |------------------:|----------------:|----------------:|--------------:|-----------:|
|                 Managed |          1.109 ns |       0.0118 ns |       0.0111 ns |          1.00 |       0.00 |
|                 PInvoke |          6.486 ns |       0.0035 ns |       0.0033 ns |          5.85 |       0.06 |
|                Delegate |          8.749 ns |       0.0511 ns |       0.0478 ns |          7.89 |       0.09 |
|              CalliFixed |         32.501 ns |       0.0556 ns |       0.0465 ns |         29.31 |       0.28 |
|          CalliCustomPin |         33.071 ns |       0.1334 ns |       0.1183 ns |         29.82 |       0.30 |
| CalliCustomPinWithLocal |         32.732 ns |       0.2967 ns |       0.2776 ns |         29.52 |       0.37 |
|             CalliString | 46,639,052.011 ns | 179,411.8348 ns | 167,821.9252 ns | 42,057,972.66 | 426,712.48 |
|                  CppCli |          8.796 ns |       0.0057 ns |       0.0051 ns |          7.93 |       0.08 |
|            CppCliDirect |          6.537 ns |       0.0458 ns |       0.0429 ns |          5.90 |       0.07 |

