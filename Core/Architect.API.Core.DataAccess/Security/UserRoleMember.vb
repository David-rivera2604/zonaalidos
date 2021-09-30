Imports Architect.Common.Proxy

Namespace Architect.API.Core.DataAccess.Security

    Partial Public NotInheritable Class UserRoleMember


        ''' <summary>
        ''' Recupera una lista de registros en la tabla UserRoleMember.
        ''' </summary>
        ''' <param name="userid"></param>
        ''' <param name="companyId"></param>
        ''' <returns>Lista de instancias de UserRoleMember</returns>
        Public Shared Function RetrieveByUserId(userid As Integer, companyId As Integer) As List(Of Utilities.Contracts.LookUpValue)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Utilities.Contracts.LookUpValue)
            With New DataManagerFactory("SELECT UserRoleMember.RoleId, RoleMember.RoleName " &
                                          "FROM UserRoleMember " &
                                          "LEFT JOIN RoleMember ON RoleMember.RoleId=UserRoleMember.RoleId " &
                                         "WHERE UserId=@:UserId AND UserRoleMember.CompanyId=@:CompanyId", "UserRoleMember", "Research")
                .AddParameter("UserId", DbType.Decimal, 9, False, userid)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                rows = .QueryExecuteToTable(True)
                If rows.IsNotEmpty AndAlso rows.Rows.Count <> 0 Then
                    Dim item As Utilities.Contracts.LookUpValue = Nothing
                    For Each itemRow As DataRow In rows.Rows
                        item = New Utilities.Contracts.LookUpValue With {.Code = itemRow.StringValue("RoleId"), .Description = itemRow.StringValue("RoleName")}
                        result.Add(item)
                    Next
                End If
            End With

            Return result
        End Function

        ''' <summary>
        ''' Recupera una lista de registros en la tabla UserRoleMember.
        ''' </summary>
        ''' <param name="userid"></param>
        ''' <param name="companyId"></param>
        ''' <returns>Lista de instancias de UserRoleMember</returns>
        Public Shared Function Retrieve(userid As Integer, companyId As Integer) As List(Of Architect.API.Core.Contracts.Security.UserRoleMember)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.API.Core.Contracts.Security.UserRoleMember)
            With New DataManagerFactory("SELECT UserRoleMember.UserId, RoleId, UserRoleMember.CompanyId, UserRoleMember.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, UserRoleMember.UpdateDate " &
                                          "FROM UserRoleMember LEFT JOIN UserMember um ON um.UserId = UserRoleMember.UpdateUserCode " &
                                         "WHERE UserRoleMember.UserId=@:UserId AND UserRoleMember.CompanyId=@:CompanyId", "UserRoleMember", "Research")
                .AddParameter("UserId", DbType.Decimal, 9, False, userid)
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
        ''' Elimina un registro en la tabla UserRoleMember por medio de su clave primaria.
        ''' </summary>
        ''' <param name="userId"></param>
        ''' <param name="roleId"></param>
        ''' <returns>Cantidad de registros eliminados.</returns>
        Public Shared Function DeleteByKey(userId As Integer, roleId As Integer) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("DELETE FROM UserRoleMember " &
                                         "WHERE UserId=@:UserId AND RoleId=@:RoleId", "UserRoleMember", "Research")
                .AddParameter("UserId", DbType.Decimal, 9, False, userId)
                .AddParameter("RoleId", DbType.Decimal, 9, False, roleId)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Elimina un registro en la tabla UserRoleMember por medio de su clave primaria.
        ''' </summary>
        ''' <param name="userId"></param>
        ''' <returns>Cantidad de registros eliminados.</returns>
        Public Shared Function DeleteByKey(userId As Integer) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("DELETE FROM UserRoleMember " &
                                         "WHERE UserId=@:UserId", "UserRoleMember", "Research")
                .AddParameter("UserId", DbType.Decimal, 9, False, userId)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

    End Class

End Namespace

