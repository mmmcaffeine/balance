using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Dgt.Dojo.AddDigits;

/// <summary>
/// Repeatedly adds digits of a non-negative integer until the result only has a single digit.
/// </summary>
/// <remarks>
/// Captures individual digits using a regular expression so they can be enumerated. The captures can then be
/// aggregated by converting into a <see cref="uint"/> to get the integer value for that character. If the answer
/// still doesn't meet the criteria a tail-recursive call can be made to further reduce the return value.
/// </remarks>
[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "TailRecursiveCall")]
public class I_RegexAndAggregateNumericValueWithRecursion : IDigitsAdder
{
    public byte AddDigits(uint value)
    {
        var digitMatches = Regex.Matches(value.ToString(), @"\d").Cast<Match>();
        var sum = digitMatches.Aggregate(0u, (total, match) => total + Convert.ToUInt32(match.Value));
    
        return sum < 10 ? (byte)sum : AddDigits(sum);
    }

    public override string ToString() => "I Digits from regex and aggregate numeric values codes with recursion";
}