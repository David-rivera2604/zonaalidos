using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;

namespace Architect.API.Insurance.Business.ManualPolicies
{
    /// <summary>
    /// .
    /// </summary>
    public static partial class Certificate
    {

        /// <summary>
        /// Recupera un registro en la tabla Policy por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="include">Indica que información incluir, opciones posibles Roles y DocumentRequests</param>
        /// <returns>Instancia de Policy</returns>
        public static Contracts.ManualPolicies.Certificate Retrieve(int companyId, int id, string include = "")
        {
            Contracts.ManualPolicies.Certificate result = DataAccess.ManualPolicies.Certificate.Retrieve(id, companyId);
            if (result.IsNotEmpty())
            {
                MapLookups(companyId, result);
                if (include == "*" || include.Contain("Role"))
                {
                    result.Roles = DataAccess.ManualPolicies.CertificateRole.RetrieveByCertificateId(companyId, id);
                }
            }

            return result;
        }

    }
}
