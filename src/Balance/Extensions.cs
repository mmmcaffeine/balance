using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Dgt.Dojo.Balance
{
    public static class Extensions
    {
        public static bool Empty<T>(this IEnumerable<T> value) => !value.Any();

        public static IEnumerable<TSource> Except<TSource>(this IEnumerable<TSource> values, TSource valueToExclude) =>
            values.Except(new[] { valueToExclude });

        public static bool None<TSource>(this IEnumerable<TSource> values, Func<TSource, bool> predicate) =>
            !values.Any(predicate);

        public static bool ExistsAtIndex(this string value, int index, string container) =>
            container.IndexOf(value, index, StringComparison.Ordinal) == index;

        public static bool ContainsAny(this string value, IEnumerable<string> strings) =>
            strings.Any(s => value.Contains(s, StringComparison.InvariantCulture));

        public static bool ContainsAny(this string value, IEnumerable<char> chars) => value.Intersect(chars).Any();
        
        public static IEnumerable<int> IndicesOf(this string value, string substring)
        {
            var indices = new List<int>();
            var index = 0;

            while ((index = value.IndexOf(substring, index, StringComparison.Ordinal)) != -1)
            {
                indices.Add(index++);
            }

            return indices;
        }

        public static string EscapeStart(this Delimiter delimiter) => Regex.Escape(delimiter.Start);

        // Helpfully, Regex.Escape does _not_ escape ']' or '}'
        // See https://docs.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.escape?view=net-5.0
        public static string EscapeEnd(this Delimiter delimiter)
        {
            return delimiter.End switch
            {
                "]" => @"\]",
                "}" => @"\}",
                var x => Regex.Escape(x)
            };
        }

        public static string JoinUsing(this IEnumerable<string> values, string separator = "")
        {
            return string.Join(separator, values);
        }
    }
}