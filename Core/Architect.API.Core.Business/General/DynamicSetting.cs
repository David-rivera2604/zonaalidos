using Architect.API.Core.Contracts.Security;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Architect.API.Core.Business.General
{
    public static class DynamicSetting
    {
        public static int IntegerValue(Core.Contracts.Security.Token tokenInfo, string settingName, int defaultValue = 0)
        {
            int result = defaultValue;

            if (tokenInfo?.Settings != null && tokenInfo.Settings.Count > 0)
            {
                SettingItem item = tokenInfo.Settings.Find(r => r.Key.ToLower() == settingName.ToLower());
                if (item != null) {
                    result = Convert.ToInt32(item.Value);
                }
            }

            return result;
        }

    }
}