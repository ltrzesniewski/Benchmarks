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

        public static readonly IntPtr GetFirstCharPtr;
        public static readonly GetFirstCharDelegate GetFirstChar;

        static NativeLibMethods()
        {
            LibHandle = NativeMethods.LoadLibrary(LibraryName);

            MultiplyPtr = NativeMethods.GetProcAddress(LibHandle, "Multiply");
            Multiply = Marshal.GetDelegateForFunctionPointer<MultiplyDelegate>(MultiplyPtr);

            GetFirstCharPtr = NativeMethods.GetProcAddress(LibHandle, "GetFirstChar");
            GetFirstChar = Marshal.GetDelegateForFunctionPointer<GetFirstCharDelegate>(GetFirstCharPtr);
        }

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int MultiplyDelegate(int a, int b);

        [SuppressUnmanagedCodeSecurity]
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        public delegate char GetFirstCharDelegate([In, MarshalAs(UnmanagedType.LPWStr)] string str);
    }
}
