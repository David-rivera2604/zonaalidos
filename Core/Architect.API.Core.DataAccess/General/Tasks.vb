Imports Architect.Common.Proxy

Namespace Architect.API.Core.DataAccess.General

    Partial Public NotInheritable Class Tasks

        Public Shared Function RetrieveByEntity(entityType As Integer, entityId As Integer, companyId As Integer, filter As String) As List(Of Architect.API.Core.Contracts.General.Tasks)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.API.Core.Contracts.General.Tasks)
            Dim condition As String = " AND EntityId=@:EntityId"

            If entityId.IsEmpty Then
                condition = String.Empty
            End If

            With New DataManagerFactory("SELECT Id, Sequence, Title, Description, CreatedDate, DueDate, AssignedTo, Type, CompletedDate, Status, EntityType, EntityId, Tasks.CompanyId, Tasks.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Tasks.UpdateDate " &
                                          "FROM Tasks LEFT JOIN UserMember um ON um.UserId = Tasks.UpdateUserCode " &
                                         "WHERE EntityType=@:EntityType" & condition & BuildFilter(filter) & " AND Tasks.companyId=@:companyId ORDER BY Id DESC", "Tasks", "Research")
                .AddParameter("EntityType", DbType.Decimal, 5, False, entityType)
                If entityId.IsNotEmpty Then
                    .AddParameter("EntityId", DbType.Decimal, 9, False, entityId)
                End If
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

        Private Shared Function BuildFilter(filter As String) As String
            Dim result As String = String.Empty

            If filter.IsNotEmpty Then
                If IsNumeric(filter) Then
                    result = String.Empty
                Else
                    result = " AND (UPPER(Tasks.Title) LIKE '%" & filter.ToUpper & "%' " &
                               "OR  UPPER(Tasks.Description) LIKE '%" & filter.ToUpper & "%')"
                End If
            End If
            Return result
        End Function
    End Class

End Namespace

