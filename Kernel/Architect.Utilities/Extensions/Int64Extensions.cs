using System;

namespace Architect.Utilities.Extensions
{
    /// <summary>
    /// Extension methods for the object data type
    /// </summary>
    public static class Int64Extensions
    {
        public static bool IsEmpty(this Int64 value)
        {
            return (value == 0);
        }

        public static bool IsNotEmpty(this Int64 value)
        {
            return (value != 0);
        }
    }
}
