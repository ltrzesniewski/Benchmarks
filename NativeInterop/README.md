# Native Interop

Compares ways to call into native code.

## NativeInteropNetFwkBench

``` ini

BenchmarkDotNet=v0.10.14, OS=Windows 10.0.16299.309 (1709/FallCreatorsUpdate/Redstone3)
Intel Core i7-7700 CPU 3.60GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
Frequency=3515629 Hz, Resolution=284.4441 ns, Timer=TSC
  [Host]     : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0
  DefaultJob : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0


```
|                        Method |       Mean |     Error |    StdDev | Scaled | ScaledSD |
|------------------------------ |-----------:|----------:|----------:|-------:|---------:|
|                       Managed |  0.8697 ns | 0.0026 ns | 0.0025 ns |   1.00 |     0.00 |
| PInvokePInvokeWithoutSecurity |  7.0018 ns | 0.0089 ns | 0.0083 ns |   8.05 |     0.02 |
|           PInvokeWithSecurity | 11.3666 ns | 0.0562 ns | 0.0498 ns |  13.07 |     0.07 |
|                      Delegate | 10.5551 ns | 0.0169 ns | 0.0158 ns |  12.14 |     0.04 |
|                         Calli |  6.7567 ns | 0.0134 ns | 0.0119 ns |   7.77 |     0.03 |
|                        CppCli | 10.6683 ns | 0.0393 ns | 0.0348 ns |  12.27 |     0.05 |
|                  CppCliDirect |  7.0388 ns | 0.0105 ns | 0.0093 ns |   8.09 |     0.02 |

## NativeInteropNetCoreBench

``` ini

BenchmarkDotNet=v0.10.14, OS=Windows 10.0.16299.309 (1709/FallCreatorsUpdate/Redstone3)
Intel Core i7-7700 CPU 3.60GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
Frequency=3515629 Hz, Resolution=284.4441 ns, Timer=TSC
.NET Core SDK=2.1.104
  [Host]     : .NET Core 2.0.6 (CoreCLR 4.6.26212.01, CoreFX 4.6.26212.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.0.6 (CoreCLR 4.6.26212.01, CoreFX 4.6.26212.01), 64bit RyuJIT


```
|                 Method |      Mean |     Error |    StdDev | Scaled | ScaledSD |
|----------------------- |----------:|----------:|----------:|-------:|---------:|
|                Managed |  1.088 ns | 0.0032 ns | 0.0028 ns |   1.00 |     0.00 |
| PInvokeWithoutSecurity |  7.043 ns | 0.0175 ns | 0.0146 ns |   6.48 |     0.02 |
|    PInvokeWithSecurity |  7.049 ns | 0.0123 ns | 0.0115 ns |   6.48 |     0.02 |
|               Delegate | 16.384 ns | 0.0383 ns | 0.0320 ns |  15.06 |     0.05 |
|                  Calli |  7.043 ns | 0.0133 ns | 0.0125 ns |   6.48 |     0.02 |

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

