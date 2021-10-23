using System.Collections.Generic;

namespace Dgt.Dojo.FizzBuzz
{
    public class I_KeyIntoDictionaryOfString : IImplementation
    {
        private static readonly Dictionary<int, string> Answers =new()
        {
            { 0, "FizzBuzz" },
            { 3, "Fizz" },
            { 5, "Buzz" },
            { 6, "Fizz" },
            { 9, "Fizz" },
            { 10, "Buzz" },
            { 12, "Fizz" },
        };
        
        // Our spec does not define behaviour on a value of 0. This would return "FizzBuzz" when it should
        // arguably return "0"
        public string FizzBuzz(int value)
        {
            var index = value % 15;

            return Answers.ContainsKey(index)
                ? Answers[index]
                : value.ToString();
        }
    }
}