using Benchmarks.Common;

namespace NativeInterop
{
    internal static class Program
    {
        private static void Main()
        {
            BenchmarkHelper.Run<NativeInteropNetCoreBench>();
            BenchmarkHelper.Run<NativeInteropStringNetCoreBench>();
        }
    }
}
