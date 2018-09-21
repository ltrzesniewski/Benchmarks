using Benchmarks.Common;

namespace Enumeration
{
    public static class Program
    {
        public static void Main()
        {
            BenchmarkHelper.Run<EmptyEnumerableBench>();
            BenchmarkHelper.Run<NonEmptyEnumerableBench>();
        }
    }
}
