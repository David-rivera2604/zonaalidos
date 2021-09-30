Imports Architect.Common.Proxy

Namespace Architect.API.Core.DataAccess.General

    ''' <summary>
    ''' 
    ''' </summary>
    Partial Public NotInheritable Class ChangeSet

        ''' <summary>
        ''' Crea un registro en la tabla ChangeSet.
        ''' </summary>
        ''' <param name="changesetItem">Instancia de ChangeSet</param>
        ''' <returns>Instancia de ChangeSet</returns>
        Public Shared Function Create(changesetItem As Architect.API.Core.Contracts.General.ChangeSet) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("INSERT INTO ChangeSet " &
                                              "(Id, EntityType, EntityId, Action, Summary, CompanyId, UpdateUserCode, UpdateDate) " &
                                        "VALUES(@:Id, @:EntityType, @:EntityId, @:Action, @:Summary, @:CompanyId, @:UpdateUserCode, @:UpdateDate)", "ChangeSet", "Research")
                .AddParameter("Id", DbType.Decimal, 9, changesetItem.Id.IsEmpty(), changesetItem.Id)
                .AddParameter("EntityType", DbType.Decimal, 5, changesetItem.EntityType.IsEmpty(), changesetItem.EntityType)
                .AddParameter("EntityId", DbType.Decimal, 18, changesetItem.EntityId.IsEmpty(), changesetItem.EntityId)
                .AddParameter("Action", DbType.AnsiString, 40, changesetItem.Action.IsEmpty(), changesetItem.Action)
                .AddParameter("Summary", DbType.AnsiString, 256, changesetItem.Summary.IsEmpty(), changesetItem.Summary)
                .AddParameter("CompanyId", DbType.Decimal, 5, changesetItem.CompanyId.IsEmpty(), changesetItem.CompanyId)
                .AddParameter("UpdateUserCode", DbType.Decimal, 9, changesetItem.UpdateUserCode.IsEmpty(), changesetItem.UpdateUserCode)
                .AddParameter("UpdateDate", DbType.DateTime, 0, changesetItem.UpdateDate.IsEmpty(), changesetItem.UpdateDate)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera un registro en la tabla ChangeSet por medio de su clave primaria.
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns>Instancia de ChangeSet</returns>
        Public Shared Function Retrieve(id As Integer) As Architect.API.Core.Contracts.General.ChangeSet
            Dim rows As Data.DataTable = Nothing
            Dim result As Architect.API.Core.Contracts.General.ChangeSet = Nothing
            With New DataManagerFactory("SELECT Id, EntityType, EntityId, Action, Summary, ChangeSet.CompanyId, ChangeSet.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ChangeSet.UpdateDate " &
                                          "FROM ChangeSet LEFT JOIN UserMember um ON um.UserId = ChangeSet.UpdateUserCode " &
                                         "WHERE Id=@:Id", "ChangeSet", "Research")
                .AddParameter("Id", DbType.Decimal, 9, False, id)
                rows = .QueryExecuteToTable(True)
                If rows.IsNotEmpty AndAlso rows.Rows.Count <> 0 Then
                    result = DataRowMapper(rows.Rows(0))
                End If
            End With
            Return result
        End Function

        ''' <summary>
        ''' Recupera una lista de registros en la tabla ChangeSet.
        ''' </summary>
        ''' <returns>Lista de instancias de ChangeSet</returns>
        Public Shared Function RetrieveAll() As List(Of Architect.API.Core.Contracts.General.ChangeSet)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.API.Core.Contracts.General.ChangeSet)
            With New DataManagerFactory("SELECT Id, EntityType, EntityId, Action, Summary, ChangeSet.CompanyId, ChangeSet.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ChangeSet.UpdateDate " &
                                          "FROM ChangeSet LEFT JOIN UserMember um ON um.UserId = ChangeSet.UpdateUserCode", "ChangeSet", "Research")
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
        ''' Verifica si existe un registro en la tabla ChangeSet por medio de su clave primaria.
        ''' </summary>
        ''' <returns>Verdadero si existe el registro, en caso contrario falso.</returns>
        Public Shared Function RetrieveLastKey() As Integer
            Dim rows As Integer = 0

            With New DataManagerFactory("SELECT NVL(MAX(Id),0) " &
                                          "FROM ChangeSet", "ChangeSet", "Research")
                rows = .QueryExecuteScalarToInteger
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Actualiza un registro en la tabla ChangeSet por medio de su clave primaria.
        ''' </summary>
        ''' <param name="changesetItem">Instancia de ChangeSet</param>
        ''' <returns>Cantidad de registros actualizados.</returns>
        Public Shared Function Update(changesetItem As Architect.API.Core.Contracts.General.ChangeSet) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("UPDATE ChangeSet " &
                                           "SET EntityType=@:EntityType, EntityId=@:EntityId, Action=@:Action, Summary=@:Summary, CompanyId=@:CompanyId, UpdateUserCode=@:UpdateUserCode, UpdateDate=@:UpdateDate " &
                                         "WHERE Id=@:Id", "ChangeSet", "Research")
                .AddParameter("EntityType", DbType.Decimal, 5, changesetItem.EntityType.IsEmpty(), changesetItem.EntityType)
                .AddParameter("EntityId", DbType.Decimal, 18, changesetItem.EntityId.IsEmpty(), changesetItem.EntityId)
                .AddParameter("Action", DbType.AnsiString, 40, changesetItem.Action.IsEmpty(), changesetItem.Action)
                .AddParameter("Summary", DbType.AnsiString, 256, changesetItem.Summary.IsEmpty(), changesetItem.Summary)
                .AddParameter("CompanyId", DbType.Decimal, 5, changesetItem.CompanyId.IsEmpty(), changesetItem.CompanyId)
                .AddParameter("UpdateUserCode", DbType.Decimal, 9, changesetItem.UpdateUserCode.IsEmpty(), changesetItem.UpdateUserCode)
                .AddParameter("UpdateDate", DbType.DateTime, 0, changesetItem.UpdateDate.IsEmpty(), changesetItem.UpdateDate)
                .AddParameter("Id", DbType.Decimal, 9, False, changesetItem.Id)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Elimina un registro en la tabla ChangeSet por medio de su clave primaria.
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns>Cantidad de registros eliminados.</returns>
        Public Shared Function Delete(id As Integer) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("DELETE FROM ChangeSet " &
                                         "WHERE Id=@:Id", "ChangeSet", "Research")
                .AddParameter("Id", DbType.Decimal, 9, False, id)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera la cantidad de registros existentes en la tabla ChangeSet por medio de su clave primaria.
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns>Cantidad de registros encontrados.</returns>
        Public Shared Function Count(id As Integer) As Integer
            Dim rows As Integer = 0

            With New DataManagerFactory("SELECT COUNT(Id) " &
                                          "FROM ChangeSet " &
                                         "WHERE Id=@:Id", "ChangeSet", "Research")
                .AddParameter("Id", DbType.Decimal, 9, False, id)
                rows = .QueryExecuteScalarToInteger
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera una lista de registros en la tabla ChangeSet.
        ''' </summary>
        ''' <param name="entityid"></param>
        ''' <param name="entitytype"></param>
        ''' <param name="companyid"></param>
        ''' <returns>Lista de instancias de ChangeSet</returns>
        Public Shared Function RetrieveByEntityIdEntityTypeCompanyId(entityid As Long, entitytype As Integer, companyid As Integer) As List(Of Architect.API.Core.Contracts.General.ChangeSet)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.API.Core.Contracts.General.ChangeSet)
            With New DataManagerFactory("Select Id, EntityType, EntityId, Action, Summary, ChangeSet.CompanyId, ChangeSet.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ChangeSet.UpdateDate " &
                                          "FROM ChangeSet LEFT JOIN UserMember um ON um.UserId = ChangeSet.UpdateUserCode " &
                                         "WHERE EntityId=@:EntityId AND EntityType=@:EntityType AND CompanyId=@:CompanyId", "ChangeSet", "Research")
                .AddParameter("EntityId", DbType.Decimal, 18, False, entityid)
                .AddParameter("EntityType", DbType.Decimal, 5, False, entitytype)
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
        ''' Elimina un registro en la tabla ChangeSet por medio de su clave primaria.
        ''' </summary>
        ''' <param name="entityid"></param>
        ''' <param name="entitytype"></param>
        ''' <param name="companyid"></param>
        ''' <returns>Cantidad de registros eliminados.</returns>
        Public Shared Function DeleteByEntityIdEntityTypeCompanyId(entityid As Long, entitytype As Integer, companyid As Integer) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("DELETE FROM ChangeSet " &
                                         "WHERE EntityId=@:EntityId AND EntityType=@:EntityType AND CompanyId=@:CompanyId", "ChangeSet", "Research")
                .AddParameter("EntityId", DbType.Decimal, 8, False, entityid)
                .AddParameter("EntityType", DbType.Decimal, 5, False, entitytype)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyid)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

#Region "Helper"

        ''' <summary>
        ''' Permite hacer el mapeo entre una fila de un datatable hacia una instancia de ChangeSet.
        ''' </summary>
        ''' <returns>Instancia de ChangeSet</returns>
        Private Shared Function DataRowMapper(itemRow As DataRow) As Architect.API.Core.Contracts.General.ChangeSet
            Return New Architect.API.Core.Contracts.General.ChangeSet With {.Id = itemRow.NumericValue("Id"), .EntityType = itemRow.NumericValue("EntityType"), .EntityId = itemRow.NumericValue("EntityId"), .Action = itemRow.StringValue("Action"), .Summary = itemRow.StringValue("Summary"), .CompanyId = itemRow.NumericValue("CompanyId"), .UpdateUserCode = itemRow.NumericValue("UpdateUserCode"), .UpdateUserName = itemRow.StringValue("UpdateUserName"), .UpdateDate = itemRow.DateTimeValue("UpdateDate")}
        End Function

#End Region

    End Class

End Namespace

