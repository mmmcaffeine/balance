using System.Collections.Generic;
using System.Linq;

namespace Dgt.Balance
{
    // TODO Enhance this to cope with the open and close delimiter being the same character e.g. double quotes for a string
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
            
            return stack.Empty();
        }
    }
}