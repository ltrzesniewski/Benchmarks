using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.CsProj;
using BenchmarkDotNet.Toolchains.DotNetCli;

namespace MemCopy
{
    [Config(typeof(Config))]
    public unsafe class SpanCopyBench
    {
        private const int bufferSize = 4 * 1024;
        private readonly byte[] _source = new byte[bufferSize];
        private readonly byte[] _destination = new byte[bufferSize];

        [Params(10, 100, 1000)]
        public int ByteCount { get; set; }

        public SpanCopyBench()
        {
            new Random(42).NextBytes(_source);
        }

        [Benchmark(Baseline = true)]
        public void Span_CopyTo()
        {
            var source = _source.AsSpan(0, ByteCount);
            var dest = _destination.AsSpan();

            source.CopyTo(dest);
        }

        [Benchmark]
        public void Buffer_MemoryCopy()
        {
            var source = _source.AsSpan(0, ByteCount);
            var dest = _destination.AsSpan();

            fixed (byte* src = source, dst = dest)
            {
                Buffer.MemoryCopy(src, dst, dest.Length, source.Length);
            }
        }

        private class Config : ManualConfig
        {
            public Config()
            {
                Add(Job.Default.With(CsProjCoreToolchain.From(NetCoreAppSettings.NetCoreApp21)));
                Add(Job.Default.With(CsProjCoreToolchain.From(NetCoreAppSettings.NetCoreApp30)));
            }
        }
    }
}
