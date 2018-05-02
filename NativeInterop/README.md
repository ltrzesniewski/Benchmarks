# Native Interop

Compares ways to call into native code.

## NativeInteropNetFwkBench

``` ini

BenchmarkDotNet=v0.10.14, OS=Windows 10.0.17134
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
  [Host]     : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3056.0
  DefaultJob : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3056.0


```
|                 Method |      Mean |     Error |    StdDev | Scaled | ScaledSD |
|----------------------- |----------:|----------:|----------:|-------:|---------:|
|                Managed | 0.6763 ns | 0.0047 ns | 0.0044 ns |   1.00 |     0.00 |
| PInvokeWithoutSecurity | 5.6360 ns | 0.0266 ns | 0.0236 ns |   8.33 |     0.06 |
|    PInvokeWithSecurity | 8.8015 ns | 0.0838 ns | 0.0699 ns |  13.01 |     0.13 |
|               Delegate | 8.5855 ns | 0.0226 ns | 0.0188 ns |  12.70 |     0.08 |
|                  Calli | 5.4197 ns | 0.0343 ns | 0.0320 ns |   8.01 |     0.07 |
|                 CppCli | 9.0576 ns | 0.0853 ns | 0.0798 ns |  13.39 |     0.14 |
|           CppCliDirect | 5.6554 ns | 0.0420 ns | 0.0393 ns |   8.36 |     0.08 |

## NativeInteropNetCoreBench

``` ini

BenchmarkDotNet=v0.10.14, OS=Windows 10.0.17134
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.1.104
  [Host]     : .NET Core 2.0.6 (CoreCLR 4.6.26212.01, CoreFX 4.6.26212.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.0.6 (CoreCLR 4.6.26212.01, CoreFX 4.6.26212.01), 64bit RyuJIT


```
|                 Method |       Mean |     Error |    StdDev | Scaled | ScaledSD |
|----------------------- |-----------:|----------:|----------:|-------:|---------:|
|                Managed |  0.6687 ns | 0.0007 ns | 0.0005 ns |   1.00 |     0.00 |
| PInvokeWithoutSecurity |  5.6523 ns | 0.0479 ns | 0.0400 ns |   8.45 |     0.06 |
|    PInvokeWithSecurity |  5.6202 ns | 0.0314 ns | 0.0294 ns |   8.41 |     0.04 |
|               Delegate | 11.9801 ns | 0.0636 ns | 0.0595 ns |  17.92 |     0.09 |
|                  Calli |  5.6552 ns | 0.0316 ns | 0.0264 ns |   8.46 |     0.04 |

## NativeInteropStringNetFwkBench

``` ini

BenchmarkDotNet=v0.10.14, OS=Windows 10.0.17134
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
  [Host]     : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3056.0
  DefaultJob : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3056.0


```
|                  Method |               Mean |           Error |          StdDev |        Scaled |   ScaledSD |
|------------------------ |-------------------:|----------------:|----------------:|--------------:|-----------:|
|                 Managed |          0.9254 ns |       0.0084 ns |       0.0070 ns |          1.00 |       0.00 |
|                 PInvoke |          6.5183 ns |       0.0362 ns |       0.0321 ns |          7.04 |       0.06 |
|                Delegate |          8.6131 ns |       0.1921 ns |       0.1703 ns |          9.31 |       0.19 |
|              CalliFixed |         34.0910 ns |       0.3785 ns |       0.3355 ns |         36.84 |       0.44 |
|          CalliCustomPin |         39.7228 ns |       0.7810 ns |       0.9297 ns |         42.93 |       1.03 |
| CalliCustomPinWithLocal |         36.0272 ns |       0.7230 ns |       0.8326 ns |         38.93 |       0.92 |
|             CalliString | 48,566,205.8004 ns | 823,417.1061 ns | 729,937.7455 ns | 52,484,101.89 | 849,725.92 |
|              CalliByRef |         86.4328 ns |       1.7202 ns |       2.2964 ns |         93.41 |       2.52 |
|                  CppCli |          8.5173 ns |       0.2022 ns |       0.2834 ns |          9.20 |       0.31 |
|            CppCliDirect |          6.5150 ns |       0.0281 ns |       0.0219 ns |          7.04 |       0.06 |

## NativeInteropStringNetCoreBench

``` ini

BenchmarkDotNet=v0.10.14, OS=Windows 10.0.17134
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.1.104
  [Host]     : .NET Core 2.0.6 (CoreCLR 4.6.26212.01, CoreFX 4.6.26212.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.0.6 (CoreCLR 4.6.26212.01, CoreFX 4.6.26212.01), 64bit RyuJIT


```
|                  Method |              Mean |           Error |          StdDev |        Scaled |   ScaledSD |
|------------------------ |------------------:|----------------:|----------------:|--------------:|-----------:|
|                 Managed |          2.452 ns |       0.0153 ns |       0.0143 ns |          1.00 |       0.00 |
|                 PInvoke |          6.764 ns |       0.0369 ns |       0.0345 ns |          2.76 |       0.02 |
|                Delegate |         12.554 ns |       0.0582 ns |       0.0544 ns |          5.12 |       0.04 |
|              CalliFixed |         33.841 ns |       0.1513 ns |       0.1415 ns |         13.80 |       0.10 |
|          CalliCustomPin |         36.470 ns |       0.0852 ns |       0.0712 ns |         14.88 |       0.09 |
| CalliCustomPinWithLocal |         34.348 ns |       0.0514 ns |       0.0456 ns |         14.01 |       0.08 |
|             CalliString | 45,974,889.367 ns | 228,532.5104 ns | 213,769.4312 ns | 18,752,236.53 | 135,324.81 |
|              CalliByRef |         85.654 ns |       0.3039 ns |       0.2694 ns |         34.94 |       0.22 |

