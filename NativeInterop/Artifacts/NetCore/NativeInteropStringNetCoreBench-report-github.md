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
