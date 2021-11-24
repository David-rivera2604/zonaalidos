using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Architect.API.Core.Business.General
{
    public static class Tenant
    {
        public static Core.Contracts.General.Tenant Information(int companyId)
        {
            List<Architect.API.Core.Contracts.General.Tenant> tenants = new List<Contracts.General.Tenant>();
            Architect.API.Core.Contracts.General.Tenant result = new Contracts.General.Tenant() { CompanyId = 0, Name = string.Empty };
            if (Architect.Utilities.Cache.NotExist("tenants"))
            {
                List<Architect.API.Core.Contracts.General.LookupValue> lookupList = Architect.API.Core.DataAccess.General.LookupCustom.RetrieveByLookupMasterKey(4, 1, 0);
                foreach (Architect.API.Core.Contracts.General.LookupValue item in lookupList)
                {
                    tenants.Add(new Architect.API.Core.Contracts.General.Tenant() { CompanyId = Convert.ToInt32(item.Code), Name = item.Description });
                }
                Architect.Utilities.Cache.SetItem("tenants", tenants);
            }
            else
                tenants = (List<Architect.API.Core.Contracts.General.Tenant>)Architect.Utilities.Cache.GetItem("tenants");

            foreach (Architect.API.Core.Contracts.General.Tenant item in tenants)
            {
                if (item.CompanyId == companyId)
                {
                    result = item;
                    break;
                }
            }
            return result;

        }

    }
}