﻿using Benchmarks.Common;

namespace NativeInterop
{
    internal static class Program
    {
        private static void Main()
        {
            BenchmarkHelper.ValidateAndRun<NativeInteropNetCoreBench>();
            BenchmarkHelper.ValidateAndRun<NativeInteropStringNetCoreBench>();
        }
    }
}