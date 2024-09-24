using System;
using System.Collections.Generic;
using Architect.Utilities.Helpers;
using System.Linq;

namespace Architect.API.Core.Business
{

    public static class Settings
    {
        public static string StringValue(string settingName, string defaultValue = "")
        {
            string result = FindSetting(settingName);
            if (result == string.Empty)
            {
                result = defaultValue;
            }
            return result;

        }

        public static int IntegerValue(string settingName, int defaultValue = 0)
        {
            string result = FindSetting(settingName);
            if (result == string.Empty)
            {
                result = defaultValue.ToString();
            }
            return Convert.ToInt32(result);
        }

        private static string FindSetting(string settingName)
        {
            List<Contracts.General.Setting> settings = null;

            string result = string.Empty;

            if (Utilities.Cache.NotExist("Setting_db") || Utilities.Helpers.Settings.StringValue("Working.Mode") == "Development")
            {
                settings = DataAccess.General.Setting.Retrieve(0);
                Architect.Utilities.Cache.SetItem("Setting_db", settings);
            }
            settings = (List<Contracts.General.Setting>)Architect.Utilities.Cache.GetItem("Setting_db");

            if (settings != null && settings.Count > 0)
            {
                Contracts.General.Setting setting = settings.Where(r => r.Key == settingName).FirstOrDefault();
                if (setting != null)
                {
                    result = setting.Value;
                }
            }

            return result;
        }

    }

}
