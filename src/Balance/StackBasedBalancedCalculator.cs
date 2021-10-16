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

                if (delimiter.Start == delimiter.End)
                {
                    if (stack.Any() && stack.Peek() == delimiter.Start)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        stack.Push(delimiter.Start);
                    }
                }
                else
                {
                    if (character == delimiter.Start)
                    {
                        stack.Push(character);
                    }
                    else
                    {
                        if (stack.Empty()) return false;
                        if (stack.Pop() != delimiter.Start) return false;
                    }
                }
            }
            
            return stack.Empty();
        }
    }
}