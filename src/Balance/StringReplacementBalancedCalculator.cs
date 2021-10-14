using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Dgt.Balance
{
    public class StringReplacementBalancedCalculator : IBalancedCalculator
    {
        public bool IsBalanced(string input, IEnumerable<Delimiter> delimiters)
        {
            var escapedStrings = delimiters.Select(x => Regex.Escape(x.ToString()));
            var pattern = string.Join('|', escapedStrings);
            var regex = new Regex(pattern, RegexOptions.Compiled);

            return IsBalanced(input, regex);
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