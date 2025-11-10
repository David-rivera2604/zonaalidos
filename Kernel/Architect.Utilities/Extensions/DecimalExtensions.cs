using System;
using System.Globalization;

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

        //MontoEntero
        public static string ToWholeAmount(this decimal value)
        {
            return value.ToString("0", new CultureInfo("en-US", false));
        }

        //MontoDecimal
        public static string ToDecimalAmount(this decimal value)
        {
            return value.ToString("0.00", new CultureInfo("en-US", false));
        }

        //ToDecimalAmount
        public static string ToDecimalAmount(this decimal value, string format)
        {
            return value.ToString(format, new CultureInfo("en-US", false));
        } 
    }
}
