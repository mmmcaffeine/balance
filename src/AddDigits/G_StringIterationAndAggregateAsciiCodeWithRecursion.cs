using System.Diagnostics.CodeAnalysis;

namespace Dgt.Dojo.AddDigits;

/// <summary>
/// Repeatedly adds digits of a non-negative integer until the result only has a single digit.
/// </summary>
/// <remarks>
/// The input value is converted into a <see cref="char"/> array so it can be enumerated. The individual characters
/// can then be aggregated using ASCII codes shifted by -48 to get the integer value for that character. If the answer
/// still doesn't meet the criteria a tail-recursive call can be made to further reduce the return value.
/// </remarks>
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
    
    public override string ToString() => "G Iterate char array and aggregate ASCII codes with recursion";
}