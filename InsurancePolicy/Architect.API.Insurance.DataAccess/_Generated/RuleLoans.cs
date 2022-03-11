using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Insurance.DataAccess.Policy
{

    /// <summary>
    /// Prestamos existentes
    /// </summary>
    public sealed partial class RuleLoans
    {

        /// <summary>
        /// Crea un registro en la tabla RuleLoans.
        /// </summary>
        /// <param name="ruleloansItem">Instancia de RuleLoans</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Contracts.Policy.RuleLoans ruleloansItem, IDbConnection connection = null)
        {
            if (ruleloansItem.UpdateDate.IsEmpty())
            {
                ruleloansItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("INSERT INTO RuleLoans (LoanNumber, CompanyId, DocumentNumber, FullName, BirthDate, Gender, StartTerm, EndTerm, Duration, Amount, Balance) " +
                                                 "VALUES(:LoanNumber, :CompanyId, :DocumentNumber, :FullName, :BirthDate, :Gender, :StartTerm, :EndTerm, :Duration, :Amount, :Balance)")
                            .AddParameter("LoanNumber", DbType.Decimal, 9, ruleloansItem.LoanNumber)
                            .AddParameter("CompanyId", DbType.Decimal, 5, ruleloansItem.CompanyId)
                            .AddParameter("DocumentNumber", DbType.AnsiString, 20, ruleloansItem.DocumentNumber)
                            .AddParameter("FullName", DbType.AnsiString, 160, ruleloansItem.FullName)
                            .AddParameter("BirthDate", DbType.DateTime, 9, ruleloansItem.BirthDate)
                            .AddParameter("Gender", DbType.Decimal, 5, ruleloansItem.Gender)
                            .AddParameter("StartTerm", DbType.DateTime, 9, ruleloansItem.StartTerm)
                            .AddParameter("EndTerm", DbType.DateTime, 9, ruleloansItem.EndTerm)
                            .AddParameter("Duration", DbType.Decimal, 3, ruleloansItem.Duration)
                            .AddParameter("Amount", DbType.Decimal, 18, ruleloansItem.Amount)
                            .AddParameter("Balance", DbType.Decimal, 18, ruleloansItem.Balance)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla RuleLoans.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="ruleloansItems">Lista de instancia de RuleLoans</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Contracts.Policy.RuleLoans> ruleloansItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Contracts.Policy.RuleLoans item in ruleloansItems)
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
        /// Recupera un registro en la tabla RuleLoans por medio de su clave primaria.
        /// </summary>
        /// <param name="loannumber">Número del préstamo.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de RuleLoans</returns>
        public static Contracts.Policy.RuleLoans Retrieve(int loannumber, IDbConnection connection = null)
        {
            Contracts.Policy.RuleLoans result = null;
            Database.Select("SELECT LoanNumber, CompanyId, DocumentNumber, FullName, BirthDate, Gender, StartTerm, EndTerm, Duration, Amount, Balance " +
                              "FROM RuleLoans " +
                             "WHERE LoanNumber=:LoanNumber")
                        .AddParameter("LoanNumber", DbType.Decimal, 9, loannumber)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToRuleLoans(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla RuleLoans.
        /// </summary>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parametros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de RuleLoans</returns>
        public static List<Contracts.Policy.RuleLoans> RetrieveAll(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Contracts.Policy.RuleLoans> result = new List<Contracts.Policy.RuleLoans>();
            Database.Select("SELECT LoanNumber, CompanyId, DocumentNumber, FullName, BirthDate, Gender, StartTerm, EndTerm, Duration, Amount, Balance " +
                              "FROM RuleLoans" + filter)
                        .AddParameter(parameters)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToRuleLoans(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla RuleLoans.
        /// </summary>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parametros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de RuleLoans</returns>
        public static List<Contracts.Policy.RuleLoans> RetrieveAll(string filter, int beginIndex, int endIndex, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Contracts.Policy.RuleLoans> result = new List<Contracts.Policy.RuleLoans>();
            if (beginIndex == 0)
            {
                beginIndex = 1;
            }
            if (endIndex == 0 || endIndex < beginIndex)
            {
                endIndex = int.MaxValue;
            }
            Database.Select("SELECT * FROM (" +
                            "SELECT LoanNumber, CompanyId, DocumentNumber, FullName, BirthDate, Gender, StartTerm, EndTerm, Duration, Amount, Balance " +
                                   ", ROW_NUMBER() OVER (ORDER BY RuleLoans.LoanNumber DESC) RowNumber " +
                              "FROM RuleLoans" + filter +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter(parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToRuleLoans(reader));
                        }));
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
        /// Último valor asignado a clave unica de la tabla RuleLoans.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT NVL(MAX(LoanNumber),0) " +
                                     "FROM RuleLoans")
                                .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla RuleLoans por medio de su clave primaria.
        /// </summary>
        /// <param name="ruleloansItem">Instancia de RuleLoans</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Contracts.Policy.RuleLoans ruleloansItem, IDbConnection connection = null)
        {
            if (ruleloansItem.UpdateDate.IsEmpty())
            {
                ruleloansItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE RuleLoans " +
                                      "SET CompanyId=:CompanyId, DocumentNumber=:DocumentNumber, FullName=:FullName, BirthDate=:BirthDate, Gender=:Gender, StartTerm=:StartTerm, EndTerm=:EndTerm, Duration=:Duration, Amount=:Amount, Balance=:Balance " +
                                    "WHERE LoanNumber=:LoanNumber")
                                .AddParameter("CompanyId", DbType.Decimal, 5, ruleloansItem.CompanyId)
                                .AddParameter("DocumentNumber", DbType.AnsiString, 20, ruleloansItem.DocumentNumber)
                                .AddParameter("FullName", DbType.AnsiString, 160, ruleloansItem.FullName)
                                .AddParameter("BirthDate", DbType.DateTime, 9, ruleloansItem.BirthDate)
                                .AddParameter("Gender", DbType.Decimal, 5, ruleloansItem.Gender)
                                .AddParameter("StartTerm", DbType.DateTime, 9, ruleloansItem.StartTerm)
                                .AddParameter("EndTerm", DbType.DateTime, 9, ruleloansItem.EndTerm)
                                .AddParameter("Duration", DbType.Decimal, 3, ruleloansItem.Duration)
                                .AddParameter("Amount", DbType.Decimal, 18, ruleloansItem.Amount)
                                .AddParameter("Balance", DbType.Decimal, 18, ruleloansItem.Balance)
                                .AddParameter("LoanNumber", DbType.Decimal, 9, ruleloansItem.LoanNumber)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla RuleLoans por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="ruleloansItems">Lista de instancia de RuleLoans</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Contracts.Policy.RuleLoans> ruleloansItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Contracts.Policy.RuleLoans item in ruleloansItems)
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
        /// Elimina un registro en la tabla RuleLoans por medio de su clave primaria.
        /// </summary>
        /// <param name="loannumber">Número del préstamo.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int loannumber, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM RuleLoans " +
                                    "WHERE LoanNumber=:LoanNumber")
                                .AddParameter("LoanNumber", DbType.Decimal, 9, loannumber)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla RuleLoans por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="loannumberList">Lista de Número del préstamo.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Delete(List<int> loannumberList, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (int item in loannumberList)
            {
                result.Add(Delete(item, connection));
            }
            if (local)
            {
                connection.Close();
            }
            return result;
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla RuleLoans por medio de su clave primaria.
        /// </summary>
        /// <param name="loannumber">Número del préstamo.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(int loannumber, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT COUNT(LoanNumber) " +
                                          "FROM RuleLoans " +
                                         "WHERE LoanNumber=:LoanNumber")
                               .AddParameter("LoanNumber", DbType.Decimal, 9, loannumber)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla RuleLoans que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parametros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(LoanNumber) " +
                                          "FROM RuleLoans " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'RuleLoans'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Contracts.Policy.RuleLoans DataReaderToRuleLoans(System.Data.IDataReader reader, Contracts.Policy.RuleLoans item = null)
        {
            if (item == null)
            {
                item = new Contracts.Policy.RuleLoans();
            }
            item.LoanNumber = reader.IntegerValue("LoanNumber");
            item.CompanyId = reader.IntegerValue("CompanyId");
            item.DocumentNumber = reader.StringValue("DocumentNumber");
            item.FullName = reader.StringValue("FullName");
            item.BirthDate = reader.DateTimeValue("BirthDate");
            item.Gender = reader.IntegerValue("Gender");
            item.StartTerm = reader.DateTimeValue("StartTerm");
            item.EndTerm = reader.DateTimeValue("EndTerm");
            item.Duration = reader.IntegerValue("Duration");
            item.Amount = reader.DoubleValue("Amount");
            item.Balance = reader.DoubleValue("Balance");
            return item;
        }
    }
}