using System.Collections.Generic;
using Xunit;

namespace Dgt.Dojo.Balance
{
    public class DelimitedStringsTestData : TheoryData<string, IEnumerable<Delimiter>, bool>
    {
        public DelimitedStringsTestData()
        {
            Add("<elementName>", new[] { Delimiter.AngleBrackets }, true);
            Add("<elementName", new[] { Delimiter.AngleBrackets }, false);
            Add("var x = Sum(new []{1, 2, 3});", new[] { Delimiter.Braces, Delimiter.Brackets, Delimiter.Parentheses }, true);
            Add("var x = Sum(new [{1, 2, 3});", new[] { Delimiter.Braces, Delimiter.Brackets, Delimiter.Parentheses }, false);
            Add("\"Properly quoted String\"", new[] { Delimiter.DoubleQuotes }, true);
            Add("\"Improperly quoted string", new[] { Delimiter.DoubleQuotes }, false);
            Add("'x'", new[] { Delimiter.SingleQuotes }, true);
            Add("'x", new[] { Delimiter.SingleQuotes }, false);
            Add("new char[] { 'x', 'y', 'z' }", new[] { Delimiter.Brackets, Delimiter.Braces, Delimiter.SingleQuotes }, true);
            Add("new char[] { 'x', 'y', 'z }", new[] { Delimiter.Brackets, Delimiter.Braces,  Delimiter.SingleQuotes }, false);
        }
    }
}