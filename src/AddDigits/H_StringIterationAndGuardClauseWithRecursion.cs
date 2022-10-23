using System.Diagnostics.CodeAnalysis;

namespace Dgt.Dojo.AddDigits;

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
}