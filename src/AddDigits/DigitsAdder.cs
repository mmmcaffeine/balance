namespace Dgt.Dojo.AddDigits;

public static class DigitsAdder
{
    public static int AddDigits(int value)
    {
        var sum = value
            .ToString()
            .ToCharArray()
            .Select(c => (int)char.GetNumericValue(c)).Sum(x => x);

        // Tail recursion... Will this be inefficient on very large numbers? Unlikely as with int we can't get up
        // to three digits on the first iteration. The highest value we can get is 82. This limits the sum. I _think_
        // we will need at most three iterations, so extra stack frames is probably not a concern to us
        return sum >= 10 ? AddDigits(sum) : sum;
    }
}