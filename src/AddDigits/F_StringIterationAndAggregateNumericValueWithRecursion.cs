using System.Diagnostics.CodeAnalysis;

namespace Dgt.Dojo.AddDigits;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "TailRecursiveCall")]
public class F_StringIterationAndAggregateNumericValueWithRecursion : IDigitsAdder
{
    public byte AddDigits(uint value)
    {
        var sum = value
            .ToString()
            .ToCharArray()
            .Aggregate(0u, (total, c) => total + (uint)char.GetNumericValue(c));

        return sum >= 10 ? AddDigits(sum) : (byte)sum;
    }
}