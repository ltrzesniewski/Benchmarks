# Enumeration

Compares stuff related to `IEnumerable<T>`.

NOTE: `EmptyEnumerableBench` - both cases generate the same assembly, everything is optimized out.

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
|           Method |          Job |       Jit | Platform | Runtime |      Mean |     Error |    StdDev | Scaled | ScaledSD |
|----------------- |------------- |---------- |--------- |-------- |----------:|----------:|----------:|-------:|---------:|
|            Array | LegacyJitX64 | LegacyJit |      X64 |     Clr | 3.6521 ns | 0.0064 ns | 0.0053 ns |  1.000 |     0.00 |
| WithoutInterface | LegacyJitX64 | LegacyJit |      X64 |     Clr | 0.0334 ns | 0.0011 ns | 0.0010 ns |  0.009 |     0.00 |
|   WithInterfaces | LegacyJitX64 | LegacyJit |      X64 |     Clr | 0.0320 ns | 0.0006 ns | 0.0005 ns |  0.009 |     0.00 |
|                  |              |           |          |         |           |           |           |        |          |
|            Array | LegacyJitX86 | LegacyJit |      X86 |     Clr | 4.3711 ns | 0.0085 ns | 0.0066 ns |   1.00 |     0.00 |
| WithoutInterface | LegacyJitX86 | LegacyJit |      X86 |     Clr | 0.1086 ns | 0.0082 ns | 0.0073 ns |   0.02 |     0.00 |
|   WithInterfaces | LegacyJitX86 | LegacyJit |      X86 |     Clr | 7.5497 ns | 0.0127 ns | 0.0112 ns |   1.73 |     0.00 |
|                  |              |           |          |         |           |           |           |        |          |
|            Array |    RyuJitX64 |    RyuJit |      X64 |    Core | 2.5526 ns | 0.0192 ns | 0.0180 ns |   1.00 |     0.00 |
| WithoutInterface |    RyuJitX64 |    RyuJit |      X64 |    Core | 0.2098 ns | 0.0061 ns | 0.0057 ns |   0.08 |     0.00 |
|   WithInterfaces |    RyuJitX64 |    RyuJit |      X64 |    Core | 0.2058 ns | 0.0038 ns | 0.0030 ns |   0.08 |     0.00 |
|                  |              |           |          |         |           |           |           |        |          |
|            Array |    RyuJitX86 |    RyuJit |      X86 |    Core |        NA |        NA |        NA |      ? |        ? |
| WithoutInterface |    RyuJitX86 |    RyuJit |      X86 |    Core |        NA |        NA |        NA |      ? |        ? |
|   WithInterfaces |    RyuJitX86 |    RyuJit |      X86 |    Core |        NA |        NA |        NA |      ? |        ? |

Benchmarks with issues:
  EmptyEnumerableBench.Array: RyuJitX86(Jit=RyuJit, Platform=X86)
  EmptyEnumerableBench.WithoutInterface: RyuJitX86(Jit=RyuJit, Platform=X86)
  EmptyEnumerableBench.WithInterfaces: RyuJitX86(Jit=RyuJit, Platform=X86)

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

