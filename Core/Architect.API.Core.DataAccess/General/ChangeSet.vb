Imports Architect.Common.Proxy

Namespace Architect.API.Core.DataAccess.General

    Partial Public NotInheritable Class ChangeSet

        Public Shared Function RetrieveByEntity(entityType As Integer, entityId As Long, companyId As Integer, filter As String) As List(Of Architect.API.Core.Contracts.General.ChangeSetView)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.API.Core.Contracts.General.ChangeSetView)
            Dim condition As String = " AND EntityId=@:EntityId"

            If entityId.IsEmpty Then
                condition = String.Empty
            End If

            With New DataManagerFactory("SELECT Id, Action, Summary, ChangeSet.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, ChangeSet.UpdateDate " &
                                          "FROM ChangeSet " &
                                     "LEFT JOIN UserMember um ON um.UserId = ChangeSet.UpdateUserCode " &
                                         "WHERE EntityType=@:EntityType" & condition & BuildFilter(filter) & " AND ChangeSet.companyId=@:companyId ORDER BY Id DESC", "ChangeSet", "Research")
                .AddParameter("EntityType", DbType.Decimal, 5, False, entityType)
                If entityId.IsNotEmpty Then
                    .AddParameter("EntityId", DbType.Decimal, 9, False, entityId)
                End If
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

        Private Shared Function DataRowMapperView(itemRow As DataRow) As Architect.API.Core.Contracts.General.ChangeSetView
            Return New Architect.API.Core.Contracts.General.ChangeSetView With {.Id = itemRow.NumericValue("Id"), .Action = itemRow.StringValue("Action"), .Summary = itemRow.StringValue("Summary"), .UpdateUserCode = itemRow.NumericValue("UpdateUserCode"), .UpdateUserName = itemRow.StringValue("UpdateUserName"), .UpdateDate = itemRow.DateTimeValue("UpdateDate")}
        End Function

        Public Shared Function BuildFilter(filter As String) As String
            Dim result As String = String.Empty

            If filter.IsNotEmpty Then
                result = " AND UPPER(ChangeSet.Summary) LIKE '%" & filter.ToUpper & "%' "
            End If

            Return result
        End Function

    End Class

End Namespace

