using System.Diagnostics.CodeAnalysis;

namespace Dgt.Dojo.AddDigits;

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
}