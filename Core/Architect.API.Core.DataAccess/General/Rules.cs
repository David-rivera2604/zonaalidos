using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    /// <summary>
    /// Reglas a ser ejecutar despues de un evento asociado a un entidad de la aplicación.
    /// </summary>
    public sealed partial class Rules
    {

        /// <summary>
        /// Recupera una lista de registros en la tabla Rules.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="entityType">Tipo de entidad u objeto que genera el registro.</param>
        /// <param name="action">Acción que genera la traza.</param>
        /// <returns>Lista de instancias de Rules</returns>
        public static List<Architect.API.Core.Contracts.General.Rules> RetrieveByEntityAction(int companyId, int entityType, string action)
        {
            List<Architect.API.Core.Contracts.General.Rules> result = new List<Architect.API.Core.Contracts.General.Rules>();
            Database.Select("SELECT Id, Description, Statement " +
                              "FROM Rules " +
                             "WHERE CompanyId=:CompanyId AND EntityType=:EntityType AND Action=:action AND RecordStatus=1 ORDER BY Sequence")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter("EntityType", DbType.Decimal, 5, entityType)
                        .AddParameter("Action", DbType.AnsiString, 40, action)
                        .Query(null, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(new Architect.API.Core.Contracts.General.Rules()
                            {
                                Id = reader.IntegerValue("Id"),
                                Description = reader.StringValue("Description"),
                                Statement = reader.StringValue("Statement")
                            });
                        }));
            return result;
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla Rules por medio de su clave primaria.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="entityType">Tipo de entidad u objeto que genera el registro.</param>
        /// <param name="action">Acción que genera la traza.</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int CountByEntityAction(int companyId, int entityType, string action)
        {

            return (int)Database.Select("SELECT COUNT(Id) " +
                                           "FROM Rules " +
                                          "WHERE CompanyId=:CompanyId AND EntityType=:EntityType AND Action=:action AND RecordStatus=1")
                                 .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                 .AddParameter("EntityType", DbType.Decimal, 5, entityType)
                                 .AddParameter("Action", DbType.AnsiString, 40, action)
                                .QueryScalar<Decimal>(null, "Research");
        }

    }

}

