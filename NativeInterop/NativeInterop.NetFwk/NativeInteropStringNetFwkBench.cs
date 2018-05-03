using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using BenchmarkDotNet.Attributes;
using InlineIL;

namespace NativeInterop
{
    [DisassemblyDiagnoser(printPrologAndEpilog: true)]
    [SuppressUnmanagedCodeSecurity]
    public unsafe class NativeInteropStringNetFwkBench
    {
        // Use a large string: if it gets copied it'll show up in the results
        private static readonly string Value = "foo" + new string('o', 64 * 1024 * 1024);

        // Make sure we have beforefieldinit
        private static readonly void* GetFirstCharPtr = NativeLibMethods.GetFirstCharPtr.ToPointer();
        private static readonly NativeLibMethods.GetFirstCharDelegate GetFirstCharDelegate = NativeLibMethods.GetFirstChar;

        [Benchmark(Baseline = true)]
        public char Managed() => ManagedImpl(Value);

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static char ManagedImpl(string str) => str?[0] ?? default;

        [Benchmark]
        public char PInvoke() => GetFirstCharPInvoke(Value);

        [SuppressUnmanagedCodeSecurity]
        [DllImport(NativeLibMethods.LibraryName, EntryPoint = "GetFirstChar", CharSet = CharSet.Unicode)]
        private static extern char GetFirstCharPInvoke([In, MarshalAs(UnmanagedType.LPWStr)] string str);

        [Benchmark]
        public char Delegate() => GetFirstCharDelegate(Value);

        [Benchmark]
        [SuppressUnmanagedCodeSecurity]
        public char CalliFixed()
        {
            fixed (void* c = Value)
            {
                IL.Push(c);
                IL.Push(GetFirstCharPtr);
                IL.Emit.Calli(new StandAloneMethodSig(CallingConvention.StdCall, typeof(char), typeof(char*)));
                return IL.Return<char>();
            }
        }

        [Benchmark]
        [SuppressUnmanagedCodeSecurity]
        public char CalliCustomPin()
        {
            IL.DeclareLocals(
                false,
                new LocalVar(typeof(string)).Pinned()
            );

            IL.Push(Value);
            IL.Emit.Stloc_0();
            IL.Emit.Ldloc_0();
            IL.Emit.Conv_U();
            IL.Push(RuntimeHelpers.OffsetToStringData);
            IL.Emit.Add();
            IL.Push(GetFirstCharPtr);
            IL.Emit.Calli(new StandAloneMethodSig(CallingConvention.StdCall, typeof(char), typeof(char*)));
            return IL.Return<char>();
        }

        [Benchmark]
        [SuppressUnmanagedCodeSecurity]
        public char CalliCustomPinWithLocal()
        {
            IL.DeclareLocals(
                false,
                typeof(char*),
                new LocalVar(typeof(string)).Pinned()
            );

            IL.Push(Value);
            IL.Emit.Stloc_1();
            IL.Emit.Ldloc_1();
            IL.Emit.Conv_U();
            IL.Emit.Stloc_0();
            IL.Emit.Ldloc_0();
            IL.Push(RuntimeHelpers.OffsetToStringData);
            IL.Emit.Add();
            IL.Emit.Stloc_0();
            IL.Emit.Ldloc_0();
            IL.Push(GetFirstCharPtr);
            IL.Emit.Calli(new StandAloneMethodSig(CallingConvention.StdCall, typeof(char), typeof(char*)));
            return IL.Return<char>();
        }

        [Benchmark]
        [SuppressUnmanagedCodeSecurity]
        public char CalliString()
        {
            // This one copies the string... I don't know if there's a way to tell it not to.

            IL.Push(Value);
            IL.Push(GetFirstCharPtr);
            IL.Emit.Calli(new StandAloneMethodSig(CallingConvention.StdCall, typeof(char), typeof(string)));
            return IL.Return<char>();
        }

        [Benchmark]
        [SuppressUnmanagedCodeSecurity]
        public char CalliByRef()
        {
            // I'm not sure if this one is safe

            IL.DeclareLocals(
                false,
                typeof(char).MakeByRefType()
            );

            IL.Push(Value);
            IL.Emit.Stloc_0();
            IL.Emit.Ldloc_0();
            IL.Push(RuntimeHelpers.OffsetToStringData);
            IL.Emit.Add();
            IL.Push(GetFirstCharPtr);
            IL.Emit.Calli(new StandAloneMethodSig(CallingConvention.StdCall, typeof(char), typeof(char).MakeByRefType()));
            return IL.Return<char>();
        }

        [Benchmark]
        public char CppCli() => NativeInterop.CppCli.GetFirstChar(Value);

        [Benchmark]
        public char CppCliDirect() => NativeInterop.CppCli.GetFirstCharDirect(Value);
    }
}
