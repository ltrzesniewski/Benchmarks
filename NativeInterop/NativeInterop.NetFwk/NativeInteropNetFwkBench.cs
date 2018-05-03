using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using BenchmarkDotNet.Attributes;
using InlineIL;

namespace NativeInterop
{
    [DisassemblyDiagnoser(printPrologAndEpilog: true)]
    public unsafe class NativeInteropNetFwkBench
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
        public int PInvokeWithoutSecurity() => MultiplyPInvokeWithoutSecurity(ValueA, ValueB);

        [Benchmark]
        public int PInvokeWithSecurity() => MultiplyPInvokeWithSecurity(ValueA, ValueB);

        [SuppressUnmanagedCodeSecurity]
        [DllImport(NativeLibMethods.LibraryName, EntryPoint = "Multiply")]
        private static extern int MultiplyPInvokeWithoutSecurity(int a, int b);

        [DllImport(NativeLibMethods.LibraryName, EntryPoint = "Multiply")]
        private static extern int MultiplyPInvokeWithSecurity(int a, int b);

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

        [Benchmark]
        public int CppCli() => NativeInterop.CppCli.Multiply(ValueA, ValueB);

        [Benchmark]
        public int CppCliDirect() => NativeInterop.CppCli.MultiplyDirect(ValueA, ValueB);
    }
}
