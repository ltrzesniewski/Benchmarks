using System;
using BenchmarkDotNet.Running;

namespace Quick
{
    internal class Program
    {
        private static void Main()
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run();
            //Test();

            Console.WriteLine();
            Console.WriteLine("Press enter to exit");

            while (Console.KeyAvailable)
                Console.ReadKey(true);

            Console.ReadLine();
        }

        private static void Test()
        {
            var inst = new AyendeSymbolSwitch { Value = 0 };
            Print();

            for (var i = 1u; i != 0; i = i << 1)
            {
                inst.Value = i;
                Print();
            }

            void Print() => Console.WriteLine($"{inst.NestedIfs()} {inst.InlineIL()} {inst.LeadingZeroCount()} {inst.Lzcnt()} {inst.Hagen()} {inst.Union()} {inst.UnsafeCast()}");
        }
    }
}
