using System.Diagnostics.CodeAnalysis;
using BenchmarkDotNet.Attributes;

namespace Dgt.Dojo.AddDigits;

[MemoryDiagnoser]
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global", Justification = "BenchmarkDotNet requires parameter sources to be public.")]
[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global", Justification = "BenchmarkDotNet requires parameter sources to have setters.")]
public class DigitsAdderBenchmarks
{
    [ParamsSource(nameof(ValuesForDigitsAdder))]
    public IDigitsAdder? DigitsAdder { get; set; }

    public static IEnumerable<IDigitsAdder> ValuesForDigitsAdder => typeof(IDigitsAdder).Assembly.GetTypes()
        .Where(x => x.IsAssignableTo(typeof(IDigitsAdder)) && !x.IsAbstract)
        .Select(Activator.CreateInstance)
        .Cast<IDigitsAdder>();

    [Params(38, 1337, 987654321, uint.MaxValue)]
    public uint Value { get; set; }

    [Benchmark]
    public byte Benchmark() => DigitsAdder!.AddDigits(Value);
}