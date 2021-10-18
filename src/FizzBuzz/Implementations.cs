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
    }
}