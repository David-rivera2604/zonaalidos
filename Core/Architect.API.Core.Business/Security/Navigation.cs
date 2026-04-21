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

        /// <summary>
        /// Recupera la lista de navegación permitida para un conjunto de roles.
        /// Cuando el idioma es diferente de 'ES', aplica las traducciones del contexto 'NAVIGATION'
        /// usando el campo <c>Code</c> como llave y reemplaza el valor de <c>Title</c>.
        /// </summary>
        /// <param name="roleNameList">Lista de nombres de roles separados por coma.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="language">Código ISO de 2 caracteres del idioma solicitado (ej: 'ES', 'EN').</param>
        /// <returns>Lista de instancias de <see cref="Contracts.Security.NavAllowed"/> con los títulos traducidos.</returns>
        public static List<Contracts.Security.NavAllowed> RetrieveNavigationAllowed(string roleNameList, int companyId, string language)
        {
            string roleNameListFormated = string.Format("'{0}'", roleNameList.Replace(",", "','"));

            List<Contracts.Security.NavAllowed> result = DataAccess.General.Navigation.RetrieveNavigationAllowed(roleNameListFormated, companyId);

            if (!string.Equals(language, "ES", StringComparison.OrdinalIgnoreCase) && result != null && result.Count > 0)
            {
                List<Contracts.General.Translation> translations = General.Translation.GetByContext("NAVIGATION", language);

                if (translations != null && translations.Count > 0)
                {
                    Dictionary<string, string> translationMap = translations
                        .ToDictionary(t => t.TranslationKey, t => t.TranslatedText, StringComparer.OrdinalIgnoreCase);

                    foreach (Contracts.Security.NavAllowed item in result)
                    {
                        if (item.Code.IsNotEmpty() && translationMap.TryGetValue(item.Code, out string translatedTitle))
                        {
                            item.Title = translatedTitle;
                        }
                    }
                }
            }

            return result;
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
