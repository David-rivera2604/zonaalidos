using Architect.API.Core.Contracts.General;
using Architect.Utilities.Extensions;
using FastMember;
using System.Collections.Generic;
using System.Data;

namespace Architect.API.Core.Business
{
    /// <summary>
    /// Logíca relacionada con la lista de valores disponible de la aplicación.
    /// </summary>
    public static class Common
    {
        /// <summary>
        /// Recupera múltiples lista de valores disponibles a partir de múltiples claves.
        /// </summary>
        /// <param name="keys">Lista de claves de valores posibles separadas por coma.</param>
        /// <param name="url"></param>
        /// <param name="tokenInfo"></param>
        /// <returns>Múltiples listas de valores disponibles</returns>
        public static List<Contracts.General.LookupValues> Lkps(string keys, string url, Core.Contracts.Security.Token tokenInfo)
        {
            List<Contracts.General.LookupValues> values = new List<Contracts.General.LookupValues>();
            if (keys == null)
            {
                return values;
            }
            List<LookupValue> customValues = null;
            Dictionary<string, string> urlParameters = TokenToToDictionary(url.ToDictionary(':', '='), tokenInfo);
            string extend;
            string keyValue;
            foreach (string keyItem in keys.Split(','))
            {
   
                if (keyItem.IndexOf(":") > -1)
                {
                    extend = keyItem.Split(':')[1];
                    keyValue = keyItem.Split(':')[0];
                    urlParameters.Add("extend", extend);
                }
                else
                {
                    keyValue = keyItem;
                    extend = string.Empty;
                }
                customValues = new List<LookupValue>();
                TenantLookup tenantLkpMaster = General.LookupMaster.TenantInformation(keyValue, tokenInfo.CompanyId);

                if (tenantLkpMaster == null)
                {
                    string message = string.Format("LookUpMaster '{0}' not found", keyValue);
                    Architect.Utilities.Log.ErrorLog("Lkps", message);
                    System.Exception exception = new System.Exception(message);
                    throw exception;
                }
                switch (tenantLkpMaster.Type)
                {
                    case 2: //Custom Select 
                        DataTable table = Architect.DataFactory.Utils.StatementExecute(tenantLkpMaster.Statement, 1, tenantLkpMaster.ConnectionName, urlParameters, tenantLkpMaster.IsCached, keyValue);
                        foreach (DataRow row in table.Rows)
                        {
                            LookupValue itemLook = new LookupValue { Code = row[0].ToString().Trim(), Description = row[1].ToString() };
                            if (table.Columns.Count != 2)
                            {
                                dynamic dItemLook = itemLook;
                                var wrapped = ObjectAccessor.Create(dItemLook);
                                for (int i = 2; i < table.Columns.Count; i++)
                                {
                                    var columnName = table.Columns[i].ColumnName;
                                    wrapped[columnName] = row[i].ToString();
                                }
                            }
                            customValues.Add(itemLook);
                        }
                        break;

                    case 3: // Custom List
                        foreach (string value in tenantLkpMaster.Statement.Split(';'))
                        {
                            customValues.Add(new LookupValue() { Code = value.Split('=')[0], Description = value.Split('=')[1] });
                        }
                        break;

                    default:
                        customValues = DataAccess.General.LookupCustom.RetrieveByLookupMasterKey(tenantLkpMaster.LookupId, 1, tenantLkpMaster.CompanyId);
                        break;
                }
                if (tenantLkpMaster.IncludeByRole.IsNotEmpty() && tenantLkpMaster.IncludeByRole.IndexOf('!') > -1)
                {
                    List<LookupValue> newList = new List<LookupValue>();
                    foreach (LookupValue value in customValues)
                    {
                        if (AllowNegative(tenantLkpMaster.IncludeByRole, value.Code, tokenInfo.Roles))
                        {
                            newList.Add(value);
                        }
                    }
                    customValues = newList;
                }

                if (tenantLkpMaster.IncludeByRole.IsNotEmpty())
                {
                    List<LookupValue> newList = new List<LookupValue>();
                    foreach (LookupValue value in customValues)
                    {
                        if (Allow(tenantLkpMaster.IncludeByRole, value.Code, tokenInfo.Roles))
                        {
                            newList.Add(value);
                        }
                    }
                    customValues = newList;
                }

                if (tenantLkpMaster.ExcludeByRole.IsNotEmpty())
                {
                    List<LookupValue> newList = new List<LookupValue>();
                    foreach (LookupValue value in customValues)
                    {
                        if (!Allow(tenantLkpMaster.ExcludeByRole, value.Code, tokenInfo.Roles))
                        {
                            newList.Add(value);
                        }
                    }
                    customValues = newList;
                }

                values.Add(new Contracts.General.LookupValues()
                {
                    Key = keyItem,
                    Lkp = customValues
                });

                if (extend.IsNotEmpty())
                {
                    urlParameters.Remove("extend");
                }

            }

            return values;
        }

