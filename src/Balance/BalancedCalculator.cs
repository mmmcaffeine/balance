using System.Collections.Generic;
using System.Linq;

namespace Dgt.Balance
{
    public static class BalancedCalculator
    {
        public static bool IsBalanced(string input, IEnumerable<(char Start, char End)> delimiters)
        {
            var listOfDelimiters = delimiters.ToList();
            var stack = new Stack<char>();

            foreach (var character in input)
            {
                var delimiter = listOfDelimiters.FirstOrDefault(x => character == x.Start || character == x.End);
                if (delimiter == default) continue;

                if (character == delimiter.Start)
                {
                    stack.Push(character);
                }
                else
                {
                    if (stack.Empty()) return false;
                    if (stack.Peek() != delimiter.Start) return false;

                    _ = stack.Pop();
                }
            }
            
            return stack.Empty();
        }
    }
}