using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Dgt.Balance
{
    public class StringReplacementBalancedCalculator : IBalancedCalculator
    {
        // TODO Prevent needless creation of the same regex if we call this recursively
        // TODO Fix multiple enumerations of delimiters
        public bool IsBalanced(string input, IEnumerable<Delimiter> delimiters)
        {
            var strings = delimiters.Select(x => x.ToString());
            var escapedStrings = strings.Select(Regex.Escape);
            var pattern = string.Join('|', escapedStrings);
            var regex = new Regex(pattern, RegexOptions.Compiled);

            var value = regex.Replace(input, string.Empty);

            if (value == string.Empty) return true;
            if (value == input) return false;

            return IsBalanced(value, delimiters);
        }
    }
}