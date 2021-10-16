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
            var stack = new Stack<string>();

            for (var i = 0; i < input.Length; i++)
            {
                var delimiter = listOfDelimiters.FirstOrDefault(x =>
                    input.IndexOf(x.Start, i, StringComparison.Ordinal) == i ||
                    input.IndexOf(x.End, i, StringComparison.Ordinal) == i
                );
                if(delimiter == default) continue;

                if (IsStartDelimiter(input, i, delimiter, stack))
                {
                    stack.Push(delimiter.Start);

                    i += delimiter.Start.Length - 1;
                }
                else
                {
                    if (stack.Empty()) return false;
                    if (stack.Pop() != delimiter.Start) return false;

                    i += delimiter.End.Length - 1;
                }
            }
            
            return stack.Empty();
        }



        private static bool IsStartDelimiter(string input, int index, Delimiter delimiter, Stack<string> stack)
        {
            if (index + delimiter.Start.Length > input.Length)
            {
                return false;
            }
            
            return delimiter.IsOpposingPair
                ? input.Substring(index, delimiter.Start.Length) == delimiter.Start
                : !(stack.Any() && stack.Peek() == delimiter.Start);
        }
    }
}