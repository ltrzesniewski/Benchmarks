using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using BenchmarkDotNet.Attributes;
using InlineIL;

namespace NativeInterop
{
    [SuppressUnmanagedCodeSecurity]
    public unsafe class NativeInteropNetCoreBench
    {
        private const int ValueA = 14;
        private const int ValueB = 3;

        // Make sure we have beforefieldinit
        private static readonly void* MultiplyPtr = NativeLibMethods.MultiplyPtr.ToPointer();
        private static readonly NativeLibMethods.MultiplyDelegate MultiplyDelegate = NativeLibMethods.Multiply;

        [Benchmark(Baseline = true)]
        public int Managed() => ManagedImpl(ValueA, ValueB);

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static int ManagedImpl(int a, int b) => a * b;

        [Benchmark]
        public int PInvoke() => MultiplyPInvoke(ValueA, ValueB);

        [SuppressUnmanagedCodeSecurity]
        [DllImport(NativeLibMethods.LibraryName, EntryPoint = "Multiply")]
        private static extern int MultiplyPInvoke(int a, int b);

        [Benchmark]
        public int Delegate() => MultiplyDelegate(ValueA, ValueB);

        [Benchmark]
        [SuppressUnmanagedCodeSecurity]
        public int Calli()
        {
            IL.Push(ValueA);
            IL.Push(ValueB);
            IL.Push(MultiplyPtr);
            IL.Emit.Calli(new StandAloneMethodSig(CallingConvention.StdCall, typeof(int), typeof(int), typeof(int)));
            return IL.Return<int>();
        }
    }
}
