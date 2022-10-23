using System.Diagnostics.CodeAnalysis;

namespace Dgt.Dojo.AddDigits;

/// <summary>
/// Repeatedly adds digits of a non-negative integer until the result only has a single digit. 
/// </summary>
/// <remarks>
/// Treats the input as numeric, and builds a <see cref="List{T}" /> of the individual digits by repeatedly taking
/// the remainder after division by 10. <see cref="Math.DivRem(uint, uint)" /> is used to perform the division. The
/// individual digits can then be summed. Finally, if the answer still doesn't meet the criteria a tail-recursive call
/// can be made to further reduce the return value.
/// </remarks>
[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "TailRecursiveCall")]
public class C_DivRemAndListWithRecursion : IDigitsAdder
{
    public byte AddDigits(uint value)
    {
        var digits = new List<uint>();
        var remaining = value;

        while (remaining > 9)
        {
            (remaining, var digit) = Math.DivRem(remaining, 10);
            digits.Add(digit);
        }
        
        digits.Add(remaining);

        var sum = digits.Sum(x => x);
        
        return sum >= 10 ? AddDigits((uint)sum) : (byte)sum;
    }

    public override string ToString() => "C Build list of digits using Math.DivRem and sum with recursion";
}