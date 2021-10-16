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
            if (character != delimiter.Start)
            {
                return false;
            }

            if (delimiter.IsOpposingPair)
            {
                return true;
            }

            return !(stack.Any() && stack.Peek() == character);
        }
    }
}