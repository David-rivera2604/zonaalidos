Imports Architect.Common.Proxy

Namespace Architect.API.Core.DataAccess.General

    Partial Public NotInheritable Class Attachments

        Public Shared Function RetrieveByEntity(entityType As Integer, entityId As Long, companyId As Integer) As List(Of Architect.API.Core.Contracts.General.AttachmentView)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.API.Core.Contracts.General.AttachmentView)
            With New DataManagerFactory("SELECT Id, DocumentType, Attachments.Description, FileName, FileSize, Attachments.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Attachments.UpdateDate " &
                                             ", LKDT.DESCRIPTION DocumentTypeDesc " &
                                          "FROM Attachments " &
                                     "LEFT JOIN UserMember um ON um.UserId= Attachments.UpdateUserCode " &
                                     "LEFT JOIN LOOKUP LKDT ON LKDT.LOOKUPID = 100 And LKDT.CODE = Attachments.DocumentType And LKDT.LANGUAGE=1 " +
                                         "WHERE EntityType=@:EntityType AND EntityId=@:EntityId AND Attachments.CompanyId=@:CompanyId ORDER BY Id", "Attachments", "Research")
                .AddParameter("EntityType", DbType.Decimal, 5, False, entityType)
                .AddParameter("EntityId", DbType.Decimal, 18, False, entityId)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                rows = .QueryExecuteToTable(True)
                If rows.IsNotEmpty AndAlso rows.Rows.Count <> 0 Then
                    For Each itemRow As DataRow In rows.Rows
                        result.Add(DataRowMapperView(itemRow))
                    Next
                End If
            End With
            Return result
        End Function

        Public Shared Function RetrieveById(Id As Integer) As Architect.API.Core.Contracts.General.AttachmentItem
            Dim rows As Data.DataTable = Nothing
            Dim result As Architect.API.Core.Contracts.General.AttachmentItem = Nothing
            With New DataManagerFactory("SELECT FileName, FileContent " &
                                          "FROM Attachments " &
                                         "WHERE Id=@:Id", "Attachments", "Research")
                .AddParameter("Id", DbType.Decimal, 5, False, Id)
                rows = .QueryExecuteToTable(True)
                If rows.IsNotEmpty AndAlso rows.Rows.Count <> 0 Then
                    result = New Contracts.General.AttachmentItem() With {.FileName = rows.FirstRow.StringValue("FileName"), .Content = rows.FirstRow.Item("FileContent")}
                    result.Type = IO.Path.GetExtension(result.FileName).Replace(".", "")
                End If
            End With
            Return result
        End Function

        Private Shared Function DataRowMapperView(itemRow As DataRow) As Architect.API.Core.Contracts.General.AttachmentView
            Return New Architect.API.Core.Contracts.General.AttachmentView With {.Id = itemRow.NumericValue("Id"), .Description = itemRow.StringValue("Description"), .FileName = itemRow.StringValue("FileName"), .FileSize = itemRow.NumericValue("FileSize"), .UpdateUserCode = itemRow.NumericValue("UpdateUserCode"), .UpdateUserName = itemRow.StringValue("UpdateUserName"), .UpdateDate = itemRow.DateTimeValue("UpdateDate"), .DocumentType = itemRow.NumericValue("DocumentType"), .DocumentTypeDesc = itemRow.StringValue("DocumentTypeDesc")}
        End Function

    End Class

End Namespace

