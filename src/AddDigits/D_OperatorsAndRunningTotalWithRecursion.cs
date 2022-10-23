using System.Diagnostics.CodeAnalysis;

namespace Dgt.Dojo.AddDigits;

/// <summary>
/// Repeatedly adds digits of a non-negative integer until the result only has a single digit. 
/// </summary>
/// <remarks>
/// Treats the input as numeric and repeatedly divides by 10 to get the remainder (i.e. a single digit). A running
/// total of the remainders can be kept. This allows a primitive to be used, rather than having to maintain a
/// <see cref="List{T}"/> allocated on the heap. Finally, if the answer still doesn't meet the criteria a tail-recursive
/// call can be made to further reduce the return value.
/// </remarks>
[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "TailRecursiveCall")]
public class D_OperatorsAndRunningTotalWithRecursion : IDigitsAdder
{
    public byte AddDigits(uint value)
    {
        var runningTotal = 0u;
        var remaining = value;

        while (remaining > 9)
        {
            runningTotal += remaining % 10;
            remaining /= 10;
        }

        runningTotal += remaining;

        return runningTotal >= 10 ? AddDigits(runningTotal) : (byte)runningTotal;
    }

    public override string ToString() => "D Maintain running total of digits and recursion";
}