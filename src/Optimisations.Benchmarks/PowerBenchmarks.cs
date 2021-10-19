using BenchmarkDotNet.Attributes;

namespace Dgt.Dojo.Optimisations
{
    [MemoryDiagnoser]
    public class PowerBenchmarks
    {
        private const int Base = 10;
        private const int Exponent = 3;
        
        [Benchmark(Baseline = true)]
        public int Baseline()
        {
            return Power.Baseline(Base, Exponent);
        }

        [Benchmark]
        public int BitTwiddling()
        {
            return Power.BitTwiddling(Base, Exponent);
        }
    }
}