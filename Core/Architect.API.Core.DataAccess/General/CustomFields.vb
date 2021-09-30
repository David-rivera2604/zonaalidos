Imports Architect.Common.Proxy

Namespace Architect.API.Core.DataAccess.General

    Public Class CustomFields

        Public Shared Function RetrieveByEntityType(entityType As Integer, companyId As Integer) As List(Of Architect.API.Core.Contracts.General.CustomFields)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.API.Core.Contracts.General.CustomFields)
            With New DataManagerFactory("SELECT Id, CustomFields.CompanyId, EntityType, Name, Caption, DataType, Precision, Scale, IsRequired, DisplayOrder, Specification, CustomFields.RecordStatus, CustomFields.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, CustomFields.UpdateDate " &
                                          "FROM CustomFields LEFT JOIN UserMember um ON um.UserId = CustomFields.UpdateUserCode " &
                                         "WHERE EntityType=@:EntityType AND CustomFields.CompanyId=@:CompanyId AND CustomFields.RecordStatus=1 ORDER BY DisplayOrder", "CustomFields", "Research")
                .AddParameter("EntityType", DbType.Decimal, 5, False, entityType)
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

    End Class

End Namespace