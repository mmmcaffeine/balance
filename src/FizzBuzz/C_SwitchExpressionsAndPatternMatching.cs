namespace Dgt.Dojo.FizzBuzz
{
    public class C_SwitchExpressionsAndPatternMatching : IImplementation
    {
        public string FizzBuzz(int value)
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