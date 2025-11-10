using System;
using System.Collections.Generic;

namespace Architect.Utilities.Extensions
{
    /// <summary>
    /// Extension methods for the object data type
    /// </summary>
    public static class ListExtensions
    {
        public static List<T> WithItems<T>(this List<T> list, List<T> items)
        {
            list.AddRange(items);
            return list;
        }
    }
}
