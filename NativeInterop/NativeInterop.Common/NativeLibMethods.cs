using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security;

namespace NativeInterop
{
    public static class NativeLibMethods
    {
        public const string LibraryName = "NativeInterop.NativeLib.dll";

        [SuppressMessage("ReSharper", "PrivateFieldCanBeConvertedToLocalVariable", Justification = "Need to keep this as a GC root")]
        private static readonly NativeLibraryHandle LibHandle;

        public static readonly IntPtr MultiplyPtr;
        public static readonly MultiplyDelegate Multiply;

        static NativeLibMethods()
        {
            LibHandle = NativeMethods.LoadLibrary(LibraryName);

            MultiplyPtr = NativeMethods.GetProcAddress(LibHandle, "Multiply");
            Multiply = Marshal.GetDelegateForFunctionPointer<MultiplyDelegate>(MultiplyPtr);
        }

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int MultiplyDelegate(int a, int b);
    }
}