        private static bool AllowNegative(string filter, string code, string roles)
        {
            bool result = false;
            bool positive = false;
            string values = string.Empty;
            string role = string.Empty;
            foreach (string item in filter.Split(';'))
            {
                if (item.IsNotEmpty())
                {
                    positive = (item.Substring(0, 1) != "!");
                    values = item.Substring(item.IndexOf('(') + 1);
                    values = values.Substring(0, values.Length - 1);

                    if (!positive)
                    {
                        role = item.Substring(0, item.IndexOf('('));
                        if (!positive &&
                         !string.Format(",{0},", roles).Contains(string.Format(",{0},", role)) &&
                         string.Format(",{0},", values).Contains(string.Format(",{0},", code)))
                        {
                            result = true;
                            break;
                        }
                    }

                }
            }
            return result;
        }
        private static bool Allow(string filter, string code, string roles)
        {
            bool result = true;
            bool positive = false;
            string values = string.Empty;
            string role = string.Empty;
            foreach (string item in filter.Split(';'))
            {
                if (item.IsNotEmpty())
                {
                    positive = (item.Substring(0, 1) != "!");
                    values = item.Substring(item.IndexOf('(') + 1);
                    values = values.Substring(0, values.Length - 1);

                    if (positive)
                    {
                        role = item.Substring(0, item.IndexOf('('));
                        if (string.Format(",{0},", roles).Contains(string.Format(",{0},", role)))
                        {
                            result = string.Format(",{0},", values).Contains(string.Format(",{0},", code));
                            break;
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Recupera una lista de valores disponibles a partir de mutiples claves.
        /// </summary>
        /// <param name="key">Clave de valores posibles.</param>
        /// <param name="companyId">Identificación de lacompañia propietaria.</param>
        /// <returns>Lista de valores disponibles</returns>
        public static List<Contracts.General.LookupValue> Lkp(string key, int companyId)
        {
            Architect.API.Core.Contracts.General.TenantLookup tenantLkpMaster = Architect.API.Core.Business.General.LookupMaster.TenantInformation(key, companyId);
            return LkpChild(key, 0, string.Empty, new Contracts.Security.Token() { CompanyId = tenantLkpMaster.CompanyId });
        }

        public static bool LkpExist(int companyId, string key, string code)
        {
            Architect.API.Core.Contracts.General.TenantLookup tenantLkpMaster = Architect.API.Core.Business.General.LookupMaster.TenantInformation(key, companyId);
            List<Contracts.General.LookupValue> values = LkpChild(key, 0, string.Empty, new Contracts.Security.Token() { CompanyId = tenantLkpMaster.CompanyId });
            return values.Exists(x => x.Code == code);
        }


        public static string LkpDescription(int companyId, string key, int parentId, string code)
        {
            string result = string.Empty;
            List<Contracts.General.LookupValue> lookups = LkpChild(key, parentId, string.Empty, new Contracts.Security.Token() { CompanyId = companyId });

            if (lookups?.Count > 0 && lookups.Exists(x => x.Code == code))
            {

                result = lookups.Find(x => x.Code == code).Description;
            }
            return result;
        }

        public static string LkpDescription(int companyId, string key, string code, string url = "")
        {
            string result = string.Empty;
            List<Contracts.General.LookupValues> lookups = Lkps(key, url, new Contracts.Security.Token() { CompanyId = companyId });

            if (lookups?.Count > 0 && lookups[0].Lkp.Exists(x => x.Code == code))
            {

                result = lookups[0].Lkp.Find(x => x.Code == code).Description;
            }
            return result;
        }

        /// <summary>
        /// Lista de valores disponibles según la clave de valores posibles.
        /// </summary>
        /// <param name="key">Clave de la lista de valores posibles.</param>
        /// <param name="parentId">Clave que identifica el agrupado de la lista dependiente.</param>
        /// <param name="url"></param>
        /// <param name="tokenInfo">Información del token de acceso.</param>
        /// <returns>Lista de valores disponibles</returns>
        public static List<Contracts.General.LookupValue> LkpChild(string key, int parentId, string url, Core.Contracts.Security.Token tokenInfo)
        {
            Dictionary<string, string> urlParameters = TokenToToDictionary(url.ToDictionary(':', '='), tokenInfo);

            string keyValue = key;
            if (key.IndexOf(":") > -1)
            {
                keyValue = key.Split(':')[0];
                urlParameters.Add("extend", key.Split(':')[1]);
            }

            TenantLookup tenantLkpMaster = General.LookupMaster.TenantInformation(keyValue, tokenInfo.CompanyId);
            List<LookupValue> values = new List<LookupValue>();

            switch (tenantLkpMaster.Type)
            {
                case 2: //Custom Select 
                    DataTable xxx = Architect.DataFactory.Utils.StatementExecute(tenantLkpMaster.Statement, 1, tenantLkpMaster.ConnectionName, urlParameters, tenantLkpMaster.IsCached, keyValue);
                    List<LookupValue> customValues = new List<LookupValue>();
                    foreach (DataRow row in xxx.Rows)
                    {
                        customValues.Add(new LookupValue() { Code = row[0].ToString().Trim(), Description = row[1].ToString() });
                    }

                    values = customValues;
                    break;

                case 3: // Custom List
                    List<LookupValue> customListValues = new List<LookupValue>();
                    foreach (string value in tenantLkpMaster.Statement.Split(';'))
                    {
                        customListValues.Add(new LookupValue() { Code = value.Split('=')[0], Description = value.Split('=')[1] });
                    }
                    values = customListValues;
                    break;

                default:

                    values = DataAccess.General.LookupCustom.RetrieveByLookupMasterKey(tenantLkpMaster.LookupId, 1, parentId, tenantLkpMaster.CompanyId);
                    break;
            }

            return values;
        }

        /// <summary>
        /// Lista de valores disponibles según dos niveles de claves de valores posibles.
        /// </summary>
        /// <param name="key">Clave de la lista de valores posibles.</param>
        /// <param name="parentId">Clave que identifica el agrupado de la lista dependiente.</param>
        /// <param name="extendId">Segunda clave que identifica el agrupado de la lista dependiente.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <returns>Lista de valores disponibles</returns>
        public static List<Contracts.General.LookupValue> LkpChild(string key, int parentId, int extendId, int companyId)
        {
            Architect.API.Core.Contracts.General.TenantLookup tenantLkpMaster = Architect.API.Core.Business.General.LookupMaster.TenantInformation(key, companyId);
            return DataAccess.General.LookupCustom.RetrieveByLookupMasterKey(tenantLkpMaster.LookupId, 1, parentId, extendId, tenantLkpMaster.CompanyId);
        }

        /// <summary>
        /// Lista de valores disponibles según la clave de valores posibles.
        /// </summary>
        /// <param name="key">Clave de la lista de valores posibles.</param>
        /// <param name="parentId">Clave que identifica el agrupado de la lista dependiente.</param>
        /// <param name="companyId">Identificación de lacompañia propietaria.</param>
        /// <returns>Lista de valores disponibles</returns>
        public static List<Architect.API.Core.Contracts.General.Lookup> LkpChildFull(string key, int parentId, int companyId)
        {
            Architect.API.Core.Contracts.General.TenantLookup tenantLkpMaster = Architect.API.Core.Business.General.LookupMaster.TenantInformation(key, companyId);
            return DataAccess.General.LookupCustom.RetrieveLpkByCodeFull(tenantLkpMaster.LookupId, 1, parentId, tenantLkpMaster.CompanyId);
        }

        /// <summary>
        /// Lista de valores disponibles según la clave de valores posibles.
        /// </summary>
        /// <param name="key">Clave de la lista de valores posibles.</param>
        /// <param name="extendStringValue1"></param>
        /// <param name="companyId">Identificación de lacompañia propietaria.</param>
        /// <returns>Lista de valores disponibles</returns>
        public static List<Architect.API.Core.Contracts.General.Lookup> LkpChildFullByExtendStringValue1(string key, string extendStringValue1, int companyId)
        {
            Architect.API.Core.Contracts.General.TenantLookup tenantLkpMaster = Architect.API.Core.Business.General.LookupMaster.TenantInformation(key, companyId);
            return DataAccess.General.LookupCustom.RetrieveLpkExtendStringValue1(tenantLkpMaster.LookupId, 1, extendStringValue1, tenantLkpMaster.CompanyId);
        }

        public static Contracts.General.LookupValue LpkByDescription(string key, string description, int companyId)
        {
            Architect.API.Core.Contracts.General.TenantLookup tenantLkpMaster = Architect.API.Core.Business.General.LookupMaster.TenantInformation(key, companyId);
            return DataAccess.General.LookupCustom.RetrieveLpkByDescription(tenantLkpMaster.LookupId, 1, description, tenantLkpMaster.CompanyId);
        }

        public static Contracts.General.LookupValue LpkByHomologousCode(string key, string homologousCode, int companyId)
        {
            Architect.API.Core.Contracts.General.TenantLookup tenantLkpMaster = Architect.API.Core.Business.General.LookupMaster.TenantInformation(key, companyId);
            return DataAccess.General.LookupCustom.RetrieveLpkByHomologousCode(tenantLkpMaster.LookupId, 1, homologousCode, tenantLkpMaster.CompanyId);
        }


        public static List<Utilities.Contracts.LookUpValue> Cache(string prefix)
        {
            if (prefix.Equals("all", System.StringComparison.CurrentCultureIgnoreCase))
            {
                Utilities.Cache.Clean();
            }
            else if (prefix != "")
            {
                Utilities.Cache.RemoveStartWith(prefix);
            }

            return Utilities.Cache.CacheCatalog();
        }

        public static Dictionary<string, string> TokenToToDictionary(Dictionary<string, string> values, Core.Contracts.Security.Token tokenInfo)
        {
            values.Add("Token.CompanyId", tokenInfo.CompanyId.ToString());
            values.Add("Token.UserId", tokenInfo.UserId.ToString());
            values.Add("Token.AgentCode", tokenInfo.AgentCode.ToString());
            values.Add("Token.SubAgentCode", tokenInfo.SubAgentCode.ToString());
            values.Add("Token.IdentificationType", tokenInfo.IdentificationType);
            values.Add("Token.Identification", tokenInfo.Identification);
            return values;
        }

    }
}
