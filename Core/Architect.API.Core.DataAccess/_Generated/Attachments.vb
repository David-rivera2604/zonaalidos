Imports Architect.Common.Proxy

Namespace Architect.API.Core.DataAccess.General

    ''' <summary>
    ''' 
    ''' </summary>
    Partial Public NotInheritable Class Attachments

        ''' <summary>
        ''' Crea un registro en la tabla Attachments.
        ''' </summary>
        ''' <param name="attachmentsItem">Instancia de Attachments</param>
        ''' <returns>Instancia de Attachments</returns>
        Public Shared Function Create(attachmentsItem As Architect.API.Core.Contracts.General.Attachments) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("INSERT INTO Attachments " &
                                              "(Id, DocumentType, Description, FileName, FileSize, FileContent, EntityType, EntityId, CompanyId, UpdateUserCode, UpdateDate) " &
                                        "VALUES(@:Id, @:DocumentType, @:Description, @:FileName, @:FileSize, @:FileContent, @:EntityType, @:EntityId, @:CompanyId, @:UpdateUserCode, @:UpdateDate)", "Attachments", "Research")
                .AddParameter("Id", DbType.Decimal, 9, attachmentsItem.Id.IsEmpty(), attachmentsItem.Id)
                .AddParameter("DocumentType", DbType.Decimal, 5, attachmentsItem.DocumentType.IsEmpty(), attachmentsItem.DocumentType)
                .AddParameter("Description", DbType.AnsiString, 120, attachmentsItem.Description.IsEmpty(), attachmentsItem.Description)
                .AddParameter("FileName", DbType.AnsiString, 80, attachmentsItem.FileName.IsEmpty(), attachmentsItem.FileName)
                .AddParameter("FileSize", DbType.Decimal, 9, attachmentsItem.FileSize.IsEmpty(), attachmentsItem.FileSize)
                If attachmentsItem.FileContent.IsNotEmpty Then
                    Dim contenido As Byte() = Common.Helpers.ByteHandler.FileToBytes(attachmentsItem.FileContent)
                    .AddParameter("FileContent", DbType.Binary, 0, False, contenido)
                Else
                    .AddParameter("FileContent", DbType.Binary, 0, True, Nothing)
                End If
                .AddParameter("EntityType", DbType.Decimal, 5, attachmentsItem.EntityType.IsEmpty(), attachmentsItem.EntityType)
                .AddParameter("EntityId", DbType.Decimal, 18, attachmentsItem.EntityId.IsEmpty(), attachmentsItem.EntityId)
                .AddParameter("CompanyId", DbType.Decimal, 5, attachmentsItem.CompanyId.IsEmpty(), attachmentsItem.CompanyId)
                .AddParameter("UpdateUserCode", DbType.Decimal, 9, attachmentsItem.UpdateUserCode.IsEmpty(), attachmentsItem.UpdateUserCode)
                .AddParameter("UpdateDate", DbType.DateTime, 0, attachmentsItem.UpdateDate.IsEmpty(), attachmentsItem.UpdateDate)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera un registro en la tabla Attachments por medio de su clave primaria.
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns>Instancia de Attachments</returns>
        Public Shared Function Retrieve(id As Integer) As Architect.API.Core.Contracts.General.Attachments
            Dim rows As Data.DataTable = Nothing
            Dim result As Architect.API.Core.Contracts.General.Attachments = Nothing
            With New DataManagerFactory("SELECT Id, DocumentType, Description, FileName, FileSize, FileContent, EntityType, EntityId, Attachments.CompanyId, Attachments.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Attachments.UpdateDate " &
                                          "FROM Attachments LEFT JOIN UserMember um ON um.UserId = Attachments.UpdateUserCode " &
                                         "WHERE Id=@:Id", "Attachments", "Research")
                .AddParameter("Id", DbType.Decimal, 9, False, id)
                rows = .QueryExecuteToTable(True)
                If rows.IsNotEmpty AndAlso rows.Rows.Count <> 0 Then
                    result = DataRowMapper(rows.Rows(0))
                End If
            End With
            Return result
        End Function

        ''' <summary>
        ''' Recupera una lista de registros en la tabla Attachments.
        ''' </summary>
        ''' <returns>Lista de instancias de Attachments</returns>
        Public Shared Function RetrieveAll() As List(Of Architect.API.Core.Contracts.General.Attachments)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.API.Core.Contracts.General.Attachments)
            With New DataManagerFactory("SELECT Id, DocumentType, Description, FileName, FileSize, FileContent, EntityType, EntityId, Attachments.CompanyId, Attachments.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Attachments.UpdateDate " &
                                          "FROM Attachments LEFT JOIN UserMember um ON um.UserId = Attachments.UpdateUserCode", "Attachments", "Research")
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
        ''' Verifica si existe un registro en la tabla Attachments por medio de su clave primaria.
        ''' </summary>
        ''' <returns>Verdadero si existe el registro, en caso contrario falso.</returns>
        Public Shared Function RetrieveLastKey() As Integer
            Dim rows As Integer = 0

            With New DataManagerFactory("SELECT NVL(MAX(Id),0) " &
                                          "FROM Attachments", "Attachments", "Research")
                rows = .QueryExecuteScalarToInteger
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Actualiza un registro en la tabla Attachments por medio de su clave primaria.
        ''' </summary>
        ''' <param name="attachmentsItem">Instancia de Attachments</param>
        ''' <returns>Cantidad de registros actualizados.</returns>
        Public Shared Function Update(attachmentsItem As Architect.API.Core.Contracts.General.Attachments) As Integer
            Dim rows As Integer = 0
            If attachmentsItem.FileContent.IsNotEmpty Then
                Dim contenido As Byte() = Common.Helpers.ByteHandler.FileToBytes(attachmentsItem.FileContent)
                With New DataManagerFactory("UPDATE Attachments " &
                                               "SET DocumentType=@:DocumentType, Description=@:Description, FileName=@:FileName, FileSize=@:FileSize, FileContent=@:FileContent, EntityType=@:EntityType, EntityId=@:EntityId, CompanyId=@:CompanyId, UpdateUserCode=@:UpdateUserCode, UpdateDate=@:UpdateDate " &
                                             "WHERE Id=@:Id", "Attachments", "Research")
                    .AddParameter("DocumentType", DbType.Decimal, 5, attachmentsItem.DocumentType.IsEmpty(), attachmentsItem.DocumentType)
                    .AddParameter("Description", DbType.AnsiString, 120, attachmentsItem.Description.IsEmpty(), attachmentsItem.Description)
                    .AddParameter("FileName", DbType.AnsiString, 80, attachmentsItem.FileName.IsEmpty(), attachmentsItem.FileName)
                    .AddParameter("FileSize", DbType.Decimal, 9, attachmentsItem.FileSize.IsEmpty(), attachmentsItem.FileSize)

                    .AddParameter("FileContent", DbType.Binary, 0, False, contenido)
                    .AddParameter("EntityType", DbType.Decimal, 5, attachmentsItem.EntityType.IsEmpty(), attachmentsItem.EntityType)
                    .AddParameter("EntityId", DbType.Decimal, 18, attachmentsItem.EntityId.IsEmpty(), attachmentsItem.EntityId)
                    .AddParameter("CompanyId", DbType.Decimal, 5, attachmentsItem.CompanyId.IsEmpty(), attachmentsItem.CompanyId)
                    .AddParameter("UpdateUserCode", DbType.Decimal, 9, attachmentsItem.UpdateUserCode.IsEmpty(), attachmentsItem.UpdateUserCode)
                    .AddParameter("UpdateDate", DbType.DateTime, 0, attachmentsItem.UpdateDate.IsEmpty(), attachmentsItem.UpdateDate)
                    .AddParameter("Id", DbType.Decimal, 9, False, attachmentsItem.Id)
                    rows = .CommandExecute()
                End With
            Else
                With New DataManagerFactory("UPDATE Attachments " &
                                               "SET DocumentType=@:DocumentType, Description=@:Description, FileName=@:FileName, FileSize=@:FileSize, EntityType=@:EntityType, EntityId=@:EntityId, CompanyId=@:CompanyId, UpdateUserCode=@:UpdateUserCode, UpdateDate=@:UpdateDate " &
                                             "WHERE Id=@:Id", "Attachments", "Research")
                    .AddParameter("DocumentType", DbType.Decimal, 5, attachmentsItem.DocumentType.IsEmpty(), attachmentsItem.DocumentType)
                    .AddParameter("Description", DbType.AnsiString, 120, attachmentsItem.Description.IsEmpty(), attachmentsItem.Description)
                    .AddParameter("FileName", DbType.AnsiString, 80, attachmentsItem.FileName.IsEmpty(), attachmentsItem.FileName)
                    .AddParameter("FileSize", DbType.Decimal, 9, attachmentsItem.FileSize.IsEmpty(), attachmentsItem.FileSize)
                    .AddParameter("EntityType", DbType.Decimal, 5, attachmentsItem.EntityType.IsEmpty(), attachmentsItem.EntityType)
                    .AddParameter("EntityId", DbType.Decimal, 18, attachmentsItem.EntityId.IsEmpty(), attachmentsItem.EntityId)
                    .AddParameter("CompanyId", DbType.Decimal, 5, attachmentsItem.CompanyId.IsEmpty(), attachmentsItem.CompanyId)
                    .AddParameter("UpdateUserCode", DbType.Decimal, 9, attachmentsItem.UpdateUserCode.IsEmpty(), attachmentsItem.UpdateUserCode)
                    .AddParameter("UpdateDate", DbType.DateTime, 0, attachmentsItem.UpdateDate.IsEmpty(), attachmentsItem.UpdateDate)
                    .AddParameter("Id", DbType.Decimal, 9, False, attachmentsItem.Id)
                    rows = .CommandExecute()
                End With
            End If

            Return rows
        End Function

        ''' <summary>
        ''' Elimina un registro en la tabla Attachments por medio de su clave primaria.
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns>Cantidad de registros eliminados.</returns>
        Public Shared Function Delete(id As Integer) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("DELETE FROM Attachments " &
                                         "WHERE Id=@:Id", "Attachments", "Research")
                .AddParameter("Id", DbType.Decimal, 9, False, id)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera la cantidad de registros existentes en la tabla Attachments por medio de su clave primaria.
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns>Cantidad de registros encontrados.</returns>
        Public Shared Function Count(id As Integer) As Integer
            Dim rows As Integer = 0

            With New DataManagerFactory("SELECT COUNT(Id) " &
                                          "FROM Attachments " &
                                         "WHERE Id=@:Id", "Attachments", "Research")
                .AddParameter("Id", DbType.Decimal, 9, False, id)
                rows = .QueryExecuteScalarToInteger
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera una lista de registros en la tabla Attachments.
        ''' </summary>
        ''' <param name="entityid"></param>
        ''' <param name="entitytype"></param>
        ''' <param name="companyid"></param>
        ''' <returns>Lista de instancias de Attachments</returns>
        Public Shared Function RetrieveByEntityIdEntityTypeCompanyId(entityid As Long, entitytype As Integer, companyid As Integer) As List(Of Architect.API.Core.Contracts.General.Attachments)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.API.Core.Contracts.General.Attachments)
            With New DataManagerFactory("Select Id, DocumentType, Description, FileName, FileSize, FileContent, EntityType, EntityId, Attachments.CompanyId, Attachments.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Attachments.UpdateDate " &
                                          "FROM Attachments LEFT JOIN UserMember um ON um.UserId = Attachments.UpdateUserCode " &
                                         "WHERE EntityId=@:EntityId AND EntityType=@:EntityType AND CompanyId=@:CompanyId", "Attachments", "Research")
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
        ''' Elimina un registro en la tabla Attachments por medio de su clave primaria.
        ''' </summary>
        ''' <param name="entityid"></param>
        ''' <param name="entitytype"></param>
        ''' <param name="companyid"></param>
        ''' <returns>Cantidad de registros eliminados.</returns>
        Public Shared Function DeleteByEntityIdEntityTypeCompanyId(entityid As Long, entitytype As Integer, companyid As Integer) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("DELETE FROM Attachments " &
                                         "WHERE EntityId=@:EntityId AND EntityType=@:EntityType AND CompanyId=@:CompanyId", "Attachments", "Research")
                .AddParameter("EntityId", DbType.Decimal, 18, False, entityid)
                .AddParameter("EntityType", DbType.Decimal, 5, False, entitytype)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyid)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

#Region "Helper"

        ''' <summary>
        ''' Permite hacer el mapeo entre una fila de un datatable hacia una instancia de Attachments.
        ''' </summary>
        ''' <returns>Instancia de Attachments</returns>
        Private Shared Function DataRowMapper(itemRow As DataRow) As Architect.API.Core.Contracts.General.Attachments
            Return New Architect.API.Core.Contracts.General.Attachments With {.Id = itemRow.NumericValue("Id"), .DocumentType = itemRow.NumericValue("DocumentType"), .Description = itemRow.StringValue("Description"), .FileName = itemRow.StringValue("FileName"), .FileSize = itemRow.NumericValue("FileSize"), .FileContent = itemRow.StringValue("FileContent"), .EntityType = itemRow.NumericValue("EntityType"), .EntityId = itemRow.NumericValue("EntityId"), .CompanyId = itemRow.NumericValue("CompanyId"), .UpdateUserCode = itemRow.NumericValue("UpdateUserCode"), .UpdateUserName = itemRow.StringValue("UpdateUserName"), .UpdateDate = itemRow.DateTimeValue("UpdateDate")}
        End Function

#End Region

    End Class

End Namespace

