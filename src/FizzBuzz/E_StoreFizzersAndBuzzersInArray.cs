using System.Linq;

namespace Dgt.Dojo.FizzBuzz
{
    public class E_StoreFizzersAndBuzzersInArray : IImplementation
    {
        private static readonly int[] Fizzers = { 3, 6, 9, 12, 15 };
        private static readonly int[] Buzzers = { 5, 10, 15 };
        
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