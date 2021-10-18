namespace Dgt.Dojo.FizzBuzz
{
    public static class Implementations
    {
        // We're performing two mathematical operations on value. Can we reduce this to 1?
        // We're potentially creating four strings so consuming way more memory than we need to
        // We _still_ have a conditional check on what we're returning
        public static string ClassicFizzBuzz(int value)
        {
            var output = string.Empty;

            if (value % 3 == 0)
            {
                output += "Fizz";
            }

            if (value % 5 == 0)
            {
                output += "Buzz";
            }

            return string.IsNullOrEmpty(output) ? value.ToString() : output;
        }

        // We're still performing two operations on value, but should be allocating fewer strings than the classic implementation
        public static string TuplesAndSwitchExpressions(int value)
        {
            // See https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/switch-expression
            // It is unclear from the docs whether switch expressions are short-circuited, but let's assume they are
            // and so put the arms in the order of greatest probability to lowest
            return (value % 3 == 0, value % 5 == 0) switch
            {
                (false, false) => value.ToString(),
                (true, false)  => "Fizz",
                (false, true)  => "Buzz",
                _              => "FizzBuzz"
            };
        }

        public static string SwitchExpressionsAndPatternMatching(int value)
        {
            return (value % 3, value % 5) switch
            {
                (> 0, > 0) => value.ToString(),
                (0, > 0)   => "Fizz",
                (> 0, 0)   => "Buzz",
                _          => "FizzBuzz"
            };
        }
    }
}