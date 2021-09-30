Imports Architect.Common.Proxy

Namespace Architect.API.Core.DataAccess.Security

    ''' <summary>
    ''' 
    ''' </summary>
    Partial Public NotInheritable Class RoleMember

        ''' <summary>
        ''' Crea un registro en la tabla RoleMember.
        ''' </summary>
        ''' <param name="rolememberItem">Instancia de RoleMember</param>
        ''' <returns>Instancia de RoleMember</returns>
        Public Shared Function Create(rolememberItem As Architect.API.Core.Contracts.Security.RoleMember) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("INSERT INTO RoleMember " &
                                              "(RoleId, CompanyId, RoleName, Description, SecurityLevel, RecordStatus, UpdateUserCode, UpdateDate) " &
                                        "VALUES(@:RoleId, @:CompanyId, @:RoleName, @:Description, @:SecurityLevel, @:RecordStatus, @:UpdateUserCode, @:UpdateDate)", "RoleMember", "Research")
                .AddParameter("RoleId", DbType.Decimal, 9, rolememberItem.RoleId.IsEmpty(), rolememberItem.RoleId)
                .AddParameter("CompanyId", DbType.Decimal, 5, rolememberItem.CompanyId.IsEmpty(), rolememberItem.CompanyId)
                .AddParameter("RoleName", DbType.AnsiString, 80, rolememberItem.RoleName.IsEmpty(), rolememberItem.RoleName)
                .AddParameter("Description", DbType.AnsiString, 120, rolememberItem.Description.IsEmpty(), rolememberItem.Description)
                .AddParameter("SecurityLevel", DbType.Decimal, 3, rolememberItem.SecurityLevel.IsEmpty(), rolememberItem.SecurityLevel)
                .AddParameter("RecordStatus", DbType.Decimal, 5, rolememberItem.RecordStatus.IsEmpty(), rolememberItem.RecordStatus)
                .AddParameter("UpdateUserCode", DbType.Decimal, 9, rolememberItem.UpdateUserCode.IsEmpty(), rolememberItem.UpdateUserCode)
                .AddParameter("UpdateDate", DbType.DateTime, 0, rolememberItem.UpdateDate.IsEmpty(), rolememberItem.UpdateDate)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera un registro en la tabla RoleMember por medio de su clave primaria.
        ''' </summary>
        ''' <param name="roleid"></param>
        ''' <param name="companyId"></param>
        ''' <returns>Instancia de RoleMember</returns>
        Public Shared Function Retrieve(roleid As Integer, companyId As Integer) As Architect.API.Core.Contracts.Security.RoleMember
            Dim rows As Data.DataTable = Nothing
            Dim result As Architect.API.Core.Contracts.Security.RoleMember = Nothing
            With New DataManagerFactory("SELECT RoleId, RoleMember.CompanyId, RoleName, Description, RoleMember.SecurityLevel, RoleMember.RecordStatus, RoleMember.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, RoleMember.UpdateDate " &
                                          "FROM RoleMember LEFT JOIN UserMember um ON um.UserId = RoleMember.UpdateUserCode " &
                                         "WHERE RoleMember.RoleId=@:RoleId AND RoleMember.CompanyId=@:CompanyId", "RoleMember", "Research")
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
        ''' Recupera una lista de registros en la tabla RoleMember.
        ''' </summary>
        ''' <param name="companyId"></param>
        ''' <param name="filter"></param>
        ''' <returns>Lista de instancias de RoleMember</returns>
        Public Shared Function RetrieveAll(companyId As Integer, filter As String) As List(Of Architect.API.Core.Contracts.Security.RoleMember)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.API.Core.Contracts.Security.RoleMember)
            With New DataManagerFactory("SELECT RoleId, RoleMember.CompanyId, RoleName, Description, RoleMember.SecurityLevel, RoleMember.RecordStatus, RoleMember.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, RoleMember.UpdateDate " &
                                          "FROM RoleMember LEFT JOIN UserMember um ON um.UserId = RoleMember.UpdateUserCode " &
                                         "WHERE RoleMember.CompanyId=@:CompanyId", "RoleMember", "Research")
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
        ''' Verifica si existe un registro en la tabla RoleMember por medio de su clave primaria.
        ''' </summary>
        ''' <returns>Verdadero si existe el registro, en caso contrario falso.</returns>
        Public Shared Function RetrieveLastKey() As Integer
            Dim rows As Integer = 0

            With New DataManagerFactory("SELECT NVL(MAX(RoleId),0) " &
                                          "FROM RoleMember", "RoleMember", "Research")
                rows = .QueryExecuteScalarToInteger
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Actualiza un registro en la tabla RoleMember por medio de su clave primaria.
        ''' </summary>
        ''' <param name="rolememberItem">Instancia de RoleMember</param>
        ''' <returns>Cantidad de registros actualizados.</returns>
        Public Shared Function Update(rolememberItem As Architect.API.Core.Contracts.Security.RoleMember) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("UPDATE RoleMember " &
                                           "SET CompanyId=@:CompanyId, RoleName=@:RoleName, Description=@:Description, SecurityLevel=@:SecurityLevel, RecordStatus=@:RecordStatus, UpdateUserCode=@:UpdateUserCode, UpdateDate=@:UpdateDate " &
                                         "WHERE RoleId=@:RoleId", "RoleMember", "Research")
                .AddParameter("CompanyId", DbType.Decimal, 5, rolememberItem.CompanyId.IsEmpty(), rolememberItem.CompanyId)
                .AddParameter("RoleName", DbType.AnsiString, 80, rolememberItem.RoleName.IsEmpty(), rolememberItem.RoleName)
                .AddParameter("Description", DbType.AnsiString, 120, rolememberItem.Description.IsEmpty(), rolememberItem.Description)
                .AddParameter("SecurityLevel", DbType.Decimal, 3, rolememberItem.SecurityLevel.IsEmpty(), rolememberItem.SecurityLevel)
                .AddParameter("RecordStatus", DbType.Decimal, 5, rolememberItem.RecordStatus.IsEmpty(), rolememberItem.RecordStatus)
                .AddParameter("UpdateUserCode", DbType.Decimal, 9, rolememberItem.UpdateUserCode.IsEmpty(), rolememberItem.UpdateUserCode)
                .AddParameter("UpdateDate", DbType.DateTime, 0, rolememberItem.UpdateDate.IsEmpty(), rolememberItem.UpdateDate)
                .AddParameter("RoleId", DbType.Decimal, 9, False, rolememberItem.RoleId)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Elimina un registro en la tabla RoleMember por medio de su clave primaria.
        ''' </summary>
        ''' <param name="roleid"></param>
        ''' <param name="companyId"></param>
        ''' <returns>Cantidad de registros eliminados.</returns>
        Public Shared Function Delete(roleid As Integer, companyId As Integer) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("DELETE FROM RoleMember " &
                                         "WHERE RoleId=@:RoleId AND CompanyId=@:CompanyId", "RoleMember", "Research")
                .AddParameter("RoleId", DbType.Decimal, 9, False, roleid)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera la cantidad de registros existentes en la tabla RoleMember por medio de su clave primaria.
        ''' </summary>
        ''' <param name="roleid"></param>
        ''' <param name="companyId"></param>
        ''' <returns>Cantidad de registros encontrados.</returns>
        Public Shared Function Count(roleid As Integer, companyId As Integer) As Integer
            Dim rows As Integer = 0

            With New DataManagerFactory("SELECT COUNT(RoleId) " &
                                          "FROM RoleMember " &
                                         "WHERE RoleId=@:RoleId AND CompanyId=@:CompanyId", "RoleMember", "Research")
                .AddParameter("RoleId", DbType.Decimal, 9, False, roleid)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                rows = .QueryExecuteScalarToInteger
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera una lista para selección de la tabla RoleMember.
        ''' </summary>
        ''' <param name="companyId"></param>
        ''' <returns>Lista de instancias de LookUpValue</returns>
        Public Shared Function LookUp(companyId As Integer, securityLevel As Integer) As List(Of Architect.Common.DataType.LookUpValue)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.Common.DataType.LookUpValue)
            With New DataManagerFactory("SELECT RoleId, RoleName " &
                                          "FROM RoleMember WHERE CompanyId=@:CompanyId AND SecurityLevel<=@:SecurityLevel ORDER BY RoleName", "RoleMember", "Research")
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                .AddParameter("SecurityLevel", DbType.Decimal, 3, False, securityLevel)
                rows = .QueryExecuteToTable(True)
                If rows.IsNotEmpty AndAlso rows.Rows.Count <> 0 Then
                    For Each itemRow As DataRow In rows.Rows
                        result.Add(New Architect.Common.DataType.LookUpValue With {.Code = itemRow.StringValue("RoleId"), .Description = itemRow.StringValue("RoleName")})
                    Next
                End If
            End With
            Return result
        End Function

        ''' <summary>
        ''' Recupera una lista de registros en la tabla RoleMember.
        ''' </summary>
        ''' <param name="roleid"></param>
        ''' <param name="companyid"></param>
        ''' <returns>Lista de instancias de RoleMember</returns>
        Public Shared Function RetrieveByRoleIdCompanyId(roleid As Integer, companyid As Integer) As List(Of Architect.API.Core.Contracts.Security.RoleMember)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.API.Core.Contracts.Security.RoleMember)
            With New DataManagerFactory("Select RoleId, RoleMember.CompanyId, RoleName, Description, RoleMember.SecurityLevel, RoleMember.RecordStatus, RoleMember.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, RoleMember.UpdateDate " &
                                          "FROM RoleMember LEFT JOIN UserMember um ON um.UserId = RoleMember.UpdateUserCode " &
                                         "WHERE RoleId=@:RoleId AND CompanyId=@:CompanyId", "RoleMember", "Research")
                .AddParameter("RoleId", DbType.Decimal, 9, False, roleid)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyid)
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
        ''' Elimina un registro en la tabla RoleMember por medio de su clave primaria.
        ''' </summary>
        ''' <param name="roleid"></param>
        ''' <param name="companyid"></param>
        ''' <returns>Cantidad de registros eliminados.</returns>
        Public Shared Function DeleteByRoleIdCompanyId(roleid As Integer, companyid As Integer) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("DELETE FROM RoleMember " &
                                         "WHERE RoleId=@:RoleId AND CompanyId=@:CompanyId", "RoleMember", "Research")
                .AddParameter("RoleId", DbType.Decimal, 9, False, roleid)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyid)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera una lista de registros en la tabla RoleMember.
        ''' </summary>
        ''' <param name="companyid"></param>
        ''' <returns>Lista de instancias de RoleMember</returns>
        Public Shared Function RetrieveByCompanyId(companyid As Integer) As List(Of Architect.API.Core.Contracts.Security.RoleMember)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.API.Core.Contracts.Security.RoleMember)
            With New DataManagerFactory("Select RoleId, RoleMember.CompanyId, RoleName, Description, RoleMember.SecurityLevel, RoleMember.RecordStatus, RoleMember.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, RoleMember.UpdateDate " &
                                          "FROM RoleMember LEFT JOIN UserMember um ON um.UserId = RoleMember.UpdateUserCode " &
                                         "WHERE CompanyId=@:CompanyId", "RoleMember", "Research")
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyid)
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
        ''' Elimina un registro en la tabla RoleMember por medio de su clave primaria.
        ''' </summary>
        ''' <param name="companyid"></param>
        ''' <returns>Cantidad de registros eliminados.</returns>
        Public Shared Function DeleteByCompanyId(companyid As Integer) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("DELETE FROM RoleMember " &
                                         "WHERE CompanyId=@:CompanyId", "RoleMember", "Research")
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyid)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

#Region "Helper"

        ''' <summary>
        ''' Permite hacer el mapeo entre una fila de un datatable hacia una instancia de RoleMember.
        ''' </summary>
        ''' <returns>Instancia de RoleMember</returns>
        Private Shared Function DataRowMapper(itemRow As DataRow) As Architect.API.Core.Contracts.Security.RoleMember
            Return New Architect.API.Core.Contracts.Security.RoleMember With {.RoleId = itemRow.NumericValue("RoleId"), .CompanyId = itemRow.NumericValue("CompanyId"), .RoleName = itemRow.StringValue("RoleName"), .Description = itemRow.StringValue("Description"), .SecurityLevel = itemRow.NumericValue("SecurityLevel"), .RecordStatus = itemRow.NumericValue("RecordStatus"), .UpdateUserCode = itemRow.NumericValue("UpdateUserCode"), .UpdateUserName = itemRow.StringValue("UpdateUserName"), .UpdateDate = itemRow.DateTimeValue("UpdateDate")}
        End Function

#End Region

    End Class

End Namespace

