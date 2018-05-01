using Microsoft.Win32.SafeHandles;

namespace NativeInterop
{
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
