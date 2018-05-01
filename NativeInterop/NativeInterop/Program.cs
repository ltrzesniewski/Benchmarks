using BenchmarkDotNet.Running;

namespace NativeInterop
{
    internal static class Program
    {
        private static void Main()
        {
            NativeInteropBench.Validate();
            BenchmarkRunner.Run<NativeInteropBench>();
        }
    }
}
