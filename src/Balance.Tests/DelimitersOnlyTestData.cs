using System.Collections.Generic;
using Xunit;

namespace Dgt.Dojo.Balance
{
    public class DelimitersOnlyTestData : TheoryData<string, IEnumerable<Delimiter>, bool>
    {
        public DelimitersOnlyTestData()
        {
            Add("[]", new[] { Delimiter.Braces, Delimiter.Brackets, Delimiter.Parentheses }, true);
            Add("{}", new[] { Delimiter.Braces, Delimiter.Brackets, Delimiter.Parentheses }, true);
            Add("()", new[] { Delimiter.Braces, Delimiter.Brackets, Delimiter.Parentheses }, true);
            Add("([)]", new[] { Delimiter.Braces, Delimiter.Brackets, Delimiter.Parentheses }, false);
            Add("([]", new[] { Delimiter.Braces, Delimiter.Brackets, Delimiter.Parentheses }, false);
            Add("{{)(}}", new[] { Delimiter.Braces, Delimiter.Brackets, Delimiter.Parentheses }, false);
            Add("({)}", new[] { Delimiter.Braces, Delimiter.Brackets, Delimiter.Parentheses }, false);
            Add("[({})]", new[] { Delimiter.Braces, Delimiter.Brackets, Delimiter.Parentheses }, true);
            Add("{}([])", new[] { Delimiter.Braces, Delimiter.Brackets, Delimiter.Parentheses }, true);
            Add("{()}[[{}]]", new[] { Delimiter.Braces, Delimiter.Brackets, Delimiter.Parentheses }, true);

            Add("''", new[] { Delimiter.SingleQuotes }, true);
            Add("\"\"", new[] { Delimiter.DoubleQuotes }, true);
            Add("\"''\"", new[] { Delimiter.SingleQuotes, Delimiter.DoubleQuotes }, true);
            Add("\"'\"", new[] { Delimiter.SingleQuotes, Delimiter.DoubleQuotes }, false);
        }
    }
}