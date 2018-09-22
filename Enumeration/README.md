# Enumeration

Compares stuff related to `IEnumerable<T>`.

NOTE: `EmptyEnumerableBench` - both cases generate the same assembly on RyuJitX64, everything is optimized out.

## EmptyEnumerableBench

``` ini

BenchmarkDotNet=v0.11.1, OS=Windows 10.0.17134.285 (1803/April2018Update/Redstone4)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.1.402
  [Host]       : .NET Core 2.1.4 (CoreCLR 4.6.26814.03, CoreFX 4.6.26814.02), 64bit RyuJIT
  LegacyJitX64 : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3163.0
  LegacyJitX86 : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3163.0
  RyuJitX64    : .NET Core 2.1.4 (CoreCLR 4.6.26814.03, CoreFX 4.6.26814.02), 64bit RyuJIT


```
|           Method |          Job |       Jit | Platform | Runtime |      Mean |     Error |    StdDev | Scaled |
|----------------- |------------- |---------- |--------- |-------- |----------:|----------:|----------:|-------:|
|            Array | LegacyJitX64 | LegacyJit |      X64 |     Clr | 3.6530 ns | 0.0079 ns | 0.0070 ns |  1.000 |
| WithoutInterface | LegacyJitX64 | LegacyJit |      X64 |     Clr | 0.0263 ns | 0.0034 ns | 0.0031 ns |  0.007 |
|   WithInterfaces | LegacyJitX64 | LegacyJit |      X64 |     Clr | 0.0327 ns | 0.0007 ns | 0.0006 ns |  0.009 |
|                  |              |           |          |         |           |           |           |        |
|            Array | LegacyJitX86 | LegacyJit |      X86 |     Clr | 4.3816 ns | 0.0263 ns | 0.0246 ns |   1.00 |
| WithoutInterface | LegacyJitX86 | LegacyJit |      X86 |     Clr | 0.1249 ns | 0.0065 ns | 0.0061 ns |   0.03 |
|   WithInterfaces | LegacyJitX86 | LegacyJit |      X86 |     Clr | 7.5543 ns | 0.0177 ns | 0.0165 ns |   1.72 |
|                  |              |           |          |         |           |           |           |        |
|            Array |    RyuJitX64 |    RyuJit |      X64 |    Core | 2.5324 ns | 0.0053 ns | 0.0044 ns |   1.00 |
| WithoutInterface |    RyuJitX64 |    RyuJit |      X64 |    Core | 0.2207 ns | 0.0209 ns | 0.0196 ns |   0.09 |
|   WithInterfaces |    RyuJitX64 |    RyuJit |      X64 |    Core | 0.2190 ns | 0.0085 ns | 0.0079 ns |   0.09 |

## NonEmptyEnumerableBench

``` ini

BenchmarkDotNet=v0.11.1, OS=Windows 10.0.17134.285 (1803/April2018Update/Redstone4)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.1.402
  [Host]     : .NET Core 2.1.4 (CoreCLR 4.6.26814.03, CoreFX 4.6.26814.02), 64bit RyuJIT
  DefaultJob : .NET Core 2.1.4 (CoreCLR 4.6.26814.03, CoreFX 4.6.26814.02), 64bit RyuJIT


```
|           Method |     Mean |     Error |    StdDev | Scaled |
|----------------- |---------:|----------:|----------:|-------:|
|            Array | 6.011 ns | 0.0142 ns | 0.0133 ns |   1.00 |
| WithoutInterface | 3.311 ns | 0.0092 ns | 0.0086 ns |   0.55 |
|   WithInterfaces | 3.313 ns | 0.0056 ns | 0.0049 ns |   0.55 |

