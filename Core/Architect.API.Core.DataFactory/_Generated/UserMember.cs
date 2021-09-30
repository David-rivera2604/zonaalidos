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
    public static partial class UserMember
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
            return Database.Insert("INSERT INTO UserMember (UserId, CompanyId, UserName, EMail, Password, OldPassword, IdentificationType, Identification, FirstName, LastName, BirthDate, FailedPasswordCount, SecurityLevel, IsLockedOut, LockedOutDate, PasswordChangedDate, OneTimePassword, LoginDate, ManagerId, AccessKey, BranchOffice, Reference, Position, PhoneNumber, SalesChannel, CustomData, RecordStatus, UpdateUserCode, UpdateDate) " +
                                                 "VALUES(:UserId, :CompanyId, :UserName, :EMail, :Password, :OldPassword, :IdentificationType, :Identification, :FirstName, :LastName, :BirthDate, :FailedPasswordCount, :SecurityLevel, :IsLockedOut, :LockedOutDate, :PasswordChangedDate, :OneTimePassword, :LoginDate, :ManagerId, :AccessKey, :BranchOffice, :Reference, :Position, :PhoneNumber, :SalesChannel, :CustomData, :RecordStatus, :UpdateUserCode, :UpdateDate)")
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
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Instancia de UserMember</returns>
        public static Architect.API.Core.Contracts.Security.UserMember Retrieve(int userid, int companyId, IDbConnection connection = null)
        {
            Architect.API.Core.Contracts.Security.UserMember result = null;
            Database.Select("SELECT UserMember.UserId, UserMember.CompanyId, UserMember.UserName, UserMember.EMail, UserMember.Password, UserMember.OldPassword, UserMember.IdentificationType, UserMember.Identification, UserMember.FirstName, UserMember.LastName, UserMember.BirthDate, UserMember.FailedPasswordCount, UserMember.SecurityLevel, UserMember.IsLockedOut, UserMember.LockedOutDate, UserMember.PasswordChangedDate, UserMember.OneTimePassword, UserMember.LoginDate, UserMember.ManagerId, UserMember.AccessKey, UserMember.BranchOffice, UserMember.Reference, UserMember.Position, UserMember.PhoneNumber, UserMember.SalesChannel, UserMember.CustomData, UserMember.RecordStatus, UserMember.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, UserMember.UpdateDate " +
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
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="parameters">Lista de parametros para complemento.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de UserMember</returns>
        public static List<Architect.API.Core.Contracts.Security.UserMember> RetrieveAll(int companyId, string filter, List<DataFactory.Contracts.Parameter> parameters = null, IDbConnection connection = null)
        {
            List<Architect.API.Core.Contracts.Security.UserMember> result = new List<Architect.API.Core.Contracts.Security.UserMember>();
            Database.Select("SELECT UserMember.UserId, UserMember.CompanyId, UserMember.UserName, UserMember.EMail, UserMember.Password, UserMember.OldPassword, UserMember.IdentificationType, UserMember.Identification, UserMember.FirstName, UserMember.LastName, UserMember.BirthDate, UserMember.FailedPasswordCount, UserMember.SecurityLevel, UserMember.IsLockedOut, UserMember.LockedOutDate, UserMember.PasswordChangedDate, UserMember.OneTimePassword, UserMember.LoginDate, UserMember.ManagerId, UserMember.AccessKey, UserMember.BranchOffice, UserMember.Reference, UserMember.Position, UserMember.PhoneNumber, UserMember.SalesChannel, UserMember.CustomData, UserMember.RecordStatus, UserMember.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, UserMember.UpdateDate " +
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
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="filter">Filtro personalizado.</param>
        /// <param name="beginIndex">Indice inicial para el paginado.</param>
        /// <param name="endIndex">Indice final para el paginado.</param>
        /// <param name="parameters">Lista de parametros para complemento.</param>
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
                            "SELECT UserMember.UserId, UserMember.CompanyId, UserMember.UserName, UserMember.EMail, UserMember.Password, UserMember.OldPassword, UserMember.IdentificationType, UserMember.Identification, UserMember.FirstName, UserMember.LastName, UserMember.BirthDate, UserMember.FailedPasswordCount, UserMember.SecurityLevel, UserMember.IsLockedOut, UserMember.LockedOutDate, UserMember.PasswordChangedDate, UserMember.OneTimePassword, UserMember.LoginDate, UserMember.ManagerId, UserMember.AccessKey, UserMember.BranchOffice, UserMember.Reference, UserMember.Position, UserMember.PhoneNumber, UserMember.SalesChannel, UserMember.CustomData, UserMember.RecordStatus, UserMember.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, UserMember.UpdateDate " +
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
        /// Último valor asignado a clave unica de la tabla UserMember.
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
                                      "SET CompanyId=:CompanyId, UserName=:UserName, EMail=:EMail, Password=:Password, OldPassword=:OldPassword, IdentificationType=:IdentificationType, Identification=:Identification, FirstName=:FirstName, LastName=:LastName, BirthDate=:BirthDate, FailedPasswordCount=:FailedPasswordCount, SecurityLevel=:SecurityLevel, IsLockedOut=:IsLockedOut, LockedOutDate=:LockedOutDate, PasswordChangedDate=:PasswordChangedDate, OneTimePassword=:OneTimePassword, LoginDate=:LoginDate, ManagerId=:ManagerId, AccessKey=:AccessKey, BranchOffice=:BranchOffice, Reference=:Reference, Position=:Position, PhoneNumber=:PhoneNumber, SalesChannel=:SalesChannel, CustomData=:CustomData, RecordStatus=:RecordStatus, UpdateUserCode=:UpdateUserCode, UpdateDate=:UpdateDate " +
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
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
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
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
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
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
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
        /// <param name="parameters">Lista de parametros para complemento.</param>
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
        /// <param name="companyId">Identificación de la compañia propietaria.</param>
        /// <param name="connection">Instancia de una conexión compartida</param>
        /// <returns>Lista de instancias de LookUpValue</returns>
        public static List<DataFactory.Contracts.LookUpValue> LookUp(int companyId, IDbConnection connection = null)
        {
            List<DataFactory.Contracts.LookUpValue> result = new List<DataFactory.Contracts.LookUpValue>();
            Database.Select("SELECT UserId, UserName " +
                              "FROM UserMember WHERE CompanyId=:CompanyId ORDER BY UserName")
                        .AddParameter("CompanyId", DbType.Decimal, 5, companyId)
                        .Query(connection, "Research", new Action<System.Data.IDataReader>((reader) =>
                            {
                                result.Add(new DataFactory.Contracts.LookUpValue()
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
            item.CustomData = reader.StringValue("CustomData");
            item.RecordStatus = reader.IntegerValue("RecordStatus");
            item.UpdateUserCode = reader.IntegerValue("UpdateUserCode");
            item.UpdateUserName = reader.StringValue("UpdateUserName");
            item.UpdateDate = reader.DateTimeValue("UpdateDate");
            return item;
        }

    }

}

