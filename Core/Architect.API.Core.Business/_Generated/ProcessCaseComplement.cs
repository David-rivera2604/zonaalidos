using System;
using System.Collections.Generic;
using Architect.Utilities.Extensions;

namespace Architect.API.Core.Business.General
{
    public static partial class ProcessCaseComplement
    {



        public static Architect.API.Core.Contracts.General.ProcessCaseComplement RetrieveById(int id, int companyId)
        {
            Architect.API.Core.Contracts.General.ProcessCaseComplement result = Architect.API.Core.DataAccess.General.ProcessCaseComplement.Retrieve(id, companyId);

            MapLookups(companyId, result);

            return result;
        }

        private static void MapLookups(int companyId, Architect.API.Core.Contracts.General.ProcessCaseComplement item)
        {
            if (item.IsNotEmpty())
            {
                if (item.Workshop.IsNotEmpty())
                    item.WorkshopDesc = Core.Business.Common.Lkp("Talleres", companyId).Find(x => x.Code == item.Workshop.ToString()).Description;

            }
        }

        public static Architect.API.Core.Contracts.General.ProcessCaseComplement CreateOrUpdate(int companyId, int userId, int id, Architect.API.Core.Contracts.General.ProcessCaseComplement item)
        {
            Architect.API.Core.Contracts.General.ProcessCaseComplement result = item;

            result.CaseId = id;
            result.CompanyId = companyId;
            result.UpdateUserCode = userId;
            result.UpdateDate = DateTime.Now;

            if (Architect.API.Core.DataAccess.General.ProcessCaseComplement.Count(id, companyId) == 0)
            {
                if (Architect.API.Core.DataAccess.General.ProcessCaseComplement.Create(result) > 0)
                {
                    MapLookups(companyId, result);
                    //Core.Business.General.ChangeSet.Create(0000, result.CaseId, companyId, "Creación", string.Format("Se creó un registro con la identificación '{0}'", result.CaseId), userId, result);
                }
            }
            else
            {
                if (Architect.API.Core.DataAccess.General.ProcessCaseComplement.Update(result) > 0)
                {
                    MapLookups(companyId, result);
                    //Core.Business.General.ChangeSet.Create(0000, item.CaseId, companyId, "Modificación", string.Format("Se modificó el registro con la identificación '{0}'", result.CaseId), userId, result);
                }
            }
            return result;
        }

    }
}
