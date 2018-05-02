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

BenchmarkDotNet=v0.10.14, OS=Windows 10.0.16299.309 (1709/FallCreatorsUpdate/Redstone3)
Intel Core i7-7700 CPU 3.60GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
Frequency=3515629 Hz, Resolution=284.4441 ns, Timer=TSC
  [Host]     : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0
  DefaultJob : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0


```
|                  Method |              Mean |           Error |          StdDev |        Scaled |   ScaledSD |
|------------------------ |------------------:|----------------:|----------------:|--------------:|-----------:|
|                 Managed |          1.398 ns |       0.0037 ns |       0.0032 ns |          1.00 |       0.00 |
|                 PInvoke |          8.570 ns |       0.0086 ns |       0.0071 ns |          6.13 |       0.01 |
|                Delegate |         10.961 ns |       0.0129 ns |       0.0121 ns |          7.84 |       0.02 |
|              CalliFixed |         42.896 ns |       0.0876 ns |       0.0819 ns |         30.68 |       0.09 |
|          CalliCustomPin |         40.889 ns |       0.1274 ns |       0.1130 ns |         29.24 |       0.10 |
| CalliCustomPinWithLocal |         40.544 ns |       0.0458 ns |       0.0331 ns |         29.00 |       0.07 |
|             CalliString | 65,440,796.654 ns | 591,815.9569 ns | 553,584.9594 ns | 46,804,874.72 | 396,455.31 |
|              CalliByRef |         98.383 ns |       0.2838 ns |       0.2370 ns |         70.37 |       0.23 |
|                  CppCli |         10.619 ns |       0.0054 ns |       0.0045 ns |          7.60 |       0.02 |
|            CppCliDirect |          8.147 ns |       0.0183 ns |       0.0171 ns |          5.83 |       0.02 |

