using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Dgt.Balance
{
    public static class Extensions
    {
        public static bool Empty<T>(this IEnumerable<T> value) => !value.Any();

        public static bool ContainsAny(this string value, IEnumerable<char> chars) => value.Intersect(chars).Any();

        public static string EscapeStart(this Delimiter delimiter) => Regex.Escape(delimiter.Start.ToString());

        // Helpfully, Regex.Escape does _not_ escape ']' or '}'
        // See https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.escape?view=net-5.0
        public static string EscapeEnd(this Delimiter delimiter)
        {
            return delimiter.End switch
            {
                ']' => @"\]",
                '}' => @"\}",
                var x => Regex.Escape(x.ToString())
            };
        }

        public static string Join(this IEnumerable<string> values, string separator = "")
        {
            return string.Join(separator, values);
        }
    }
}