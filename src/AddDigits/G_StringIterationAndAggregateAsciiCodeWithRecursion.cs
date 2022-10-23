using System.Diagnostics.CodeAnalysis;

namespace Dgt.Dojo.AddDigits;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "TailRecursiveCall")]
public class G_StringIterationAndAggregateAsciiCodeWithRecursion : IDigitsAdder
{
    public byte AddDigits(uint value)
    {
        var sum = value
            .ToString()
            .ToCharArray()
            .Aggregate(0u, (total, c) => total + c - 48);

        return sum >= 10 ? AddDigits(sum) : (byte)sum;
    }
}