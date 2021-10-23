using System;

namespace Dgt.Dojo.FizzBuzz
{
    public class G_IndexIntoPreCalculatedCharArray : IImplementation
    {
        private static readonly char[] FizzBuzzChars = { 'F', 'i', 'z', 'z', 'B', 'u', 'z', 'z' };
        
        public string FizzBuzz(int value)
        {
            var fizz = value % 3 == 0;
            var buzz = value % 5 == 0;
            var start = -1;
            var length = 0;

            if (buzz)
            {
                start = 4;
                length = 4;
            }

            if (fizz)
            {
                start = 0;
                length += 4;
            }

            return start == -1
                ? value.ToString()
                : new string(FizzBuzzChars[start..(start + length)]);
        }
    }
}