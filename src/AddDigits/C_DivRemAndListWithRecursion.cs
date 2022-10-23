using System.Diagnostics.CodeAnalysis;

namespace Dgt.Dojo.AddDigits;

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
}