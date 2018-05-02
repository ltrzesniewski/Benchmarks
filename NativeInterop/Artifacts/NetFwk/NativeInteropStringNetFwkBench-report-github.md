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
