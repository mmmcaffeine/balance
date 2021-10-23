using System.Collections.Generic;

namespace Dgt.Dojo.FizzBuzz
{
    public class J_KeyIntoDictionaryOfStringWithNulls : IImplementation
    {
        private static readonly Dictionary<int, string?> Answers =new()
        {
            { 0, "FizzBuzz" },
            { 1, null },
            { 2, null },
            { 3, "Fizz" },
            { 4, null },
            { 5, "Buzz" },
            { 6, "Fizz" },
            { 7, null },
            { 8, null },
            { 9, "Fizz" },
            { 10, "Buzz" },
            { 11, null },
            { 12, "Fizz" },
            { 13, null },
            { 14, null }
        };
        
        // Our spec does not define behaviour on a value of 0. This would return "FizzBuzz" when it should
        // arguably return "0"
        public string FizzBuzz(int value) => Answers[value % 15] ?? value.ToString();
    }
}