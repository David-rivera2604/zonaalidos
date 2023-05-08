using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.General
{
    /// <summary>
    /// Casos asociados a los procesos.
    /// </summary>
    public sealed partial class ProcessCase
    {

        /// <summary>
        /// Crea un registro en la tabla ProcessCase.
        /// </summary>
        /// <param name="processcaseItem">Instancia de ProcessCase</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Core.Contracts.General.ProcessCase processcaseItem, IDbConnection connection = null)
        {
            if (processcaseItem.UpdateDate.IsEmpty())
            {
                processcaseItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("INSERT INTO ProcessCase (Id, CompanyId, Title, Description, Priority, InstanceId, CurrentStepId, Reference1, Reference2, Reference3, Reference4, Reference5, Reference6, Reference7, Reference8, Reference9, Reference10, ContactMainName, ContactMainEmail, Status, Label, SubStatus, SubLabel, FlowId, UserId, SLA, UpdateUserCode, UpdateDate, UserSend) " +
                                                 "VALUES(:Id, :CompanyId, :Title, :Description, :Priority, :InstanceId, :CurrentStepId, :Reference1, :Reference2, :Reference3, :Reference4, :Reference5, :Reference6, :Reference7, :Reference8, :Reference9, :Reference10, :ContactMainName, :ContactMainEmail, :Status, :Label, :SubStatus, :SubLabel, :FlowId, :UserId, :SLA, :UpdateUserCode, :UpdateDate, :UserSend)")
                            .AddParameter("Id", DbType.Decimal, 9, processcaseItem.Id)
                            .AddParameter("CompanyId", DbType.Decimal, 5, processcaseItem.CompanyId)
                            .AddParameter("Title", DbType.AnsiString, 120, processcaseItem.Title)
                            .AddParameter("Description", DbType.AnsiString, 300, processcaseItem.Description)
                            .AddParameter("Priority", DbType.Decimal, 3, processcaseItem.Priority)
                            .AddParameter("InstanceId", DbType.Decimal, 9, processcaseItem.InstanceId)
                            .AddParameter("CurrentStepId", DbType.Decimal, 9, processcaseItem.CurrentStepId)
                            .AddParameter("Reference1", DbType.AnsiString, 36, processcaseItem.Reference1)
                            .AddParameter("Reference2", DbType.AnsiString, 36, processcaseItem.Reference2)
                            .AddParameter("Reference3", DbType.AnsiString, 36, processcaseItem.Reference3)
                            .AddParameter("Reference4", DbType.AnsiString, 36, processcaseItem.Reference4)
                            .AddParameter("Reference5", DbType.AnsiString, 36, processcaseItem.Reference5)
                            .AddParameter("Reference6", DbType.AnsiString, 80, processcaseItem.Reference6)
                            .AddParameter("Reference7", DbType.AnsiString, 80, processcaseItem.Reference7)
                            .AddParameter("Reference8", DbType.AnsiString, 80, processcaseItem.Reference8)
                            .AddParameter("Reference9", DbType.AnsiString, 80, processcaseItem.Reference9)
                            .AddParameter("Reference10", DbType.AnsiString, 80, processcaseItem.Reference10)
                            .AddParameter("ContactMainName", DbType.AnsiString, 256, processcaseItem.ContactMainName)
                            .AddParameter("ContactMainEmail", DbType.AnsiString, 256, processcaseItem.ContactMainEmail)
                            .AddParameter("Status", DbType.Decimal, 3, processcaseItem.Status)
                            .AddParameter("Label", DbType.AnsiString, 80, processcaseItem.Label)
                            .AddParameter("SubStatus", DbType.Decimal, 3, processcaseItem.SubStatus)
                            .AddParameter("SubLabel", DbType.AnsiString, 80, processcaseItem.SubLabel)
                            .AddParameter("FlowId", DbType.Decimal, 9, processcaseItem.FlowId)
                            .AddParameter("UserId", DbType.Decimal, 9, processcaseItem.UserId)
                            .AddParameter("SLA", DbType.Decimal, 5, processcaseItem.SLA)
                            .AddParameter("UpdateUserCode", DbType.Decimal, 9, processcaseItem.UpdateUserCode)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, processcaseItem.UpdateDate)

                            //Añadido extra solo para detectar el usuario que envio el caso
                            .AddParameter("UserSend", DbType.Decimal, 9, processcaseItem.UserSend)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla ProcessCase.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="processcaseItems">Lista de instancia de ProcessCase</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Core.Contracts.General.ProcessCase> processcaseItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.ProcessCase item in processcaseItems)
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
        /// Recupera un registro en la tabla ProcessCase por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del proceso.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de ProcessCase</returns>
        public static Architect.API.Core.Contracts.General.ProcessCase Retrieve(int id, int companyId, IDbConnection connection = null)
        {
            Architect.API.Core.Contracts.General.ProcessCase result = null;
            //Agregado provisional Sebastian UserSend
            Database.Select("SELECT Id, ProcessCase.CompanyId, Title, Description, Priority, InstanceId, CurrentStepId, Reference1, Reference2, Reference3, Reference4, Reference5, Reference6, Reference7, Reference8, Reference9, Reference10, ContactMainName, ContactMainEmail, Status, Label, SubStatus, SubLabel, FlowId, ProcessCase.UserId, SLA, ProcessCase.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessCase.UpdateDate, UserSend " +
                              "FROM ProcessCase LEFT JOIN UserMember um ON um.UserId = ProcessCase.UpdateUserCode " +
                             "WHERE ProcessCase.Id=:Id AND ProcessCase.CompanyId=:CompanyId")
                        .AddParameter("Id", DbType.Decimal, 9, id)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToProcessCase(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessCase.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de ProcessCase</returns>
        public static List<Architect.API.Core.Contracts.General.ProcessCase> RetrieveAll(int companyId, string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.ProcessCase> result = new List<Architect.API.Core.Contracts.General.ProcessCase>();
            Database.Select("SELECT Id, ProcessCase.CompanyId, Title, Description, Priority, InstanceId, CurrentStepId, Reference1, Reference2, Reference3, Reference4, Reference5, Reference6, Reference7, Reference8, Reference9, Reference10, ContactMainName, ContactMainEmail, Status, Label, SubStatus, SubLabel, FlowId, ProcessCase.UserId, SLA, ProcessCase.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessCase.UpdateDate " +
                              "FROM ProcessCase LEFT JOIN UserMember um ON um.UserId = ProcessCase.UpdateUserCode " +
                             "WHERE ProcessCase.CompanyId=:CompanyId" + filter)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToProcessCase(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessCase.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de ProcessCase</returns>
        public static List<Architect.API.Core.Contracts.General.ProcessCase> RetrieveAll(int companyId, string filter, int beginIndex, int endIndex, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.General.ProcessCase> result = new List<Architect.API.Core.Contracts.General.ProcessCase>();
            if (beginIndex == 0)
            {
                beginIndex = 1;
            }
            if (endIndex == 0 || endIndex < beginIndex)
            {
                endIndex = int.MaxValue;
            }
            Database.Select("SELECT * FROM (" +
                            "SELECT Id, ProcessCase.CompanyId, Title, Description, Priority, InstanceId, CurrentStepId, Reference1, Reference2, Reference3, Reference4, Reference5, Reference6, Reference7, Reference8, Reference9, Reference10, ContactMainName, ContactMainEmail, Status, Label, SubStatus, SubLabel, FlowId, ProcessCase.UserId, SLA, ProcessCase.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessCase.UpdateDate, ProcessCase.UserSend " +
                                   ", ROW_NUMBER() OVER (ORDER BY ProcessCase.Id DESC) RowNumber " +
                              "FROM ProcessCase LEFT JOIN UserMember um ON um.UserId = ProcessCase.UpdateUserCode " +
                             "WHERE ProcessCase.CompanyId=:CompanyId" + filter +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToProcessCase(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Genera complemento de la consulta para habilitar el filtro por columnas establecidas.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros.</param>
        /// <param name="includeWhere">Indica que el complemento debe incluir el WHERE del comando.</param>
        /// <returns>Complemento de la consulta</returns>
        public static string FilterBuilder(string filter, bool includeWhere = true)
        {
            string result = string.Empty;


            return result;
        }

        /// <summary>
        /// Último valor asignado a clave única de la tabla ProcessCase.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT NVL(MAX(Id),0) " +
                                     "FROM ProcessCase")
                                .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla ProcessCase por medio de su clave primaria.
        /// </summary>
        /// <param name="processcaseItem">Instancia de ProcessCase</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Core.Contracts.General.ProcessCase processcaseItem, IDbConnection connection = null)
        {
            if (processcaseItem.UpdateDate.IsEmpty())
            {
                processcaseItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE ProcessCase " +
                                      "SET CompanyId=:CompanyId, Title=:Title, Description=:Description, Priority=:Priority, InstanceId=:InstanceId, CurrentStepId=:CurrentStepId, Reference1=:Reference1, Reference2=:Reference2, Reference3=:Reference3, Reference4=:Reference4, Reference5=:Reference5, Reference6=:Reference6, Reference7=:Reference7, Reference8=:Reference8, Reference9=:Reference9, Reference10=:Reference10, ContactMainName=:ContactMainName, ContactMainEmail=:ContactMainEmail, Status=:Status, Label=:Label, SubStatus=:SubStatus, SubLabel=:SubLabel, FlowId=:FlowId, UserId=:UserId, SLA=:SLA, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE Id=:Id")
                                .AddParameter("CompanyId", DbType.Decimal, 5, processcaseItem.CompanyId)
                                .AddParameter("Title", DbType.AnsiString, 120, processcaseItem.Title)
                                .AddParameter("Description", DbType.AnsiString, 300, processcaseItem.Description)
                                .AddParameter("Priority", DbType.Decimal, 3, processcaseItem.Priority)
                                .AddParameter("InstanceId", DbType.Decimal, 9, processcaseItem.InstanceId)
                                .AddParameter("CurrentStepId", DbType.Decimal, 9, processcaseItem.CurrentStepId)
                                .AddParameter("Reference1", DbType.AnsiString, 36, processcaseItem.Reference1)
                                .AddParameter("Reference2", DbType.AnsiString, 36, processcaseItem.Reference2)
                                .AddParameter("Reference3", DbType.AnsiString, 36, processcaseItem.Reference3)
                                .AddParameter("Reference4", DbType.AnsiString, 36, processcaseItem.Reference4)
                                .AddParameter("Reference5", DbType.AnsiString, 36, processcaseItem.Reference5)
                                .AddParameter("Reference6", DbType.AnsiString, 80, processcaseItem.Reference6)
                                .AddParameter("Reference7", DbType.AnsiString, 80, processcaseItem.Reference7)
                                .AddParameter("Reference8", DbType.AnsiString, 80, processcaseItem.Reference8)
                                .AddParameter("Reference9", DbType.AnsiString, 80, processcaseItem.Reference9)
                                .AddParameter("Reference10", DbType.AnsiString, 80, processcaseItem.Reference10)
                                .AddParameter("ContactMainName", DbType.AnsiString, 256, processcaseItem.ContactMainName)
                                .AddParameter("ContactMainEmail", DbType.AnsiString, 256, processcaseItem.ContactMainEmail)
                                .AddParameter("Status", DbType.Decimal, 3, processcaseItem.Status)
                                .AddParameter("Label", DbType.AnsiString, 80, processcaseItem.Label)
                                .AddParameter("SubStatus", DbType.Decimal, 3, processcaseItem.SubStatus)
                                .AddParameter("SubLabel", DbType.AnsiString, 80, processcaseItem.SubLabel)
                                .AddParameter("FlowId", DbType.Decimal, 9, processcaseItem.FlowId)
                                .AddParameter("UserId", DbType.Decimal, 9, processcaseItem.UserId)
                                .AddParameter("SLA", DbType.Decimal, 5, processcaseItem.SLA)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, processcaseItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, processcaseItem.UpdateDate)
                                .AddParameter("Id", DbType.Decimal, 9, processcaseItem.Id)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla ProcessCase por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="processcaseItems">Lista de instancia de ProcessCase</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Core.Contracts.General.ProcessCase> processcaseItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.General.ProcessCase item in processcaseItems)
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
        /// Elimina un registro en la tabla ProcessCase por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del proceso.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int id, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM ProcessCase " +
                                    "WHERE Id=:Id AND CompanyId=:CompanyId")
                                .AddParameter("Id", DbType.Decimal, 9, id)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla ProcessCase por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="idList">Lista de Identificación única del proceso.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
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
        /// Recupera la cantidad de registros existentes en la tabla ProcessCase por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del proceso.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(int id, int companyId, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM ProcessCase " +
                                         "WHERE Id=:Id AND CompanyId=:CompanyId")
                               .AddParameter("Id", DbType.Decimal, 9, id)
                               .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla ProcessCase que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM ProcessCase " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera una lista para selección de la tabla ProcessCase.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de LookUpValue</returns>
        public static List<Utilities.Contracts.LookUpValue> LookUp(int companyId, IDbConnection connection = null)
        {
            List<Utilities.Contracts.LookUpValue> result = new List<Utilities.Contracts.LookUpValue>();
            Database.Select("SELECT Id, Title " +
                              "FROM ProcessCase WHERE CompanyId=:CompanyId ORDER BY Title")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(new Utilities.Contracts.LookUpValue()
                            {
                                Code = reader.StringValue("Id"),
                                Description = reader.StringValue("Title")
                            });
                        }));
            return result;
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'ProcessCase'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Core.Contracts.General.ProcessCase DataReaderToProcessCase(System.Data.IDataReader reader, Architect.API.Core.Contracts.General.ProcessCase item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Core.Contracts.General.ProcessCase();
            }
            item.Id = reader.IntegerValue("Id");
            item.CompanyId = reader.IntegerValue("CompanyId");
            item.Title = reader.StringValue("Title");
            item.Description = reader.StringValue("Description");
            item.Priority = reader.IntegerValue("Priority");
            item.InstanceId = reader.IntegerValue("InstanceId");
            item.CurrentStepId = reader.IntegerValue("CurrentStepId");
            item.Reference1 = reader.StringValue("Reference1");
            item.Reference2 = reader.StringValue("Reference2");
            item.Reference3 = reader.StringValue("Reference3");
            item.Reference4 = reader.StringValue("Reference4");
            item.Reference5 = reader.StringValue("Reference5");
            item.Reference6 = reader.StringValue("Reference6");
            item.Reference7 = reader.StringValue("Reference7");
            item.Reference8 = reader.StringValue("Reference8");
            item.Reference9 = reader.StringValue("Reference9");
            item.Reference10 = reader.StringValue("Reference10");
            item.ContactMainName = reader.StringValue("ContactMainName");
            item.ContactMainEmail = reader.StringValue("ContactMainEmail");
            item.Status = reader.IntegerValue("Status");
            item.Label = reader.StringValue("Label");
            item.SubStatus = reader.IntegerValue("SubStatus");
            item.SubLabel = reader.StringValue("SubLabel");
            item.FlowId = reader.IntegerValue("FlowId");
            item.UserId = reader.IntegerValue("UserId");
            item.SLA = reader.IntegerValue("SLA");
            item.UpdateUserCode = reader.IntegerValue("UpdateUserCode");
            item.UpdateUserName = reader.StringValue("UpdateUserName");
            item.UpdateDate = reader.DateTimeValue("UpdateDate");

            //Agregado para la lectura del usuario que envio el caso
            item.UserSend = reader.IntegerValue("UserSend");
            return item;
        }

    }

}

