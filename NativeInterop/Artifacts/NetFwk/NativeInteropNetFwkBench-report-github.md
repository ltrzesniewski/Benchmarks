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
