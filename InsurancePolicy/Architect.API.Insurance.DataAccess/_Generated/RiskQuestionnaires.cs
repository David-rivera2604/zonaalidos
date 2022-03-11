using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Insurance.DataAccess.Policy
{
    /// <summary>
    /// Cuestionarios vinculados a una póliza.
    /// </summary>
    public sealed partial class RiskQuestionnaires
    {
        /// <summary>
        /// Crea un registro en la tabla RiskQuestionnaires.
        /// </summary>
        /// <param name="riskquestionnairesItem">Instancia de RiskQuestionnaires</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Insurance.Contracts.Policy.RiskQuestionnaires riskquestionnairesItem, IDbConnection connection = null)
        {
            if (riskquestionnairesItem.UpdateDate.IsEmpty())
            {
                riskquestionnairesItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("INSERT INTO RiskQuestionnaires (Id, CompanyId, PolicyId, Type, QuestionId, Confirmation, Diagnosis, Treatment, Doctor, When, UpdateUserCode, UpdateDate) " +
                                                 "VALUES(:Id, :CompanyId, :PolicyId, :Type, :QuestionId, :Confirmation, :Diagnosis, :Treatment, :Doctor, :When, :UpdateUserCode, :UpdateDate)")
                            .AddParameter("Id", DbType.Decimal, 9, riskquestionnairesItem.Id)
                            .AddParameter("CompanyId", DbType.Decimal, 5, riskquestionnairesItem.CompanyId)
                            .AddParameter("PolicyId", DbType.Decimal, 9, riskquestionnairesItem.PolicyId)
                            .AddParameter("Type", DbType.Decimal, 9, riskquestionnairesItem.Type)
                            .AddParameter("QuestionId", DbType.Decimal, 9, riskquestionnairesItem.QuestionId)
                            .AddParameter("Confirmation", DbType.Decimal, 1, riskquestionnairesItem.Confirmation)
                            .AddParameter("Diagnosis", DbType.AnsiString, 200, riskquestionnairesItem.Diagnosis)
                            .AddParameter("Treatment", DbType.AnsiString, 200, riskquestionnairesItem.Treatment)
                            .AddParameter("Doctor", DbType.AnsiString, 120, riskquestionnairesItem.Doctor)
                            .AddParameter("When", DbType.DateTime, 9, riskquestionnairesItem.When)
                            .AddParameter("UpdateUserCode", DbType.Decimal, 9, riskquestionnairesItem.UpdateUserCode)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, riskquestionnairesItem.UpdateDate)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla RiskQuestionnaires.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="riskquestionnairesItems">Lista de instancia de RiskQuestionnaires</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Insurance.Contracts.Policy.RiskQuestionnaires> riskquestionnairesItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Insurance.Contracts.Policy.RiskQuestionnaires item in riskquestionnairesItems)
            {
                result.Add(Create(item, connection));
            }
            if (local)
            {
                connection.Close();
            }
            return result;
        }

        /// <summary>
        /// Genera complemento del query para habilitar el filtro por columnas establecidas.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros.</param>
        /// <param name="where">Indica que el complement debe incluir el WHERE del comando.</param>
        /// <returns>Complemento del query</returns>
        public static string FilterBuilder(string filter, bool includeWhere = true)
        {
            string result = string.Empty;

            return result;
        }

        /// <summary>
        /// Último valor asignado a clave unica de la tabla RiskQuestionnaires.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT NVL(MAX(Id),0) " +
                                     "FROM RiskQuestionnaires")
                                .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla RiskQuestionnaires por medio de su clave primaria.
        /// </summary>
        /// <param name="riskquestionnairesItem">Instancia de RiskQuestionnaires</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Insurance.Contracts.Policy.RiskQuestionnaires riskquestionnairesItem, IDbConnection connection = null)
        {
            if (riskquestionnairesItem.UpdateDate.IsEmpty())
            {
                riskquestionnairesItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE RiskQuestionnaires " +
                                      "SET CompanyId=:CompanyId, PolicyId=:PolicyId, Type=:Type, QuestionId=:QuestionId, Confirmation=:Confirmation, Diagnosis=:Diagnosis, Treatment=:Treatment, Doctor=:Doctor, When=:When, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE Id=:Id")
                                .AddParameter("CompanyId", DbType.Decimal, 5, riskquestionnairesItem.CompanyId)
                                .AddParameter("PolicyId", DbType.Decimal, 9, riskquestionnairesItem.PolicyId)
                                .AddParameter("Type", DbType.Decimal, 9, riskquestionnairesItem.Type)
                                .AddParameter("QuestionId", DbType.Decimal, 9, riskquestionnairesItem.QuestionId)
                                .AddParameter("Confirmation", DbType.Decimal, 1, riskquestionnairesItem.Confirmation)
                                .AddParameter("Diagnosis", DbType.AnsiString, 200, riskquestionnairesItem.Diagnosis)
                                .AddParameter("Treatment", DbType.AnsiString, 200, riskquestionnairesItem.Treatment)
                                .AddParameter("Doctor", DbType.AnsiString, 120, riskquestionnairesItem.Doctor)
                                .AddParameter("When", DbType.DateTime, 9, riskquestionnairesItem.When)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, riskquestionnairesItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, riskquestionnairesItem.UpdateDate)
                                .AddParameter("Id", DbType.Decimal, 9, riskquestionnairesItem.Id)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla RiskQuestionnaires por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="riskquestionnairesItems">Lista de instancia de RiskQuestionnaires</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Insurance.Contracts.Policy.RiskQuestionnaires> riskquestionnairesItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Insurance.Contracts.Policy.RiskQuestionnaires item in riskquestionnairesItems)
            {
                result.Add(Update(item, connection));
            }
            if (local)
            {
                connection.Close();
            }
            return result;
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla RiskQuestionnaires que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parametros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM RiskQuestionnaires " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'RiskQuestionnaires'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Insurance.Contracts.Policy.RiskQuestionnaires DataReaderToRiskQuestionnaires(System.Data.IDataReader reader, Architect.API.Insurance.Contracts.Policy.RiskQuestionnaires item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Insurance.Contracts.Policy.RiskQuestionnaires();
            }
            item.Id = reader.IntegerValue("Id");
            item.CompanyId = reader.IntegerValue("CompanyId");
            item.PolicyId = reader.IntegerValue("PolicyId");
            item.Type = reader.IntegerValue("Type");
            item.QuestionId = reader.IntegerValue("QuestionId");
            item.Confirmation = reader.IntegerValue("Confirmation");
            item.Diagnosis = reader.StringValue("Diagnosis");
            item.Treatment = reader.StringValue("Treatment");
            item.Doctor = reader.StringValue("Doctor");
            item.When = reader.DateTimeValue("When");
            item.UpdateUserCode = reader.IntegerValue("UpdateUserCode");
            item.UpdateUserName = reader.StringValue("UpdateUserName");
            item.UpdateDate = reader.DateTimeValue("UpdateDate");
            return item;
        }
    }
}