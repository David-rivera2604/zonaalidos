Imports Architect.Common.Proxy

Namespace Architect.API.Core.DataAccess.Security

    ''' <summary>
    ''' Usuarios registrados.
    ''' </summary>
    Partial Public NotInheritable Class UserMember

        ''' <summary>
        ''' Crea un registro en la tabla UserMember.
        ''' </summary>
        ''' <param name="usermemberItem">Instancia de UserMember</param>
        ''' <returns>Cantidad de registros creados.</returns>
        Public Shared Function Create(usermemberItem As Architect.API.Core.Contracts.Security.UserMember) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("INSERT INTO UserMember " &
                                              "(UserId, CompanyId, UserName, EMail, Password, OldPassword, IdentificationType, Identification, FirstName, LastName, BirthDate, FailedPasswordCount, SecurityLevel, IsLockedOut, LockedOutDate, PasswordChangedDate, OneTimePassword, LoginDate, ManagerId, AccessKey, BranchOffice, Reference, Position, PhoneNumber, SalesChannel, CustomData, RecordStatus, UpdateUserCode, UpdateDate) " &
                                        "VALUES(@:UserId, @:CompanyId, @:UserName, @:EMail, @:Password, @:OldPassword, @:IdentificationType, @:Identification, @:FirstName, @:LastName, @:BirthDate, @:FailedPasswordCount, @:SecurityLevel, @:IsLockedOut, @:LockedOutDate, @:PasswordChangedDate, @:OneTimePassword, @:LoginDate, @:ManagerId, @:AccessKey, @:BranchOffice, @:Reference, @:Position, @:PhoneNumber, @:SalesChannel, @:CustomData, @:RecordStatus, @:UpdateUserCode, @:UpdateDate)", "UserMember", "Research")
                .AddParameter("UserId", DbType.Decimal, 9, usermemberItem.UserId.IsEmpty(), usermemberItem.UserId)
                .AddParameter("CompanyId", DbType.Decimal, 5, usermemberItem.CompanyId.IsEmpty(), usermemberItem.CompanyId)
                .AddParameter("UserName", DbType.AnsiString, 35, usermemberItem.UserName.IsEmpty(), usermemberItem.UserName)
                .AddParameter("EMail", DbType.AnsiString, 120, usermemberItem.EMail.IsEmpty(), usermemberItem.EMail)
                .AddParameter("Password", DbType.AnsiString, 255, usermemberItem.Password.IsEmpty(), usermemberItem.Password)
                .AddParameter("OldPassword", DbType.AnsiString, 255, usermemberItem.OldPassword.IsEmpty(), usermemberItem.OldPassword)
                .AddParameter("IdentificationType", DbType.Decimal, 3, usermemberItem.IdentificationType.IsEmpty(), usermemberItem.IdentificationType)
                .AddParameter("Identification", DbType.AnsiString, 20, usermemberItem.Identification.IsEmpty(), usermemberItem.Identification)
                .AddParameter("FirstName", DbType.AnsiString, 35, usermemberItem.FirstName.IsEmpty(), usermemberItem.FirstName)
                .AddParameter("LastName", DbType.AnsiString, 35, usermemberItem.LastName.IsEmpty(), usermemberItem.LastName)
                .AddParameter("BirthDate", DbType.DateTime, 9, usermemberItem.BirthDate.IsEmpty(), usermemberItem.BirthDate)
                .AddParameter("FailedPasswordCount", DbType.Decimal, 3, usermemberItem.FailedPasswordCount.IsEmpty(), usermemberItem.FailedPasswordCount)
                .AddParameter("SecurityLevel", DbType.Decimal, 3, False, usermemberItem.SecurityLevel)
                .AddParameter("IsLockedOut", DbType.Decimal, 1, False, IIf(usermemberItem.IsLockedOut, 1, 0))
                .AddParameter("LockedOutDate", DbType.DateTime, 9, usermemberItem.LockedOutDate.IsEmpty(), usermemberItem.LockedOutDate)
                .AddParameter("PasswordChangedDate", DbType.DateTime, 9, usermemberItem.PasswordChangedDate.IsEmpty(), usermemberItem.PasswordChangedDate)
                .AddParameter("OneTimePassword", DbType.AnsiStringFixedLength, 6, usermemberItem.OneTimePassword.IsEmpty(), usermemberItem.OneTimePassword)
                .AddParameter("LoginDate", DbType.DateTime, 9, usermemberItem.LoginDate.IsEmpty(), usermemberItem.LoginDate)
                .AddParameter("ManagerId", DbType.Decimal, 9, usermemberItem.ManagerId.IsEmpty(), usermemberItem.ManagerId)
                .AddParameter("AccessKey", DbType.AnsiString, 20, usermemberItem.AccessKey.IsEmpty(), usermemberItem.AccessKey)
                .AddParameter("BranchOffice", DbType.Decimal, 5, usermemberItem.BranchOffice.IsEmpty(), usermemberItem.BranchOffice)
                .AddParameter("Reference", DbType.AnsiString, 36, usermemberItem.Reference.IsEmpty(), usermemberItem.Reference)
                .AddParameter("Position", DbType.Decimal, 5, usermemberItem.Position.IsEmpty(), usermemberItem.Position)
                .AddParameter("PhoneNumber", DbType.AnsiString, 20, usermemberItem.PhoneNumber.IsEmpty(), usermemberItem.PhoneNumber)
                .AddParameter("SalesChannel", DbType.Decimal, 9, usermemberItem.SalesChannel.IsEmpty(), usermemberItem.SalesChannel)
                .AddParameter("CustomData", DbType.AnsiString, 2000, usermemberItem.CustomData.IsEmpty(), usermemberItem.CustomData)
                .AddParameter("RecordStatus", DbType.Decimal, 5, usermemberItem.RecordStatus.IsEmpty(), usermemberItem.RecordStatus)
                .AddParameter("UpdateUserCode", DbType.Decimal, 9, usermemberItem.UpdateUserCode.IsEmpty(), usermemberItem.UpdateUserCode)
                .AddParameter("UpdateDate", DbType.DateTime, 0, usermemberItem.UpdateDate.IsEmpty(), usermemberItem.UpdateDate)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera un registro en la tabla UserMember por medio de su clave primaria.
        ''' </summary>
        ''' <param name="userid">Identificación del usuario.</param>
        ''' <param name="companyId">Identificación de la compañía propietaria.</param>
        ''' <returns>Instancia de UserMember</returns>
        Public Shared Function Retrieve(userid As Integer, companyId As Integer) As Architect.API.Core.Contracts.Security.UserMember
            Dim rows As Data.DataTable = Nothing
            Dim result As Architect.API.Core.Contracts.Security.UserMember = Nothing
            With New DataManagerFactory("SELECT UserMember.UserId, UserMember.CompanyId, UserMember.UserName, UserMember.EMail, UserMember.Password, UserMember.OldPassword, UserMember.IdentificationType, UserMember.Identification, UserMember.FirstName, UserMember.LastName, UserMember.BirthDate, UserMember.FailedPasswordCount, UserMember.SecurityLevel, UserMember.IsLockedOut, UserMember.LockedOutDate, UserMember.PasswordChangedDate, UserMember.OneTimePassword, UserMember.LoginDate, UserMember.ManagerId, UserMember.AccessKey, UserMember.BranchOffice, UserMember.Reference, UserMember.Position, UserMember.PhoneNumber, UserMember.SalesChannel, UserMember.CustomData, UserMember.RecordStatus, UserMember.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, UserMember.UpdateDate, " &
                                               "(SELECT LISTAGG(RM.ROLENAME , ', ') WITHIN GROUP (ORDER BY RM.ROLENAME ) FROM USERROLEMEMBER urm LEFT JOIN ROLEMEMBER rm ON rm.RoleId = urm.RoleId WHERE urm.UserId = UserMember.UserId) Roles " &
                                          "FROM UserMember LEFT JOIN UserMember um ON um.UserId = UserMember.UpdateUserCode " &
                                         "WHERE UserMember.UserId=@:UserId AND UserMember.CompanyId=@:CompanyId", "UserMember", "Research")
                .AddParameter("UserId", DbType.Decimal, 9, False, userid)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                rows = .QueryExecuteToTable(True)
                If rows.IsNotEmpty AndAlso rows.Rows.Count <> 0 Then
                    result = DataRowMapper(rows.Rows(0))
                End If
            End With
            Return result
        End Function

        ''' <summary>
        ''' Recupera una lista de registros en la tabla UserMember.
        ''' </summary>
        ''' <param name="companyId">Identificación de la compañía propietaria.</param>
        ''' <param name="filter">Filtro personalizado.</param>
        ''' <param name="recordStatus"></param>
        ''' <returns>Lista de instancias de UserMember</returns>
        Public Shared Function RetrieveAll(companyId As Integer, securityLevel As Integer, filter As String, recordStatus As String) As List(Of Architect.API.Core.Contracts.Security.UserMember)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.API.Core.Contracts.Security.UserMember)
            With New DataManagerFactory("SELECT UserMember.UserId, UserMember.CompanyId, UserMember.UserName, UserMember.EMail, UserMember.Password, UserMember.OldPassword, UserMember.IdentificationType, UserMember.Identification, UserMember.FirstName, UserMember.LastName, UserMember.BirthDate, UserMember.FailedPasswordCount, UserMember.SecurityLevel, UserMember.IsLockedOut, UserMember.LockedOutDate, UserMember.PasswordChangedDate, UserMember.OneTimePassword, UserMember.LoginDate, UserMember.ManagerId, UserMember.AccessKey, UserMember.BranchOffice, UserMember.Reference, UserMember.Position, UserMember.PhoneNumber, UserMember.SalesChannel, UserMember.CustomData, UserMember.RecordStatus, UserMember.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, UserMember.UpdateDate, " &
                                               "(SELECT LISTAGG(RM.ROLENAME , ', ') WITHIN GROUP (ORDER BY RM.ROLENAME ) FROM USERROLEMEMBER urm LEFT JOIN ROLEMEMBER rm ON rm.RoleId = urm.RoleId WHERE urm.UserId = UserMember.UserId) Roles " &
                                          "FROM UserMember LEFT JOIN UserMember um ON um.UserId = UserMember.UpdateUserCode " &
                                         "WHERE UserMember.CompanyId=@:CompanyId AND UserMember.SecurityLevel<=@:SecurityLevel" & BuildFilter(filter, recordStatus), "UserMember", "Research")
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                .AddParameter("SecurityLevel", DbType.Decimal, 3, False, securityLevel)
                rows = .QueryExecuteToTable(True)
                If rows.IsNotEmpty AndAlso rows.Rows.Count <> 0 Then
                    For Each itemRow As DataRow In rows.Rows
                        result.Add(DataRowMapper(itemRow))
                    Next
                End If
            End With
            Return result
        End Function


        Public Shared Function BuildFilter(filter As String, recordStatus As String) As String
            Dim result As String = String.Empty

            If filter.IsNotEmpty Then
                result = " AND (UPPER(UserMember.UserName) LIKE '%" & filter.ToUpper & "%' " &
                            "OR UPPER(UserMember.FirstName) LIKE '%" & filter.ToUpper & "%' " &
                            "OR UPPER(UserMember.LastName) LIKE '%" & filter.ToUpper & "%' " &
                            "OR UPPER(UserMember.EMail) LIKE '%" & filter.ToUpper & "%') "
            End If

            If recordStatus.IsNotEmpty Then
                result = " AND UserMember.RecordStatus IN (" & recordStatus & ") "
            End If

            Return result
        End Function

        ''' <summary>
        ''' Último valor asignado a clave única de la tabla UserMember.
        ''' </summary>
        ''' <returns>Último valor asignado.</returns>
        Public Shared Function RetrieveLastKey() As Integer
            Dim rows As Integer = 0

            With New DataManagerFactory("SELECT NVL(MAX(UserId),0) " &
                                          "FROM UserMember WHERE UserId < 999999000", "UserMember", "Research")
                rows = .QueryExecuteScalarToInteger
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Actualiza un registro en la tabla UserMember por medio de su clave primaria.
        ''' </summary>
        ''' <param name="usermemberItem">Instancia de UserMember</param>
        ''' <returns>Cantidad de registros actualizados.</returns>
        Public Shared Function Update(usermemberItem As Architect.API.Core.Contracts.Security.UserMember) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("UPDATE UserMember " &
                                           "SET CompanyId=@:CompanyId, UserName=@:UserName, EMail=@:EMail, Password=@:Password, OldPassword=@:OldPassword, IdentificationType=@:IdentificationType, Identification=@:Identification, FirstName=@:FirstName, LastName=@:LastName, BirthDate=@:BirthDate, FailedPasswordCount=@:FailedPasswordCount, SecurityLevel=@:SecurityLevel, IsLockedOut=@:IsLockedOut, LockedOutDate=@:LockedOutDate, PasswordChangedDate=@:PasswordChangedDate, OneTimePassword=@:OneTimePassword, LoginDate=@:LoginDate, ManagerId=@:ManagerId, AccessKey=@:AccessKey, BranchOffice=@:BranchOffice, Reference=@:Reference, Position=@:Position, PhoneNumber=@:PhoneNumber, SalesChannel=@:SalesChannel, CustomData=@:CustomData, RecordStatus=@:RecordStatus, UpdateUserCode=@:UpdateUserCode, UpdateDate=@:UpdateDate " &
                                         "WHERE UserId=@:UserId", "UserMember", "Research")
                .AddParameter("CompanyId", DbType.Decimal, 5, usermemberItem.CompanyId.IsEmpty(), usermemberItem.CompanyId)
                .AddParameter("UserName", DbType.AnsiString, 35, usermemberItem.UserName.IsEmpty(), usermemberItem.UserName)
                .AddParameter("EMail", DbType.AnsiString, 120, usermemberItem.EMail.IsEmpty(), usermemberItem.EMail)
                .AddParameter("Password", DbType.AnsiString, 255, usermemberItem.Password.IsEmpty(), usermemberItem.Password)
                .AddParameter("OldPassword", DbType.AnsiString, 255, usermemberItem.OldPassword.IsEmpty(), usermemberItem.OldPassword)
                .AddParameter("IdentificationType", DbType.Decimal, 3, usermemberItem.IdentificationType.IsEmpty(), usermemberItem.IdentificationType)
                .AddParameter("Identification", DbType.AnsiString, 20, usermemberItem.Identification.IsEmpty(), usermemberItem.Identification)
                .AddParameter("FirstName", DbType.AnsiString, 35, usermemberItem.FirstName.IsEmpty(), usermemberItem.FirstName)
                .AddParameter("LastName", DbType.AnsiString, 35, usermemberItem.LastName.IsEmpty(), usermemberItem.LastName)
                .AddParameter("BirthDate", DbType.DateTime, 9, usermemberItem.BirthDate.IsEmpty(), usermemberItem.BirthDate)
                .AddParameter("FailedPasswordCount", DbType.Decimal, 3, usermemberItem.FailedPasswordCount.IsEmpty(), usermemberItem.FailedPasswordCount)
                .AddParameter("SecurityLevel", DbType.Decimal, 3, False, usermemberItem.SecurityLevel)
                .AddParameter("IsLockedOut", DbType.Decimal, 1, False, IIf(usermemberItem.IsLockedOut, 1, 0))
                .AddParameter("LockedOutDate", DbType.DateTime, 9, usermemberItem.LockedOutDate.IsEmpty(), usermemberItem.LockedOutDate)
                .AddParameter("PasswordChangedDate", DbType.DateTime, 9, usermemberItem.PasswordChangedDate.IsEmpty(), usermemberItem.PasswordChangedDate)
                .AddParameter("OneTimePassword", DbType.AnsiStringFixedLength, 6, usermemberItem.OneTimePassword.IsEmpty(), usermemberItem.OneTimePassword)
                .AddParameter("LoginDate", DbType.DateTime, 9, usermemberItem.LoginDate.IsEmpty(), usermemberItem.LoginDate)
                .AddParameter("ManagerId", DbType.Decimal, 9, usermemberItem.ManagerId.IsEmpty(), usermemberItem.ManagerId)
                .AddParameter("AccessKey", DbType.AnsiString, 20, usermemberItem.AccessKey.IsEmpty(), usermemberItem.AccessKey)
                .AddParameter("BranchOffice", DbType.Decimal, 5, usermemberItem.BranchOffice.IsEmpty(), usermemberItem.BranchOffice)
                .AddParameter("Reference", DbType.AnsiString, 36, usermemberItem.Reference.IsEmpty(), usermemberItem.Reference)
                .AddParameter("Position", DbType.Decimal, 5, usermemberItem.Position.IsEmpty(), usermemberItem.Position)
                .AddParameter("PhoneNumber", DbType.AnsiString, 20, usermemberItem.PhoneNumber.IsEmpty(), usermemberItem.PhoneNumber)
                .AddParameter("SalesChannel", DbType.Decimal, 9, usermemberItem.SalesChannel.IsEmpty(), usermemberItem.SalesChannel)
                .AddParameter("CustomData", DbType.AnsiString, 2000, usermemberItem.CustomData.IsEmpty(), usermemberItem.CustomData)
                .AddParameter("RecordStatus", DbType.Decimal, 5, usermemberItem.RecordStatus.IsEmpty(), usermemberItem.RecordStatus)
                .AddParameter("UpdateUserCode", DbType.Decimal, 9, usermemberItem.UpdateUserCode.IsEmpty(), usermemberItem.UpdateUserCode)
                .AddParameter("UpdateDate", DbType.DateTime, 0, usermemberItem.UpdateDate.IsEmpty(), usermemberItem.UpdateDate)
                .AddParameter("UserId", DbType.Decimal, 9, False, usermemberItem.UserId)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Elimina un registro en la tabla UserMember por medio de su clave primaria.
        ''' </summary>
        ''' <param name="userid">Identificación del usuario.</param>
        ''' <param name="companyId">Identificación de la compañia propietaria.</param>
        ''' <returns>Cantidad de registros eliminados.</returns>
        Public Shared Function Delete(userid As Integer, companyId As Integer) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("DELETE FROM UserMember " &
                                         "WHERE UserId=@:UserId AND CompanyId=@:CompanyId", "UserMember", "Research")
                .AddParameter("UserId", DbType.Decimal, 9, False, userid)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera la cantidad de registros existentes en la tabla UserMember por medio de su clave primaria.
        ''' </summary>
        ''' <param name="userid">Identificación del usuario.</param>
        ''' <param name="companyId">Identificación de la compañia propietaria.</param>
        ''' <returns>Cantidad de registros encontrados.</returns>
        Public Shared Function Count(userid As Integer, companyId As Integer) As Integer
            Dim rows As Integer = 0

            With New DataManagerFactory("SELECT COUNT(UserId) " &
                                          "FROM UserMember " &
                                         "WHERE UserId=@:UserId AND CompanyId=@:CompanyId", "UserMember", "Research")
                .AddParameter("UserId", DbType.Decimal, 9, False, userid)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                rows = .QueryExecuteScalarToInteger
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera una lista para selección de la tabla UserMember.
        ''' </summary>
        ''' <param name="companyId"></param>
        ''' <returns>Lista de instancias de LookUpValue</returns>
        Public Shared Function LookUp(companyId As Integer) As List(Of Architect.Common.DataType.LookUpValue)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.Common.DataType.LookUpValue)
            With New DataManagerFactory("SELECT UserId, UserName " &
                                          "FROM UserMember WHERE CompanyId=@:CompanyId ORDER BY UserName", "UserMember", "Research")
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                rows = .QueryExecuteToTable(True)
                If rows.IsNotEmpty AndAlso rows.Rows.Count <> 0 Then
                    For Each itemRow As DataRow In rows.Rows
                        result.Add(New Architect.Common.DataType.LookUpValue With {.Code = itemRow.StringValue("UserId"), .Description = itemRow.StringValue("UserName")})
                    Next
                End If
            End With
            Return result
        End Function

#Region "Helper"

        ''' <summary>
        ''' Permite hacer el mapeo entre una fila de un datatable hacia una instancia de UserMember.
        ''' </summary>
        ''' <returns>Instancia de UserMember</returns>
        Private Shared Function DataRowMapper(itemRow As DataRow) As Architect.API.Core.Contracts.Security.UserMember
            Return New Architect.API.Core.Contracts.Security.UserMember With {.UserId = itemRow.NumericValue("UserId"), .CompanyId = itemRow.NumericValue("CompanyId"), .UserName = itemRow.StringValue("UserName"), .EMail = itemRow.StringValue("EMail"), .Password = itemRow.StringValue("Password"), .OldPassword = itemRow.StringValue("OldPassword"), .IdentificationType = itemRow.NumericValue("IdentificationType"), .Identification = itemRow.StringValue("Identification"), .FirstName = itemRow.StringValue("FirstName"), .LastName = itemRow.StringValue("LastName"), .BirthDate = itemRow.DateTimeValue("BirthDate"), .FailedPasswordCount = itemRow.NumericValue("FailedPasswordCount"), .SecurityLevel = itemRow.NumericValue("SecurityLevel"), .IsLockedOut = (itemRow.NumericValue("IsLockedOut") = 1), .LockedOutDate = itemRow.DateTimeValue("LockedOutDate"), .PasswordChangedDate = itemRow.DateTimeValue("PasswordChangedDate"), .OneTimePassword = itemRow.StringValue("OneTimePassword"), .LoginDate = itemRow.DateTimeValue("LoginDate"), .ManagerId = itemRow.NumericValue("ManagerId"), .AccessKey = itemRow.StringValue("AccessKey"), .BranchOffice = itemRow.NumericValue("BranchOffice"), .Reference = itemRow.StringValue("Reference"), .Position = itemRow.NumericValue("Position"), .PhoneNumber = itemRow.StringValue("PhoneNumber"), .SalesChannel = itemRow.NumericValue("SalesChannel"), .CustomData = itemRow.StringValue("CustomData"), .RecordStatus = itemRow.NumericValue("RecordStatus"), .UpdateUserCode = itemRow.NumericValue("UpdateUserCode"), .UpdateUserName = itemRow.StringValue("UpdateUserName"), .UpdateDate = itemRow.DateTimeValue("UpdateDate"), .RoleList = itemRow.StringValue("Roles")}
        End Function

#End Region

    End Class

End Namespace

