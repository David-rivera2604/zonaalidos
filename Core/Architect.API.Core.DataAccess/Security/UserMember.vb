Imports Architect.Common.Proxy

Namespace Architect.API.Core.DataAccess.Security

    Partial Public NotInheritable Class UserMember


        ''' <summary>
        ''' Actualiza un registro en la tabla UserMember por medio de su clave primaria.
        ''' </summary>
        ''' <param name="usermemberItem">Instancia de UserMember</param>
        ''' <returns>Cantidad de registros actualizados.</returns>
        Public Shared Function InternalUpdate(usermemberItem As Architect.API.Core.Contracts.Security.UserMember) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("UPDATE UserMember " &
                                           "SET Password=@:Password, OldPassword=@:OldPassword, FailedPasswordCount=@:FailedPasswordCount, SecurityLevel=@:SecurityLevel, IsLockedOut=@:IsLockedOut, LockedOutDate=@:LockedOutDate, PasswordChangedDate=@:PasswordChangedDate, OneTimePassword=@:OneTimePassword, LoginDate=@:LoginDate " &
                                         "WHERE UserId=@:UserId", "UserMember", "Research")
                .AddParameter("Password", DbType.AnsiString, 255, usermemberItem.Password.IsEmpty(), usermemberItem.Password)
                .AddParameter("OldPassword", DbType.AnsiString, 255, usermemberItem.OldPassword.IsEmpty(), usermemberItem.OldPassword)
                .AddParameter("FailedPasswordCount", DbType.Decimal, 3, usermemberItem.FailedPasswordCount.IsEmpty(), usermemberItem.FailedPasswordCount)
                .AddParameter("SecurityLevel", DbType.Decimal, 3, False, usermemberItem.SecurityLevel)
                .AddParameter("IsLockedOut", DbType.Decimal, 1, False, IIf(usermemberItem.IsLockedOut, 1, 0))
                .AddParameter("LockedOutDate", DbType.DateTime, 9, usermemberItem.LockedOutDate.IsEmpty(), usermemberItem.LockedOutDate)
                .AddParameter("PasswordChangedDate", DbType.DateTime, 9, usermemberItem.PasswordChangedDate.IsEmpty(), usermemberItem.PasswordChangedDate)
                .AddParameter("OneTimePassword", DbType.AnsiStringFixedLength, 6, usermemberItem.OneTimePassword.IsEmpty(), usermemberItem.OneTimePassword)
                .AddParameter("LoginDate", DbType.DateTime, 9, usermemberItem.LoginDate.IsEmpty(), usermemberItem.LoginDate)
                .AddParameter("UserId", DbType.Decimal, 9, False, usermemberItem.UserId)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera una lista con la información de correo electronico de los usuario asociados a un rol.
        ''' </summary>
        ''' <param name="companyId">Identificación de la compañia propietaria.</param>
        ''' <param name="roleName">Nombre del rol usando para filtrar la lista</param>
        ''' <returns>Lista de instancias de UserMember</returns>
        Public Shared Function EmailInfoByRoleName(companyId As Integer, roleName As String) As List(Of Architect.API.Core.Contracts.Security.UserMember)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.API.Core.Contracts.Security.UserMember)

            roleName &= ",,,"

            With New DataManagerFactory(My.Resources.UserMember_EmailInfoByRoleName, "UserMember", "Research")
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                .AddParameter("RoleName1", DbType.AnsiString, 80, False, roleName.Split(",")(0).Trim().ToLower())
                .AddParameter("RoleName2", DbType.AnsiString, 80, False, roleName.Split(",")(1).Trim().ToLower())
                .AddParameter("RoleName3", DbType.AnsiString, 80, False, roleName.Split(",")(2).Trim().ToLower())

                rows = .QueryExecuteToTable(True)
                If rows.IsNotEmpty AndAlso rows.Rows.Count <> 0 Then
                    For Each itemRow As DataRow In rows.Rows
                        result.Add(New Contracts.Security.UserMember With {.EMail = itemRow.StringValue("EMail"),
                                                                           .FirstName = itemRow.StringValue("FirstName"),
                                                                           .LastName = itemRow.StringValue("LastName")})
                    Next
                End If
            End With
            Return result
        End Function

        ''' <summary>
        ''' Recupera un registro en la tabla UserMember por medio de su clave primaria.
        ''' </summary>
        ''' <param name="eMail">E-Mail del Usuario.</param>
        ''' <param name="companyId">Identificación de la compañia propietaria.</param>
        ''' <returns>Instancia de UserMember</returns>
        Public Shared Function RetrieveByEMail(eMail As String, companyId As Integer) As Architect.API.Core.Contracts.Security.UserMember
            Dim rows As Data.DataTable = Nothing
            Dim result As Architect.API.Core.Contracts.Security.UserMember = Nothing
            With New DataManagerFactory("SELECT UserId, UserName, EMail, Password, OldPassword, FirstName, LastName, FailedPasswordCount, SecurityLevel, IsLockedOut, LockedOutDate, OneTimePassword, PasswordChangedDate, ManagerId, RecordStatus, CompanyId, LoginDate, BranchOffice, IdentificationType, Identification " &
                                          "FROM UserMember " &
                                         "WHERE LOWER(EMail)=@:EMail AND CompanyId=@:CompanyId", "UserMember", "Research")
                .AddParameter("EMail", DbType.AnsiString, 120, False, eMail.IfEmpty(String.Empty).ToLower.Trim)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                rows = .QueryExecuteToTable(True)
                If rows.IsNotEmpty AndAlso rows.Rows.Count <> 0 Then
                    result = DataRowMapperLight(rows.FirstRow)
                End If
            End With
            Return result
        End Function

        ''' <summary>
        ''' Recupera un registro en la tabla UserMember por medio de su clave primaria.
        ''' </summary>
        ''' <param name="userName">Nombre Usuario.</param>
        ''' <param name="companyId">Identificación de la compañia propietaria.</param>
        ''' <returns>Instancia de UserMember</returns>
        Public Shared Function RetrieveByUserName(userName As String, companyId As Integer) As Architect.API.Core.Contracts.Security.UserMember
            Dim rows As Data.DataTable = Nothing
            Dim result As Architect.API.Core.Contracts.Security.UserMember = Nothing
            With New DataManagerFactory("SELECT UserId, UserName, EMail, Password, OldPassword, FirstName, LastName, FailedPasswordCount, SecurityLevel, IsLockedOut, LockedOutDate, OneTimePassword, PasswordChangedDate, ManagerId, RecordStatus, CompanyId, LoginDate, BranchOffice, IdentificationType, Identification " &
                                          "FROM UserMember " &
                                         "WHERE LOWER(UserName)=@:UserName AND CompanyId=@:CompanyId", "UserMember", "Research")
                .AddParameter("UserName", DbType.AnsiString, 35, False, userName.IfEmpty(String.Empty).ToLower.Trim)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                rows = .QueryExecuteToTable(True)
                If rows.IsNotEmpty AndAlso rows.Rows.Count <> 0 Then
                    result = DataRowMapperLight(rows.FirstRow)
                End If
            End With
            Return result
        End Function


        ''' <summary>
        ''' Recupera un registro en la tabla UserMember por medio de una clave de acceso.
        ''' </summary>
        ''' <param name="accessKey">valor usado para identificar un usuario para servicios.</param>
        ''' <returns>Instancia de UserMember</returns>
        Public Shared Function RetrieveByAccessKey(accessKey As String) As Architect.API.Core.Contracts.Security.UserMember
            Dim rows As Data.DataTable = Nothing
            Dim result As Architect.API.Core.Contracts.Security.UserMember = Nothing
            With New DataManagerFactory("SELECT UserId, UserName, EMail, Password, OldPassword, FirstName, LastName, FailedPasswordCount, SecurityLevel, IsLockedOut, LockedOutDate, OneTimePassword, PasswordChangedDate, ManagerId, RecordStatus, CompanyId, LoginDate, BranchOffice, IdentificationType, Identification " &
                                          "FROM UserMember " &
                                         "WHERE AccessKey=@:AccessKey", "UserMember", "Research")
                .AddParameter("AccessKey", DbType.AnsiString, 20, False, accessKey)
                rows = .QueryExecuteToTable(True)
                If rows.IsNotEmpty AndAlso rows.Rows.Count <> 0 Then
                    result = DataRowMapperLight(rows.FirstRow)
                End If
            End With
            Return result
        End Function

        ''' <summary>
        ''' Permite hacer el mapeo entre una fila de un datatable hacia una instancia de UserMember.
        ''' </summary>
        ''' <returns>Instancia de UserMember</returns>
        Private Shared Function DataRowMapperLight(itemRow As DataRow) As Architect.API.Core.Contracts.Security.UserMember
            Return New Architect.API.Core.Contracts.Security.UserMember With {.UserId = itemRow.NumericValue("UserId"), .UserName = itemRow.StringValue("UserName"), .EMail = itemRow.StringValue("EMail"), .Password = itemRow.StringValue("Password"), .OldPassword = itemRow.StringValue("OldPassword"), .FirstName = itemRow.StringValue("FirstName"), .LastName = itemRow.StringValue("LastName"), .FailedPasswordCount = itemRow.NumericValue("FailedPasswordCount"), .SecurityLevel = itemRow.NumericValue("SecurityLevel"), .IsLockedOut = (itemRow.NumericValue("IsLockedOut") = 1), .PasswordChangedDate = itemRow.DateTimeValue("PasswordChangedDate"), .ManagerId = itemRow.NumericValue("ManagerId"), .RecordStatus = itemRow.NumericValue("RecordStatus"), .CompanyId = itemRow.NumericValue("CompanyId"), .LockedOutDate = itemRow.DateTimeValue("LockedOutDate"), .OneTimePassword = itemRow.StringValue("OneTimePassword"), .LoginDate = itemRow.DateTimeValue("LoginDate"), .BranchOffice = itemRow.NumericValue("BranchOffice"), .IdentificationType = itemRow.NumericValue("IdentificationType"), .Identification = itemRow.StringValue("Identification")}
        End Function

    End Class

End Namespace

