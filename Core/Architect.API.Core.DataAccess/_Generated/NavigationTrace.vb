Imports Architect.Common.Proxy

Namespace Architect.API.Core.DataAccess.Security

    ''' <summary>
    ''' 
    ''' </summary>
    Partial Public NotInheritable Class NavigationTrace

        ''' <summary>
        ''' Crea un registro en la tabla NavigationTrace.
        ''' </summary>
        ''' <param name="navigationtraceItem">Instancia de NavigationTrace</param>
        ''' <returns>Instancia de NavigationTrace</returns>
        Public Shared Function Create(navigationtraceItem As Architect.API.Core.Contracts.Security.NavigationTrace) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("INSERT INTO NavigationTrace " &
                                              "(Id, Code, UserId, EffectDate, CompanyId) " &
                                        "VALUES(@:Id, @:Code, @:UserId, @:EffectDate, @:CompanyId)", "NavigationTrace", "Research")
                .AddParameter("Id", DbType.Decimal, 9, navigationtraceItem.Id.IsEmpty(), navigationtraceItem.Id)
                .AddParameter("Code", DbType.AnsiStringFixedLength, 8, navigationtraceItem.Code.IsEmpty(), navigationtraceItem.Code)
                .AddParameter("UserId", DbType.Decimal, 9, navigationtraceItem.UserId.IsEmpty(), navigationtraceItem.UserId)
                .AddParameter("EffectDate", DbType.DateTime, 9, navigationtraceItem.EffectDate.IsEmpty(), navigationtraceItem.EffectDate)
                .AddParameter("CompanyId", DbType.Decimal, 5, navigationtraceItem.CompanyId.IsEmpty(), navigationtraceItem.CompanyId)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera un registro en la tabla NavigationTrace por medio de su clave primaria.
        ''' </summary>
        ''' <param name="id"></param>
        ''' <param name="code"></param>
        ''' <returns>Instancia de NavigationTrace</returns>
        Public Shared Function Retrieve(id As Integer, code As String) As Architect.API.Core.Contracts.Security.NavigationTrace
            Dim rows As Data.DataTable = Nothing
            Dim result As Architect.API.Core.Contracts.Security.NavigationTrace = Nothing
            With New DataManagerFactory("SELECT Id, Code, UserId, EffectDate, CompanyId " &
                                          "FROM NavigationTrace " &
                                         "WHERE Id=@:Id AND Code=@:Code", "NavigationTrace", "Research")
                .AddParameter("Id", DbType.Decimal, 9, False, id)
                .AddParameter("Code", DbType.AnsiStringFixedLength, 8, False, code)
                rows = .QueryExecuteToTable(True)
                If rows.IsNotEmpty AndAlso rows.Rows.Count <> 0 Then
                    result = DataRowMapper(rows.Rows(0))
                End If
            End With
            Return result
        End Function

        ''' <summary>
        ''' Recupera una lista de registros en la tabla NavigationTrace.
        ''' </summary>
        ''' <returns>Lista de instancias de NavigationTrace</returns>
        Public Shared Function RetrieveAll() As List(Of Architect.API.Core.Contracts.Security.NavigationTrace)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.API.Core.Contracts.Security.NavigationTrace)
            With New DataManagerFactory("SELECT Id, Code, UserId, EffectDate, CompanyId " &
                                          "FROM NavigationTrace", "NavigationTrace", "Research")
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
        ''' Verifica si existe un registro en la tabla NavigationTrace por medio de su clave primaria.
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns>Verdadero si existe el registro, en caso contrario falso.</returns>
        Public Shared Function RetrieveLastKey(id As Integer) As Integer
            Dim rows As Integer = 0

            With New DataManagerFactory("SELECT NVL(MAX(Code),0) " &
                                          "FROM NavigationTrace " &
                                         "WHERE Id=@:Id", "NavigationTrace", "Research")
                .AddParameter("Id", DbType.Decimal, 9, False, id)
                rows = .QueryExecuteScalarToInteger
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Actualiza un registro en la tabla NavigationTrace por medio de su clave primaria.
        ''' </summary>
        ''' <param name="navigationtraceItem">Instancia de NavigationTrace</param>
        ''' <returns>Cantidad de registros actualizados.</returns>
        Public Shared Function Update(navigationtraceItem As Architect.API.Core.Contracts.Security.NavigationTrace) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("UPDATE NavigationTrace " &
                                           "SET UserId=@:UserId, EffectDate=@:EffectDate, CompanyId=@:CompanyId " &
                                         "WHERE Id=@:Id AND Code=@:Code", "NavigationTrace", "Research")
                .AddParameter("UserId", DbType.Decimal, 9, navigationtraceItem.UserId.IsEmpty(), navigationtraceItem.UserId)
                .AddParameter("EffectDate", DbType.DateTime, 9, navigationtraceItem.EffectDate.IsEmpty(), navigationtraceItem.EffectDate)
                .AddParameter("CompanyId", DbType.Decimal, 5, navigationtraceItem.CompanyId.IsEmpty(), navigationtraceItem.CompanyId)
                .AddParameter("Id", DbType.Decimal, 9, False, navigationtraceItem.Id)
                .AddParameter("Code", DbType.AnsiStringFixedLength, 8, False, navigationtraceItem.Code)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Elimina un registro en la tabla NavigationTrace por medio de su clave primaria.
        ''' </summary>
        ''' <param name="id"></param>
        ''' <param name="code"></param>
        ''' <returns>Cantidad de registros eliminados.</returns>
        Public Shared Function Delete(id As Integer, code As String) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("DELETE FROM NavigationTrace " &
                                         "WHERE Id=@:Id AND Code=@:Code", "NavigationTrace", "Research")
                .AddParameter("Id", DbType.Decimal, 9, False, id)
                .AddParameter("Code", DbType.AnsiStringFixedLength, 8, False, code)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera la cantidad de registros existentes en la tabla NavigationTrace por medio de su clave primaria.
        ''' </summary>
        ''' <param name="id"></param>
        ''' <param name="code"></param>
        ''' <returns>Cantidad de registros encontrados.</returns>
        Public Shared Function Count(id As Integer, code As String) As Integer
            Dim rows As Integer = 0

            With New DataManagerFactory("SELECT COUNT(Id) " &
                                          "FROM NavigationTrace " &
                                         "WHERE Id=@:Id AND Code=@:Code", "NavigationTrace", "Research")
                .AddParameter("Id", DbType.Decimal, 9, False, id)
                .AddParameter("Code", DbType.AnsiStringFixedLength, 8, False, code)
                rows = .QueryExecuteScalarToInteger
            End With
            Return rows
        End Function

#Region "Helper"

        ''' <summary>
        ''' Permite hacer el mapeo entre una fila de un datatable hacia una instancia de NavigationTrace.
        ''' </summary>
        ''' <returns>Instancia de NavigationTrace</returns>
        Private Shared Function DataRowMapper(itemRow As DataRow) As Architect.API.Core.Contracts.Security.NavigationTrace
            Return New Architect.API.Core.Contracts.Security.NavigationTrace With {.Id = itemRow.NumericValue("Id"), .Code = itemRow.StringValue("Code"), .UserId = itemRow.NumericValue("UserId"), .EffectDate = itemRow.DateTimeValue("EffectDate"), .CompanyId = itemRow.NumericValue("CompanyId")}
        End Function

#End Region

    End Class

End Namespace

