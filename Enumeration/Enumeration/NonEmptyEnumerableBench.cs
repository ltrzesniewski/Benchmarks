using System.Collections;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace Enumeration
{
    [ReturnValueValidator]
    public class NonEmptyEnumerableBench
    {
        [Benchmark(Baseline = true)]
        public int WithoutInterface()
        {
            var sum = 0;
            foreach (var i in new StructWithoutInterface())
                sum += i;
            return sum;
        }

        [Benchmark]
        public int WithInterfaces()
        {
            var sum = 0;
            foreach (var i in new StructWithInterfaces())
                sum += i;
            return sum;
        }

        public struct StructWithoutInterface
        {
            private int _i;
            public StructWithoutInterface GetEnumerator() => new StructWithoutInterface();
            public int Current => _i;

            public bool MoveNext()
            {
                if (_i >= 10)
                    return false;

                ++_i;
                return true;
            }
        }

        public struct StructWithInterfaces : IEnumerable<int>, IEnumerator<int>
        {
            private int _i;
            public StructWithInterfaces GetEnumerator() => new StructWithInterfaces();
            IEnumerator<int> IEnumerable<int>.GetEnumerator() => GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
            public int Current => _i;
            object IEnumerator.Current => _i;

            public bool MoveNext()
            {
                if (_i >= 10)
                    return false;

                ++_i;
                return true;
            }

            public void Reset()
            {
                _i = 0;
            }

            public void Dispose()
            {
            }
        }
    }
}
