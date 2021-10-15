using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Dgt.Balance
{
    // TODO Enhance this to cope with the open and close delimiter being the same character e.g. double quotes for a string
    // TODO Enhance this to cope with text between delimiters (providing that text _doesn't_ match other delimiters)
    public class StringReplacementBalancedCalculator : IBalancedCalculator
    {
        public bool IsBalanced(string input, IEnumerable<Delimiter> delimiters)
        {
            var regex = CreateRegex(delimiters.ToList());

            return IsBalanced(input, regex);
        }

        private static Regex CreateRegex(IReadOnlyCollection<Delimiter> delimiters)
        {
            var patterns = delimiters.Select(x => GetPattern(x, delimiters.Except(new[] { x })));
            
            return new Regex(string.Join("|", patterns), RegexOptions.Compiled);
        }

        private static string GetPattern(Delimiter expectedDelimiter, IEnumerable<Delimiter> unexpectedDelimiters)
        {
            var unexpectedCharacters = unexpectedDelimiters
                .Select(x => $"{EscapeStart(x)}{EscapeEnd(x)}")
                .ToList(); 
            var escapedStart = EscapeStart(expectedDelimiter);
            var characterGroup = unexpectedCharacters.Any()
                ? $"[^${string.Join(string.Empty, unexpectedCharacters)}]*"
                : ".*";
            var escapedEnd = EscapeEnd(expectedDelimiter);

            return $"{escapedStart}{characterGroup}{escapedEnd}";
        }

        private static string EscapeStart(Delimiter delimiter) => Regex.Escape(delimiter.Start.ToString());

        // Helpfully, Regex.Escape does _not_ escape ']' or '}'
        // See https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.escape?view=net-5.0
        private static string EscapeEnd(Delimiter delimiter)
        {
            return delimiter.End switch
            {
                ']' => @"\]",
                '}' => @"\}",
                var x => Regex.Escape(x.ToString())
            };
        }

        private static bool IsBalanced(string input, Regex regex)
        {
            while (true)
            {
                var value = regex.Replace(input, string.Empty);

                if (value == string.Empty) return true;
                if (value == input) return false;

                input = value;
            }
        }
    }
}