``` ini

BenchmarkDotNet=v0.10.14, OS=Windows 10.0.17134
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
  [Host]     : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3056.0
  DefaultJob : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3056.0


```
|                 Method |      Mean |     Error |    StdDev | Scaled | ScaledSD |
|----------------------- |----------:|----------:|----------:|-------:|---------:|
|                Managed | 0.6723 ns | 0.0050 ns | 0.0041 ns |   1.00 |     0.00 |
| PInvokeWithoutSecurity | 5.6039 ns | 0.0049 ns | 0.0043 ns |   8.34 |     0.05 |
|    PInvokeWithSecurity | 8.7801 ns | 0.0661 ns | 0.0618 ns |  13.06 |     0.12 |
|               Delegate | 8.2446 ns | 0.0344 ns | 0.0305 ns |  12.26 |     0.08 |
|                  Calli | 5.4057 ns | 0.0395 ns | 0.0370 ns |   8.04 |     0.07 |
|                 CppCli | 8.9838 ns | 0.0506 ns | 0.0422 ns |  13.36 |     0.10 |
|           CppCliDirect | 5.7095 ns | 0.0684 ns | 0.0606 ns |   8.49 |     0.10 |
