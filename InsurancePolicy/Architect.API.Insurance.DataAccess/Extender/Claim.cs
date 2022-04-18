using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Insurance.DataAccess.ManualClaims
{
    /// <summary>
    /// .
    /// </summary>
    public sealed partial class Claim
    {

        /// <summary>
        /// Recupera un registro en la tabla Claim por medio de la identificación del siniestro.
        /// </summary>
        /// <param name="claimId">Identificación del siniestro.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de Claim</returns>
        public static Architect.API.Insurance.Contracts.ManualClaims.Claim RetrieveByClaimId(string claimId, int companyId, IDbConnection connection = null)
        {
            return RetrieveAll(companyId,
                            " AND Claim.ClaimId=:ClaimId",
                            Database.ParameterList().AddParameter("ClaimId", DbType.AnsiString, 19, claimId).Parameters, connection).FirstOrDefault();
        }
    }

}

