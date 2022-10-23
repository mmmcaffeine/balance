using System.Diagnostics.CodeAnalysis;
using BenchmarkDotNet.Attributes;

namespace Dgt.Dojo.AddDigits;

[MemoryDiagnoser]
[SuppressMessage("Performance", "CA1822:Mark members as static")]
public class DigitsAdderBenchmarks
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

    [Benchmark(Baseline = true, Description = "0 String iteration with recursion")]
    [ArgumentsSource(nameof(ValuesForValue))]
    public byte DigitsAdder_AddDigitsUsingStringIterationAndRecursion(uint value) =>
        DigitsAdder.AddDigitsUsingStringIterationAndRecursion(value);

    [Benchmark(Description = "1 Modulo and division operators with recursion")]
    [ArgumentsSource(nameof(ValuesForValue))]
    public byte DigitsAdder_AddDigitsUsingOperatorsAndRecursion(uint value) =>
        DigitsAdder.AddDigitsUsingOperatorsAndRecursion(value);

    [Benchmark(Description = "2 Math.DivRem with recursion")]
    [ArgumentsSource(nameof(ValuesForValue))]
    public byte DigitsAdder_AddDigitsUsingDivRemAndRecursion(uint value) =>
        DigitsAdder.AddDigitsUsingDivRemAndRecursion(value);

    [Benchmark(Description = "3 Modulo and division operators with running total and recursion")]
    [ArgumentsSource(nameof(ValuesForValue))]
    public byte DigitsAdder_AddDigitsUsingOperatorsWithRunningTotalAndRecursion(uint value) =>
        DigitsAdder.AddDigitsUsingOperatorsWithRunningTotalAndRecursion(value);

    [Benchmark(Description = "4 Modulo and division operators with running total and nested loop")]
    [ArgumentsSource(nameof(ValuesForValue))]
    public byte DigitsAdder_AddDigitsUsingOperatorsWithRunningTotalAndNestedLoop(uint value) =>
        DigitsAdder.AddDigitsUsingOperatorsWithRunningTotalAndNestedLoop(value);
}