Imports Architect.Common.Proxy

Namespace Architect.API.Core.DataAccess.Security

    ''' <summary>
    ''' Auditoria de autenticación de usuarios e intentos de acceso al sistema.
    ''' </summary>
    Partial Public NotInheritable Class AuthenticationTrace

        ''' <summary>
        ''' Crea un registro en la tabla AuthenticationTrace.
        ''' </summary>
        ''' <param name="authenticationtraceItem">Instancia de AuthenticationTrace</param>
        ''' <returns>Cantidad de registros creados.</returns>
        Public Shared Function Create(authenticationtraceItem As Architect.API.Core.Contracts.Security.AuthenticationTrace) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("INSERT INTO AuthenticationTrace " &
                                              "(Id, CompanyId, EffectDate, IPAddress, UserName, UserId, TraceType, Reason, UserAgent) " &
                                        "VALUES(@:Id, @:CompanyId, @:EffectDate, @:IPAddress, @:UserName, @:UserId, @:TraceType, @:Reason, @:UserAgent)", "AuthenticationTrace", "Research")
                .AddParameter("Id", DbType.Decimal, 9, authenticationtraceItem.Id.IsEmpty(), authenticationtraceItem.Id)
                .AddParameter("CompanyId", DbType.Decimal, 5, authenticationtraceItem.CompanyId.IsEmpty(), authenticationtraceItem.CompanyId)
                .AddParameter("EffectDate", DbType.DateTime, 9, authenticationtraceItem.EffectDate.IsEmpty(), authenticationtraceItem.EffectDate)
                .AddParameter("IPAddress", DbType.AnsiString, 20, authenticationtraceItem.IPAddress.IsEmpty(), authenticationtraceItem.IPAddress)
                .AddParameter("UserName", DbType.AnsiString, 35, authenticationtraceItem.UserName.IsEmpty(), authenticationtraceItem.UserName)
                .AddParameter("UserId", DbType.Decimal, 9, authenticationtraceItem.UserId.IsEmpty(), authenticationtraceItem.UserId)
                .AddParameter("TraceType", DbType.Decimal, 5, authenticationtraceItem.TraceType.IsEmpty(), authenticationtraceItem.TraceType)
                .AddParameter("Reason", DbType.AnsiString, 60, authenticationtraceItem.Reason.IsEmpty(), authenticationtraceItem.Reason)
                .AddParameter("UserAgent", DbType.AnsiString, 512, authenticationtraceItem.UserAgent.IsEmpty(), authenticationtraceItem.UserAgent)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera un registro en la tabla AuthenticationTrace por medio de su clave primaria.
        ''' </summary>
        ''' <param name="id">Identificador único.</param>
        ''' <param name="companyId">Identificación de la compañia propietaria.</param>
        ''' <returns>Instancia de AuthenticationTrace</returns>
        Public Shared Function Retrieve(id As Integer, companyId As Integer) As Architect.API.Core.Contracts.Security.AuthenticationTrace
            Dim rows As Data.DataTable = Nothing
            Dim result As Architect.API.Core.Contracts.Security.AuthenticationTrace = Nothing
            With New DataManagerFactory("SELECT Id, CompanyId, EffectDate, IPAddress, UserName, UserId, TraceType, Reason, UserAgent " &
                                          "FROM AuthenticationTrace " &
                                         "WHERE Id=@:Id AND AuthenticationTrace.CompanyId=@:CompanyId", "AuthenticationTrace", "Research")
                .AddParameter("Id", DbType.Decimal, 9, False, id)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                rows = .QueryExecuteToTable(True)
                If rows.IsNotEmpty AndAlso rows.Rows.Count <> 0 Then
                    result = DataRowMapper(rows.Rows(0))
                End If
            End With
            Return result
        End Function

        ''' <summary>
        ''' Recupera una lista de registros en la tabla AuthenticationTrace.
        ''' </summary>
        ''' <param name="companyId">Identificación de la compañia propietaria.</param>
        ''' <param name="filter">Filtro personalizado.</param>
        ''' <returns>Lista de instancias de AuthenticationTrace</returns>
        Public Shared Function RetrieveAll(companyId As Integer, filter As String) As List(Of Architect.API.Core.Contracts.Security.AuthenticationTrace)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.API.Core.Contracts.Security.AuthenticationTrace)
            With New DataManagerFactory("SELECT Id, CompanyId, EffectDate, IPAddress, UserName, UserId, TraceType, Reason, UserAgent " &
                                          "FROM AuthenticationTrace " &
                                         "WHERE AuthenticationTrace.CompanyId=@:CompanyId", "AuthenticationTrace", "Research")
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
        ''' Último valor asignado a clave unica de la tabla AuthenticationTrace.
        ''' </summary>
        ''' <returns>Último valor asignado.</returns>
        Public Shared Function RetrieveLastKey() As Integer
            Dim rows As Integer = 0

            With New DataManagerFactory("SELECT NVL(MAX(Id),0) " &
                                          "FROM AuthenticationTrace", "AuthenticationTrace", "Research")
                rows = .QueryExecuteScalarToInteger
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Actualiza un registro en la tabla AuthenticationTrace por medio de su clave primaria.
        ''' </summary>
        ''' <param name="authenticationtraceItem">Instancia de AuthenticationTrace</param>
        ''' <returns>Cantidad de registros actualizados.</returns>
        Public Shared Function Update(authenticationtraceItem As Architect.API.Core.Contracts.Security.AuthenticationTrace) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("UPDATE AuthenticationTrace " &
                                           "SET CompanyId=@:CompanyId, EffectDate=@:EffectDate, IPAddress=@:IPAddress, UserName=@:UserName, UserId=@:UserId, TraceType=@:TraceType, Reason=@:Reason, UserAgent=@:UserAgent " &
                                         "WHERE Id=@:Id", "AuthenticationTrace", "Research")
                .AddParameter("CompanyId", DbType.Decimal, 5, authenticationtraceItem.CompanyId.IsEmpty(), authenticationtraceItem.CompanyId)
                .AddParameter("EffectDate", DbType.DateTime, 9, authenticationtraceItem.EffectDate.IsEmpty(), authenticationtraceItem.EffectDate)
                .AddParameter("IPAddress", DbType.AnsiString, 20, authenticationtraceItem.IPAddress.IsEmpty(), authenticationtraceItem.IPAddress)
                .AddParameter("UserName", DbType.AnsiString, 35, authenticationtraceItem.UserName.IsEmpty(), authenticationtraceItem.UserName)
                .AddParameter("UserId", DbType.Decimal, 9, authenticationtraceItem.UserId.IsEmpty(), authenticationtraceItem.UserId)
                .AddParameter("TraceType", DbType.Decimal, 5, authenticationtraceItem.TraceType.IsEmpty(), authenticationtraceItem.TraceType)
                .AddParameter("Reason", DbType.AnsiString, 60, authenticationtraceItem.Reason.IsEmpty(), authenticationtraceItem.Reason)
                .AddParameter("UserAgent", DbType.AnsiString, 512, authenticationtraceItem.UserAgent.IsEmpty(), authenticationtraceItem.UserAgent)
                .AddParameter("Id", DbType.Decimal, 9, False, authenticationtraceItem.Id)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Elimina un registro en la tabla AuthenticationTrace por medio de su clave primaria.
        ''' </summary>
        ''' <param name="id">Identificador único.</param>
        ''' <param name="companyId">Identificación de la compañia propietaria.</param>
        ''' <returns>Cantidad de registros eliminados.</returns>
        Public Shared Function Delete(id As Integer, companyId As Integer) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("DELETE FROM AuthenticationTrace " &
                                         "WHERE Id=@:Id AND CompanyId=@:CompanyId", "AuthenticationTrace", "Research")
                .AddParameter("Id", DbType.Decimal, 9, False, id)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera la cantidad de registros existentes en la tabla AuthenticationTrace por medio de su clave primaria.
        ''' </summary>
        ''' <param name="id"></param>
        ''' <param name="companyId">Identificación de la compañia propietaria.</param>
        ''' <returns>Cantidad de registros encontrados.</returns>
        Public Shared Function Count(id As Integer, companyId As Integer) As Integer
            Dim rows As Integer = 0

            With New DataManagerFactory("SELECT COUNT(Id) " &
                                          "FROM AuthenticationTrace " &
                                         "WHERE Id=@:Id AND CompanyId=@:CompanyId", "AuthenticationTrace", "Research")
                .AddParameter("Id", DbType.Decimal, 9, False, id)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                rows = .QueryExecuteScalarToInteger
            End With
            Return rows
        End Function

#Region "Helper"

        ''' <summary>
        ''' Permite hacer el mapeo entre una fila de un datatable hacia una instancia de AuthenticationTrace.
        ''' </summary>
        ''' <returns>Instancia de AuthenticationTrace</returns>
        Private Shared Function DataRowMapper(itemRow As DataRow) As Architect.API.Core.Contracts.Security.AuthenticationTrace
            Return New Architect.API.Core.Contracts.Security.AuthenticationTrace With {.Id = itemRow.NumericValue("Id"), .CompanyId = itemRow.NumericValue("CompanyId"), .EffectDate = itemRow.DateTimeValue("EffectDate"), .IPAddress = itemRow.StringValue("IPAddress"), .UserName = itemRow.StringValue("UserName"), .UserId = itemRow.NumericValue("UserId"), .TraceType = itemRow.NumericValue("TraceType"), .Reason = itemRow.StringValue("Reason"), .UserAgent = itemRow.StringValue("UserAgent")}
        End Function

#End Region

    End Class

End Namespace

