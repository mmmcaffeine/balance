using System.Diagnostics.CodeAnalysis;

namespace Dgt.Dojo.AddDigits;

/// <summary>
/// Repeatedly adds digits of a non-negative integer until the result only has a single digit. 
/// </summary>
/// <remarks>
/// Treats the input as numeric and repeatedly divides by 10 to get the remainder (i.e. a single digit). A running
/// total of the remainders can be kept. This allows a primitive to be used, rather than having to maintain a
/// <see cref="List{T}"/> allocated on the heap. This occurs in an inner loop. An outer loop repeatedly executes the
/// inner loop until the answer has been reduced to a single digit. This removes the need for a tail-recursive
/// function call.
/// </remarks>
[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public class E_OperatorsAndRunningTotalWithNestedLoop: IDigitsAdder
{
    public byte AddDigits(uint value)
    {
        var runningTotal = 0u;
        var remaining = value;

        do
        {
            while (remaining > 9)
            {
                runningTotal += remaining % 10;
                remaining /= 10;
            }

            runningTotal += remaining;

            if (runningTotal <= 9)
            {
                return (byte)runningTotal;
            }
            
            remaining = runningTotal;
            runningTotal = 0;

        } while (true);
    }

    public override string ToString() => "E Maintain running total of digits and nested loop";
}