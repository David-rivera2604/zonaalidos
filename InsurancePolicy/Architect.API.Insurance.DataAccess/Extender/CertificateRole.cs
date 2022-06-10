using Architect.DataFactory;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Insurance.DataAccess.ManualPolicies
{
    /// <summary>
    /// .
    /// </summary>
    public sealed partial class CertificateRole
    {

        /// <summary>
        /// Recupera una lista de roles de un certificado.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="certificatId">Identificación única del certificado.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de CertificateRole</returns>
        public static List<Architect.API.Insurance.Contracts.ManualPolicies.CertificateRole> RetrieveByCertificateId(int companyId, int certificatId, IDbConnection connection = null)
        {
            return RetrieveAll(companyId,
                " AND CertificateRole.CertificatInternalId=:CertificatInternalId",
                Database.ParameterList().AddParameter("CertificatInternalId", DbType.Decimal, 9, certificatId).Parameters, connection);
        }

    }

}

