using System.Collections.Generic;

namespace Dgt.Dojo.FizzBuzz
{
    public class F_StoreFizzersAndBuzzersInHashset : IImplementation
    {
        private static readonly HashSet<int> Fizzers = new(new[] { 3, 6, 9, 12, 15 });
        private static readonly HashSet<int> Buzzers = new(new[] { 5, 10, 15 });
        
        public string FizzBuzz(int value)
        {
            var index = value;
            
            while (index > 15)
            {
                index -= 15;
            }

            var fizz = Fizzers.Contains(index);
            var buzz = Buzzers.Contains(index);

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