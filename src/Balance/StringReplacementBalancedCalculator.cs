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
            var escapedDelimiters = listOfDelimiters
                .Select(delimiter => $"{delimiter.EscapeStart()}{delimiter.EscapeEnd()}")
                .Join();
            var delimiterCharacters = listOfDelimiters.SelectMany(x => new[] { x.Start, x.End });
            var regex = CreateRegex(listOfDelimiters, escapedDelimiters);

            return IsBalanced(input, delimiterCharacters, regex);
        }

        private static Regex CreateRegex(IEnumerable<Delimiter> delimiters, string escapedDelimiters)
        {
            var patterns = delimiters.Select(delimiter => GetPattern(delimiter, escapedDelimiters));
            
            return new Regex(string.Join("|", patterns), RegexOptions.Compiled);
        }

        private static string GetPattern(Delimiter currentDelimiter, string escapedDelimiters)
        {
            var escapedStart = currentDelimiter.EscapeStart();
            var characterGroup = $"[^${escapedDelimiters}]";
            var escapedEnd = currentDelimiter.EscapeEnd();

            return $"{escapedStart}{characterGroup}*?{escapedEnd}";
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