Imports Architect.Common.Proxy

Namespace Architect.API.Core.DataAccess.General

    ''' <summary>
    ''' 
    ''' </summary>
    Partial Public NotInheritable Class Labels

        ''' <summary>
        ''' Crea un registro en la tabla Labels.
        ''' </summary>
        ''' <param name="labelsItem">Instancia de Labels</param>
        ''' <returns>Instancia de Labels</returns>
        Public Shared Function Create(labelsItem As Architect.API.Core.Contracts.General.Labels) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("INSERT INTO Labels " &
                                              "(Id, Sequence, LabelId, EntityType, EntityId, CompanyId, UpdateUserCode, UpdateDate) " &
                                        "VALUES(@:Id, @:Sequence, @:LabelId, @:EntityType, @:EntityId, @:CompanyId, @:UpdateUserCode, @:UpdateDate)", "Labels", "Research")
                .AddParameter("Id", DbType.Decimal, 9, labelsItem.Id.IsEmpty(), labelsItem.Id)
                '.AddParameter("Sequence", DbType.Decimal, 9, labelsItem.Sequence.IsEmpty(), labelsItem.Sequence)
                .AddParameter("LabelId", DbType.Decimal, 5, labelsItem.LabelId.IsEmpty(), labelsItem.LabelId)
                .AddParameter("EntityType", DbType.Decimal, 5, labelsItem.EntityType.IsEmpty(), labelsItem.EntityType)
                .AddParameter("EntityId", DbType.Decimal, 9, labelsItem.EntityId.IsEmpty(), labelsItem.EntityId)
                .AddParameter("CompanyId", DbType.Decimal, 5, labelsItem.CompanyId.IsEmpty(), labelsItem.CompanyId)
                .AddParameter("UpdateUserCode", DbType.Decimal, 9, labelsItem.UpdateUserCode.IsEmpty(), labelsItem.UpdateUserCode)
                .AddParameter("UpdateDate", DbType.DateTime, 0, labelsItem.UpdateDate.IsEmpty(), labelsItem.UpdateDate)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera un registro en la tabla Labels por medio de su clave primaria.
        ''' </summary>
        ''' <param name="id"></param>
        ''' <param name="sequence"></param>
        ''' <returns>Instancia de Labels</returns>
        Public Shared Function Retrieve(id As Integer, sequence As Integer) As Architect.API.Core.Contracts.General.Labels
            Dim rows As Data.DataTable = Nothing
            Dim result As Architect.API.Core.Contracts.General.Labels = Nothing
            With New DataManagerFactory("SELECT Id, Sequence, LabelId, EntityType, EntityId, Labels.CompanyId, Labels.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Labels.UpdateDate " &
                                          "FROM Labels LEFT JOIN UserMember um ON um.UserId = Labels.UpdateUserCode " &
                                         "WHERE Id=@:Id AND Sequence=@:Sequence", "Labels", "Research")
                .AddParameter("Id", DbType.Decimal, 9, False, id)
                .AddParameter("Sequence", DbType.Decimal, 9, False, sequence)
                rows = .QueryExecuteToTable(True)
                If rows.IsNotEmpty AndAlso rows.Rows.Count <> 0 Then
                    result = DataRowMapper(rows.Rows(0))
                End If
            End With
            Return result
        End Function

        ''' <summary>
        ''' Recupera una lista de registros en la tabla Labels.
        ''' </summary>
        ''' <returns>Lista de instancias de Labels</returns>
        Public Shared Function RetrieveAll() As List(Of Architect.API.Core.Contracts.General.Labels)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.API.Core.Contracts.General.Labels)
            With New DataManagerFactory("SELECT Id, Sequence, LabelId, EntityType, EntityId, Labels.CompanyId, Labels.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Labels.UpdateDate " &
                                          "FROM Labels LEFT JOIN UserMember um ON um.UserId = Labels.UpdateUserCode", "Labels", "Research")
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
        ''' Verifica si existe un registro en la tabla Labels por medio de su clave primaria.
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns>Verdadero si existe el registro, en caso contrario falso.</returns>
        Public Shared Function RetrieveLastKey(id As Integer) As Integer
            Dim rows As Integer = 0

            With New DataManagerFactory("SELECT NVL(MAX(Sequence),0) " &
                                          "FROM Labels " &
                                         "WHERE Id=@:Id", "Labels", "Research")
                .AddParameter("Id", DbType.Decimal, 9, False, id)
                rows = .QueryExecuteScalarToInteger
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Actualiza un registro en la tabla Labels por medio de su clave primaria.
        ''' </summary>
        ''' <param name="labelsItem">Instancia de Labels</param>
        ''' <returns>Cantidad de registros actualizados.</returns>
        Public Shared Function Update(labelsItem As Architect.API.Core.Contracts.General.Labels) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("UPDATE Labels " &
                                           "SET LabelId=@:LabelId, EntityType=@:EntityType, EntityId=@:EntityId, CompanyId=@:CompanyId, UpdateUserCode=@:UpdateUserCode, UpdateDate=@:UpdateDate " &
                                         "WHERE Id=@:Id AND Sequence=@:Sequence", "Labels", "Research")
                .AddParameter("LabelId", DbType.Decimal, 5, labelsItem.LabelId.IsEmpty(), labelsItem.LabelId)
                .AddParameter("EntityType", DbType.Decimal, 5, labelsItem.EntityType.IsEmpty(), labelsItem.EntityType)
                .AddParameter("EntityId", DbType.Decimal, 9, labelsItem.EntityId.IsEmpty(), labelsItem.EntityId)
                .AddParameter("CompanyId", DbType.Decimal, 5, labelsItem.CompanyId.IsEmpty(), labelsItem.CompanyId)
                .AddParameter("UpdateUserCode", DbType.Decimal, 9, labelsItem.UpdateUserCode.IsEmpty(), labelsItem.UpdateUserCode)
                .AddParameter("UpdateDate", DbType.DateTime, 0, labelsItem.UpdateDate.IsEmpty(), labelsItem.UpdateDate)
                .AddParameter("Id", DbType.Decimal, 9, False, labelsItem.Id)
                '.AddParameter("Sequence", DbType.Decimal, 9, False, labelsItem.Sequence)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Elimina un registro en la tabla Labels por medio de su clave primaria.
        ''' </summary>
        ''' <param name="id"></param>
        ''' <param name="sequence"></param>
        ''' <returns>Cantidad de registros eliminados.</returns>
        Public Shared Function Delete(id As Integer, sequence As Integer) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("DELETE FROM Labels " &
                                         "WHERE Id=@:Id AND Sequence=@:Sequence", "Labels", "Research")
                .AddParameter("Id", DbType.Decimal, 9, False, id)
                .AddParameter("Sequence", DbType.Decimal, 9, False, sequence)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera la cantidad de registros existentes en la tabla Labels por medio de su clave primaria.
        ''' </summary>
        ''' <param name="id"></param>
        ''' <param name="sequence"></param>
        ''' <returns>Cantidad de registros encontrados.</returns>
        Public Shared Function Count(id As Integer, sequence As Integer) As Integer
            Dim rows As Integer = 0

            With New DataManagerFactory("SELECT COUNT(Id) " &
                                          "FROM Labels " &
                                         "WHERE Id=@:Id AND Sequence=@:Sequence", "Labels", "Research")
                .AddParameter("Id", DbType.Decimal, 9, False, id)
                .AddParameter("Sequence", DbType.Decimal, 9, False, sequence)
                rows = .QueryExecuteScalarToInteger
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera una lista de registros en la tabla Labels.
        ''' </summary>
        ''' <param name="entityid"></param>
        ''' <param name="entitytype"></param>
        ''' <param name="companyid"></param>
        ''' <returns>Lista de instancias de Labels</returns>
        Public Shared Function RetrieveByEntityIdEntityTypeCompanyId(entityid As Integer, entitytype As Integer, companyid As Integer) As List(Of Architect.API.Core.Contracts.General.Labels)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.API.Core.Contracts.General.Labels)
            With New DataManagerFactory("Select Id, Sequence, LabelId, EntityType, EntityId, Labels.CompanyId, Labels.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Labels.UpdateDate " &
                                          "FROM Labels LEFT JOIN UserMember um ON um.UserId = Labels.UpdateUserCode " &
                                         "WHERE EntityId=@:EntityId AND EntityType=@:EntityType AND CompanyId=@:CompanyId", "Labels", "Research")
                .AddParameter("EntityId", DbType.Decimal, 9, False, entityid)
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
        ''' Elimina un registro en la tabla Labels por medio de su clave primaria.
        ''' </summary>
        ''' <param name="entityid"></param>
        ''' <param name="entitytype"></param>
        ''' <param name="companyid"></param>
        ''' <returns>Cantidad de registros eliminados.</returns>
        Public Shared Function DeleteByEntityIdEntityTypeCompanyId(entityid As Integer, entitytype As Integer, companyid As Integer) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("DELETE FROM Labels " &
                                         "WHERE EntityId=@:EntityId AND EntityType=@:EntityType AND CompanyId=@:CompanyId", "Labels", "Research")
                .AddParameter("EntityId", DbType.Decimal, 9, False, entityid)
                .AddParameter("EntityType", DbType.Decimal, 5, False, entitytype)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyid)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

#Region "Helper"

        ''' <summary>
        ''' Permite hacer el mapeo entre una fila de un datatable hacia una instancia de Labels.
        ''' </summary>
        ''' <returns>Instancia de Labels</returns>
        Private Shared Function DataRowMapper(itemRow As DataRow) As Architect.API.Core.Contracts.General.Labels
            Return New Architect.API.Core.Contracts.General.Labels With {.Id = itemRow.NumericValue("Id"), .LabelId = itemRow.NumericValue("LabelId"), .EntityType = itemRow.NumericValue("EntityType"), .EntityId = itemRow.NumericValue("EntityId"), .CompanyId = itemRow.NumericValue("CompanyId"), .UpdateUserCode = itemRow.NumericValue("UpdateUserCode"), .UpdateUserName = itemRow.StringValue("UpdateUserName"), .UpdateDate = itemRow.DateTimeValue("UpdateDate")}
        End Function

#End Region

    End Class

End Namespace

