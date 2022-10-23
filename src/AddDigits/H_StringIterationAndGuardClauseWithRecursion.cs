using System.Diagnostics.CodeAnalysis;

namespace Dgt.Dojo.AddDigits;

/// <summary>
/// Repeatedly adds digits of a non-negative integer until the result only has a single digit.
/// </summary>
/// <remarks>
/// The input value is converted into a <see cref="char"/> array so it can be enumerated, but only after checking it is
/// necessary to do so. The individual characters can then be aggregated using their numeric value. A tail-recursive
/// call is then made to ensure the answer is fully reduced. The guard clause in the method will prevent any
/// stack overflow.
/// </remarks>
[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "TailRecursiveCall")]
public class H_StringIterationAndGuardClauseWithRecursion : IDigitsAdder
{
    public byte AddDigits(uint value)
    {
        if (value < 10) return (byte)value;
        
        var sum = value
            .ToString()
            .ToCharArray()
            .Select(c => (uint)char.GetNumericValue(c)).Sum(x => x);

        return AddDigits((uint)sum);
    }
    
    public override string ToString() => "H Iterate char array and aggregate numeric values with guard clause";
}