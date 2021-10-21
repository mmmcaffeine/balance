using System;

namespace Dgt.Dojo.FizzBuzz
{
    public class D_LookUpAnswerFunction : IImplementation
    {
        private static readonly Func<int, string>[] AnswerFunctions =
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
        
        public string FizzBuzz(int value)
        {
            var index = value - 1;
            
            while (index >= 15)
            {
                index -= 15;
            }

            return AnswerFunctions[index](value);
        }
    }
}