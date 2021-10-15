using System.Collections.Generic;
using Xunit;

namespace Dgt.Balance
{
    public class DelimitersOnlyTestData : TheoryData<string, bool>
    {
        public static IEnumerable<Delimiter> Delimiters { get; } = new[]
        {
            Delimiter.Braces,
            Delimiter.Brackets,
            Delimiter.Parentheses
        };

        public DelimitersOnlyTestData()
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