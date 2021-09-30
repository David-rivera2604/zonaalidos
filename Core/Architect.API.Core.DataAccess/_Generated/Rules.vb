Imports Architect.Common.Proxy

Namespace Architect.API.Core.DataAccess.General

    ''' <summary>
    ''' 
    ''' </summary>
    Partial Public NotInheritable Class Rules

        ''' <summary>
        ''' Crea un registro en la tabla Rules.
        ''' </summary>
        ''' <param name="rulesItem">Instancia de Rules</param>
        ''' <returns>Instancia de Rules</returns>
        Public Shared Function Create(rulesItem As Architect.API.Core.Contracts.General.Rules) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("INSERT INTO Rules " &
                                              "(Id, CompanyId, EntityType, Action, Sequence, Description, Statement, RecordStatus, UpdateUserCode, UpdateDate) " &
                                        "VALUES(@:Id, @:CompanyId, @:EntityType, @:Action, @:Sequence, @:Description, @:Statement, @:RecordStatus, @:UpdateUserCode, @:UpdateDate)", "Rules", "Research")
                .AddParameter("Id", DbType.Decimal, 9, rulesItem.Id.IsEmpty(), rulesItem.Id)
                .AddParameter("CompanyId", DbType.Decimal, 5, rulesItem.CompanyId.IsEmpty(), rulesItem.CompanyId)
                .AddParameter("EntityType", DbType.Decimal, 5, rulesItem.EntityType.IsEmpty(), rulesItem.EntityType)
                .AddParameter("Action", DbType.AnsiString, 30, rulesItem.Action.IsEmpty(), rulesItem.Action)
                .AddParameter("Sequence", DbType.Decimal, 9, rulesItem.Sequence.IsEmpty(), rulesItem.Sequence)
                .AddParameter("Description", DbType.AnsiString, 120, rulesItem.Description.IsEmpty(), rulesItem.Description)
                .AddParameter("Statement", DbType.AnsiString, 2048, rulesItem.Statement.IsEmpty(), rulesItem.Statement)
                .AddParameter("RecordStatus", DbType.Decimal, 5, rulesItem.RecordStatus.IsEmpty(), rulesItem.RecordStatus)
                .AddParameter("UpdateUserCode", DbType.Decimal, 9, rulesItem.UpdateUserCode.IsEmpty(), rulesItem.UpdateUserCode)
                .AddParameter("UpdateDate", DbType.DateTime, 0, rulesItem.UpdateDate.IsEmpty(), rulesItem.UpdateDate)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera un registro en la tabla Rules por medio de su clave primaria.
        ''' </summary>
        ''' <param name="id"></param>
        ''' <param name="companyId"></param>
        ''' <returns>Instancia de Rules</returns>
        Public Shared Function Retrieve(id As Integer, companyId As Integer) As Architect.API.Core.Contracts.General.Rules
            Dim rows As Data.DataTable = Nothing
            Dim result As Architect.API.Core.Contracts.General.Rules = Nothing
            With New DataManagerFactory("SELECT Id, Rules.CompanyId, EntityType, Action, Sequence, Description, Statement, Rules.RecordStatus, Rules.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Rules.UpdateDate " &
                                          "FROM Rules LEFT JOIN UserMember um ON um.UserId = Rules.UpdateUserCode " &
                                         "WHERE Rules.Id=@:Id AND Rules.CompanyId=@:CompanyId", "Rules", "Research")
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
        ''' Recupera una lista de registros en la tabla Rules.
        ''' </summary>
        ''' <param name="companyId"></param>
        ''' <param name="filter"></param>
        ''' <returns>Lista de instancias de Rules</returns>
        Public Shared Function RetrieveAll(companyId As Integer, filter As String) As List(Of Architect.API.Core.Contracts.General.Rules)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.API.Core.Contracts.General.Rules)
            With New DataManagerFactory("SELECT Id, Rules.CompanyId, EntityType, Action, Sequence, Description, Statement, Rules.RecordStatus, Rules.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Rules.UpdateDate " &
                                          "FROM Rules LEFT JOIN UserMember um ON um.UserId = Rules.UpdateUserCode " &
                                         "WHERE Rules.CompanyId=@:CompanyId", "Rules", "Research")
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
        ''' Verifica si existe un registro en la tabla Rules por medio de su clave primaria.
        ''' </summary>
        ''' <returns>Verdadero si existe el registro, en caso contrario falso.</returns>
        Public Shared Function RetrieveLastKey() As Integer
            Dim rows As Integer = 0

            With New DataManagerFactory("SELECT NVL(MAX(Id),0) " &
                                          "FROM Rules", "Rules", "Research")
                rows = .QueryExecuteScalarToInteger
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Actualiza un registro en la tabla Rules por medio de su clave primaria.
        ''' </summary>
        ''' <param name="rulesItem">Instancia de Rules</param>
        ''' <returns>Cantidad de registros actualizados.</returns>
        Public Shared Function Update(rulesItem As Architect.API.Core.Contracts.General.Rules) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("UPDATE Rules " &
                                           "SET CompanyId=@:CompanyId, EntityType=@:EntityType, Action=@:Action, Sequence=@:Sequence, Description=@:Description, Statement=@:Statement, RecordStatus=@:RecordStatus, UpdateUserCode=@:UpdateUserCode, UpdateDate=@:UpdateDate " &
                                         "WHERE Id=@:Id", "Rules", "Research")
                .AddParameter("CompanyId", DbType.Decimal, 5, rulesItem.CompanyId.IsEmpty(), rulesItem.CompanyId)
                .AddParameter("EntityType", DbType.Decimal, 5, rulesItem.EntityType.IsEmpty(), rulesItem.EntityType)
                .AddParameter("Action", DbType.AnsiString, 30, rulesItem.Action.IsEmpty(), rulesItem.Action)
                .AddParameter("Sequence", DbType.Decimal, 9, rulesItem.Sequence.IsEmpty(), rulesItem.Sequence)
                .AddParameter("Description", DbType.AnsiString, 120, rulesItem.Description.IsEmpty(), rulesItem.Description)
                .AddParameter("Statement", DbType.AnsiString, 2048, rulesItem.Statement.IsEmpty(), rulesItem.Statement)
                .AddParameter("RecordStatus", DbType.Decimal, 5, rulesItem.RecordStatus.IsEmpty(), rulesItem.RecordStatus)
                .AddParameter("UpdateUserCode", DbType.Decimal, 9, rulesItem.UpdateUserCode.IsEmpty(), rulesItem.UpdateUserCode)
                .AddParameter("UpdateDate", DbType.DateTime, 0, rulesItem.UpdateDate.IsEmpty(), rulesItem.UpdateDate)
                .AddParameter("Id", DbType.Decimal, 9, False, rulesItem.Id)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Elimina un registro en la tabla Rules por medio de su clave primaria.
        ''' </summary>
        ''' <param name="id"></param>
        ''' <param name="companyId"></param>
        ''' <returns>Cantidad de registros eliminados.</returns>
        Public Shared Function Delete(id As Integer, companyId As Integer) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("DELETE FROM Rules " &
                                         "WHERE Id=@:Id AND CompanyId=@:CompanyId", "Rules", "Research")
                .AddParameter("Id", DbType.Decimal, 9, False, id)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera la cantidad de registros existentes en la tabla Rules por medio de su clave primaria.
        ''' </summary>
        ''' <param name="id"></param>
        ''' <param name="companyId"></param>
        ''' <returns>Cantidad de registros encontrados.</returns>
        Public Shared Function Count(id As Integer, companyId As Integer) As Integer
            Dim rows As Integer = 0

            With New DataManagerFactory("SELECT COUNT(Id) " &
                                          "FROM Rules " &
                                         "WHERE Id=@:Id AND CompanyId=@:CompanyId", "Rules", "Research")
                .AddParameter("Id", DbType.Decimal, 9, False, id)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                rows = .QueryExecuteScalarToInteger
            End With
            Return rows
        End Function

#Region "Helper"

        ''' <summary>
        ''' Permite hacer el mapeo entre una fila de un datatable hacia una instancia de Rules.
        ''' </summary>
        ''' <returns>Instancia de Rules</returns>
        Private Shared Function DataRowMapper(itemRow As DataRow) As Architect.API.Core.Contracts.General.Rules
            Return New Architect.API.Core.Contracts.General.Rules With {.Id = itemRow.NumericValue("Id"), .CompanyId = itemRow.NumericValue("CompanyId"), .EntityType = itemRow.NumericValue("EntityType"), .Action = itemRow.StringValue("Action"), .Sequence = itemRow.NumericValue("Sequence"), .Description = itemRow.StringValue("Description"), .Statement = itemRow.StringValue("Statement"), .RecordStatus = itemRow.NumericValue("RecordStatus"), .UpdateUserCode = itemRow.NumericValue("UpdateUserCode"), .UpdateUserName = itemRow.StringValue("UpdateUserName"), .UpdateDate = itemRow.DateTimeValue("UpdateDate")}
        End Function

#End Region

    End Class

End Namespace

