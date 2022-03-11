using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Architect.Utilities.Extensions;

namespace Architect.Utilities.Helpers
{
    public static class Settings
    {

        public static int IntegerValue(string settingName, int defaultValue = 0)
        {
            string current = ConfigurationManager.AppSettings[settingName];
            if (current.IsNotEmpty())
            {
                return Convert.ToInt32(current);
            }
            else
                return defaultValue;
        }

        public static string StringValue(string settingName, string defaultValue = "")
        {
            string current = ConfigurationManager.AppSettings[settingName];
            if (current.IsNotEmpty())
            {
                return current;
            }
            else
                return defaultValue;
        }
    }
}
