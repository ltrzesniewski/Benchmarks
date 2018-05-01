using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;

namespace NativeInterop
{
    public class NativeInteropBench
    {
        private const int ValueA = 14;
        private const int ValueB = 3;

        public static void Validate()
        {
            const int expectedValue = ValueA * ValueB;
            var bench = new NativeInteropBench();

            if (bench.Managed() != expectedValue)
                throw new InvalidOperationException();
            if (bench.PInvoke() != expectedValue)
                throw new InvalidOperationException();
        }

        [Benchmark(Baseline = true)]
        public int Managed() => ManagedImpl(ValueA, ValueB);

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static int ManagedImpl(int a, int b) => a * b;

        [Benchmark]
        public int PInvoke() => MultiplyPInvoke(ValueA, ValueB);

        [DllImport("NativeInterop.NativeLib.dll", EntryPoint = "Multiply")]
        private static extern int MultiplyPInvoke(int a, int b);
    }
}
