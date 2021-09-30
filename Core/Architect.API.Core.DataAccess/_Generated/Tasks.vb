Imports Architect.Common.Proxy

Namespace Architect.API.Core.DataAccess.General

    ''' <summary>
    ''' Lista de tareas o chequeo.
    ''' </summary>
    Partial Public NotInheritable Class Tasks

        ''' <summary>
        ''' Crea un registro en la tabla Tasks.
        ''' </summary>
        ''' <param name="tasksItem">Instancia de Tasks</param>
        ''' <returns>Cantidad de registros creados.</returns>
        Public Shared Function Create(tasksItem As Architect.API.Core.Contracts.General.Tasks) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("INSERT INTO Tasks " &
                                              "(Id, Sequence, Title, Description, CreatedDate, DueDate, AssignedTo, Type, CompletedDate, Status, EntityType, EntityId, CompanyId, UpdateUserCode, UpdateDate) " &
                                        "VALUES(@:Id, @:Sequence, @:Title, @:Description, @:CreatedDate, @:DueDate, @:AssignedTo, @:Type, @:CompletedDate, @:Status, @:EntityType, @:EntityId, @:CompanyId, @:UpdateUserCode, @:UpdateDate)", "Tasks", "Research")
                .AddParameter("Id", DbType.Decimal, 9, tasksItem.Id.IsEmpty(), tasksItem.Id)
                .AddParameter("Sequence", DbType.Decimal, 9, tasksItem.Sequence.IsEmpty(), tasksItem.Sequence)
                .AddParameter("Title", DbType.AnsiString, 120, tasksItem.Title.IsEmpty(), tasksItem.Title)
                .AddParameter("Description", DbType.AnsiString, 512, tasksItem.Description.IsEmpty(), tasksItem.Description)
                .AddParameter("CreatedDate", DbType.DateTime, 9, tasksItem.CreatedDate.IsEmpty(), tasksItem.CreatedDate)
                .AddParameter("DueDate", DbType.DateTime, 9, tasksItem.DueDate.IsEmpty(), tasksItem.DueDate)
                .AddParameter("AssignedTo", DbType.Decimal, 9, tasksItem.AssignedTo.IsEmpty(), tasksItem.AssignedTo)
                .AddParameter("Type", DbType.Decimal, 5, tasksItem.Type.IsEmpty(), tasksItem.Type)
                .AddParameter("CompletedDate", DbType.DateTime, 9, tasksItem.CompletedDate.IsEmpty(), tasksItem.CompletedDate)
                .AddParameter("Status", DbType.Decimal, 5, tasksItem.Status.IsEmpty(), tasksItem.Status)
                .AddParameter("EntityType", DbType.Decimal, 5, tasksItem.EntityType.IsEmpty(), tasksItem.EntityType)
                .AddParameter("EntityId", DbType.Decimal, 9, tasksItem.EntityId.IsEmpty(), tasksItem.EntityId)
                .AddParameter("CompanyId", DbType.Decimal, 5, tasksItem.CompanyId.IsEmpty(), tasksItem.CompanyId)
                .AddParameter("UpdateUserCode", DbType.Decimal, 9, tasksItem.UpdateUserCode.IsEmpty(), tasksItem.UpdateUserCode)
                .AddParameter("UpdateDate", DbType.DateTime, 0, tasksItem.UpdateDate.IsEmpty(), tasksItem.UpdateDate)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera un registro en la tabla Tasks por medio de su clave primaria.
        ''' </summary>
        ''' <param name="id">Identificación única del registro.</param>
        ''' <param name="sequence">Identificación secuencial asociada al identificador único del registro.</param>
        ''' <returns>Instancia de Tasks</returns>
        Public Shared Function Retrieve(id As Integer, sequence As Integer) As Architect.API.Core.Contracts.General.Tasks
            Dim rows As Data.DataTable = Nothing
            Dim result As Architect.API.Core.Contracts.General.Tasks = Nothing
            With New DataManagerFactory("SELECT Id, Sequence, Title, Description, CreatedDate, DueDate, AssignedTo, Type, CompletedDate, Status, EntityType, EntityId, Tasks.CompanyId, Tasks.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Tasks.UpdateDate " &
                                          "FROM Tasks LEFT JOIN UserMember um ON um.UserId = Tasks.UpdateUserCode " &
                                         "WHERE Tasks.Id=@:Id AND Tasks.Sequence=@:Sequence", "Tasks", "Research")
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
        ''' Recupera una lista de registros en la tabla Tasks.
        ''' </summary>
        ''' <returns>Lista de instancias de Tasks</returns>
        Public Shared Function RetrieveAll() As List(Of Architect.API.Core.Contracts.General.Tasks)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.API.Core.Contracts.General.Tasks)
            With New DataManagerFactory("SELECT Id, Sequence, Title, Description, CreatedDate, DueDate, AssignedTo, Type, CompletedDate, Status, EntityType, EntityId, Tasks.CompanyId, Tasks.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Tasks.UpdateDate " &
                                          "FROM Tasks LEFT JOIN UserMember um ON um.UserId = Tasks.UpdateUserCode", "Tasks", "Research")
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
        ''' Último valor asignado a clave unica de la tabla Tasks.
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns>Último valor asignado.</returns>
        Public Shared Function RetrieveLastKey(id As Integer) As Integer
            Dim rows As Integer = 0

            With New DataManagerFactory("SELECT NVL(MAX(Sequence),0) " &
                                          "FROM Tasks " &
                                         "WHERE Id=@:Id", "Tasks", "Research")
                .AddParameter("Id", DbType.Decimal, 9, False, id)
                rows = .QueryExecuteScalarToInteger
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Actualiza un registro en la tabla Tasks por medio de su clave primaria.
        ''' </summary>
        ''' <param name="tasksItem">Instancia de Tasks</param>
        ''' <returns>Cantidad de registros actualizados.</returns>
        Public Shared Function Update(tasksItem As Architect.API.Core.Contracts.General.Tasks) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("UPDATE Tasks " &
                                           "SET Title=@:Title, Description=@:Description, CreatedDate=@:CreatedDate, DueDate=@:DueDate, AssignedTo=@:AssignedTo, Type=@:Type, CompletedDate=@:CompletedDate, Status=@:Status, EntityType=@:EntityType, EntityId=@:EntityId, CompanyId=@:CompanyId, UpdateUserCode=@:UpdateUserCode, UpdateDate=@:UpdateDate " &
                                         "WHERE Id=@:Id AND Sequence=@:Sequence", "Tasks", "Research")
                .AddParameter("Title", DbType.AnsiString, 120, tasksItem.Title.IsEmpty(), tasksItem.Title)
                .AddParameter("Description", DbType.AnsiString, 512, tasksItem.Description.IsEmpty(), tasksItem.Description)
                .AddParameter("CreatedDate", DbType.DateTime, 9, tasksItem.CreatedDate.IsEmpty(), tasksItem.CreatedDate)
                .AddParameter("DueDate", DbType.DateTime, 9, tasksItem.DueDate.IsEmpty(), tasksItem.DueDate)
                .AddParameter("AssignedTo", DbType.Decimal, 9, tasksItem.AssignedTo.IsEmpty(), tasksItem.AssignedTo)
                .AddParameter("Type", DbType.Decimal, 5, tasksItem.Type.IsEmpty(), tasksItem.Type)
                .AddParameter("CompletedDate", DbType.DateTime, 9, tasksItem.CompletedDate.IsEmpty(), tasksItem.CompletedDate)
                .AddParameter("Status", DbType.Decimal, 5, tasksItem.Status.IsEmpty(), tasksItem.Status)
                .AddParameter("EntityType", DbType.Decimal, 5, tasksItem.EntityType.IsEmpty(), tasksItem.EntityType)
                .AddParameter("EntityId", DbType.Decimal, 9, tasksItem.EntityId.IsEmpty(), tasksItem.EntityId)
                .AddParameter("CompanyId", DbType.Decimal, 5, tasksItem.CompanyId.IsEmpty(), tasksItem.CompanyId)
                .AddParameter("UpdateUserCode", DbType.Decimal, 9, tasksItem.UpdateUserCode.IsEmpty(), tasksItem.UpdateUserCode)
                .AddParameter("UpdateDate", DbType.DateTime, 0, tasksItem.UpdateDate.IsEmpty(), tasksItem.UpdateDate)
                .AddParameter("Id", DbType.Decimal, 9, False, tasksItem.Id)
                .AddParameter("Sequence", DbType.Decimal, 9, False, tasksItem.Sequence)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Elimina un registro en la tabla Tasks por medio de su clave primaria.
        ''' </summary>
        ''' <param name="id">Identificación única del registro.</param>
        ''' <param name="sequence">Identificación secuencial asociada al identificador único del registro.</param>
        ''' <returns>Cantidad de registros eliminados.</returns>
        Public Shared Function Delete(id As Integer, sequence As Integer) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("DELETE FROM Tasks " &
                                         "WHERE Id=@:Id AND Sequence=@:Sequence", "Tasks", "Research")
                .AddParameter("Id", DbType.Decimal, 9, False, id)
                .AddParameter("Sequence", DbType.Decimal, 9, False, sequence)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera la cantidad de registros existentes en la tabla Tasks por medio de su clave primaria.
        ''' </summary>
        ''' <param name="id"></param>
        ''' <param name="sequence"></param>
        ''' <returns>Cantidad de registros encontrados.</returns>
        Public Shared Function Count(id As Integer, sequence As Integer) As Integer
            Dim rows As Integer = 0

            With New DataManagerFactory("SELECT COUNT(Id) " &
                                          "FROM Tasks " &
                                         "WHERE Id=@:Id AND Sequence=@:Sequence", "Tasks", "Research")
                .AddParameter("Id", DbType.Decimal, 9, False, id)
                .AddParameter("Sequence", DbType.Decimal, 9, False, sequence)
                rows = .QueryExecuteScalarToInteger
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera una lista de registros en la tabla Tasks.
        ''' </summary>
        ''' <param name="entitytype"></param>
        ''' <param name="entityid"></param>
        ''' <param name="companyid"></param>
        ''' <returns>Lista de instancias de Tasks</returns>
        Public Shared Function RetrieveByEntityTypeEntityIdCompanyId(entitytype As Integer, entityid As Integer, companyid As Integer) As List(Of Architect.API.Core.Contracts.General.Tasks)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.API.Core.Contracts.General.Tasks)
            With New DataManagerFactory("Select Id, Sequence, Title, Description, CreatedDate, DueDate, AssignedTo, Type, CompletedDate, Status, EntityType, EntityId, Tasks.CompanyId, Tasks.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Tasks.UpdateDate " &
                                          "FROM Tasks LEFT JOIN UserMember um ON um.UserId = Tasks.UpdateUserCode " &
                                         "WHERE EntityType=@:EntityType AND EntityId=@:EntityId AND CompanyId=@:CompanyId", "Tasks", "Research")
                .AddParameter("EntityType", DbType.Decimal, 5, False, entitytype)
                .AddParameter("EntityId", DbType.Decimal, 9, False, entityid)
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
        ''' Elimina un registro en la tabla Tasks por medio de su clave primaria.
        ''' </summary>
        ''' <param name="entitytype"></param>
        ''' <param name="entityid"></param>
        ''' <param name="companyid"></param>
        ''' <returns>Cantidad de registros eliminados.</returns>
        Public Shared Function DeleteByEntityTypeEntityIdCompanyId(entitytype As Integer, entityid As Integer, companyid As Integer) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("DELETE FROM Tasks " &
                                         "WHERE EntityType=@:EntityType AND EntityId=@:EntityId AND CompanyId=@:CompanyId", "Tasks", "Research")
                .AddParameter("EntityType", DbType.Decimal, 5, False, entitytype)
                .AddParameter("EntityId", DbType.Decimal, 9, False, entityid)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyid)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

