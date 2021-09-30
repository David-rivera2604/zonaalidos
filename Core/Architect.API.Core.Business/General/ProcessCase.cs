using System;
using System.Collections.Generic;
using Architect.Utilities.Extensions;

namespace Architect.API.Core.Business.General
{
    public static partial class ProcessCase
    {

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
