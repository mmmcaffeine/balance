using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Dgt.Balance
{
    public class RegexBasedBalancedCalculator : IBalancedCalculator
    {
        private const string AlternationCharacter = "|";
        
        public bool IsBalanced(string input, IEnumerable<Delimiter> delimiters)
        {
            var listOfDelimiters = delimiters.ToList();
            var unescapedDelimiterStrings = listOfDelimiters
                .SelectMany(x => new[] { x.Start, x.End })
                .Distinct();
            var escapedDelimiterStrings = listOfDelimiters
                .SelectMany(x => new[] { x.EscapeStart(), x.EscapeEnd() })
                .Distinct();
            var regex = CreateRegex(listOfDelimiters, escapedDelimiterStrings.JoinUsing(AlternationCharacter));

            return IsBalanced(input, unescapedDelimiterStrings, regex);
        }

        private static Regex CreateRegex(IEnumerable<Delimiter> delimiters, string escapedDelimiters)
        {
            var subPatterns = delimiters.Select(delimiter => GetPattern(delimiter, escapedDelimiters));
            var pattern = subPatterns.JoinUsing(AlternationCharacter);
            
            return new Regex(pattern);
        }

        private static string GetPattern(Delimiter currentDelimiter, string escapedDelimiters)
        {
            var escapedStart = currentDelimiter.EscapeStart();
            var escapedEnd = currentDelimiter.EscapeEnd();

            return $"{escapedStart}((?!({escapedDelimiters})).)*?{escapedEnd}";
        }

        private static bool IsBalanced(string input, IEnumerable<string> unescapedDelimiterStrings, Regex regex)
        {
            string previousValue;
            var value = input;
            
            do
            {
                previousValue = value;
                value = regex.Replace(previousValue, string.Empty);
                
            } while (value != previousValue);

            return !value.ContainsAny(unescapedDelimiterStrings);
        }
    }
}