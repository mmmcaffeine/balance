using System.Collections.Generic;
using Xunit;

namespace Dgt.Balance
{
    public class DelimitedStringsTestData : TheoryData<string, IEnumerable<Delimiter>, bool>
    {
        public DelimitedStringsTestData()
        {
            Add("<elementName>", new[] { Delimiter.AngleBrackets }, true);
            Add("<elementName", new[] { Delimiter.AngleBrackets }, false);
            Add("var x = Sum(new []{1, 2, 3});", new[] { Delimiter.Braces, Delimiter.Brackets, Delimiter.Parentheses }, true);
            Add("var x = Sum(new [{1, 2, 3});", new[] { Delimiter.Braces, Delimiter.Brackets, Delimiter.Parentheses }, false);
        }
    }
}