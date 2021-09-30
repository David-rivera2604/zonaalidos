using System;

namespace Architect.Utilities.Extensions
{
    /// <summary>
    /// Extension methods for the object data type
    /// </summary>
    public static class IntExtensions
    {
        public static bool IsEmpty(this int value)
        {
            return (value == null || value == 0);
        }

        public static bool IsNotEmpty(this int value)
        {
            return (value != null && value != 0);
        }

        public static int IfEmpty(this int value, int defaultValue)
        {
            if(value.IsEmpty())
            {
                return defaultValue;
            }
            else
            {
                return value;
            }
        }
    }
}
