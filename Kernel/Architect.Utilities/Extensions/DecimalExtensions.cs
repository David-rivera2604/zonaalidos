using System;

namespace Architect.Utilities.Extensions
{
    /// <summary>
    /// Extension methods for the object data type
    /// </summary>
    public static class DecimalExtensions
    {
        public static bool IsEmpty(this decimal value)
        {
            return (value == 0);
        }

        public static bool IsNotEmpty(this decimal value)
        {
            return (value != 0);
        }
    }
}
