// See following link for CA1822. However, BenchmarkDotNet requires benchmarks to be instance methods
// https://docs.microsoft.com/en-us/dotnet/fundamentals/code-analysis/quality-rules/ca1822
#pragma warning disable CA1822

using BenchmarkDotNet.Attributes;

namespace Dgt.Dojo.FizzBuzz
{
    [MemoryDiagnoser]
    public class FizzBuzzBenchmarks
    {
        [Benchmark(Baseline = true)]
        public void A_Baseline()
        {
            var implementation = new A_Baseline();
            
            for (var i = 1; i <= 100; i++)
            {
                _ = implementation.FizzBuzz(i);
            }
        }

        [Benchmark]
        public void B_TuplesAndSwitchExpressions()
        {
            var implementation = new B_TuplesAndSwitchExpressions();
            
            for (var i = 1; i <= 100; i++)
            {
                _ = implementation.FizzBuzz(i);
            }
        }
        
        [Benchmark]
        public void C_SwitchExpressionsAndPatternMatching()
        {
            var implementation = new C_SwitchExpressionsAndPatternMatching();
            
            for (var i = 1; i <= 100; i++)
            {
                _ = implementation.FizzBuzz(i);
            }
        }
        
        [Benchmark]
        public void D_LookUpAnswerFunction()
        {
            var implementation = new D_LookUpAnswerFunction();
            
            for (var i = 1; i <= 100; i++)
            {
                _ = implementation.FizzBuzz(i);
            }
        }
        
        [Benchmark]
        public void E_StoreFizzersAndBuzzersInArray()
        {
            var implementation = new E_StoreFizzersAndBuzzersInArray();
            
            for (var i = 1; i <= 100; i++)
            {
                _ = implementation.FizzBuzz(i);
            }
        }
        
        [Benchmark]
        public void F_StoreFizzersAndBuzzersInHashset()
        {
            var implementation = new F_StoreFizzersAndBuzzersInHashset();
            
            for (var i = 1; i <= 100; i++)
            {
                _ = implementation.FizzBuzz(i);
            }
        }
        
        [Benchmark]
        public void G_IndexIntoPreCalculatedCharArray()
        {
            var implementation = new G_IndexIntoPreCalculatedCharArray();
            
            for (var i = 1; i <= 100; i++)
            {
                _ = implementation.FizzBuzz(i);
            }
        }
        
        [Benchmark]
        public void H_IndexIntoPreCalculatedString()
        {
            var implementation = new H_IndexIntoPreCalculatedString();
            
            for (var i = 1; i <= 100; i++)
            {
                _ = implementation.FizzBuzz(i);
            }
        }
    }
}

#pragma warning restore CA1822