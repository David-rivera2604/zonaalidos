Imports Architect.Common.Proxy

Namespace Architect.API.Core.DataAccess.Security

    ''' <summary>
    ''' 
    ''' </summary>
    Partial Public NotInheritable Class UserRoleMember

        ''' <summary>
        ''' Crea un registro en la tabla UserRoleMember.
        ''' </summary>
        ''' <param name="userrolememberItem">Instancia de UserRoleMember</param>
        ''' <returns>Instancia de UserRoleMember</returns>
        Public Shared Function Create(userrolememberItem As Architect.API.Core.Contracts.Security.UserRoleMember) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("INSERT INTO UserRoleMember " &
                                              "(UserId, RoleId, CompanyId, UpdateUserCode, UpdateDate) " &
                                        "VALUES(@:UserId, @:RoleId, @:CompanyId, @:UpdateUserCode, @:UpdateDate)", "UserRoleMember", "Research")
                .AddParameter("UserId", DbType.Decimal, 9, userrolememberItem.UserId.IsEmpty(), userrolememberItem.UserId)
                .AddParameter("RoleId", DbType.Decimal, 9, userrolememberItem.RoleId.IsEmpty(), userrolememberItem.RoleId)
                .AddParameter("CompanyId", DbType.Decimal, 5, userrolememberItem.CompanyId.IsEmpty(), userrolememberItem.CompanyId)
                .AddParameter("UpdateUserCode", DbType.Decimal, 9, userrolememberItem.UpdateUserCode.IsEmpty(), userrolememberItem.UpdateUserCode)
                .AddParameter("UpdateDate", DbType.DateTime, 0, userrolememberItem.UpdateDate.IsEmpty(), userrolememberItem.UpdateDate)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera un registro en la tabla UserRoleMember por medio de su clave primaria.
        ''' </summary>
        ''' <param name="userid"></param>
        ''' <param name="roleid"></param>
        ''' <param name="companyId"></param>
        ''' <returns>Instancia de UserRoleMember</returns>
        Public Shared Function Retrieve(userid As Integer, roleid As Integer, companyId As Integer) As Architect.API.Core.Contracts.Security.UserRoleMember
            Dim rows As Data.DataTable = Nothing
            Dim result As Architect.API.Core.Contracts.Security.UserRoleMember = Nothing
            With New DataManagerFactory("SELECT UserRoleMember.UserId, RoleId, UserRoleMember.CompanyId, UserRoleMember.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, UserRoleMember.UpdateDate " &
                                          "FROM UserRoleMember LEFT JOIN UserMember um ON um.UserId = UserRoleMember.UpdateUserCode " &
                                         "WHERE UserRoleMember.UserId=@:UserId AND UserRoleMember.RoleId=@:RoleId AND UserRoleMember.CompanyId=@:CompanyId", "UserRoleMember", "Research")
                .AddParameter("UserId", DbType.Decimal, 9, False, userid)
                .AddParameter("RoleId", DbType.Decimal, 9, False, roleid)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                rows = .QueryExecuteToTable(True)
                If rows.IsNotEmpty AndAlso rows.Rows.Count <> 0 Then
                    result = DataRowMapper(rows.Rows(0))
                End If
            End With
            Return result
        End Function

        ''' <summary>
        ''' Recupera una lista de registros en la tabla UserRoleMember.
        ''' </summary>
        ''' <param name="companyId"></param>
        ''' <param name="filter"></param>
        ''' <returns>Lista de instancias de UserRoleMember</returns>
        Public Shared Function RetrieveAll(companyId As Integer, filter As String) As List(Of Architect.API.Core.Contracts.Security.UserRoleMember)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.API.Core.Contracts.Security.UserRoleMember)
            With New DataManagerFactory("SELECT UserRoleMember.UserId, RoleId, UserRoleMember.CompanyId, UserRoleMember.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, UserRoleMember.UpdateDate " &
                                          "FROM UserRoleMember LEFT JOIN UserMember um ON um.UserId = UserRoleMember.UpdateUserCode " &
                                         "WHERE UserRoleMember.CompanyId=@:CompanyId", "UserRoleMember", "Research")
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                rows = .QueryExecuteToTable(True)
                If rows.IsNotEmpty AndAlso rows.Rows.Count <> 0 Then
                    For Each itemRow As DataRow In rows.Rows
                        result.Add(DataRowMapper(itemRow))
                    Next
                End If
            End With
            Return result
        End Function

        ''' <summary>
        ''' Verifica si existe un registro en la tabla UserRoleMember por medio de su clave primaria.
        ''' </summary>
        ''' <param name="userid"></param>
        ''' <returns>Verdadero si existe el registro, en caso contrario falso.</returns>
        Public Shared Function RetrieveLastKey(userid As Integer) As Integer
            Dim rows As Integer = 0

            With New DataManagerFactory("SELECT NVL(MAX(RoleId),0) " &
                                          "FROM UserRoleMember " &
                                         "WHERE UserId=@:UserId", "UserRoleMember", "Research")
                .AddParameter("UserId", DbType.Decimal, 9, False, userid)
                rows = .QueryExecuteScalarToInteger
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Actualiza un registro en la tabla UserRoleMember por medio de su clave primaria.
        ''' </summary>
        ''' <param name="userrolememberItem">Instancia de UserRoleMember</param>
        ''' <returns>Cantidad de registros actualizados.</returns>
        Public Shared Function Update(userrolememberItem As Architect.API.Core.Contracts.Security.UserRoleMember) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("UPDATE UserRoleMember " &
                                           "SET CompanyId=@:CompanyId, UpdateUserCode=@:UpdateUserCode, UpdateDate=@:UpdateDate " &
                                         "WHERE UserId=@:UserId AND RoleId=@:RoleId", "UserRoleMember", "Research")
                .AddParameter("CompanyId", DbType.Decimal, 5, userrolememberItem.CompanyId.IsEmpty(), userrolememberItem.CompanyId)
                .AddParameter("UpdateUserCode", DbType.Decimal, 9, userrolememberItem.UpdateUserCode.IsEmpty(), userrolememberItem.UpdateUserCode)
                .AddParameter("UpdateDate", DbType.DateTime, 0, userrolememberItem.UpdateDate.IsEmpty(), userrolememberItem.UpdateDate)
                .AddParameter("UserId", DbType.Decimal, 9, False, userrolememberItem.UserId)
                .AddParameter("RoleId", DbType.Decimal, 9, False, userrolememberItem.RoleId)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Elimina un registro en la tabla UserRoleMember por medio de su clave primaria.
        ''' </summary>
        ''' <param name="userid"></param>
        ''' <param name="roleid"></param>
        ''' <param name="companyId"></param>
        ''' <returns>Cantidad de registros eliminados.</returns>
        Public Shared Function Delete(userid As Integer, roleid As Integer, companyId As Integer) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("DELETE FROM UserRoleMember " &
                                         "WHERE UserId=@:UserId AND RoleId=@:RoleId AND CompanyId=@:CompanyId", "UserRoleMember", "Research")
                .AddParameter("UserId", DbType.Decimal, 9, False, userid)
                .AddParameter("RoleId", DbType.Decimal, 9, False, roleid)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera la cantidad de registros existentes en la tabla UserRoleMember por medio de su clave primaria.
        ''' </summary>
        ''' <param name="userid"></param>
        ''' <param name="roleid"></param>
        ''' <param name="companyId"></param>
        ''' <returns>Cantidad de registros encontrados.</returns>
        Public Shared Function Count(userid As Integer, roleid As Integer, companyId As Integer) As Integer
            Dim rows As Integer = 0

            With New DataManagerFactory("SELECT COUNT(UserId) " &
                                          "FROM UserRoleMember " &
                                         "WHERE UserId=@:UserId AND RoleId=@:RoleId AND CompanyId=@:CompanyId", "UserRoleMember", "Research")
                .AddParameter("UserId", DbType.Decimal, 9, False, userid)
                .AddParameter("RoleId", DbType.Decimal, 9, False, roleid)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                rows = .QueryExecuteScalarToInteger
            End With
            Return rows
        End Function

#Region "Helper"

        ''' <summary>
        ''' Permite hacer el mapeo entre una fila de un datatable hacia una instancia de UserRoleMember.
        ''' </summary>
        ''' <returns>Instancia de UserRoleMember</returns>
        Private Shared Function DataRowMapper(itemRow As DataRow) As Architect.API.Core.Contracts.Security.UserRoleMember
            Return New Architect.API.Core.Contracts.Security.UserRoleMember With {.UserId = itemRow.NumericValue("UserId"), .RoleId = itemRow.NumericValue("RoleId"), .CompanyId = itemRow.NumericValue("CompanyId"), .UpdateUserCode = itemRow.NumericValue("UpdateUserCode"), .UpdateUserName = itemRow.StringValue("UpdateUserName"), .UpdateDate = itemRow.DateTimeValue("UpdateDate")}
        End Function

#End Region

    End Class

End Namespace

