using System.Collections;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace Enumeration
{
    [ReturnValueValidator]
    [DisassemblyDiagnoser(printPrologAndEpilog: true)]
    public class EmptyEnumerableBench
    {
        [Benchmark(Baseline = true)]
        public int Array()
        {
            var sum = 0;
            foreach (var i in System.Array.Empty<int>())
                sum += i;
            return sum;
        }

        [Benchmark]
        public int WithoutInterface()
        {
            var sum = 0;
            foreach (var i in new StructWithoutInterface<int>())
                sum += i;
            return sum;
        }

        [Benchmark]
        public int WithInterfaces()
        {
            var sum = 0;
            foreach (var i in new StructWithInterfaces<int>())
                sum += i;
            return sum;
        }

        public struct StructWithoutInterface<T>
        {
            public StructWithoutInterface<T> GetEnumerator() => this;
            public T Current => default;
            public bool MoveNext() => false;
        }

        public struct StructWithInterfaces<T> : IEnumerable<T>, IEnumerator<T>
        {
            public StructWithInterfaces<T> GetEnumerator() => this;
            IEnumerator<T> IEnumerable<T>.GetEnumerator() => this;
            IEnumerator IEnumerable.GetEnumerator() => this;
            public T Current => default;
            object IEnumerator.Current => default;
            public bool MoveNext() => false;

            public void Reset()
            {
            }

            public void Dispose()
            {
            }
        }
    }
}
