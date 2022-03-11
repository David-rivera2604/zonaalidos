using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;

namespace Architect.API.Insurance.Business.ManualClaims
{
    /// <summary>
    /// .
    /// </summary>
    public static partial class Claim
    {

        /// <summary>
        /// Recupera un registro en la tabla Claim por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="id">Identificación única del registro.</param>
        /// <param name="include">Indica que información incluir, opciones posibles Roles y DocumentRequests</param>
        /// <returns>Instancia de Claim</returns>
        public static Contracts.ManualClaims.Claim Retrieve(int companyId, int id, string include = "")
        {
            Contracts.ManualClaims.Claim result = DataAccess.ManualClaims.Claim.Retrieve(id, companyId);

            MapLookups(companyId, result);

            if (result.IsNotEmpty())
            {
                if (include == "*" || include.Contain("Role"))
                {
                    result.Roles = DataAccess.ManualClaims.ClaimRole.RetrieveByClaimId(companyId, id);
                }
                if (include == "*" || include.Contain("DocumentRequest"))
                {
                    result.DocumentRequests = DataAccess.ManualClaims.ClaimDocumentRequest.RetrieveByClaimId(companyId, id);
                }
            }
            return result;
        }

    }
}
