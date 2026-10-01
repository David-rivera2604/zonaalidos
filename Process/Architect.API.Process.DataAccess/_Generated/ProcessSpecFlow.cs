using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Process.DataAccess.General
{
    /// <summary>
    /// Especificación de un proceso.
    /// </summary>
    public sealed partial class ProcessSpecFlow
    {

        /// <summary>
        /// Crea un registro en la tabla ProcessSpecFlow.
        /// </summary>
        /// <param name="processspecflowItem">Instancia de ProcessSpecFlow</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Process.Contracts.General.ProcessSpecFlow processspecflowItem, IDbConnection connection = null)
        {
            if (processspecflowItem.UpdateDate.IsEmpty())
            {
                processspecflowItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("INSERT INTO ProcessSpecFlow (Id, CompanyId, Name, Description, Alias, MailServer, ReferenceCaption1, ReferenceType1, ReferenceRequired1, ReferenceLookupList1, ReferenceCaption2, ReferenceType2, ReferenceRequired2, ReferenceLookupList2, ReferenceCaption3, ReferenceType3, ReferenceRequired3, ReferenceLookupList3, ReferenceCaption4, ReferenceType4, ReferenceRequired4, ReferenceLookupList4, ReferenceCaption5, ReferenceType5, ReferenceRequired5, ReferenceLookupList5, ReferenceCaption6, ReferenceType6, ReferenceRequired6, ReferenceLookupList6, ReferenceCaption7, ReferenceType7, ReferenceRequired7, ReferenceLookupList7, ReferenceCaption8, ReferenceType8, ReferenceRequired8, ReferenceLookupList8, ReferenceCaption9, ReferenceType9, ReferenceRequired9, ReferenceLookupList9, ReferenceCaption10, ReferenceType10, ReferenceRequired10, ReferenceLookupList10, SLA, SLADuration, Status, UpdateUserCode, UpdateDate) " +
                                                 "VALUES(:Id, :CompanyId, :Name, :Description, :Alias, :MailServer, :ReferenceCaption1, :ReferenceType1, :ReferenceRequired1, :ReferenceLookupList1, :ReferenceCaption2, :ReferenceType2, :ReferenceRequired2, :ReferenceLookupList2, :ReferenceCaption3, :ReferenceType3, :ReferenceRequired3, :ReferenceLookupList3, :ReferenceCaption4, :ReferenceType4, :ReferenceRequired4, :ReferenceLookupList4, :ReferenceCaption5, :ReferenceType5, :ReferenceRequired5, :ReferenceLookupList5, :ReferenceCaption6, :ReferenceType6, :ReferenceRequired6, :ReferenceLookupList6, :ReferenceCaption7, :ReferenceType7, :ReferenceRequired7, :ReferenceLookupList7, :ReferenceCaption8, :ReferenceType8, :ReferenceRequired8, :ReferenceLookupList8, :ReferenceCaption9, :ReferenceType9, :ReferenceRequired9, :ReferenceLookupList9, :ReferenceCaption10, :ReferenceType10, :ReferenceRequired10, :ReferenceLookupList10, :SLA, :SLADuration, :Status, :UpdateUserCode, :UpdateDate)")
                            .AddParameter("Id", DbType.Decimal, 9, processspecflowItem.Id)
                            .AddParameter("CompanyId", DbType.Decimal, 5, processspecflowItem.CompanyId)
                            .AddParameter("Name", DbType.AnsiString, 80, processspecflowItem.Name)
                            .AddParameter("Description", DbType.AnsiString, 256, processspecflowItem.Description)
                            .AddParameter("Alias", DbType.AnsiString, 30, processspecflowItem.Alias)
                            .AddParameter("MailServer", DbType.Decimal, 5, processspecflowItem.MailServer)
                            .AddParameter("ReferenceCaption1", DbType.AnsiString, 80, processspecflowItem.ReferenceCaption1)
                            .AddParameter("ReferenceType1", DbType.Decimal, 3, processspecflowItem.ReferenceType1)
                            .AddParameter("ReferenceRequired1", DbType.Decimal, 1, processspecflowItem.ReferenceRequired1 ? 1 : 0)
                            .AddParameter("ReferenceLookupList1", DbType.AnsiString, 4000, processspecflowItem.ReferenceLookupList1)
                            .AddParameter("ReferenceCondition1", DbType.AnsiString, 4000, processspecflowItem.ReferenceCondition1)
                            .AddParameter("ReferenceCaption2", DbType.AnsiString, 80, processspecflowItem.ReferenceCaption2)
                            .AddParameter("ReferenceType2", DbType.Decimal, 3, processspecflowItem.ReferenceType2)
                            .AddParameter("ReferenceRequired2", DbType.Decimal, 1, processspecflowItem.ReferenceRequired2 ? 1 : 0)
                            .AddParameter("ReferenceLookupList2", DbType.AnsiString, 4000, processspecflowItem.ReferenceLookupList2)
                            .AddParameter("ReferenceCondition2", DbType.AnsiString, 4000, processspecflowItem.ReferenceCondition2)
                            .AddParameter("ReferenceCaption3", DbType.AnsiString, 80, processspecflowItem.ReferenceCaption3)
                            .AddParameter("ReferenceType3", DbType.Decimal, 3, processspecflowItem.ReferenceType3)
                            .AddParameter("ReferenceRequired3", DbType.Decimal, 1, processspecflowItem.ReferenceRequired3 ? 1 : 0)
                            .AddParameter("ReferenceLookupList3", DbType.AnsiString, 4000, processspecflowItem.ReferenceLookupList3)
                            .AddParameter("ReferenceCondition3", DbType.AnsiString, 4000, processspecflowItem.ReferenceCondition3)
                            .AddParameter("ReferenceCaption4", DbType.AnsiString, 80, processspecflowItem.ReferenceCaption4)
                            .AddParameter("ReferenceType4", DbType.Decimal, 3, processspecflowItem.ReferenceType4)
                            .AddParameter("ReferenceRequired4", DbType.Decimal, 1, processspecflowItem.ReferenceRequired4 ? 1 : 0)
                            .AddParameter("ReferenceLookupList4", DbType.AnsiString, 4000, processspecflowItem.ReferenceLookupList4)
                            .AddParameter("ReferenceCondition4", DbType.AnsiString, 4000, processspecflowItem.ReferenceCondition4)
                            .AddParameter("ReferenceCaption5", DbType.AnsiString, 80, processspecflowItem.ReferenceCaption5)
                            .AddParameter("ReferenceType5", DbType.Decimal, 3, processspecflowItem.ReferenceType5)
                            .AddParameter("ReferenceRequired5", DbType.Decimal, 1, processspecflowItem.ReferenceRequired5 ? 1 : 0)
                            .AddParameter("ReferenceLookupList5", DbType.AnsiString, 4000, processspecflowItem.ReferenceLookupList5)
                            .AddParameter("ReferenceCondition5", DbType.AnsiString, 4000, processspecflowItem.ReferenceCondition5)
                            .AddParameter("ReferenceCaption6", DbType.AnsiString, 80, processspecflowItem.ReferenceCaption6)
                            .AddParameter("ReferenceType6", DbType.Decimal, 3, processspecflowItem.ReferenceType6)
                            .AddParameter("ReferenceRequired6", DbType.Decimal, 1, processspecflowItem.ReferenceRequired6 ? 1 : 0)
                            .AddParameter("ReferenceLookupList6", DbType.AnsiString, 2048, processspecflowItem.ReferenceLookupList6)
                            .AddParameter("ReferenceCondition6", DbType.AnsiString, 4000, processspecflowItem.ReferenceCondition6)
                            .AddParameter("ReferenceCaption7", DbType.AnsiString, 80, processspecflowItem.ReferenceCaption7)
                            .AddParameter("ReferenceType7", DbType.Decimal, 3, processspecflowItem.ReferenceType7)
                            .AddParameter("ReferenceRequired7", DbType.Decimal, 1, processspecflowItem.ReferenceRequired7 ? 1 : 0)
                            .AddParameter("ReferenceLookupList7", DbType.AnsiString, 2048, processspecflowItem.ReferenceLookupList7)
                            .AddParameter("ReferenceCondition7", DbType.AnsiString, 4000, processspecflowItem.ReferenceCondition7)
                            .AddParameter("ReferenceCaption8", DbType.AnsiString, 80, processspecflowItem.ReferenceCaption8)
                            .AddParameter("ReferenceType8", DbType.Decimal, 3, processspecflowItem.ReferenceType8)
                            .AddParameter("ReferenceRequired8", DbType.Decimal, 1, processspecflowItem.ReferenceRequired8 ? 1 : 0)
                            .AddParameter("ReferenceLookupList8", DbType.AnsiString, 2048, processspecflowItem.ReferenceLookupList8)
                            .AddParameter("ReferenceCondition8", DbType.AnsiString, 4000, processspecflowItem.ReferenceCondition8)
                            .AddParameter("ReferenceCaption9", DbType.AnsiString, 80, processspecflowItem.ReferenceCaption9)
                            .AddParameter("ReferenceType9", DbType.Decimal, 3, processspecflowItem.ReferenceType9)
                            .AddParameter("ReferenceRequired9", DbType.Decimal, 1, processspecflowItem.ReferenceRequired9 ? 1 : 0)
                            .AddParameter("ReferenceLookupList9", DbType.AnsiString, 2048, processspecflowItem.ReferenceLookupList9)
                            .AddParameter("ReferenceCondition9", DbType.AnsiString, 4000, processspecflowItem.ReferenceCondition9)
                            .AddParameter("ReferenceCaption10", DbType.AnsiString, 80, processspecflowItem.ReferenceCaption10)
                            .AddParameter("ReferenceType10", DbType.Decimal, 3, processspecflowItem.ReferenceType10)
                            .AddParameter("ReferenceRequired10", DbType.Decimal, 1, processspecflowItem.ReferenceRequired10 ? 1 : 0)
                            .AddParameter("ReferenceLookupList10", DbType.AnsiString, 2048, processspecflowItem.ReferenceLookupList10)
                            .AddParameter("ReferenceCondition10", DbType.AnsiString, 4000, processspecflowItem.ReferenceCondition10)
                            .AddParameter("SLA", DbType.Decimal, 5, processspecflowItem.SLA)
                            .AddParameter("SLADuration", DbType.Decimal, 5, processspecflowItem.SLADuration)
                            .AddParameter("Status", DbType.Decimal, 3, processspecflowItem.Status)
                            .AddParameter("UpdateUserCode", DbType.Decimal, 9, processspecflowItem.UpdateUserCode)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, processspecflowItem.UpdateDate)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla ProcessSpecFlow.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="processspecflowItems">Lista de instancia de ProcessSpecFlow</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Process.Contracts.General.ProcessSpecFlow> processspecflowItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Process.Contracts.General.ProcessSpecFlow item in processspecflowItems)
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
        /// Recupera un registro en la tabla ProcessSpecFlow por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del proceso.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de ProcessSpecFlow</returns>
        public static Architect.API.Process.Contracts.General.ProcessSpecFlow Retrieve(int id, int companyId, IDbConnection connection = null)
        {
            Architect.API.Process.Contracts.General.ProcessSpecFlow result = null;
            Database.Select("SELECT Id, ProcessSpecFlow.CompanyId, Name, Description, Alias, MailServer, ReferenceCaption1, ReferenceType1, ReferenceRequired1, ReferenceLookupList1, ReferenceCondition1, ReferenceCaption2, ReferenceType2, ReferenceRequired2, ReferenceLookupList2, ReferenceCondition2, ReferenceCaption3, ReferenceType3, ReferenceRequired3, ReferenceLookupList3, ReferenceCondition3, ReferenceCaption4, ReferenceType4, ReferenceRequired4, ReferenceLookupList4, ReferenceCondition4, ReferenceCaption5, ReferenceType5, ReferenceRequired5, ReferenceLookupList5, ReferenceCondition5, ReferenceCaption6, ReferenceType6, ReferenceRequired6, ReferenceLookupList6, ReferenceCondition6, ReferenceCaption7, ReferenceType7, ReferenceRequired7, ReferenceLookupList7, ReferenceCondition7, ReferenceCaption8, ReferenceType8, ReferenceRequired8, ReferenceLookupList8, ReferenceCondition8, ReferenceCaption9, ReferenceType9, ReferenceRequired9, ReferenceLookupList9, ReferenceCondition9, ReferenceCaption10, ReferenceType10, ReferenceRequired10, ReferenceLookupList10, ReferenceCondition10, SLA, SLADuration, Status, ProcessSpecFlow.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessSpecFlow.UpdateDate " +
                              "FROM ProcessSpecFlow LEFT JOIN UserMember um ON um.UserId = ProcessSpecFlow.UpdateUserCode " +
                             "WHERE ProcessSpecFlow.Id=:Id AND ProcessSpecFlow.CompanyId=:CompanyId")
                        .AddParameter("Id", DbType.Decimal, 9, id)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToProcessSpecFlow(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessSpecFlow.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de ProcessSpecFlow</returns>
        public static List<Architect.API.Process.Contracts.General.ProcessSpecFlow> RetrieveAll(int companyId, string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Process.Contracts.General.ProcessSpecFlow> result = new List<Architect.API.Process.Contracts.General.ProcessSpecFlow>();
            Database.Select("SELECT Id, ProcessSpecFlow.CompanyId, Name, Description, Alias, MailServer, ReferenceCaption1, ReferenceType1, ReferenceRequired1, ReferenceLookupList1, ReferenceCondition1, ReferenceCaption2, ReferenceType2, ReferenceRequired2, ReferenceLookupList2, ReferenceCondition2, ReferenceCaption3, ReferenceType3, ReferenceRequired3, ReferenceLookupList3, ReferenceCondition3, ReferenceCaption4, ReferenceType4, ReferenceRequired4, ReferenceLookupList4, ReferenceCondition4, ReferenceCaption5, ReferenceType5, ReferenceRequired5, ReferenceLookupList5, ReferenceCondition5, ReferenceCaption6, ReferenceType6, ReferenceRequired6, ReferenceLookupList6, ReferenceCondition6, ReferenceCaption7, ReferenceType7, ReferenceRequired7, ReferenceLookupList7, ReferenceCondition7, ReferenceCaption8, ReferenceType8, ReferenceRequired8, ReferenceLookupList8, ReferenceCondition8, ReferenceCaption9, ReferenceType9, ReferenceRequired9, ReferenceLookupList9, ReferenceCondition9, ReferenceCaption10, ReferenceType10, ReferenceRequired10, ReferenceLookupList10, ReferenceCondition10, SLA, SLADuration, Status, ProcessSpecFlow.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessSpecFlow.UpdateDate " +
                              "FROM ProcessSpecFlow LEFT JOIN UserMember um ON um.UserId = ProcessSpecFlow.UpdateUserCode " +
                             "WHERE ProcessSpecFlow.CompanyId=:CompanyId" + filter)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToProcessSpecFlow(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla ProcessSpecFlow.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de ProcessSpecFlow</returns>
        public static List<Architect.API.Process.Contracts.General.ProcessSpecFlow> RetrieveAll(int companyId, string filter, int beginIndex, int endIndex, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Process.Contracts.General.ProcessSpecFlow> result = new List<Architect.API.Process.Contracts.General.ProcessSpecFlow>();
            if (beginIndex == 0)
            {
                beginIndex = 1;
            }
            if (endIndex == 0 || endIndex < beginIndex)
            {
                endIndex = int.MaxValue;
            }
            Database.Select("SELECT * FROM (" +
                            "SELECT Id, ProcessSpecFlow.CompanyId, Name, Description, Alias, MailServer, ReferenceCaption1, ReferenceType1, ReferenceRequired1, ReferenceLookupList1, ReferenceCondition1, ReferenceCaption2, ReferenceType2, ReferenceRequired2, ReferenceLookupList2, ReferenceCondition2, ReferenceCaption3, ReferenceType3, ReferenceRequired3, ReferenceLookupList3, ReferenceCondition3, ReferenceCaption4, ReferenceType4, ReferenceRequired4, ReferenceLookupList4, ReferenceCondition4, ReferenceCaption5, ReferenceType5, ReferenceRequired5, ReferenceLookupList5, ReferenceCondition5, ReferenceCaption6, ReferenceType6, ReferenceRequired6, ReferenceLookupList6, ReferenceCondition6, ReferenceCaption7, ReferenceType7, ReferenceRequired7, ReferenceLookupList7, ReferenceCondition7, ReferenceCaption8, ReferenceType8, ReferenceRequired8, ReferenceLookupList8, ReferenceCondition8, ReferenceCaption9, ReferenceType9, ReferenceRequired9, ReferenceLookupList9, ReferenceCondition9, ReferenceCaption10, ReferenceType10, ReferenceRequired10, ReferenceLookupList10, ReferenceCondition10, SLA, SLADuration, Status, ProcessSpecFlow.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ProcessSpecFlow.UpdateDate " +
                            ", (SELECT LISTAGG(RM.ROLENAME , ', ') WITHIN GROUP (ORDER BY RM.ROLENAME ) FROM ProcessSpecFlowRole prm LEFT JOIN ROLEMEMBER rm ON rm.RoleId = prm.RoleId WHERE prm.COMPANYID=ProcessSpecFlow.CompanyId AND prm.ID=ProcessSpecFlow.ID) Roles" +
                                   ", ROW_NUMBER() OVER (ORDER BY ProcessSpecFlow.Id DESC) RowNumber " +
                              "FROM ProcessSpecFlow LEFT JOIN UserMember um ON um.UserId = ProcessSpecFlow.UpdateUserCode " +
                             "WHERE ProcessSpecFlow.CompanyId=:CompanyId" + filter +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToProcessSpecFlow(reader, null, true));
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

            if (filter.IsNotEmpty())
            {
                string condition = string.Empty;
                if (filter.IndexOf("|") > -1)
                {
                    condition = filter.Substring(filter.IndexOf("|"));
                    filter = filter.Substring(0, filter.IndexOf("|"));
                }
                if (includeWhere)
                {
                    result = " WHERE ";
                }
                else
                {
                    result = " AND ";
                }

                result += "(";
                result += " UPPER(ProcessSpecFlow.Status) LIKE '%" + filter.ToUpper() + "%' ";

                result += ")";
                if (condition.IsNotEmpty())
                {
                    result += Database.FilterFactory(condition, "ProcessSpecFlow");
                }
            }
            return result;
        }

        /// <summary>
        /// Último valor asignado a clave única de la tabla ProcessSpecFlow.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT NVL(MAX(Id),0) " +
                                     "FROM ProcessSpecFlow")
                                .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla ProcessSpecFlow por medio de su clave primaria.
        /// </summary>
        /// <param name="processspecflowItem">Instancia de ProcessSpecFlow</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Process.Contracts.General.ProcessSpecFlow processspecflowItem, IDbConnection connection = null)
        {
            if (processspecflowItem.UpdateDate.IsEmpty())
            {
                processspecflowItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE ProcessSpecFlow " +
                                      "SET CompanyId=:CompanyId, Name=:Name, Description=:Description, Alias=:Alias, MailServer=:MailServer, ReferenceCaption1=:ReferenceCaption1, ReferenceType1=:ReferenceType1, ReferenceRequired1=:ReferenceRequired1, ReferenceLookupList1=:ReferenceLookupList1, ReferenceCondition1=:ReferenceCondition1, ReferenceCaption2=:ReferenceCaption2, ReferenceType2=:ReferenceType2, ReferenceRequired2=:ReferenceRequired2, ReferenceLookupList2=:ReferenceLookupList2, ReferenceCondition2=:ReferenceCondition2, ReferenceCaption3=:ReferenceCaption3, ReferenceType3=:ReferenceType3, ReferenceRequired3=:ReferenceRequired3, ReferenceLookupList3=:ReferenceLookupList3, ReferenceCondition3=:ReferenceCondition3, ReferenceCaption4=:ReferenceCaption4, ReferenceType4=:ReferenceType4, ReferenceRequired4=:ReferenceRequired4, ReferenceLookupList4=:ReferenceLookupList4, ReferenceCondition4=:ReferenceCondition4, ReferenceCaption5=:ReferenceCaption5, ReferenceType5=:ReferenceType5, ReferenceRequired5=:ReferenceRequired5, ReferenceLookupList5=:ReferenceLookupList5, ReferenceCondition5=:ReferenceCondition5, ReferenceCaption6=:ReferenceCaption6, ReferenceType6=:ReferenceType6, ReferenceRequired6=:ReferenceRequired6, ReferenceLookupList6=:ReferenceLookupList6, ReferenceCondition6=:ReferenceCondition6, ReferenceCaption7=:ReferenceCaption7, ReferenceType7=:ReferenceType7, ReferenceRequired7=:ReferenceRequired7, ReferenceLookupList7=:ReferenceLookupList7, ReferenceCondition7=:ReferenceCondition7, ReferenceCaption8=:ReferenceCaption8, ReferenceType8=:ReferenceType8, ReferenceRequired8=:ReferenceRequired8, ReferenceLookupList8=:ReferenceLookupList8, ReferenceCondition8=:ReferenceCondition8, ReferenceCaption9=:ReferenceCaption9, ReferenceType9=:ReferenceType9, ReferenceRequired9=:ReferenceRequired9, ReferenceLookupList9=:ReferenceLookupList9, ReferenceCondition9=:ReferenceCondition9, ReferenceCaption10=:ReferenceCaption10, ReferenceType10=:ReferenceType10, ReferenceRequired10=:ReferenceRequired10, ReferenceLookupList10=:ReferenceLookupList10, ReferenceCondition10=:ReferenceCondition10, SLA=:SLA, SLADuration=:SLADuration, Status=:Status, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE Id=:Id")
                                .AddParameter("CompanyId", DbType.Decimal, 5, processspecflowItem.CompanyId)
                                .AddParameter("Name", DbType.AnsiString, 80, processspecflowItem.Name)
                                .AddParameter("Description", DbType.AnsiString, 256, processspecflowItem.Description)
                                .AddParameter("Alias", DbType.AnsiString, 30, processspecflowItem.Alias)
                                .AddParameter("MailServer", DbType.Decimal, 5, processspecflowItem.MailServer)
                                .AddParameter("ReferenceCaption1", DbType.AnsiString, 80, processspecflowItem.ReferenceCaption1)
                                .AddParameter("ReferenceType1", DbType.Decimal, 3, processspecflowItem.ReferenceType1)
                                .AddParameter("ReferenceRequired1", DbType.Decimal, 1, processspecflowItem.ReferenceRequired1 ? 1 : 0)
                                .AddParameter("ReferenceLookupList1", DbType.AnsiString, 4000, processspecflowItem.ReferenceLookupList1)
                                .AddParameter("ReferenceCondition1", DbType.AnsiString, 4000, processspecflowItem.ReferenceCondition1)
                                .AddParameter("ReferenceCaption2", DbType.AnsiString, 80, processspecflowItem.ReferenceCaption2)
                                .AddParameter("ReferenceType2", DbType.Decimal, 3, processspecflowItem.ReferenceType2)
                                .AddParameter("ReferenceRequired2", DbType.Decimal, 1, processspecflowItem.ReferenceRequired2 ? 1 : 0)
                                .AddParameter("ReferenceLookupList2", DbType.AnsiString, 4000, processspecflowItem.ReferenceLookupList2)
                                .AddParameter("ReferenceCondition2", DbType.AnsiString, 4000, processspecflowItem.ReferenceCondition2)
                                .AddParameter("ReferenceCaption3", DbType.AnsiString, 80, processspecflowItem.ReferenceCaption3)
                                .AddParameter("ReferenceType3", DbType.Decimal, 3, processspecflowItem.ReferenceType3)
                                .AddParameter("ReferenceRequired3", DbType.Decimal, 1, processspecflowItem.ReferenceRequired3 ? 1 : 0)
                                .AddParameter("ReferenceLookupList3", DbType.AnsiString, 4000, processspecflowItem.ReferenceLookupList3)
                                .AddParameter("ReferenceCondition3", DbType.AnsiString, 4000, processspecflowItem.ReferenceCondition3)
                                .AddParameter("ReferenceCaption4", DbType.AnsiString, 80, processspecflowItem.ReferenceCaption4)
                                .AddParameter("ReferenceType4", DbType.Decimal, 3, processspecflowItem.ReferenceType4)
                                .AddParameter("ReferenceRequired4", DbType.Decimal, 1, processspecflowItem.ReferenceRequired4 ? 1 : 0)
                                .AddParameter("ReferenceLookupList4", DbType.AnsiString, 4000, processspecflowItem.ReferenceLookupList4)
                                .AddParameter("ReferenceCondition4", DbType.AnsiString, 4000, processspecflowItem.ReferenceCondition4)
                                .AddParameter("ReferenceCaption5", DbType.AnsiString, 80, processspecflowItem.ReferenceCaption5)
                                .AddParameter("ReferenceType5", DbType.Decimal, 3, processspecflowItem.ReferenceType5)
                                .AddParameter("ReferenceRequired5", DbType.Decimal, 1, processspecflowItem.ReferenceRequired5 ? 1 : 0)
                                .AddParameter("ReferenceLookupList5", DbType.AnsiString, 4000, processspecflowItem.ReferenceLookupList5)
                                .AddParameter("ReferenceCondition5", DbType.AnsiString, 4000, processspecflowItem.ReferenceCondition5)
                                .AddParameter("ReferenceCaption6", DbType.AnsiString, 80, processspecflowItem.ReferenceCaption6)
                                .AddParameter("ReferenceType6", DbType.Decimal, 3, processspecflowItem.ReferenceType6)
                                .AddParameter("ReferenceRequired6", DbType.Decimal, 1, processspecflowItem.ReferenceRequired6 ? 1 : 0)
                                .AddParameter("ReferenceLookupList6", DbType.AnsiString, 2048, processspecflowItem.ReferenceLookupList6)
                                .AddParameter("ReferenceCondition6", DbType.AnsiString, 4000, processspecflowItem.ReferenceCondition6)
                                .AddParameter("ReferenceCaption7", DbType.AnsiString, 80, processspecflowItem.ReferenceCaption7)
                                .AddParameter("ReferenceType7", DbType.Decimal, 3, processspecflowItem.ReferenceType7)
                                .AddParameter("ReferenceRequired7", DbType.Decimal, 1, processspecflowItem.ReferenceRequired7 ? 1 : 0)
                                .AddParameter("ReferenceLookupList7", DbType.AnsiString, 2048, processspecflowItem.ReferenceLookupList7)
                                .AddParameter("ReferenceCondition7", DbType.AnsiString, 4000, processspecflowItem.ReferenceCondition7)
                                .AddParameter("ReferenceCaption8", DbType.AnsiString, 80, processspecflowItem.ReferenceCaption8)
                                .AddParameter("ReferenceType8", DbType.Decimal, 3, processspecflowItem.ReferenceType8)
                                .AddParameter("ReferenceRequired8", DbType.Decimal, 1, processspecflowItem.ReferenceRequired8 ? 1 : 0)
                                .AddParameter("ReferenceLookupList8", DbType.AnsiString, 2048, processspecflowItem.ReferenceLookupList8)
                                .AddParameter("ReferenceCondition8", DbType.AnsiString, 4000, processspecflowItem.ReferenceCondition8)
                                .AddParameter("ReferenceCaption9", DbType.AnsiString, 80, processspecflowItem.ReferenceCaption9)
                                .AddParameter("ReferenceType9", DbType.Decimal, 3, processspecflowItem.ReferenceType9)
                                .AddParameter("ReferenceRequired9", DbType.Decimal, 1, processspecflowItem.ReferenceRequired9 ? 1 : 0)
                                .AddParameter("ReferenceLookupList9", DbType.AnsiString, 2048, processspecflowItem.ReferenceLookupList9)
                                .AddParameter("ReferenceCondition9", DbType.AnsiString, 4000, processspecflowItem.ReferenceCondition9)
                                .AddParameter("ReferenceCaption10", DbType.AnsiString, 80, processspecflowItem.ReferenceCaption10)
                                .AddParameter("ReferenceType10", DbType.Decimal, 3, processspecflowItem.ReferenceType10)
                                .AddParameter("ReferenceRequired10", DbType.Decimal, 1, processspecflowItem.ReferenceRequired10 ? 1 : 0)
                                .AddParameter("ReferenceLookupList10", DbType.AnsiString, 2048, processspecflowItem.ReferenceLookupList10)
                                .AddParameter("ReferenceCondition10", DbType.AnsiString, 4000, processspecflowItem.ReferenceCondition10)
                                .AddParameter("SLA", DbType.Decimal, 5, processspecflowItem.SLA)
                                .AddParameter("SLADuration", DbType.Decimal, 5, processspecflowItem.SLADuration)
                                .AddParameter("Status", DbType.Decimal, 3, processspecflowItem.Status)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, processspecflowItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, processspecflowItem.UpdateDate)
                                .AddParameter("Id", DbType.Decimal, 9, processspecflowItem.Id)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla ProcessSpecFlow por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="processspecflowItems">Lista de instancia de ProcessSpecFlow</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Process.Contracts.General.ProcessSpecFlow> processspecflowItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Process.Contracts.General.ProcessSpecFlow item in processspecflowItems)
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
        /// Elimina un registro en la tabla ProcessSpecFlow por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del proceso.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int id, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM ProcessSpecFlow " +
                                    "WHERE Id=:Id AND CompanyId=:CompanyId")
                                .AddParameter("Id", DbType.Decimal, 9, id)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla ProcessSpecFlow por medio de su clave primaria.
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
        /// Recupera la cantidad de registros existentes en la tabla ProcessSpecFlow por medio de su clave primaria.
        /// </summary>
        /// <param name="id">Identificación única del proceso.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(int id, int companyId, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM ProcessSpecFlow " +
                                         "WHERE Id=:Id AND CompanyId=:CompanyId")
                               .AddParameter("Id", DbType.Decimal, 9, id)
                               .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla ProcessSpecFlow que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(Id) " +
                                          "FROM ProcessSpecFlow " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera una lista para selección de la tabla ProcessSpecFlow.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de LookUpValue</returns>
        public static List<Utilities.Contracts.LookUpValue> LookUp(int companyId, IDbConnection connection = null)
        {
            List<Utilities.Contracts.LookUpValue> result = new List<Utilities.Contracts.LookUpValue>();
            Database.Select("SELECT Id, Name " +
                              "FROM ProcessSpecFlow WHERE CompanyId=:CompanyId ORDER BY Name")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(new Utilities.Contracts.LookUpValue()
                            {
                                Code = reader.StringValue("Id"),
                                Description = reader.StringValue("Name")
                            });
                        }));
            return result;
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'ProcessSpecFlow'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Process.Contracts.General.ProcessSpecFlow DataReaderToProcessSpecFlow(System.Data.IDataReader reader, Architect.API.Process.Contracts.General.ProcessSpecFlow item = null, bool queryExt = false)

        {
            if (item == null)
            {
                item = new Architect.API.Process.Contracts.General.ProcessSpecFlow();
            }
            item.Id = reader.IntegerValue("Id");
            item.CompanyId = reader.IntegerValue("CompanyId");
            item.Name = reader.StringValue("Name");
            item.Description = reader.StringValue("Description");
            item.Alias = reader.StringValue("Alias");
            item.MailServer = reader.IntegerValue("MailServer");
            item.ReferenceCaption1 = reader.StringValue("ReferenceCaption1");
            item.ReferenceType1 = reader.IntegerValue("ReferenceType1");
            item.ReferenceRequired1 = reader.IntegerValue("ReferenceRequired1") == 1;
            item.ReferenceLookupList1 = reader.StringValue("ReferenceLookupList1");
            item.ReferenceCondition1 = reader.StringValue("ReferenceCondition1");
            item.ReferenceCaption2 = reader.StringValue("ReferenceCaption2");
            item.ReferenceType2 = reader.IntegerValue("ReferenceType2");
            item.ReferenceRequired2 = reader.IntegerValue("ReferenceRequired2") == 1;
            item.ReferenceLookupList2 = reader.StringValue("ReferenceLookupList2");
            item.ReferenceCondition2 = reader.StringValue("ReferenceCondition2");
            item.ReferenceCaption3 = reader.StringValue("ReferenceCaption3");
            item.ReferenceType3 = reader.IntegerValue("ReferenceType3");
            item.ReferenceRequired3 = reader.IntegerValue("ReferenceRequired3") == 1;
            item.ReferenceLookupList3 = reader.StringValue("ReferenceLookupList3");
            item.ReferenceCondition3 = reader.StringValue("ReferenceCondition3");
            item.ReferenceCaption4 = reader.StringValue("ReferenceCaption4");
            item.ReferenceType4 = reader.IntegerValue("ReferenceType4");
            item.ReferenceRequired4 = reader.IntegerValue("ReferenceRequired4") == 1;
            item.ReferenceLookupList4 = reader.StringValue("ReferenceLookupList4");
            item.ReferenceCondition4 = reader.StringValue("ReferenceCondition4");
            item.ReferenceCaption5 = reader.StringValue("ReferenceCaption5");
            item.ReferenceType5 = reader.IntegerValue("ReferenceType5");
            item.ReferenceRequired5 = reader.IntegerValue("ReferenceRequired5") == 1;
            item.ReferenceLookupList5 = reader.StringValue("ReferenceLookupList5");
            item.ReferenceCondition5 = reader.StringValue("ReferenceCondition5");
            item.ReferenceCaption6 = reader.StringValue("ReferenceCaption6");
            item.ReferenceType6 = reader.IntegerValue("ReferenceType6");
            item.ReferenceRequired6 = reader.IntegerValue("ReferenceRequired6") == 1;
            item.ReferenceLookupList6 = reader.StringValue("ReferenceLookupList6");
            item.ReferenceCondition6 = reader.StringValue("ReferenceCondition6");
            item.ReferenceCaption7 = reader.StringValue("ReferenceCaption7");
            item.ReferenceType7 = reader.IntegerValue("ReferenceType7");
            item.ReferenceRequired7 = reader.IntegerValue("ReferenceRequired7") == 1;
            item.ReferenceLookupList7 = reader.StringValue("ReferenceLookupList7");
            item.ReferenceCondition7 = reader.StringValue("ReferenceCondition7");
            item.ReferenceCaption8 = reader.StringValue("ReferenceCaption8");
            item.ReferenceType8 = reader.IntegerValue("ReferenceType8");
            item.ReferenceRequired8 = reader.IntegerValue("ReferenceRequired8") == 1;
            item.ReferenceLookupList8 = reader.StringValue("ReferenceLookupList8");
            item.ReferenceCondition8 = reader.StringValue("ReferenceCondition8");
            item.ReferenceCaption9 = reader.StringValue("ReferenceCaption9");
            item.ReferenceType9 = reader.IntegerValue("ReferenceType9");
            item.ReferenceRequired9 = reader.IntegerValue("ReferenceRequired9") == 1;
            item.ReferenceLookupList9 = reader.StringValue("ReferenceLookupList9");
            item.ReferenceCondition9 = reader.StringValue("ReferenceCondition9");
            item.ReferenceCaption10 = reader.StringValue("ReferenceCaption10");
            item.ReferenceType10 = reader.IntegerValue("ReferenceType10");
            item.ReferenceRequired10 = reader.IntegerValue("ReferenceRequired10") == 1;
            item.ReferenceLookupList10 = reader.StringValue("ReferenceLookupList10");
            item.ReferenceCondition10 = reader.StringValue("ReferenceCondition10");
            item.SLA = reader.IntegerValue("SLA");
            item.SLADuration = reader.IntegerValue("SLADuration");
            item.Status = reader.IntegerValue("Status");
            item.UpdateUserCode = reader.IntegerValue("UpdateUserCode");
            item.UpdateUserName = reader.StringValue("UpdateUserName");
            item.UpdateDate = reader.DateTimeValue("UpdateDate");

            if (queryExt)
            {
                item.RoleNames = reader.StringValue("Roles");
            }
            return item;
        }

    }

}

