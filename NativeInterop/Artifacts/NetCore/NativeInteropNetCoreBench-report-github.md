``` ini

BenchmarkDotNet=v0.10.14, OS=Windows 10.0.17134
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.1.300-preview2-008533
  [Host]     : .NET Core 2.0.6 (CoreCLR 4.6.26212.01, CoreFX 4.6.26212.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.0.6 (CoreCLR 4.6.26212.01, CoreFX 4.6.26212.01), 64bit RyuJIT


```
|                 Method |       Mean |     Error |    StdDev | Scaled | ScaledSD |
|----------------------- |-----------:|----------:|----------:|-------:|---------:|
|                Managed |  0.8720 ns | 0.0080 ns | 0.0071 ns |   1.00 |     0.00 |
| PInvokeWithoutSecurity |  5.6539 ns | 0.0410 ns | 0.0342 ns |   6.48 |     0.06 |
|    PInvokeWithSecurity |  5.6037 ns | 0.0058 ns | 0.0055 ns |   6.43 |     0.05 |
|               Delegate | 12.0347 ns | 0.0123 ns | 0.0103 ns |  13.80 |     0.11 |
|                  Calli |  5.6390 ns | 0.0426 ns | 0.0356 ns |   6.47 |     0.06 |
