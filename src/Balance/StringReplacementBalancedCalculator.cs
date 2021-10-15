using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Dgt.Balance
{
    // TODO Enhance this to cope with the open and close delimiter being the same character e.g. double quotes for a string
    public class StringReplacementBalancedCalculator : IBalancedCalculator
    {
        public bool IsBalanced(string input, IEnumerable<Delimiter> delimiters)
        {
            var listOfDelimiters = delimiters.ToList();
            var regex = CreateRegex(listOfDelimiters);
            var delimiterCharacters = listOfDelimiters.SelectMany(x => new[] { x.Start, x.End });

            return IsBalanced(input, delimiterCharacters, regex);
        }

        private static Regex CreateRegex(IReadOnlyCollection<Delimiter> delimiters)
        {
            var patterns = delimiters.Select(x => GetPattern(x, delimiters.Except(new[] { x })));
            
            return new Regex(string.Join("|", patterns), RegexOptions.Compiled);
        }

        private static string GetPattern(Delimiter expectedDelimiter, IEnumerable<Delimiter> unexpectedDelimiters)
        {
            var unexpectedCharacters = unexpectedDelimiters
                .Select(delimiter => $"{delimiter.EscapeStart()}{delimiter.EscapeEnd()}")
                .ToList(); 
            var escapedStart = expectedDelimiter.EscapeStart();
            var characterGroup = unexpectedCharacters.Any()
                ? $"[^${string.Join(string.Empty, unexpectedCharacters)}]*"
                : ".*";
            var escapedEnd = expectedDelimiter.EscapeEnd();

            return $"{escapedStart}{characterGroup}{escapedEnd}";
        }

        private static bool IsBalanced(string input, IEnumerable<char> delimiterCharacters, Regex regex)
        {
            string previousValue;
            var value = input;
            
            do
            {
                previousValue = value;
                value = regex.Replace(previousValue, string.Empty);
                
            } while (value != previousValue);

            return !value.ContainsAny(delimiterCharacters);
        }
    }
}