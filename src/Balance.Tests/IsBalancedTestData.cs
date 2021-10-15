using System.Collections.Generic;
using Xunit;

namespace Dgt.Balance
{
    public class IsBalancedTestData : TheoryData<string, bool>
    {
        public static IEnumerable<Delimiter> Delimiters { get; } = new[]
        {
            Delimiter.Braces,
            Delimiter.Brackets,
            Delimiter.Parentheses
        };

        public IsBalancedTestData()
        {
            Add("[]", true);
            Add("{}", true);
            Add("()", true);
            Add("([)]", false);
            Add("([]", false);
            Add("{{)(}}", false);
            Add("({)}", false);
            Add("[({})]", true);
            Add("{}([])", true);
            Add("{()}[[{}]]", true);
        }
    }
}