using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Insurance.DataAccess.ManualClaims
{
    /// <summary>
    /// Beneficiarios, Asociado.
    /// </summary>
    public sealed partial class ClaimRole
    {

        /// <summary>
        /// Recupera una lista de roles de un siniestro.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="claimId">Identificación única del siniestro.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de ClaimRole</returns>
        public static List<Architect.API.Insurance.Contracts.ManualClaims.ClaimRole> RetrieveByClaimId(int companyId, int claimId, IDbConnection connection = null)
        {
            return RetrieveAll(companyId,
                            " AND ClaimRole.ClaimInternalId=:ClaimInternalId",
                            Database.ParameterList().AddParameter("ClaimInternalId", DbType.Decimal, 9, claimId).Parameters, connection);
        }

    }

}

