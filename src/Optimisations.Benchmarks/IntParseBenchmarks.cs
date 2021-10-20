using BenchmarkDotNet.Attributes;

namespace Dgt.Dojo.Optimisations
{
    [MemoryDiagnoser]
    public class IntParseBenchmarks
    {
        private const string Input = "1976";

        [Benchmark(Baseline = true)]
        public int Baseline_Should_ParseIntFromString()
        {
            return IntParse.Baseline(Input);
        }

        [Benchmark]
        public int A_TwoLoopVariables_Should_ParseIntFromString()
        {
            return IntParse.A_TwoLoopVariables(Input);
        }

        [Benchmark]
        public int B_MathOperations_Should_ParseIntFromString()
        {
            return IntParse.B_MathOperations(Input);
        }

        [Benchmark]
        public int C_EnumerateBackwardsForPowersOfTen()
        {
            return IntParse.C_EnumerateBackwardsForPowersOfTen(Input);
        }
    }
}