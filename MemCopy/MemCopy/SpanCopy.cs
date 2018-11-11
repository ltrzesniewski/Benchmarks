using System;
using BenchmarkDotNet.Attributes;

namespace MemCopy
{
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
    }
}
