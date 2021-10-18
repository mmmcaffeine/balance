using System.Collections.Generic;
using Xunit;

namespace Dgt.Dojo.Balance
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

            Add("@* <!-- Nested --> *@", new[] { Delimiter.HtmlComment, Delimiter.RazorComment, Delimiter.AspxComment }, true);
            Add("<%-- <!-- Nested --> --%>", new[] { Delimiter.HtmlComment, Delimiter.RazorComment, Delimiter.AspxComment }, true);
            Add("@* <!-- <%-- Nested --%> --> *@", new[] { Delimiter.HtmlComment, Delimiter.RazorComment, Delimiter.AspxComment }, true);
            
            Add("<!-- First --><!-- Second -->", new[] { Delimiter.HtmlComment, Delimiter.RazorComment, Delimiter.AspxComment }, true);
            
            Add("<!-- Unbalanced @* --> *@", new[] { Delimiter.HtmlComment, Delimiter.RazorComment, Delimiter.AspxComment }, false);
            Add("@* <!-- Unbalanced @* -->", new[] { Delimiter.HtmlComment, Delimiter.RazorComment, Delimiter.AspxComment }, false);
            Add("<!-- <%-- Not Closed -->", new[] { Delimiter.HtmlComment, Delimiter.RazorComment, Delimiter.AspxComment }, false);
        }
    }
}