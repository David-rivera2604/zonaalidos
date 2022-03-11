using Architect.DataFactory;
using Architect.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using DbType = Architect.DataFactory.Enumerations.DbType;

namespace Architect.API.Core.DataAccess.Security
{
    /// <summary>
    /// Usuarios registrados.
    /// </summary>
    public sealed partial class UserMember
    {

        /// <summary>
        /// Crea un registro en la tabla UserMember.
        /// </summary>
        /// <param name="usermemberItem">Instancia de UserMember</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros creados.</returns>
        public static int Create(Architect.API.Core.Contracts.Security.UserMember usermemberItem, IDbConnection connection = null)
        {
            if (usermemberItem.UpdateDate.IsEmpty())
            {
                usermemberItem.UpdateDate = DateTime.Now;
            }
            return Database.Insert("INSERT INTO UserMember (UserId, CompanyId, UserName, EMail, Password, OldPassword, IdentificationType, Identification, FirstName, LastName, BirthDate, FailedPasswordCount, SecurityLevel, IsLockedOut, LockedOutDate, PasswordChangedDate, OneTimePassword, LoginDate, ManagerId, AccessKey, BranchOffice, Reference, Position, PhoneNumber, SalesChannel, InitialNavigationCode, CustomData, RecordStatus, UpdateUserCode, UpdateDate) " +
                                                 "VALUES(:UserId, :CompanyId, :UserName, :EMail, :Password, :OldPassword, :IdentificationType, :Identification, :FirstName, :LastName, :BirthDate, :FailedPasswordCount, :SecurityLevel, :IsLockedOut, :LockedOutDate, :PasswordChangedDate, :OneTimePassword, :LoginDate, :ManagerId, :AccessKey, :BranchOffice, :Reference, :Position, :PhoneNumber, :SalesChannel, :InitialNavigationCode, :CustomData, :RecordStatus, :UpdateUserCode, :UpdateDate)")
                            .AddParameter("UserId", DbType.Decimal, 9, usermemberItem.UserId)
                            .AddParameter("CompanyId", DbType.Decimal, 5, usermemberItem.CompanyId)
                            .AddParameter("UserName", DbType.AnsiString, 35, usermemberItem.UserName)
                            .AddParameter("EMail", DbType.AnsiString, 120, usermemberItem.EMail)
                            .AddParameter("Password", DbType.AnsiString, 255, usermemberItem.Password)
                            .AddParameter("OldPassword", DbType.AnsiString, 255, usermemberItem.OldPassword)
                            .AddParameter("IdentificationType", DbType.Decimal, 3, usermemberItem.IdentificationType)
                            .AddParameter("Identification", DbType.AnsiString, 20, usermemberItem.Identification)
                            .AddParameter("FirstName", DbType.AnsiString, 35, usermemberItem.FirstName)
                            .AddParameter("LastName", DbType.AnsiString, 35, usermemberItem.LastName)
                            .AddParameter("BirthDate", DbType.DateTime, 9, usermemberItem.BirthDate)
                            .AddParameter("FailedPasswordCount", DbType.Decimal, 3, usermemberItem.FailedPasswordCount)
                            .AddParameter("SecurityLevel", DbType.Decimal, 3, usermemberItem.SecurityLevel)
                            .AddParameter("IsLockedOut", DbType.Decimal, 1, usermemberItem.IsLockedOut ? 1 : 0)
                            .AddParameter("LockedOutDate", DbType.DateTime, 9, usermemberItem.LockedOutDate)
                            .AddParameter("PasswordChangedDate", DbType.DateTime, 9, usermemberItem.PasswordChangedDate)
                            .AddParameter("OneTimePassword", DbType.AnsiStringFixedLength, 6, usermemberItem.OneTimePassword)
                            .AddParameter("LoginDate", DbType.DateTime, 9, usermemberItem.LoginDate)
                            .AddParameter("ManagerId", DbType.Decimal, 9, usermemberItem.ManagerId)
                            .AddParameter("AccessKey", DbType.AnsiString, 20, usermemberItem.AccessKey)
                            .AddParameter("BranchOffice", DbType.Decimal, 5, usermemberItem.BranchOffice)
                            .AddParameter("Reference", DbType.AnsiString, 36, usermemberItem.Reference)
                            .AddParameter("Position", DbType.Decimal, 5, usermemberItem.Position)
                            .AddParameter("PhoneNumber", DbType.AnsiString, 20, usermemberItem.PhoneNumber)
                            .AddParameter("SalesChannel", DbType.Decimal, 9, usermemberItem.SalesChannel)
                            .AddParameter("InitialNavigationCode", DbType.AnsiStringFixedLength, 8, usermemberItem.InitialNavigationCode)
                            .AddParameter("CustomData", DbType.AnsiString, 2000, usermemberItem.CustomData)
                            .AddParameter("RecordStatus", DbType.Decimal, 5, usermemberItem.RecordStatus)
                            .AddParameter("UpdateUserCode", DbType.Decimal, 9, usermemberItem.UpdateUserCode)
                            .AddParameter("UpdateDate", DbType.DateTime, 0, usermemberItem.UpdateDate)
                            .Execute(connection, "Research");
        }

