using System;
using System.Collections.Generic;
using System.Linq;

namespace Dgt.Balance
{
    public class StackBasedBalancedCalculator : IBalancedCalculator
    {
        public bool IsBalanced(string input, IEnumerable<Delimiter> delimiters)
        {
            var listOfDelimiters = delimiters.ToList();

            if (listOfDelimiters.Any(x => x.Start.Length > 1 || x.End.Length > 1))
            {
                throw new NotSupportedException("Start or end delimiters of more than one character are not yet supported.");
            }
            
            var stack = new Stack<char>();

            foreach (var character in input)
            {
                var delimiter = listOfDelimiters.FirstOrDefault(x => character == x.Start[0] || character == x.End[0]);
                if (delimiter == default) continue;

                if (IsStartCharacter(character, delimiter, stack))
                {
                    stack.Push(character);
                }
                else
                {
                    if (stack.Empty()) return false;
                    if (stack.Pop() != delimiter.Start[0]) return false;
                }
            }
            
            return stack.Empty();
        }

        private static bool IsStartCharacter(char character, Delimiter delimiter, Stack<char> stack)
        {
            if (character != delimiter.Start[0])
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