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
