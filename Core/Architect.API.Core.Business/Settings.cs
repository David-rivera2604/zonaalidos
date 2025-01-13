using System;
using System.Collections.Generic;
using Architect.Utilities.Helpers;
using System.Linq;

namespace Architect.API.Core.Business
{

    public static class Settings
    {

        public static string URLRelativeAndFullValue(int companyId, string baseSettingName, string servicePath, string fullSettingName)
        {
            string result = FindSetting(companyId, baseSettingName);
            if (result == string.Empty)
            {
                result = FindSetting(companyId, fullSettingName);
            } else
            {
                result += servicePath;
            }
            return result;

        }

        public static string StringValue(int companyId, string settingName, string defaultValue = "")
        {
            string result = FindSetting(companyId, settingName);
            if (result == string.Empty)
            {
                result = defaultValue;
            }
            return result;

        }

        public static int IntegerValue(int companyId, string settingName, int defaultValue = 0)
        {
            string result = FindSetting(companyId, settingName);
            if (result == string.Empty)
            {
                result = defaultValue.ToString();
            }
            return Convert.ToInt32(result);
        }

        private static string FindSetting(int companyId, string settingName)
        {
            List<Contracts.General.Setting> settings = null;

            string result = string.Empty;

            settings = SettingByCompany(companyId);

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

        public static List<Contracts.General.Setting> SettingByCompany(int companyId)
        {
            List<Contracts.General.Setting> settings = null;

            if (Utilities.Cache.NotExist("Setting_db") || Utilities.Helpers.Settings.StringValue("Working.Mode") == "Development")
            {
                settings = DataAccess.General.Setting.Retrieve();
                Architect.Utilities.Cache.SetItem("Setting_db", settings);
            }

            settings = (List<Contracts.General.Setting>)Architect.Utilities.Cache.GetItem("Setting_db");

            List<Contracts.General.Setting> result = null;

            if (settings != null && settings.Count > 0)
            {
                result = new List<Contracts.General.Setting>();
                foreach (Contracts.General.Setting item in settings.Where(r => r.CompanyId == 0 || r.CompanyId == companyId).OrderByDescending(o => o.CompanyId))
                {
                    if (result.Find(r => r.Key == item.Key) == null)
                    {
                        result.Add(item);
                    }
                }
            }

            if (result == null)
            {
                result = new List<Contracts.General.Setting>();
            }


            return result;
        }

    }

}
