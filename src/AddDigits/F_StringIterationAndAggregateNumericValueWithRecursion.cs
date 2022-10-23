using System.Diagnostics.CodeAnalysis;

namespace Dgt.Dojo.AddDigits;

/// <summary>
/// Repeatedly adds digits of a non-negative integer until the result only has a single digit.
/// </summary>
/// <remarks>
/// The input value is converted into a <see cref="char"/> array so it can be enumerated. The individual characters
/// can then be aggregated using their numeric value. If the answer still doesn't meet the criteria a tail-recursive
/// call can be made to further reduce the return value.
/// </remarks>
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
    
    public override string ToString() => "F Iterate char array and aggregate numeric values with recursion";
}