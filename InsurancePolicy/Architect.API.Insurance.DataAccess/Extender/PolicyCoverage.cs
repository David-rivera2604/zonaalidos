using Architect.DataFactory;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Insurance.DataAccess.ManualPolicies
{
    /// <summary>
    /// Coberturas.
    /// </summary>
    public sealed partial class PolicyCoverage
    {


        /// <summary>
        /// Recupera una lista de coberturas de una póliza.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="policyId">Identificación única de la póliza.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de PolicyCoverage</returns>
        public static List<Architect.API.Insurance.Contracts.ManualPolicies.PolicyCoverage> RetrieveByPolicyId(int companyId, int policyId, IDbConnection connection = null)
        {
            return RetrieveAll(companyId,
                " AND PolicyCoverage.PolicyInternalId=:PolicyInternalId",
                Database.ParameterList().AddParameter("PolicyInternalId", DbType.Decimal, 9, policyId).Parameters, connection);
        }

    }

}

