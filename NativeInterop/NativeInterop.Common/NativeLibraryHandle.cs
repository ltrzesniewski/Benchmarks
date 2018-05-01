using System.Diagnostics.CodeAnalysis;
using Microsoft.Win32.SafeHandles;

namespace NativeInterop
{
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    internal class NativeLibraryHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        public NativeLibraryHandle()
            : base(true)
        {
        }

        protected override bool ReleaseHandle()
            => NativeMethods.FreeLibrary(handle);
    }
}
