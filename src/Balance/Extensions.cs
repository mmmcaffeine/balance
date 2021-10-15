using System.Collections.Generic;
using System.Linq;

namespace Dgt.Balance
{
    public static class Extensions
    {
        public static bool Empty<T>(this IEnumerable<T> value) => !value.Any();

        public static bool ContainsAny(this string value, IEnumerable<char> chars) => value.Intersect(chars).Any();
    }
}