``` ini

BenchmarkDotNet=v0.10.14, OS=Windows 10.0.17134
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
  [Host]     : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3056.0
  DefaultJob : .NET Framework 4.7.1 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3056.0


```
|                  Method |               Mean |           Error |          StdDev |        Scaled |   ScaledSD |
|------------------------ |-------------------:|----------------:|----------------:|--------------:|-----------:|
|                 Managed |          0.9284 ns |       0.0114 ns |       0.0101 ns |          1.00 |       0.00 |
|                 PInvoke |          6.5058 ns |       0.0689 ns |       0.0644 ns |          7.01 |       0.10 |
|                Delegate |          9.1327 ns |       0.0912 ns |       0.0808 ns |          9.84 |       0.13 |
|              CalliFixed |         33.8796 ns |       0.4559 ns |       0.4265 ns |         36.49 |       0.58 |
|          CalliCustomPin |         35.2593 ns |       0.7229 ns |       1.1039 ns |         37.98 |       1.23 |
| CalliCustomPinWithLocal |         34.6123 ns |       0.7965 ns |       0.7450 ns |         37.28 |       0.87 |
|             CalliString | 47,882,284.4625 ns | 507,481.6980 ns | 449,869.2629 ns | 51,578,467.30 | 707,137.78 |
|              CalliByRef |         82.0797 ns |       0.7486 ns |       0.7003 ns |         88.42 |       1.17 |
|                  CppCli |          8.2391 ns |       0.1065 ns |       0.0996 ns |          8.88 |       0.14 |
|            CppCliDirect |          6.5807 ns |       0.0586 ns |       0.0549 ns |          7.09 |       0.09 |