#Region "Helper"

        ''' <summary>
        ''' Permite hacer el mapeo entre una fila de un datatable hacia una instancia de Tasks.
        ''' </summary>
        ''' <returns>Instancia de Tasks</returns>
        Private Shared Function DataRowMapper(itemRow As DataRow) As Architect.API.Core.Contracts.General.Tasks
            Return New Architect.API.Core.Contracts.General.Tasks With {.Id = itemRow.NumericValue("Id"), .Sequence = itemRow.NumericValue("Sequence"), .Title = itemRow.StringValue("Title"), .Description = itemRow.StringValue("Description"), .CreatedDate = itemRow.DateTimeValue("CreatedDate"), .DueDate = itemRow.DateTimeValue("DueDate"), .AssignedTo = itemRow.NumericValue("AssignedTo"), .Type = itemRow.NumericValue("Type"), .CompletedDate = itemRow.DateTimeValue("CompletedDate"), .Status = itemRow.NumericValue("Status"), .EntityType = itemRow.NumericValue("EntityType"), .EntityId = itemRow.NumericValue("EntityId"), .CompanyId = itemRow.NumericValue("CompanyId"), .UpdateUserCode = itemRow.NumericValue("UpdateUserCode"), .UpdateUserName = itemRow.StringValue("UpdateUserName"), .UpdateDate = itemRow.DateTimeValue("UpdateDate")}
        End Function

#End Region

    End Class

End Namespace

