namespace Dgt.Dojo.FizzBuzz
{
    public class H_IndexIntoPreCalculatedString : IImplementation
    {
        private static readonly string FizzBuzzString = "FizzBuzz";

        public string FizzBuzz(int value)
        {
            var start = -1;
            var length = 0;

            if (value % 5 == 0)
            {
                start = 4;
                length = 4;
            }

            if (value % 3 == 0)
            {
                start = 0;
                length += 4;
            }

            return start == -1
                ? value.ToString()
                : FizzBuzzString[start..(start + length)];
        }
    }
}