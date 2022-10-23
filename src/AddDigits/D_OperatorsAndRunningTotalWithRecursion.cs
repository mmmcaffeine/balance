using System.Diagnostics.CodeAnalysis;

namespace Dgt.Dojo.AddDigits;

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
}