using System.Diagnostics.CodeAnalysis;

namespace Dgt.Dojo.AddDigits;

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
}