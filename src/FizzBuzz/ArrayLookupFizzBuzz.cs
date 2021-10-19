using System;
using System.Collections.Generic;
using System.Linq;

namespace Dgt.Dojo.FizzBuzz
{
    public static class ArrayLookupFizzBuzz
    {
        // Would a HashSet<int> work faster
        private static readonly int[] FizzesAsArray = { 3, 6, 9, 12, 15 };
        private static readonly int[] BuzzesAsArray = { 5, 10, 15 };

        private static readonly HashSet<int> FizzesAsHashset = new(new[] { 3, 6, 9, 12, 15 });
        private static readonly HashSet<int> BuzzesAsHashset = new(new[] { 5, 10, 15 });

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

        public static string GetFizzBuzzFromAnswerFuncs(int value)
        {
            var index = value - 1;
            
            while (index >= 15)
            {
                index -= 15;
            }

            return AnswerFuncs[index](value);
        }

        public static string GetFizzBuzzFromValueArrays(int value)
        {
            var index = value;
            
            while (index > 15)
            {
                index -= 15;
            }

            var fizz = FizzesAsArray.Contains(index);
            var buzz = BuzzesAsArray.Contains(index);

            return (fizz, buzz) switch
            {
                (false, false) => value.ToString(),
                (true, false)  => "Fizz",
                (false, true)  => "Buzz",
                _              => "FizzBuzz"
            };
        }
        
        public static string GetFizzBuzzFromValueHashsets(int value)
        {
            var index = value;
            
            while (index > 15)
            {
                index -= 15;
            }

            var fizz = FizzesAsHashset.Contains(index);
            var buzz = BuzzesAsHashset.Contains(index);

            return (fizz, buzz) switch
            {
                (false, false) => value.ToString(),
                (true, false)  => "Fizz",
                (false, true)  => "Buzz",
                _              => "FizzBuzz"
            };
        }
    }
}