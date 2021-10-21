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