using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Insurance.DataAccess.Policy
{
    /// <summary>
    /// Información centralizada de terceros (personas y empresas).
    /// </summary>
    public sealed partial class ThirdParty
    {


        /// <summary>
        /// Recupera la información de un tercero por medio de su documento o número de identificación.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="documentType">Tipo de documento.</param>
        /// <param name="documentNumber">Documento o número de identificación.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de ThirdParty</returns>
        public static Contracts.Policy.ThirdParty RetrieveByDocument(int companyId, int documentType, string documentNumber, IDbConnection connection = null)
        {
            return RetrieveAll(companyId,
                    " AND ThirdParty.DocumentType=:DocumentType AND DocumentNumber=:DocumentNumber",
                        Database.ParameterList()
                            .AddParameter("DocumentType", DbType.Decimal, 9, documentType)
                            .AddParameter("DocumentNumber", DbType.Decimal, 9, documentNumber).Parameters, connection).FirstOrDefault();
        }

    }

}

