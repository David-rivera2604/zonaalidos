using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO.Compression;
using System.Text;

namespace Architect.Utilities.Extensions
{
    /// <summary>
    /// Extension methods for the DateTime data type
    /// </summary>
    public static class DateTimeExtensions
    {

        /// <summary>
        /// Determines whether the specified string is null or empty.
        /// </summary>
        /// <param name="value">The string value to check.</param>
        public static bool IsEmpty(this DateTime value)
        {
            return value == null || value == DateTime.MinValue;
        }

        /// <summary>
        /// Determines whether the specified string is not null or empty.
        /// </summary>
        /// <param name="value">The string value to check.</param>
        public static bool IsNotEmpty(this DateTime value)
        {
            return !value.IsEmpty();
        }

        public static int Age(this DateTime value)
        {
            int ageValue = 0;
            if (value.IsNotEmpty())
            {
                ageValue = DateTime.Today.Year - value.Year;
                if (DateTime.Today.Month < value.Month || (DateTime.Today.Month == value.Month && DateTime.Today.Day < value.Day))
                {
                    ageValue--;
                }
            }
            return ageValue;
        }

        public static DateTime FirstDayOfMonth(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, 1);
        }

        public static int WeekOfMonth(this DateTime value)
        {
            return (CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(value, CalendarWeekRule.FirstDay, DayOfWeek.Monday) -
                   CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(value.FirstDayOfMonth(), CalendarWeekRule.FirstDay, DayOfWeek.Monday)) + 1;
        }

        public static int NumericDayOfWeek(this DateTime value)
        {
            return (int)CultureInfo.CurrentCulture.Calendar.GetDayOfWeek(value);
        }

    }
}