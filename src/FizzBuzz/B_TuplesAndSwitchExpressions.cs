namespace Dgt.Dojo.FizzBuzz
{
    public class B_TuplesAndSwitchExpressions : IImplementation
    {
        // We're still performing two operations on value, but should be allocating fewer strings than the classic implementation
        public string FizzBuzz(int value)
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
    }
}