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
        
        [Benchmark]
        public int D_NoSpan()
        {
            return IntParse.D_NoSpan(Input);
        }
        
        [Benchmark]
        public int E_InputSpan()
        {
            return IntParse.E_InputSpan(Input);
        }
        
        [Benchmark]
        public int F_MultiplyAndAddWithForLoop()
        {
            return IntParse.F_MultiplyAndAddWithForLoop(Input);
        }
        
        [Benchmark]
        public int G_MultiplyAndAddWithForEachLoop()
        {
            return IntParse.G_MultiplyAndAddWithForEachLoop(Input);
        }
    }
}