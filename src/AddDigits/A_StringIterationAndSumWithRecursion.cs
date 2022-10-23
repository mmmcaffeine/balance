using System.Diagnostics.CodeAnalysis;

namespace Dgt.Dojo.AddDigits;

/// <summary>
/// Repeatedly adds digits of a non-negative integer until the result only has a single digit. <para>The baseline
/// implementation of <see cref="IDigitsAdder"/>.</para> 
/// </summary>
/// <remarks>
/// The default implementation that most people seem to go for. The input value is converted into a <see cref="char"/>
/// array so it can be enumerated. The individual characters can then be converted back into a single-digit number
/// and summed. Finally, if the answer still doesn't meet the criteria a tail-recursive call can be made to further
/// reduce the return value.
/// </remarks>
[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "TailRecursiveCall")]
public class A_StringIterationAndSumWithRecursion : IDigitsAdder
{
    public byte AddDigits(uint value)
    {
        var sum = value
            .ToString()
            .ToCharArray()
            .Select(c => (uint)char.GetNumericValue(c)).Sum(x => x);
        
        // Tail recursion... Will this be inefficient on very large numbers? Unlikely as with int we can't get up
        // to three digits on the first iteration. The highest value we can get is 84. This limits the sum. I _think_
        // we will need at most three iterations, so extra stack frames is probably not a concern to us
        
        return sum >= 10 ? AddDigits((uint)sum) : (byte)sum;
    }

    public override string ToString() => "A Iterate char array and sum numeric values with recursion";
}