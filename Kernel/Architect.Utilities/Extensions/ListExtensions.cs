using System;
using System.Collections.Generic;
using System.Linq;

namespace Architect.Utilities.Extensions
{
    /// <summary>
    /// Extension methods for the object data type
    /// </summary>
    public static class ListExtensions
    {
        public static TResult[] ToArrayOf<TSource, TResult>(
        this IEnumerable<TSource> source,
        Func<TSource, TResult> selector)
        {
            return source.Select(selector).ToArray();
        }

        public static List<T> WithItems<T>(this List<T> list, List<T> items)
        {
            list.AddRange(items);
            return list;
        }
    }
}
