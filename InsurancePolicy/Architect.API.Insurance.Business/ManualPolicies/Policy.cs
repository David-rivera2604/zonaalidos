using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;

namespace Architect.API.Insurance.Business.ManualPolicies
{
    /// <summary>
    /// Póliza
    /// </summary>
    public static partial class Policy
    {

        /// <summary>
        /// Recupera un registro en la tabla Policy por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="include">Indica que información incluir, opciones posibles Roles y DocumentRequests</param>
        /// <returns>Instancia de Policy</returns>
        public static Contracts.ManualPolicies.Policy Retrieve(int companyId, int id, string include = "")
        {
            Contracts.ManualPolicies.Policy result = DataAccess.ManualPolicies.Policy.Retrieve(id, companyId);
            if (result.IsNotEmpty())
            {
                MapLookups(companyId, result);
                if (include == "*" || include.Contain("Role"))
                {
                    result.Roles = DataAccess.ManualPolicies.PolicyRole.RetrieveByPolicyId(companyId, id);
                }
                if (include == "*" || include.Contain("DocumentRequest"))
                {
                    result.Coverages = DataAccess.ManualPolicies.PolicyCoverage.RetrieveByPolicyId(companyId, id);
                }
            }

            return result;
        }

    }
}
