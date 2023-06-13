using System;
using System.Collections.Generic;
using Architect.Utilities.Extensions;

namespace Architect.API.Core.Business.General
{
    public static partial class ProcessCase
    {
        /// <summary>
        /// Elimina un registro en la tabla ProcessCase por medio de su clave primaria.
        /// </summary>
        public static Architect.API.Core.Contracts.General.ProcessCaseResult DeleteFull(int companyId, int userId, int id)
        {
            Architect.API.Core.Contracts.General.ProcessCase result = null;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.General.ProcessCase.Validate(companyId, new Architect.API.Core.Contracts.General.ProcessCase() { Id = id }, false, true);

            if (errors.Count == 0)
            {
                result = Architect.API.Core.DataAccess.General.ProcessCase.Retrieve(id, companyId);
                if (result.IsNotEmpty())
                {
                    Architect.API.Core.DataAccess.General.ProcessInstance.DeleteByCaseId(id, companyId);
                    if (Architect.API.Core.DataAccess.General.ProcessCase.Delete(id, companyId) > 0)
                    {
                        Core.Business.General.ChangeSet.Create(1304, id, companyId, "Eliminar", string.Format("Se eliminó el processcase '{0}'", result.Title), userId, result);
                    }
                }
            }
            return new Architect.API.Core.Contracts.General.ProcessCaseResult() { ProcessCase = result, Errors = errors };
        }

        /// <summary>
        /// Elimina un registro en la tabla ProcessCase por medio de su clave primaria.
        /// </summary>
        public static Architect.API.Core.Contracts.General.ProcessCaseResult DeleteFull(int companyId, int userId, int id)
        {
            Architect.API.Core.Contracts.General.ProcessCase result = null;
            List<Contracts.General.Error> errors = Architect.API.Core.Business.General.ProcessCase.Validate(companyId, new Architect.API.Core.Contracts.General.ProcessCase() { Id = id }, false, true);

            if (errors.Count == 0)
            {
                result = Architect.API.Core.DataAccess.General.ProcessCase.Retrieve(id, companyId);
                if (result.IsNotEmpty() )
                {
                    Architect.API.Core.DataAccess.General.ProcessInstance.DeleteByCaseId(id, companyId);
                    if (Architect.API.Core.DataAccess.General.ProcessCase.Delete(id, companyId) > 0)
                    {
                        Core.Business.General.ChangeSet.Create(1304, id, companyId, "Eliminar", string.Format("Se eliminó el processcase '{0}'", result.Title), userId, result);
                    }
                }
            }
            return new Architect.API.Core.Contracts.General.ProcessCaseResult() { ProcessCase = result, Errors = errors };
        }

        public static Architect.API.Core.Contracts.General.ProcessCase CreateRaw(int companyId, int userId, Architect.API.Core.Contracts.General.ProcessCase item)
        {
            Architect.API.Core.Contracts.General.ProcessCase result = item;

            if (result.Id.IsEmpty())
                result.Id = Architect.API.Core.DataAccess.General.ProcessCase.RetrieveLastKey() + 1;

            result.CompanyId = companyId;
            result.UpdateUserCode = userId;
            result.UpdateDate = DateTime.Now;

            Architect.API.Core.DataAccess.General.ProcessCase.Create(result);

            return result;
        }

    }
}
