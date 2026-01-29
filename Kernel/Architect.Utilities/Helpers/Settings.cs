using Architect.Utilities.Extensions;
using System;
using System.Configuration;

namespace Architect.Utilities.Helpers
{
    public static class Settings
    {
        public static T GetValue<T>(this string settingName, T defaultValue = default(T))
        {
            string current = ConfigurationManager.AppSettings[settingName];

            if (current.IsEmpty())
            {
                return defaultValue;
            }

            try
            {
                Type targetType = typeof(T);

                // Handle nullable types
                Type underlyingType = Nullable.GetUnderlyingType(targetType) ?? targetType;

                // Handle boolean type with special cases
                if (underlyingType == typeof(bool))
                {
                    return (T)(object)ParseBoolValue(current);
                }

                // Handle other types using Convert.ChangeType
                return (T)Convert.ChangeType(current, underlyingType);
            }
            catch
            {
                return defaultValue;
            }
        }

        public static int IntegerValue(this string settingName, int defaultValue = 0)
        {
            return settingName.GetValue(defaultValue);
        }

        public static string StringValue(this string settingName, string defaultValue = "")
        {
            return settingName.GetValue(defaultValue);
        }

        public static bool BoolValue(this string settingName, bool defaultValue = false)
        {
            return settingName.GetValue(defaultValue);
        }

        private static bool ParseBoolValue(string value)
        {
            if (value.IsEmpty())
            {
                return false;
            }

            string lowerValue = value.ToLower();
            return lowerValue == "true" ||
                   lowerValue == "verdadero" ||
                   lowerValue == "yes" ||
                   lowerValue == "si" ||
                   lowerValue == "1";
        }
    }
}
