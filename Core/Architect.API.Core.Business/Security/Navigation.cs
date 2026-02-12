using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Architect.API.Core.Business.Security
{
    public static class Navigation
    {
        public static int IsLive(string authenticationToken)
        {
            int result = 0;
            Contracts.Security.Activity session = (from s in Architect.API.Core.Security.Session.Sessions(string.Empty) where s.Token.Equals(authenticationToken) select s).FirstOrDefault();
            if (session.IsNotEmpty())
            {
                DateTime expDateTime = session.LastDateTime.AddMinutes("Session.Timeout".IntegerValue(30));
                result = Convert.ToInt32(expDateTime.Subtract(DateTime.Now).TotalSeconds);
            }
            return result;
        }

        public static List<Contracts.Security.NavAllowed> RetrieveNavigationAllowed(string roleNameList, int companyId)
        {
            string roleNameListFormated = string.Format("'{0}'", roleNameList.Replace(",", "','"));

            return DataAccess.General.Navigation.RetrieveNavigationAllowed(roleNameListFormated, companyId);
        }

        /// <summary>
        /// Permite recuperar un registra de navegación por medio ruta física de la página.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="urlPath">Ruta física de la página a ser ejecutada.</param>
        /// <returns>Instancia de Navigation</returns>
        public static List<Architect.Utilities.Contracts.LookUpValue> RetrieveByURLPath(int companyId, string urlPath)
        {
            List<Architect.Utilities.Contracts.LookUpValue> result = new List<Architect.Utilities.Contracts.LookUpValue>();
            Contracts.General.Navigation nav =DataAccess.General.Navigation.RetrieveByURLPath(urlPath, companyId);

            if (nav.IsNotEmpty() && nav.Code.IsNotEmpty())
            {
                result = DataAccess.Security.RoleMemberNavigation.RetrieveLookUpByCode(companyId, nav.Code);

            }
            return result;
        }

    }
}
