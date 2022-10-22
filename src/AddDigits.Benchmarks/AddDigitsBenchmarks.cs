using BenchmarkDotNet.Attributes;

namespace Dgt.Dojo.AddDigits;

[MemoryDiagnoser]
public class AddDigitsBenchmarks
{
    public static IEnumerable<uint> ValuesForValue
    {
        get
        {
            yield return 38;
            yield return 1337;
            yield return 987654321;
            yield return uint.MaxValue;
        }
    }

    [Benchmark(Baseline = true)]
    [ArgumentsSource(nameof(ValuesForValue))]
    public byte DigitsAdder_AddDigitsUsingStringIterationAndRecursion(uint value) =>
        DigitsAdder.AddDigitsUsingStringIterationAndRecursion(value);
}