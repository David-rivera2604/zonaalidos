using System;
using System.Collections.Generic;
using Architect.Utilities.Extensions;

namespace Architect.API.Core.Business.General
{
    public static partial class LookupMaster
    {

        /// <summary>
        /// Recupera la información de la tabla LookUpMaster vinculada a la compañía por medio de sus clave.
        /// </summary>
        /// <remarks>
        /// Por medio del campo Tenant se sabe si la lista es particular por compañía propietaria o es global.
        /// </remarks>
        /// <param name="key">Clave que identifica la lista.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <returns>Instancia de LookupMaster.</returns>	
        public static Contracts.General.TenantLookup TenantInformation(string key, int companyId)
        {

            List<Contracts.General.TenantLookup> tenantLkpMaster = new List<Contracts.General.TenantLookup>();
            Contracts.General.TenantLookup result = null;
            if (Utilities.Cache.NotExist("tenantLkpMaster") || Utilities.Helpers.Settings.StringValue("Working.Mode") == "Development")
            {
                List<Contracts.General.LookupMaster> lookupList = DataAccess.General.LookupMaster.RetrieveAll(string.Empty);
                foreach (Contracts.General.LookupMaster item in lookupList)
                {
                    tenantLkpMaster.Add(new Contracts.General.TenantLookup()
                    {
                        Key = item.Key,
                        LookupId = item.LookupId,
                        Tenant = item.Tenant,
                        Type = item.Type,
                        StatementType = item.StatementType,
                        Statement = item.Statement,
                        Fields = item.Fields,
                        ConnectionName = item.ConnectionName,
                        IncludeByRole = item.IncludeByRole,
                        ExcludeByRole = item.ExcludeByRole,
                        IsCached = item.IsCached
                    });
                }
                Architect.Utilities.Cache.SetItem("tenantLkpMaster", tenantLkpMaster);
            }
            else
            {
                tenantLkpMaster = (List<Contracts.General.TenantLookup>)Architect.Utilities.Cache.GetItem("tenantLkpMaster");
            }
            foreach (Contracts.General.TenantLookup item in tenantLkpMaster)
            {
                if (item.Key.ToLower() == key.ToLower())
                {
                    result = item;
                    if (result.Tenant)
                    {
                        result.CompanyId = companyId;
                    }
                    else
                    {
                        result.CompanyId = 0;
                    }
                    break;
                }
            }
            return result;
        }

    }
}
