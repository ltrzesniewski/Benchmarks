using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;
using InlineIL;

namespace Quick
{
    [ReturnValueValidator, DisassemblyDiagnoser]
    public class AyendeSymbolSwitch
    {
        // https://ayende.com/blog/188353-A/writing-high-performance-code-despite-c

        [Params(0x000042u, 0x0042FFu, 0x42FFFFu)]
        public uint Value { get; set; }

        [Benchmark]
        public uint NestedIfs()
        {
            uint dw = Value;
            uint symbol = 0;

            if (dw > 0x000000FF)
            {
                symbol = 1;
                if (dw > 0x0000FFFF)
                {
                    symbol = 2;
                    if (dw > 0x00FFFFFF)
                    {
                        symbol = 3;
                    }
                }
            }

            return symbol;
        }

        [Benchmark]
        public uint InlineIL()
        {
            uint dw = Value;
            uint symbol = AsUInt32(dw > 0x000000FF) + AsUInt32(dw > 0x0000FFFF) + AsUInt32(dw > 0x00FFFFFF);
            return symbol;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static uint AsUInt32(bool b)
        {
            IL.Emit.Ldarg_0();
            IL.Emit.Conv_U4();
            return IL.Return<uint>();
        }

        [Benchmark]
        public uint LeadingZeroCount()
        {
            uint dw = Value;
            uint symbol = (31 - (uint)BitOperations.LeadingZeroCount(dw | 1)) >> 3;

            return symbol;
        }

        [Benchmark]
        public uint Lzcnt()
        {
            uint dw = Value;
            uint symbol = (31 - System.Runtime.Intrinsics.X86.Lzcnt.LeadingZeroCount(dw | 1)) >> 3;

            return symbol;
        }

        [Benchmark]
        public uint Hagen()
        {
            uint dw = Value;
            uint filled = Fill(Fill(Fill(dw, 1), 2), 4);
            uint symbol = (filled >> 24 | ~filled >> 16 & filled >> 8) & 1u
                          | (filled >> 23 | filled >> 15) & 2u;

            return symbol;
        }

        private static uint Fill(uint value, int shift)
            => value | (value >> shift);

        [Benchmark]
        public uint Union()
        {
            uint dw = Value;

            BoolUint a = default, b = default, c = default;
            a.Bool = dw > 0x000000FF;
            b.Bool = dw > 0x0000FFFF;
            c.Bool = dw > 0x00FFFFFF;
            uint symbol = a.Uint + b.Uint + c.Uint;

            return symbol;
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct BoolUint
        {
            [FieldOffset(0)] public bool Bool;
            [FieldOffset(0)] public uint Uint;
        }

        [Benchmark]
        public uint UnsafeCast()
        {
            uint dw = Value;

            var a = dw > 0x000000FF;
            var b = dw > 0x0000FFFF;
            var c = dw > 0x00FFFFFF;

            uint symbol = 0;
            symbol += Unsafe.As<bool, uint>(ref a);
            symbol += Unsafe.As<bool, uint>(ref b);
            symbol += Unsafe.As<bool, uint>(ref c);

            return symbol;
        }
    }
}
