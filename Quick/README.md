# Quick benchmarks

## AyendeSymbolSwitch

[Blog post](https://ayende.com/blog/188353-A/writing-high-performance-code-despite-c)

```
BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-7700 CPU 3.60GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.0.100-rc1-014190
  [Host]     : .NET Core 3.0.0-rc1-19456-20 (CoreCLR 4.700.19.45506, CoreFX 4.700.19.45604), 64bit RyuJIT
  DefaultJob : .NET Core 3.0.0-rc1-19456-20 (CoreCLR 4.700.19.45506, CoreFX 4.700.19.45604), 64bit RyuJIT


|           Method |   Value |      Mean |     Error |    StdDev |    Median |
|----------------- |-------- |----------:|----------:|----------:|----------:|
|        NestedIfs |   17151 | 0.3260 ns | 0.0067 ns | 0.0059 ns | 0.3228 ns |
|         InlineIL |   17151 | 0.2856 ns | 0.0101 ns | 0.0095 ns | 0.2826 ns |
| LeadingZeroCount |   17151 | 0.0156 ns | 0.0135 ns | 0.0127 ns | 0.0088 ns |
|            Lzcnt |   17151 | 0.0189 ns | 0.0084 ns | 0.0075 ns | 0.0161 ns |
|            Hagen |   17151 | 0.9252 ns | 0.0081 ns | 0.0068 ns | 0.9234 ns |
|            Union |   17151 | 5.9519 ns | 0.0092 ns | 0.0082 ns | 5.9530 ns |
|       UnsafeCast |   17151 | 1.3950 ns | 0.0124 ns | 0.0116 ns | 1.3932 ns |
|        NestedIfs | 4390911 | 0.3495 ns | 0.0127 ns | 0.0119 ns | 0.3431 ns |
|         InlineIL | 4390911 | 0.2798 ns | 0.0061 ns | 0.0057 ns | 0.2792 ns |
| LeadingZeroCount | 4390911 | 0.0522 ns | 0.0041 ns | 0.0034 ns | 0.0520 ns |
|            Lzcnt | 4390911 | 0.0464 ns | 0.0051 ns | 0.0048 ns | 0.0449 ns |
|            Hagen | 4390911 | 0.8711 ns | 0.0070 ns | 0.0062 ns | 0.8710 ns |
|            Union | 4390911 | 5.6731 ns | 0.0124 ns | 0.0104 ns | 5.6706 ns |
|       UnsafeCast | 4390911 | 1.4757 ns | 0.0150 ns | 0.0140 ns | 1.4759 ns |
|        NestedIfs |      66 | 0.2787 ns | 0.0084 ns | 0.0070 ns | 0.2786 ns |
|         InlineIL |      66 | 0.2428 ns | 0.0096 ns | 0.0085 ns | 0.2424 ns |
| LeadingZeroCount |      66 | 0.0133 ns | 0.0093 ns | 0.0082 ns | 0.0100 ns |
|            Lzcnt |      66 | 0.0118 ns | 0.0068 ns | 0.0063 ns | 0.0102 ns |
|            Hagen |      66 | 0.8718 ns | 0.0097 ns | 0.0086 ns | 0.8705 ns |
|            Union |      66 | 5.6232 ns | 0.0092 ns | 0.0082 ns | 5.6205 ns |
|       UnsafeCast |      66 | 1.3873 ns | 0.0079 ns | 0.0070 ns | 1.3858 ns |
```
