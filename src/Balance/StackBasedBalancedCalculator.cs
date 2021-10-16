using System.Collections.Generic;
using System.Linq;

namespace Dgt.Balance
{
    public class StackBasedBalancedCalculator : IBalancedCalculator
    {
        public bool IsBalanced(string input, IEnumerable<Delimiter> delimiters)
        {
            var listOfDelimiters = delimiters.ToList();
            var stack = new Stack<char>();

            foreach (var character in input)
            {
                var delimiter = listOfDelimiters.FirstOrDefault(x => character == x.Start || character == x.End);
                if (delimiter == default) continue;

                if (IsStartCharacter(character, delimiter, stack))
                {
                    stack.Push(character);
                }
                else
                {
                    if (stack.Empty()) return false;
                    if (stack.Pop() != delimiter.Start) return false;
                }
            }
            
            return stack.Empty();
        }

        private static bool IsStartCharacter(char character, Delimiter delimiter, Stack<char> stack)
        {
            var (start, end) = delimiter;
            
            if (character != start)
            {
                return false;
            }

            var isOpposingPair = start != end;

            if (isOpposingPair)
            {
                return true;
            }

            return !(stack.Any() && stack.Peek() == character);
        }
    }
}