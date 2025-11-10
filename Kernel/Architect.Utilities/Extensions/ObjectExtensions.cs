using System;

namespace Architect.Utilities.Extensions
{
    /// <summary>
    /// Extension methods for the object data type
    /// </summary>
    public static class ObjectExtensions
    {
        public static T With<T>(this T item, Action<T> work)
        {
            work(item);
            return item;
        }

        public static bool IsEmpty(this object value)
        {
            return (value == null);
        }

        public static bool IsNotEmpty(this object value)
        {
            return (value != null);
        }
    }
}
