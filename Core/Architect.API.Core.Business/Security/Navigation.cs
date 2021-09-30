using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Architect.API.Core.Business.Security
{
    public static class Navigation
    {
        public static int IsLive(string authenticationToken)
        {
            int result = 0;
            Contracts.Security.Activity session = (from s in Session.Sessions(string.Empty) where s.Token.Equals(authenticationToken) select s).FirstOrDefault();
            if (session.IsNotEmpty())
            {
                DateTime expDateTime = session.LastDateTime.AddSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["Session.Timeout"]) * 60);
                ////En cao que la session halla expirado, es decir si el time del ultimos resuest mas la duracion de session es 
                result = Convert.ToInt32(expDateTime.Subtract(DateTime.Now).TotalSeconds);
            }
            return result;
        }

        public static List<Architect.API.Core.Contracts.Security.NavAllowed> RetrieveNavigationAllowed(string roleNameList, int companyId)
        {
            string roleNameListFormated = string.Format("'{0}'", roleNameList.Replace(",", "','"));

            return DataAccess.General.Navigation.RetrieveNavigationAllowed(roleNameListFormated, companyId);
        }
    }
}
