using System;

namespace Dgt.Dojo.FizzBuzz
{
    public static class ArrayLookupFizzBuzz
    {
        private static readonly Func<int, string>[] AnswerFuncs =
        {
            i => i.ToString(),
            i => i.ToString(),
            _ => "Fizz",
            i => i.ToString(),
            _ => "Buzz",
            _ => "Fizz",
            i => i.ToString(),
            i => i.ToString(),
            _ => "Fizz",
            _ => "Buzz",
            i => i.ToString(),
            _ => "Fizz",
            i => i.ToString(),
            i => i.ToString(),
            _ => "FizzBuzz"
        };

        public static string GetFizzBuzz(int value)
        {
            var index = value - 1;
            
            while (index >= 15)
            {
                index -= 15;
            }

            return AnswerFuncs[index](value);
        }
    }
}