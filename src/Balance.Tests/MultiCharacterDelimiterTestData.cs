using System.Collections.Generic;
using Xunit;

namespace Dgt.Balance
{
    public class MultiCharacterDelimiterTestData : TheoryData<string, IEnumerable<Delimiter>, bool>
    {
        public MultiCharacterDelimiterTestData()
        {
            Add("<!-- HTML Comment -->", new[] { Delimiter.HtmlComment }, true);
            Add("<!-- XML Comment -->", new[] { Delimiter.XmlComment }, true);
            Add("@* Razor Comment *@", new[] { Delimiter.RazorComment }, true);
            Add("<%-- ASPX Comment --%>", new[] { Delimiter.AspxComment }, true);
            Add("/* Multi Line Comment */", new[] { Delimiter.MultiLineComment }, true);
            
            Add("*@ Razor Comment", new[] { Delimiter.RazorComment }, false);
            Add("ASPX Comment --%>", new[] { Delimiter.AspxComment }, false);
        }
    }
}