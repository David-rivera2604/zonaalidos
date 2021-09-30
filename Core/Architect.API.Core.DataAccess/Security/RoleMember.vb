Imports Architect.Common.Proxy

Namespace Architect.API.Core.DataAccess.Security

    Partial Public NotInheritable Class RoleMember

        Public Shared Function RetrieveAll(companyId As Integer, filter As String, recordStatus As String) As List(Of Architect.API.Core.Contracts.Security.RoleMember)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.API.Core.Contracts.Security.RoleMember)
            With New DataManagerFactory("SELECT RoleId, RoleName, Description, RoleMember.SecurityLevel, RoleMember.RecordStatus, RoleMember.CompanyId, RoleMember.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, RoleMember.UpdateDate " &
                                          "FROM RoleMember LEFT JOIN UserMember um ON um.UserId = RoleMember.UpdateUserCode " &
                                          "WHERE RoleMember.CompanyId=@:CompanyId" & BuildFilter(filter, recordStatus) &
                                         " ORDER BY RoleName", "RoleMember", "Research")
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

        Public Shared Function BuildFilter(filter As String, recordStatus As String) As String
            Dim result As String = String.Empty

            If filter.IsNotEmpty Then
                result = " AND (UPPER(RoleMember.RoleName) LIKE '%" & filter.ToUpper & "%' " &
                           "OR UPPER(RoleMember.Description) LIKE '%" & filter.ToUpper & "%') "
            End If

            If recordStatus.IsNotEmpty Then
                result = " AND RoleMember.RecordStatus IN (" & recordStatus & ") "
            End If

            Return result
        End Function

    End Class

End Namespace

