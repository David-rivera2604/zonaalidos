using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Insurance.DataAccess.Policy
{

    /// <summary>
    /// Información de los prestamos vinculados a una póliza.
    /// </summary>
    public sealed partial class RiskOverdraft
    {

        /// <summary>
        /// Crea un registro en la tabla RiskOverdraft.
        /// </summary>
        /// <param name="riskoverdraftItem">Instancia de RiskOverdraft</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Insurance.Contracts.Policy.RiskOverdraft riskoverdraftItem, IDbConnection connection = null)
        {
            if (riskoverdraftItem.UpdateDate.IsEmpty())
            {
                riskoverdraftItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("INSERT INTO RiskOverdraft (Id, CompanyId, StartTerm, EndTerm, Amount1, EndTermOnAmount1, Recast1, Amount2, EndTermOnAmount2, Recast2, Amount3, EndTermOnAmount3, Recast3, Amount4, EndTermOnAmount4, Recast4, Amount5, EndTermOnAmount5, Recast5, UpdateUserCode, UpdateDate) " +
                                                 "VALUES(:Id, :CompanyId, :StartTerm, :EndTerm, :Amount1, :EndTermOnAmount1, :Recast1, :Amount2, :EndTermOnAmount2, :Recast2, :Amount3, :EndTermOnAmount3, :Recast3, :Amount4, :EndTermOnAmount4, :Recast4, :Amount5, :EndTermOnAmount5, :Recast5, :UpdateUserCode, :UpdateDate)")
                            .AddParameter("Id", DbType.Decimal, 9, riskoverdraftItem.Id)
                            .AddParameter("CompanyId", DbType.Decimal, 5, riskoverdraftItem.CompanyId)
                            .AddParameter("StartTerm", DbType.DateTime, 9, riskoverdraftItem.StartTerm)
                            .AddParameter("EndTerm", DbType.DateTime, 9, riskoverdraftItem.EndTerm)
                            .AddParameter("Amount1", DbType.Decimal, 18, riskoverdraftItem.Amount1)
                            .AddParameter("EndTermOnAmount1", DbType.DateTime, 9, riskoverdraftItem.EndTermOnAmount1)
                            .AddParameter("Recast1", DbType.Decimal, 1, riskoverdraftItem.Recast1 ? 1 : 0)
                            .AddParameter("Amount2", DbType.Decimal, 18, riskoverdraftItem.Amount2)
                            .AddParameter("EndTermOnAmount2", DbType.DateTime, 9, riskoverdraftItem.EndTermOnAmount2)
                            .AddParameter("Recast2", DbType.Decimal, 1, riskoverdraftItem.Recast2 ? 1 : 0)
                            .AddParameter("Amount3", DbType.Decimal, 18, riskoverdraftItem.Amount3)
                            .AddParameter("EndTermOnAmount3", DbType.DateTime, 9, riskoverdraftItem.EndTermOnAmount3)
                            .AddParameter("Recast3", DbType.Decimal, 1, riskoverdraftItem.Recast3 ? 1 : 0)
                            .AddParameter("Amount4", DbType.Decimal, 18, riskoverdraftItem.Amount4)
                            .AddParameter("EndTermOnAmount4", DbType.DateTime, 9, riskoverdraftItem.EndTermOnAmount4)
                            .AddParameter("Recast4", DbType.Decimal, 1, riskoverdraftItem.Recast4 ? 1 : 0)
                            .AddParameter("Amount5", DbType.Decimal, 18, riskoverdraftItem.Amount5)
                            .AddParameter("EndTermOnAmount5", DbType.DateTime, 9, riskoverdraftItem.EndTermOnAmount5)
                            .AddParameter("Recast5", DbType.Decimal, 1, riskoverdraftItem.Recast5 ? 1 : 0)
                            .AddParameter("UpdateUserCode", DbType.Decimal, 9, riskoverdraftItem.UpdateUserCode)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, riskoverdraftItem.UpdateDate)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla RiskOverdraft.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="riskoverdraftItems">Lista de instancia de RiskOverdraft</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Insurance.Contracts.Policy.RiskOverdraft> riskoverdraftItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Insurance.Contracts.Policy.RiskOverdraft item in riskoverdraftItems)
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
        /// Recupera un registro en la tabla RiskOverdraft por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única de la póliza.</param>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de RiskOverdraft</returns>
        public static Architect.API.Insurance.Contracts.Policy.RiskOverdraft Retrieve(int id, int companyId, IDbConnection connection = null)
        {
            Architect.API.Insurance.Contracts.Policy.RiskOverdraft result = null;
            Database.Select("SELECT Id, RiskOverdraft.CompanyId, StartTerm, EndTerm, Amount1, EndTermOnAmount1, Recast1, Amount2, EndTermOnAmount2, Recast2, Amount3, EndTermOnAmount3, Recast3, Amount4, EndTermOnAmount4, Recast4, Amount5, EndTermOnAmount5, Recast5, RiskOverdraft.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, RiskOverdraft.UpdateDate " +
                              "FROM RiskOverdraft LEFT JOIN UserMember um ON um.UserId = RiskOverdraft.UpdateUserCode " +
                             "WHERE RiskOverdraft.Id=:Id AND RiskOverdraft.CompanyId=:CompanyId")
                        .AddParameter("Id", DbType.Decimal, 9, id)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToRiskOverdraft(reader);
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
        /// Actualiza un registro en la tabla RiskOverdraft por medio de su clave primaria.
        /// </summary>
        /// <param name="riskoverdraftItem">Instancia de RiskOverdraft</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Insurance.Contracts.Policy.RiskOverdraft riskoverdraftItem, IDbConnection connection = null)
        {
            if (riskoverdraftItem.UpdateDate.IsEmpty())
            {
                riskoverdraftItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE RiskOverdraft " +
                                      "SET CompanyId=:CompanyId, StartTerm=:StartTerm, EndTerm=:EndTerm, Amount1=:Amount1, EndTermOnAmount1=:EndTermOnAmount1, Recast1=:Recast1, Amount2=:Amount2, EndTermOnAmount2=:EndTermOnAmount2, Recast2=:Recast2, Amount3=:Amount3, EndTermOnAmount3=:EndTermOnAmount3, Recast3=:Recast3, Amount4=:Amount4, EndTermOnAmount4=:EndTermOnAmount4, Recast4=:Recast4, Amount5=:Amount5, EndTermOnAmount5=:EndTermOnAmount5, Recast5=:Recast5, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE Id=:Id")
                                .AddParameter("CompanyId", DbType.Decimal, 5, riskoverdraftItem.CompanyId)
                                .AddParameter("StartTerm", DbType.DateTime, 9, riskoverdraftItem.StartTerm)
                                .AddParameter("EndTerm", DbType.DateTime, 9, riskoverdraftItem.EndTerm)
                                .AddParameter("Amount1", DbType.Decimal, 18, riskoverdraftItem.Amount1)
                                .AddParameter("EndTermOnAmount1", DbType.DateTime, 9, riskoverdraftItem.EndTermOnAmount1)
                                .AddParameter("Recast1", DbType.Decimal, 1, riskoverdraftItem.Recast1 ? 1 : 0)
                                .AddParameter("Amount2", DbType.Decimal, 18, riskoverdraftItem.Amount2)
                                .AddParameter("EndTermOnAmount2", DbType.DateTime, 9, riskoverdraftItem.EndTermOnAmount2)
                                .AddParameter("Recast2", DbType.Decimal, 1, riskoverdraftItem.Recast2 ? 1 : 0)
                                .AddParameter("Amount3", DbType.Decimal, 18, riskoverdraftItem.Amount3)
                                .AddParameter("EndTermOnAmount3", DbType.DateTime, 9, riskoverdraftItem.EndTermOnAmount3)
                                .AddParameter("Recast3", DbType.Decimal, 1, riskoverdraftItem.Recast3 ? 1 : 0)
                                .AddParameter("Amount4", DbType.Decimal, 18, riskoverdraftItem.Amount4)
                                .AddParameter("EndTermOnAmount4", DbType.DateTime, 9, riskoverdraftItem.EndTermOnAmount4)
                                .AddParameter("Recast4", DbType.Decimal, 1, riskoverdraftItem.Recast4 ? 1 : 0)
                                .AddParameter("Amount5", DbType.Decimal, 18, riskoverdraftItem.Amount5)
                                .AddParameter("EndTermOnAmount5", DbType.DateTime, 9, riskoverdraftItem.EndTermOnAmount5)
                                .AddParameter("Recast5", DbType.Decimal, 1, riskoverdraftItem.Recast5 ? 1 : 0)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, riskoverdraftItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, riskoverdraftItem.UpdateDate)
                                .AddParameter("Id", DbType.Decimal, 9, riskoverdraftItem.Id)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla RiskOverdraft por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="riskoverdraftItems">Lista de instancia de RiskOverdraft</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Insurance.Contracts.Policy.RiskOverdraft> riskoverdraftItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Insurance.Contracts.Policy.RiskOverdraft item in riskoverdraftItems)
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
        /// Elimina un registro en la tabla RiskOverdraft por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única de la póliza.</param>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int id, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM RiskOverdraft " +
                                    "WHERE Id=:Id AND CompanyId=:CompanyId")
                                .AddParameter("Id", DbType.Decimal, 9, id)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }


        /// <summary>
        /// Actualiza una lista de registros en la tabla RiskOverdraft por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="idList">Lista de Identificación única de la póliza.</param>
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Delete(List<int> idList, int companyId, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (int item in idList)
            {
                result.Add(Delete(item, companyId, connection));
            }
            if (local)
            {
                connection.Close();
            }
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla RiskOverdraft.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="companyid"></param>
        /// <returns>Lista de instancias de RiskOverdraft</returns>
        public static List<Contracts.Policy.RiskOverdraft> RetrieveByIdCompanyId(int id, int companyId, IDbConnection connection = null)
        {
            var result = new List<Contracts.Policy.RiskOverdraft>();
            Database.Select(@"SELECT Id, RiskOverdraft.CompanyId, StartTerm, EndTerm, Amount1, EndTermOnAmount1, Recast1, Amount2, EndTermOnAmount2, Recast2, Amount3, EndTermOnAmount3, Recast3, Amount4, EndTermOnAmount4, Recast4, Amount5, EndTermOnAmount5, Recast5, RiskOverdraft.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, RiskOverdraft.UpdateDate  
                                FROM RiskOverdraft LEFT JOIN UserMember um ON um.UserId = RiskOverdraft.UpdateUserCode  
                               WHERE Id=:Id AND CompanyId=:CompanyId")
                        .AddParameter("Id", DbType.Decimal, 9, id)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToRiskOverdraft(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Elimina un registro en la tabla RiskOverdraft por medio de su clave primaria.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="companyId"></param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int DeleteByIdCompanyId(int id, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM RiskOverdraft " +
                                    "WHERE Id=:Id AND CompanyId=:CompanyId")
                                .AddParameter("Id", DbType.Decimal, 9, id)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla RiskOverdraft que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parametros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM RiskOverdraft " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'RiskOverdraft'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Insurance.Contracts.Policy.RiskOverdraft DataReaderToRiskOverdraft(System.Data.IDataReader reader, Architect.API.Insurance.Contracts.Policy.RiskOverdraft item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Insurance.Contracts.Policy.RiskOverdraft();
            }
            item.Id = reader.IntegerValue("Id");
            item.CompanyId = reader.IntegerValue("CompanyId");
            item.StartTerm = reader.DateTimeValue("StartTerm");
            item.EndTerm = reader.DateTimeValue("EndTerm");
            item.Amount1 = reader.DoubleValue("Amount1");
            item.EndTermOnAmount1 = reader.DateTimeValue("EndTermOnAmount1");
            item.Recast1 = reader.IntegerValue("Recast1") == 1;
            item.Amount2 = reader.DoubleValue("Amount2");
            item.EndTermOnAmount2 = reader.DateTimeValue("EndTermOnAmount2");
            item.Recast2 = reader.IntegerValue("Recast2") == 1;
            item.Amount3 = reader.DoubleValue("Amount3");
            item.EndTermOnAmount3 = reader.DateTimeValue("EndTermOnAmount3");
            item.Recast3 = reader.IntegerValue("Recast3") == 1;
            item.Amount4 = reader.DoubleValue("Amount4");
            item.EndTermOnAmount4 = reader.DateTimeValue("EndTermOnAmount4");
            item.Recast4 = reader.IntegerValue("Recast4") == 1;
            item.Amount5 = reader.DoubleValue("Amount5");
            item.EndTermOnAmount5 = reader.DateTimeValue("EndTermOnAmount5");
            item.Recast5 = reader.IntegerValue("Recast5") == 1;
            item.UpdateUserCode = reader.IntegerValue("UpdateUserCode");
            item.UpdateUserName = reader.StringValue("UpdateUserName");
            item.UpdateDate = reader.DateTimeValue("UpdateDate");
            return item;
        }
    }
}