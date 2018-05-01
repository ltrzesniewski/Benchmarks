using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using BenchmarkDotNet.Attributes;
using InlineIL;

namespace NativeInterop
{
    [SuppressUnmanagedCodeSecurity]
    public unsafe class NativeInteropBench
    {
        private const int ValueA = 14;
        private const int ValueB = 3;

        // make sure we have beforefieldinit
        private static readonly void* MultiplyPtr = NativeLibMethods.MultiplyPtr.ToPointer();
        private static readonly NativeLibMethods.MultiplyDelegate MultiplyDelegate = NativeLibMethods.Multiply;

        public static void Validate()
        {
            const int expectedValue = ValueA * ValueB;
            var bench = new NativeInteropBench();

            var methods = typeof(NativeInteropBench)
                .GetMethods()
                .Where(m => m.IsPublic && Attribute.IsDefined(m, typeof(BenchmarkAttribute)));

            foreach (var method in methods)
            {
                var result = (int) method.Invoke(bench, Array.Empty<object>());
                if (result != expectedValue)
                    throw new InvalidOperationException($"Invalid result for {method.Name}: {result}, expected {expectedValue}");

                Console.WriteLine($"Valid: {method.Name}");
            }
        }

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

        [Benchmark]
        public int CppCli() => NativeInterop.CppCli.Multiply(ValueA, ValueB);

        [Benchmark]
        public int CppCliDirect() => NativeInterop.CppCli.MultiplyDirect(ValueA, ValueB);
    }
}