        /// <summary>
        /// Crea una lista de registros en la tabla UserMember.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="usermemberItems">Lista de instancia de UserMember</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Create(List<Architect.API.Core.Contracts.Security.UserMember> usermemberItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.Security.UserMember item in usermemberItems)
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
        /// Recupera un registro en la tabla UserMember por medio de su clave primaria.
        /// </summary>
        /// <param name="userid">Identificación del usuario.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de UserMember</returns>
        public static Architect.API.Core.Contracts.Security.UserMember Retrieve(int userid, int companyId, IDbConnection connection = null)
        {
            Architect.API.Core.Contracts.Security.UserMember result = null;
            Database.Select("SELECT UserMember.UserId, UserMember.CompanyId, UserMember.UserName, UserMember.EMail, UserMember.Password, UserMember.OldPassword, UserMember.IdentificationType, UserMember.Identification, UserMember.FirstName, UserMember.LastName, UserMember.BirthDate, UserMember.FailedPasswordCount, UserMember.SecurityLevel, UserMember.IsLockedOut, UserMember.LockedOutDate, UserMember.PasswordChangedDate, UserMember.OneTimePassword, UserMember.LoginDate, UserMember.ManagerId, UserMember.AccessKey, UserMember.BranchOffice, UserMember.Reference, UserMember.Position, UserMember.PhoneNumber, UserMember.SalesChannel, UserMember.InitialNavigationCode, UserMember.CustomData, UserMember.RecordStatus, UserMember.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, UserMember.UpdateDate " +
                              "FROM UserMember LEFT JOIN UserMember um ON um.UserId = UserMember.UpdateUserCode " +
                             "WHERE UserMember.UserId=:UserId AND UserMember.CompanyId=:CompanyId")
                        .AddParameter("UserId", DbType.Decimal, 9, userid)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result = DataReaderToUserMember(reader);
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla UserMember.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de UserMember</returns>
        public static List<Architect.API.Core.Contracts.Security.UserMember> RetrieveAll(int companyId, string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.Security.UserMember> result = new List<Architect.API.Core.Contracts.Security.UserMember>();
            Database.Select("SELECT UserMember.UserId, UserMember.CompanyId, UserMember.UserName, UserMember.EMail, UserMember.Password, UserMember.OldPassword, UserMember.IdentificationType, UserMember.Identification, UserMember.FirstName, UserMember.LastName, UserMember.BirthDate, UserMember.FailedPasswordCount, UserMember.SecurityLevel, UserMember.IsLockedOut, UserMember.LockedOutDate, UserMember.PasswordChangedDate, UserMember.OneTimePassword, UserMember.LoginDate, UserMember.ManagerId, UserMember.AccessKey, UserMember.BranchOffice, UserMember.Reference, UserMember.Position, UserMember.PhoneNumber, UserMember.SalesChannel, UserMember.InitialNavigationCode, UserMember.CustomData, UserMember.RecordStatus, UserMember.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, UserMember.UpdateDate " +
                              "FROM UserMember LEFT JOIN UserMember um ON um.UserId = UserMember.UpdateUserCode " +
                             "WHERE UserMember.CompanyId=:CompanyId" + filter)
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToUserMember(reader));
                        }));
            return result;
        }

        /// <summary>
        /// Recupera una lista de registros en la tabla UserMember.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de UserMember</returns>
        public static List<Architect.API.Core.Contracts.Security.UserMember> RetrieveAll(int companyId, string filter, int beginIndex, int endIndex, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.Security.UserMember> result = new List<Architect.API.Core.Contracts.Security.UserMember>();
            if (beginIndex == 0)
            {
                beginIndex = 1;
            }
            if (endIndex == 0 || endIndex < beginIndex)
            {
                endIndex = int.MaxValue;
            }
            Database.Select("SELECT * FROM (" +
                            "SELECT UserMember.UserId, UserMember.CompanyId, UserMember.UserName, UserMember.EMail, UserMember.Password, UserMember.OldPassword, UserMember.IdentificationType, UserMember.Identification, UserMember.FirstName, UserMember.LastName, UserMember.BirthDate, UserMember.FailedPasswordCount, UserMember.SecurityLevel, UserMember.IsLockedOut, UserMember.LockedOutDate, UserMember.PasswordChangedDate, UserMember.OneTimePassword, UserMember.LoginDate, UserMember.ManagerId, UserMember.AccessKey, UserMember.BranchOffice, UserMember.Reference, UserMember.Position, UserMember.PhoneNumber, UserMember.SalesChannel, UserMember.InitialNavigationCode, UserMember.CustomData, UserMember.RecordStatus, UserMember.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, UserMember.UpdateDate " +
                                   ", ROW_NUMBER() OVER (ORDER BY UserMember.UserId DESC) RowNumber " +
                              "FROM UserMember LEFT JOIN UserMember um ON um.UserId = UserMember.UpdateUserCode " +
                             "WHERE UserMember.CompanyId=:CompanyId" + filter +
                               ") WHERE RowNumber BETWEEN :beginIndex AND :endIndex")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .AddParameter(parameters)
                        .AddParameter("beginIndex", DbType.Decimal, 9, beginIndex)
                        .AddParameter("endIndex", DbType.Decimal, 9, endIndex)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(DataReaderToUserMember(reader));
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
                if (filter.IndexOf("|")>-1)
                {
                    condition = filter.Substring( filter.IndexOf("|"));
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
                result += " UPPER(UserMember.UserName) LIKE '%" + filter.ToUpper() + "%' ";
                result += " OR UPPER(UserMember.EMail) LIKE '%" + filter.ToUpper() + "%' ";
                result += " OR UPPER(UserMember.FirstName) LIKE '%" + filter.ToUpper() + "%' ";
                result += " OR UPPER(UserMember.LastName) LIKE '%" + filter.ToUpper() + "%' ";

                result += ")";
                if (condition.IsNotEmpty())
                {
                    result += Database.FilterFactory(condition, "UserMember");
                }				
            }
            return result;
        }

        /// <summary>
        /// Último valor asignado a clave única de la tabla UserMember.
        /// </summary>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Último valor asignado.</returns>
        public static int RetrieveLastKey(IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT NVL(MAX(UserId),0) " +
                                     "FROM UserMember")
                                .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Actualiza un registro en la tabla UserMember por medio de su clave primaria.
        /// </summary>
        /// <param name="usermemberItem">Instancia de UserMember</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int Update(Architect.API.Core.Contracts.Security.UserMember usermemberItem, IDbConnection connection = null)
        {
            if (usermemberItem.UpdateDate.IsEmpty())
            {
                usermemberItem.UpdateDate = DateTime.Now;
            }
            return Database.Update("UPDATE UserMember " +
                                      "SET CompanyId=:CompanyId, UserName=:UserName, EMail=:EMail, Password=:Password, OldPassword=:OldPassword, IdentificationType=:IdentificationType, Identification=:Identification, FirstName=:FirstName, LastName=:LastName, BirthDate=:BirthDate, FailedPasswordCount=:FailedPasswordCount, SecurityLevel=:SecurityLevel, IsLockedOut=:IsLockedOut, LockedOutDate=:LockedOutDate, PasswordChangedDate=:PasswordChangedDate, OneTimePassword=:OneTimePassword, LoginDate=:LoginDate, ManagerId=:ManagerId, AccessKey=:AccessKey, BranchOffice=:BranchOffice, Reference=:Reference, Position=:Position, PhoneNumber=:PhoneNumber, SalesChannel=:SalesChannel, InitialNavigationCode=:InitialNavigationCode, CustomData=:CustomData, RecordStatus=:RecordStatus, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
                                    "WHERE UserId=:UserId")
                                .AddParameter("CompanyId", DbType.Decimal, 5, usermemberItem.CompanyId)
                                .AddParameter("UserName", DbType.AnsiString, 35, usermemberItem.UserName)
                                .AddParameter("EMail", DbType.AnsiString, 120, usermemberItem.EMail)
                                .AddParameter("Password", DbType.AnsiString, 255, usermemberItem.Password)
                                .AddParameter("OldPassword", DbType.AnsiString, 255, usermemberItem.OldPassword)
                                .AddParameter("IdentificationType", DbType.Decimal, 3, usermemberItem.IdentificationType)
                                .AddParameter("Identification", DbType.AnsiString, 20, usermemberItem.Identification)
                                .AddParameter("FirstName", DbType.AnsiString, 35, usermemberItem.FirstName)
                                .AddParameter("LastName", DbType.AnsiString, 35, usermemberItem.LastName)
                                .AddParameter("BirthDate", DbType.DateTime, 9, usermemberItem.BirthDate)
                                .AddParameter("FailedPasswordCount", DbType.Decimal, 3, usermemberItem.FailedPasswordCount)
                                .AddParameter("SecurityLevel", DbType.Decimal, 3, usermemberItem.SecurityLevel)
                                .AddParameter("IsLockedOut", DbType.Decimal, 1, usermemberItem.IsLockedOut ? 1 : 0)
                                .AddParameter("LockedOutDate", DbType.DateTime, 9, usermemberItem.LockedOutDate)
                                .AddParameter("PasswordChangedDate", DbType.DateTime, 9, usermemberItem.PasswordChangedDate)
                                .AddParameter("OneTimePassword", DbType.AnsiStringFixedLength, 6, usermemberItem.OneTimePassword)
                                .AddParameter("LoginDate", DbType.DateTime, 9, usermemberItem.LoginDate)
                                .AddParameter("ManagerId", DbType.Decimal, 9, usermemberItem.ManagerId)
                                .AddParameter("AccessKey", DbType.AnsiString, 20, usermemberItem.AccessKey)
                                .AddParameter("BranchOffice", DbType.Decimal, 5, usermemberItem.BranchOffice)
                                .AddParameter("Reference", DbType.AnsiString, 36, usermemberItem.Reference)
                                .AddParameter("Position", DbType.Decimal, 5, usermemberItem.Position)
                                .AddParameter("PhoneNumber", DbType.AnsiString, 20, usermemberItem.PhoneNumber)
                                .AddParameter("SalesChannel", DbType.Decimal, 9, usermemberItem.SalesChannel)
                                .AddParameter("InitialNavigationCode", DbType.AnsiStringFixedLength, 8, usermemberItem.InitialNavigationCode)
                                .AddParameter("CustomData", DbType.AnsiString, 2000, usermemberItem.CustomData)
                                .AddParameter("RecordStatus", DbType.Decimal, 5, usermemberItem.RecordStatus)
                                .AddParameter("UpdateUserCode", DbType.Decimal, 9, usermemberItem.UpdateUserCode)
                                .AddParameter("UpdateDate", DbType.DateTime, 0, usermemberItem.UpdateDate)
                                .AddParameter("UserId", DbType.Decimal, 9, usermemberItem.UserId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla UserMember por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="usermemberItems">Lista de instancia de UserMember</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Update(List<Architect.API.Core.Contracts.Security.UserMember> usermemberItems, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (Architect.API.Core.Contracts.Security.UserMember item in usermemberItems)
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
        /// Elimina un registro en la tabla UserMember por medio de su clave primaria.
        /// </summary>
        /// <param name="userid">Identificación del usuario.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros eliminados.</returns>
        public static int Delete(int userid, int companyId, IDbConnection connection = null)
        {
            return Database.Delete("DELETE FROM UserMember " +
                                    "WHERE UserId=:UserId AND CompanyId=:CompanyId")
                                .AddParameter("UserId", DbType.Decimal, 9, userid)
                                .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                                .Execute(connection, "Research");
        }

        /// <summary>
        /// Actualiza una lista de registros en la tabla UserMember por medio de su clave primaria.
        /// </summary>
        /// <remarks>Complemento para procesamiento masivo</remarks>
        /// <param name="useridList">Lista de Identificación del usuario.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista con el resultado de la creación de cada instancia.</returns>
        public static List<int> Delete(List<int> useridList, int companyId, IDbConnection connection = null)
        {
            List<int> result = new List<int>();
            bool local = false;

            if (connection == null)
            {
                connection = Architect.DataFactory.Database.OpenConnection("Research");
                local = true;
            }
            foreach (int item in useridList)
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
        /// Recupera la cantidad de registros existentes en la tabla UserMember por medio de su clave primaria.
        /// </summary>
        /// <param name="userid">Identificación del usuario.</param>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(int userid, int companyId, IDbConnection connection = null)
        {

            return (int)Database.Select("SELECT COUNT(UserId) " +
                                          "FROM UserMember " +
                                         "WHERE UserId=:UserId AND CompanyId=:CompanyId")
                               .AddParameter("UserId", DbType.Decimal, 9, userid)
                               .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera la cantidad de registros existentes en la tabla UserMember que cumplen con el filtro.
        /// </summary>
        /// <param name="filter">Permite filtrar la lista de registros</param>
        /// <param name="parameters">Lista de parámetros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros encontrados.</returns>
        public static int Count(string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            return (int)Database.Select("SELECT COUNT(UserId) " +
                                          "FROM UserMember " + filter)
                               .AddParameter(parameters)
                               .QueryScalar<Decimal>(connection, "Research");
        }

        /// <summary>
        /// Recupera una lista para selección de la tabla UserMember.
        /// </summary>
        /// <param name="companyId">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de LookUpValue</returns>
        public static List<Utilities.Contracts.LookUpValue> LookUp(int companyId, IDbConnection connection = null)
        {
            List<Utilities.Contracts.LookUpValue> result = new List<Utilities.Contracts.LookUpValue>();
            Database.Select("SELECT UserId, UserName " +
                              "FROM UserMember WHERE CompanyId=:CompanyId ORDER BY UserName")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                        {
                            result.Add(new Utilities.Contracts.LookUpValue()
                            {
                                Code = reader.StringValue("UserId"),
                                Description = reader.StringValue("UserName")
                            });
                        }));
            return result;
        }

        /// <summary>
        /// Convierte una fila de un 'DataReader' a un clase de tipo 'UserMember'.
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <param name="item">Instancia pre creada</param>
        /// <returns>Instancia con la información de la fila del 'DataReader'</returns>
        public static Architect.API.Core.Contracts.Security.UserMember DataReaderToUserMember(System.Data.IDataReader reader, Architect.API.Core.Contracts.Security.UserMember item = null)
        {
            if (item == null)
            {
                item = new Architect.API.Core.Contracts.Security.UserMember();
            }
            item.UserId = reader.IntegerValue("UserId");
            item.CompanyId = reader.IntegerValue("CompanyId");
            item.UserName = reader.StringValue("UserName");
            item.EMail = reader.StringValue("EMail");
            item.Password = reader.StringValue("Password");
            item.OldPassword = reader.StringValue("OldPassword");
            item.IdentificationType = reader.IntegerValue("IdentificationType");
            item.Identification = reader.StringValue("Identification");
            item.FirstName = reader.StringValue("FirstName");
            item.LastName = reader.StringValue("LastName");
            item.BirthDate = reader.DateTimeValue("BirthDate");
            item.FailedPasswordCount = reader.IntegerValue("FailedPasswordCount");
            item.SecurityLevel = reader.IntegerValue("SecurityLevel");
            item.IsLockedOut = reader.IntegerValue("IsLockedOut") == 1;
            item.LockedOutDate = reader.DateTimeValue("LockedOutDate");
            item.PasswordChangedDate = reader.DateTimeValue("PasswordChangedDate");
            item.OneTimePassword = reader.StringValue("OneTimePassword");
            item.LoginDate = reader.DateTimeValue("LoginDate");
            item.ManagerId = reader.IntegerValue("ManagerId");
            item.AccessKey = reader.StringValue("AccessKey");
            item.BranchOffice = reader.IntegerValue("BranchOffice");
            item.Reference = reader.StringValue("Reference");
            item.Position = reader.IntegerValue("Position");
            item.PhoneNumber = reader.StringValue("PhoneNumber");
            item.SalesChannel = reader.IntegerValue("SalesChannel");
            item.InitialNavigationCode = reader.StringValue("InitialNavigationCode");
            item.CustomData = reader.StringValue("CustomData");
            item.RecordStatus = reader.IntegerValue("RecordStatus");
            item.UpdateUserCode = reader.IntegerValue("UpdateUserCode");
            item.UpdateUserName = reader.StringValue("UpdateUserName");
            item.UpdateDate = reader.DateTimeValue("UpdateDate");
            return item;
        }

        #region Custom Methods

        /// <summary>
        /// Recupera una lista para selección de la tabla RoleMember.
        /// </summary>
        /// <param name="companyid">Identificación de la compañía propietaria.</param>
        /// <param name="securitylevel">Nivel de seguridad.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de UserMember</returns>
        public static List<Architect.API.Core.Contracts.Security.UserMember> RetrieveAll(int companyid, int securitylevel, string filter, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.Security.UserMember> result = new List<Architect.API.Core.Contracts.Security.UserMember>();
            Architect.API.Core.Contracts.Security.UserMember item = null;
            Database.Select("SELECT UserMember.UserId, UserMember.CompanyId, UserMember.UserName, UserMember.EMail, UserMember.Password, UserMember.OldPassword, UserMember.IdentificationType, UserMember.Identification, UserMember.FirstName, UserMember.LastName, UserMember.BirthDate, UserMember.FailedPasswordCount, UserMember.SecurityLevel, UserMember.IsLockedOut, UserMember.LockedOutDate, UserMember.PasswordChangedDate, UserMember.OneTimePassword, UserMember.LoginDate, UserMember.ManagerId, UserMember.AccessKey, UserMember.BranchOffice, UserMember.Reference, UserMember.Position, UserMember.PhoneNumber, UserMember.SalesChannel, UserMember.InitialNavigationCode, UserMember.CustomData, UserMember.RecordStatus, UserMember.UpdateUserCode, UserMember.UpdateDate, um.FirstName || ' ' || um.LastName AS UpdateUserName, (SELECT LISTAGG(RM.ROLENAME , ', ') WITHIN GROUP (ORDER BY RM.ROLENAME ) FROM USERROLEMEMBER urm LEFT JOIN ROLEMEMBER rm ON rm.RoleId = urm.RoleId WHERE urm.UserId = UserMember.UserId) RoleList FROM UserMember LEFT JOIN UserMember um ON um.UserId = UserMember.UpdateUserCode  WHERE UserMember.CompanyId=:CompanyId AND UserMember.SecurityLevel<=:SecurityLevel" + filter)
                .AddParameter("CompanyId", DbType.Decimal, 5, companyid)
                .AddParameter("SecurityLevel", DbType.Decimal, 3, securitylevel)
                .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                {
                     item = DataReaderToUserMember(reader);
                     item.RoleList = reader.StringValue("RoleList");
                     result.Add(item);
                }));
            return result;
        }

        /// <summary>
        /// Recupera una lista con la información de correo electrónico de los usuario asociados a un rol.
        /// </summary>
        /// <param name="companyid">Identificación de la compañía propietaria.</param>
        /// <param name="rolename1"></param>
        /// <param name="rolename2"></param>
        /// <param name="rolename3"></param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de UserMember</returns>
        public static List<Architect.API.Core.Contracts.Security.UserMember> EmailInfoByRoleName(int companyid, string rolename1, string rolename2, string rolename3, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.Security.UserMember> result = new List<Architect.API.Core.Contracts.Security.UserMember>();
            Database.Select("SELECT UserMember.FirstName, UserMember.LastName, UserMember.Email FROM UserMember JOIN UserRoleMember urm ON urm.UserId=UserMember.UserId JOIN RoleMember rm ON rm.RoleId=urm.RoleId  WHERE UserMember.CompanyId=:CompanyId AND UserMember.RecordStatus=1 AND LOWER(rm.Rolename) IN (:Rolename1,:Rolename2,:Rolename3)")
                .AddParameter("CompanyId", DbType.Decimal, 5, companyid)
                .AddParameter("Rolename1", DbType.AnsiString, 255, rolename1)
                .AddParameter("Rolename2", DbType.AnsiString, 255, rolename2)
                .AddParameter("Rolename3", DbType.AnsiString, 255, rolename3)
                .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                {
                    result.Add(new Architect.API.Core.Contracts.Security.UserMember()
                    {
                        FirstName = reader.StringValue("FirstName"),
                        LastName = reader.StringValue("LastName"),
                        EMail = reader.StringValue("EMail")
                    });
                }));
            return result;
        }

        /// <summary>
        /// Recupera un registro en la tabla UserMember por medio del e-mail del usuario.
        /// </summary>
        /// <param name="email">E-Mail del Usuario.</param>
        /// <param name="companyid">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de UserMember</returns>
        public static Architect.API.Core.Contracts.Security.UserMember RetrieveByEMail(string email, int companyid, IDbConnection connection = null)
        {
            Architect.API.Core.Contracts.Security.UserMember result = null;
            Database.Select("SELECT UserId, UserName, EMail, Password, OldPassword, FirstName, LastName, FailedPasswordCount, SecurityLevel, IsLockedOut, LockedOutDate, OneTimePassword, PasswordChangedDate, ManagerId, RecordStatus, CompanyId, LoginDate, BranchOffice, IdentificationType, Identification, InitialNavigationCode FROM UserMember WHERE LOWER(EMail)=:EMail AND CompanyId=:CompanyId")
                .AddParameter("EMail", DbType.AnsiString, 120, email)
                .AddParameter("CompanyId", DbType.Decimal, 5, companyid)
                .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                {
                    result = new Architect.API.Core.Contracts.Security.UserMember()
                    {
                        UserId = reader.IntegerValue("UserId"),
                        UserName = reader.StringValue("UserName"),
                        EMail = reader.StringValue("EMail"),
                        Password = reader.StringValue("Password"),
                        OldPassword = reader.StringValue("OldPassword"),
                        FirstName = reader.StringValue("FirstName"),
                        LastName = reader.StringValue("LastName"),
                        FailedPasswordCount = reader.IntegerValue("FailedPasswordCount"),
                        SecurityLevel = reader.IntegerValue("SecurityLevel"),
                        IsLockedOut = reader.IntegerValue("IsLockedOut") == 1,
                        LockedOutDate = reader.DateTimeValue("LockedOutDate"),
                        OneTimePassword = reader.StringValue("OneTimePassword"),
                        PasswordChangedDate = reader.DateTimeValue("PasswordChangedDate"),
                        ManagerId = reader.IntegerValue("ManagerId"),
                        RecordStatus = reader.IntegerValue("RecordStatus"),
                        CompanyId = reader.IntegerValue("CompanyId"),
                        LoginDate = reader.DateTimeValue("LoginDate"),
                        BranchOffice = reader.IntegerValue("BranchOffice"),
                        IdentificationType = reader.IntegerValue("IdentificationType"),
                        Identification = reader.StringValue("Identification"),
                        InitialNavigationCode = reader.StringValue("InitialNavigationCode")
                    };
                }));
            return result;
        }

        /// <summary>
        /// Recupera un registro en la tabla UserMember por medio del nombre del usuario.
        /// </summary>
        /// <param name="username">Nombre Usuario.</param>
        /// <param name="companyid">Identificación de la compañía propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de UserMember</returns>
        public static Architect.API.Core.Contracts.Security.UserMember RetrieveByUserName(string username, int companyid, IDbConnection connection = null)
        {
            Architect.API.Core.Contracts.Security.UserMember result = null;
            Database.Select("SELECT UserId, UserName, EMail, Password, OldPassword, FirstName, LastName, FailedPasswordCount, SecurityLevel, IsLockedOut, LockedOutDate, OneTimePassword, PasswordChangedDate, ManagerId, RecordStatus, CompanyId, LoginDate, BranchOffice, IdentificationType, Identification, InitialNavigationCode FROM UserMember WHERE LOWER(UserName)=:UserName AND CompanyId=:CompanyId")
                .AddParameter("UserName", DbType.AnsiString, 35, username)
                .AddParameter("CompanyId", DbType.Decimal, 5, companyid)
                .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                {
                    result = new Architect.API.Core.Contracts.Security.UserMember()
                    {
                        UserId = reader.IntegerValue("UserId"),
                        UserName = reader.StringValue("UserName"),
                        EMail = reader.StringValue("EMail"),
                        Password = reader.StringValue("Password"),
                        OldPassword = reader.StringValue("OldPassword"),
                        FirstName = reader.StringValue("FirstName"),
                        LastName = reader.StringValue("LastName"),
                        FailedPasswordCount = reader.IntegerValue("FailedPasswordCount"),
                        SecurityLevel = reader.IntegerValue("SecurityLevel"),
                        IsLockedOut = reader.IntegerValue("IsLockedOut") == 1,
                        LockedOutDate = reader.DateTimeValue("LockedOutDate"),
                        OneTimePassword = reader.StringValue("OneTimePassword"),
                        PasswordChangedDate = reader.DateTimeValue("PasswordChangedDate"),
                        ManagerId = reader.IntegerValue("ManagerId"),
                        RecordStatus = reader.IntegerValue("RecordStatus"),
                        CompanyId = reader.IntegerValue("CompanyId"),
                        LoginDate = reader.DateTimeValue("LoginDate"),
                        BranchOffice = reader.IntegerValue("BranchOffice"),
                        IdentificationType = reader.IntegerValue("IdentificationType"),
                        Identification = reader.StringValue("Identification"),
                        InitialNavigationCode = reader.StringValue("InitialNavigationCode")
                    };
                }));
            return result;
        }

        /// <summary>
        /// Recupera un registro en la tabla UserMember por medio de una clave de acceso.
        /// </summary>
        /// <param name="accesskey">valor usado para identificar un usuario para servicios.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de UserMember</returns>
        public static Architect.API.Core.Contracts.Security.UserMember RetrieveByAccessKey(string accesskey, IDbConnection connection = null)
        {
            Architect.API.Core.Contracts.Security.UserMember result = null;
            Database.Select("SELECT UserId, UserName, EMail, Password, OldPassword, FirstName, LastName, FailedPasswordCount, SecurityLevel, IsLockedOut, LockedOutDate, OneTimePassword, PasswordChangedDate, ManagerId, RecordStatus, CompanyId, LoginDate, BranchOffice, IdentificationType, Identification, InitialNavigationCode FROM UserMember WHERE AccessKey=:AccessKey")
                .AddParameter("AccessKey", DbType.AnsiString, 20, accesskey)
                .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                {
                    result = new Architect.API.Core.Contracts.Security.UserMember()
                    {
                        UserId = reader.IntegerValue("UserId"),
                        UserName = reader.StringValue("UserName"),
                        EMail = reader.StringValue("EMail"),
                        Password = reader.StringValue("Password"),
                        OldPassword = reader.StringValue("OldPassword"),
                        FirstName = reader.StringValue("FirstName"),
                        LastName = reader.StringValue("LastName"),
                        FailedPasswordCount = reader.IntegerValue("FailedPasswordCount"),
                        SecurityLevel = reader.IntegerValue("SecurityLevel"),
                        IsLockedOut = reader.IntegerValue("IsLockedOut") == 1,
                        LockedOutDate = reader.DateTimeValue("LockedOutDate"),
                        OneTimePassword = reader.StringValue("OneTimePassword"),
                        PasswordChangedDate = reader.DateTimeValue("PasswordChangedDate"),
                        ManagerId = reader.IntegerValue("ManagerId"),
                        RecordStatus = reader.IntegerValue("RecordStatus"),
                        CompanyId = reader.IntegerValue("CompanyId"),
                        LoginDate = reader.DateTimeValue("LoginDate"),
                        BranchOffice = reader.IntegerValue("BranchOffice"),
                        IdentificationType = reader.IntegerValue("IdentificationType"),
                        Identification = reader.StringValue("Identification"),
                        InitialNavigationCode = reader.StringValue("InitialNavigationCode")
                    };
                }));
            return result;
        }

        /// <summary>
        /// Actualiza los campos de control de acceso de la tabla UserMember por medio de su clave primaria.
        /// </summary>
        /// <param name="usermemberItem">Instancia de UserMember</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Cantidad de registros actualizados.</returns>
        public static int InternalUpdate(Architect.API.Core.Contracts.Security.UserMember usermemberItem, IDbConnection connection = null)
        {
            return Database.Update("UPDATE UserMember SET Password=:Password, OldPassword=:OldPassword, FailedPasswordCount=:FailedPasswordCount, SecurityLevel=:SecurityLevel, IsLockedOut=:IsLockedOut, LockedOutDate=:LockedOutDate, PasswordChangedDate=:PasswordChangedDate, OneTimePassword=:OneTimePassword, LoginDate=:LoginDate WHERE UserId=:UserId AND CompanyId=:CompanyId")
                .AddParameter("Password", DbType.AnsiString, 255, usermemberItem.Password)
                .AddParameter("OldPassword", DbType.AnsiString, 255, usermemberItem.OldPassword)
                .AddParameter("FailedPasswordCount", DbType.Decimal, 3, usermemberItem.FailedPasswordCount)
                .AddParameter("SecurityLevel", DbType.Decimal, 3, usermemberItem.SecurityLevel)
                .AddParameter("IsLockedOut", DbType.Decimal, 1, usermemberItem.IsLockedOut? 1 : 0)
                .AddParameter("LockedOutDate", DbType.DateTime, 9, usermemberItem.LockedOutDate)
                .AddParameter("PasswordChangedDate", DbType.DateTime, 9, usermemberItem.PasswordChangedDate)
                .AddParameter("OneTimePassword", DbType.AnsiStringFixedLength, 6, usermemberItem.OneTimePassword)
                .AddParameter("LoginDate", DbType.DateTime, 9, usermemberItem.LoginDate)
                .AddParameter("UserId", DbType.Decimal, 9, usermemberItem.UserId)
                .AddParameter("CompanyId", DbType.Decimal, 5, usermemberItem.CompanyId)
                .Execute(connection, "Research");
        }

        #endregion  Custom Methods

    }

}

