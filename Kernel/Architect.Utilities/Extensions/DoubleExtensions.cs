using System;

namespace Architect.Utilities.Extensions
{
    /// <summary>
    /// Extension methods for the object data type
    /// </summary>
    public static class DoubleExtensions
    {
        public static bool IsEmpty(this double value)
        {
            return (value == null || value == 0);
        }

        public static bool IsNotEmpty(this double value)
        {
            return (value != null && value != 0);
        }
    }
}
