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
        public void ClassicFizzBuzz()
        {
            for (var i = 1; i <= 100; i++)
            {
                _ = Implementations.ClassicFizzBuzz(i);
            }
        }

        [Benchmark]
        public void TuplesAndSwitchExpressions()
        {
            for (var i = 1; i <= 100; i++)
            {
                _ = Implementations.TuplesAndSwitchExpressions(i);
            }
        }
        
        [Benchmark]
        public void SwitchExpressionsAndPatternMatching()
        {
            for (var i = 1; i <= 100; i++)
            {
                _ = Implementations.SwitchExpressionsAndPatternMatching(i);
            }
        }
        
        [Benchmark]
        public void GetFizzBuzzFromAnswerFuncs()
        {
            for (var i = 1; i <= 100; i++)
            {
                _ = ArrayLookupFizzBuzz.GetFizzBuzzFromAnswerFuncs(i);
            }
        }
        
        [Benchmark]
        public void GetFizzBuzzFromValueArrays()
        {
            for (var i = 1; i <= 100; i++)
            {
                _ = ArrayLookupFizzBuzz.GetFizzBuzzFromValueArrays(i);
            }
        }
        
        [Benchmark]
        public void GetFizzBuzzFromValueHashsets()
        {
            for (var i = 1; i <= 100; i++)
            {
                _ = ArrayLookupFizzBuzz.GetFizzBuzzFromValueHashsets(i);
            }
        }
    }
}

#pragma warning restore CA1822