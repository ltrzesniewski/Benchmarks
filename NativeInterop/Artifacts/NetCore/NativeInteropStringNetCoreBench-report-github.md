``` ini

BenchmarkDotNet=v0.10.14, OS=Windows 10.0.17134
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.1.300-preview2-008533
  [Host]     : .NET Core 2.0.6 (CoreCLR 4.6.26212.01, CoreFX 4.6.26212.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.0.6 (CoreCLR 4.6.26212.01, CoreFX 4.6.26212.01), 64bit RyuJIT


```
|                  Method |              Mean |           Error |          StdDev |        Scaled |   ScaledSD |
|------------------------ |------------------:|----------------:|----------------:|--------------:|-----------:|
|                 Managed |          1.794 ns |       0.0064 ns |       0.0056 ns |          1.00 |       0.00 |
|                 PInvoke |          6.747 ns |       0.0223 ns |       0.0186 ns |          3.76 |       0.02 |
|                Delegate |         11.782 ns |       0.1838 ns |       0.1719 ns |          6.57 |       0.09 |
|              CalliFixed |         33.300 ns |       0.2587 ns |       0.2293 ns |         18.56 |       0.14 |
|          CalliCustomPin |         33.428 ns |       0.3923 ns |       0.3477 ns |         18.63 |       0.20 |
| CalliCustomPinWithLocal |         33.363 ns |       0.1435 ns |       0.1199 ns |         18.60 |       0.09 |
|             CalliString | 47,532,051.454 ns | 740,476.2190 ns | 692,641.8473 ns | 26,492,895.52 | 381,480.09 |
|              CalliByRef |         86.939 ns |       1.5797 ns |       1.4004 ns |         48.46 |       0.77 |
