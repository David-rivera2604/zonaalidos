using Architect.DataFactory;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Insurance.DataAccess.ManualPolicies
{
    /// <summary>
    /// Rol del tercero en la póliza.
    /// </summary>
    public sealed partial class PolicyRole
    {

        /// <summary>
        /// Recupera una lista de roles de una póliza.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="policyId">Identificación única de la póliza.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de PolicyRole</returns>
        public static List<Architect.API.Insurance.Contracts.ManualPolicies.PolicyRole> RetrieveByPolicyId(int companyId, int policyId, IDbConnection connection = null)
        {
            return RetrieveAll(companyId,
                " AND PolicyRole.PolicyInternalId=:PolicyInternalId",
                Database.ParameterList().AddParameter("PolicyInternalId", DbType.Decimal, 9, policyId).Parameters, connection);
        }

    }

}

