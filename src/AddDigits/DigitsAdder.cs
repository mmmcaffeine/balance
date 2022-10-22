namespace Dgt.Dojo.AddDigits;

public static class DigitsAdder
{
    public static byte AddDigitsUsingStringIterationAndRecursion(uint value)
    {
        var sum = value
            .ToString()
            .ToCharArray()
            .Select(c => (uint)char.GetNumericValue(c)).Sum(x => x);

        // Tail recursion... Will this be inefficient on very large numbers? Unlikely as with int we can't get up
        // to three digits on the first iteration. The highest value we can get is 84. This limits the sum. I _think_
        // we will need at most three iterations, so extra stack frames is probably not a concern to us
        return sum >= 10 ? AddDigitsUsingStringIterationAndRecursion((uint)sum) : (byte)sum;
    }

    public static byte AddDigitsUsingOperatorsAndRecursion(uint value)
    {
        var digits = new List<uint>();
        var remaining = value;

        while (remaining > 9)
        {
            digits.Add(remaining % 10);
            remaining /= 10;
        }

        digits.Add(remaining);

        var sum = digits.Sum(x => x);

        return sum >= 10 ? AddDigitsUsingOperatorsAndRecursion((uint)sum) : (byte)sum;
    }

    public static byte AddDigitsUsingOperatorsWithRunningTotalAndRecursion(uint value)
    {
        var runningTotal = 0u;
        var remaining = value;

        while (remaining > 9)
        {
            runningTotal += remaining % 10;
            remaining /= 10;
        }

        runningTotal += remaining;
        
        return runningTotal >= 10
            ? AddDigitsUsingOperatorsWithRunningTotalAndRecursion(runningTotal)
            : (byte)runningTotal;
    }

    public static byte AddDigitsUsingDivRemAndRecursion(uint value)
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
        
        return sum >= 10 ? AddDigitsUsingDivRemAndRecursion((uint)sum) : (byte)sum;
    }
}