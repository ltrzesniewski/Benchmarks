# Native Interop

Compares ways to call into native code.

## NativeInteropNetFwkBench

``` ini

BenchmarkDotNet=v0.11.1, OS=Windows 10.0.17134.285 (1803/April2018Update/Redstone4)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3163.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3163.0


```
|                 Method |      Mean |     Error |    StdDev | Scaled | ScaledSD |
|----------------------- |----------:|----------:|----------:|-------:|---------:|
|                Managed | 0.6997 ns | 0.0128 ns | 0.0107 ns |   1.00 |     0.00 |
| PInvokeWithoutSecurity | 5.7421 ns | 0.0625 ns | 0.0554 ns |   8.21 |     0.14 |
|    PInvokeWithSecurity | 8.9558 ns | 0.0692 ns | 0.0647 ns |  12.80 |     0.21 |
|               Delegate | 8.7397 ns | 0.0768 ns | 0.0718 ns |  12.49 |     0.21 |
|                  Calli | 5.4677 ns | 0.0364 ns | 0.0340 ns |   7.82 |     0.12 |
|                 CppCli | 8.8428 ns | 0.0236 ns | 0.0220 ns |  12.64 |     0.18 |
|           CppCliDirect | 5.7820 ns | 0.0845 ns | 0.0790 ns |   8.27 |     0.16 |

## NativeInteropNetCoreBench

``` ini

BenchmarkDotNet=v0.11.1, OS=Windows 10.0.17134.285 (1803/April2018Update/Redstone4)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.1.402
  [Host]     : .NET Core 2.0.9 (CoreCLR 4.6.26614.01, CoreFX 4.6.26614.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.0.9 (CoreCLR 4.6.26614.01, CoreFX 4.6.26614.01), 64bit RyuJIT


```
|                 Method |       Mean |     Error |    StdDev | Scaled | ScaledSD |
|----------------------- |-----------:|----------:|----------:|-------:|---------:|
|                Managed |  0.6752 ns | 0.0040 ns | 0.0035 ns |   1.00 |     0.00 |
| PInvokeWithoutSecurity |  5.6718 ns | 0.0068 ns | 0.0060 ns |   8.40 |     0.04 |
|    PInvokeWithSecurity |  5.6713 ns | 0.0230 ns | 0.0204 ns |   8.40 |     0.05 |
|               Delegate | 12.4701 ns | 0.1461 ns | 0.1366 ns |  18.47 |     0.22 |
|                  Calli |  5.7523 ns | 0.0510 ns | 0.0452 ns |   8.52 |     0.08 |

## NativeInteropStringNetFwkBench

``` ini

BenchmarkDotNet=v0.11.1, OS=Windows 10.0.17134.285 (1803/April2018Update/Redstone4)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3163.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3163.0


```
|                  Method |              Mean |           Error |          StdDev |        Scaled |   ScaledSD |
|------------------------ |------------------:|----------------:|----------------:|--------------:|-----------:|
|                 Managed |          2.739 ns |       0.0274 ns |       0.0242 ns |          1.00 |       0.00 |
|                 PInvoke |          7.946 ns |       0.0360 ns |       0.0300 ns |          2.90 |       0.03 |
|                Delegate |         10.461 ns |       0.0203 ns |       0.0169 ns |          3.82 |       0.03 |
|              CalliFixed |         36.300 ns |       0.1023 ns |       0.0907 ns |         13.25 |       0.12 |
|          CalliCustomPin |         36.611 ns |       0.2907 ns |       0.2719 ns |         13.37 |       0.15 |
| CalliCustomPinWithLocal |         37.191 ns |       0.7240 ns |       0.7746 ns |         13.58 |       0.30 |
|             CalliString | 49,055,775.239 ns | 870,971.3029 ns | 814,707.0178 ns | 17,912,501.59 | 325,245.08 |
|              CalliByRef |         87.667 ns |       0.5082 ns |       0.4244 ns |         32.01 |       0.31 |
|                  CppCli |         10.128 ns |       0.0570 ns |       0.0505 ns |          3.70 |       0.04 |
|            CppCliDirect |          8.017 ns |       0.1283 ns |       0.1200 ns |          2.93 |       0.05 |

## NativeInteropStringNetCoreBench

``` ini

BenchmarkDotNet=v0.11.1, OS=Windows 10.0.17134.285 (1803/April2018Update/Redstone4)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.1.402
  [Host]     : .NET Core 2.0.9 (CoreCLR 4.6.26614.01, CoreFX 4.6.26614.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.0.9 (CoreCLR 4.6.26614.01, CoreFX 4.6.26614.01), 64bit RyuJIT


```
|                  Method |              Mean |           Error |          StdDev |        Scaled |   ScaledSD |
|------------------------ |------------------:|----------------:|----------------:|--------------:|-----------:|
|                 Managed |          4.259 ns |       0.0349 ns |       0.0309 ns |          1.00 |       0.00 |
|                 PInvoke |          8.170 ns |       0.0247 ns |       0.0219 ns |          1.92 |       0.01 |
|                Delegate |         13.628 ns |       0.1164 ns |       0.1089 ns |          3.20 |       0.03 |
|              CalliFixed |         35.795 ns |       0.4625 ns |       0.4100 ns |          8.40 |       0.11 |
|          CalliCustomPin |         36.237 ns |       0.2519 ns |       0.2356 ns |          8.51 |       0.08 |
| CalliCustomPinWithLocal |         35.809 ns |       0.3807 ns |       0.3561 ns |          8.41 |       0.10 |
|             CalliString | 49,225,124.842 ns | 969,502.3853 ns | 952,180.8852 ns | 11,558,271.61 | 230,931.14 |
|              CalliByRef |         90.306 ns |       0.9404 ns |       0.8797 ns |         21.20 |       0.25 |

