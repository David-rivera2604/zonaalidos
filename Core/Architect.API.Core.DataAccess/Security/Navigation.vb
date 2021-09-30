Imports Architect.Common.Proxy

Namespace Architect.API.Core.DataAccess.Security

    Partial Public NotInheritable Class Navigation

        ''' <summary>
        ''' Recupera una lista de registros en la tabla Navigation.
        ''' </summary>
        ''' <returns>Lista de instancias de Navigation</returns>
        Public Shared Function RetrieveNavigationAllowed(roleNameList As String, companyId As Integer) As List(Of Architect.API.Core.Contracts.Security.NavAllowed)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.API.Core.Contracts.Security.NavAllowed)
            With New DataManagerFactory("SELECT DISTINCT nav.Sequence, nav.ParentCode, rn.Code, nav.Type, nav.MenuTitle, nav.Title, nav.Description, nav.URLPath, nav.SmallImage " &
                                          "FROM RoleMember " &
                                          "JOIN RoleMemberNavigation rn ON rn.RoleId=RoleMember.RoleId AND rn.CompanyId=RoleMember.CompanyId " &
                                          "JOIN Navigation nav ON nav.Code=rn.Code AND nav.RecordStatus=1 " &
                                         "WHERE RoleMember.CompanyId=@:CompanyId AND RoleMember.RoleName IN (" & roleNameList & ") " &
                                        " ORDER BY nav.Sequence", "RoleMemberNavigation", "Research")
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                rows = .QueryExecuteToTable(True)
                If rows.IsNotEmpty AndAlso rows.Rows.Count <> 0 Then
                    For Each itemRow As DataRow In rows.Rows
                        result.Add(DataRowMapperNavigationAllowed(itemRow))
                    Next
                End If
            End With
            Return result
        End Function

        ''' <summary>
        ''' Permite hacer el mapeo entre una fila de un datatable hacia una instancia de Navigation.
        ''' </summary>
        ''' <returns>Instancia de RoleMemberNavigation</returns>
        Private Shared Function DataRowMapperNavigationAllowed(itemRow As DataRow) As Architect.API.Core.Contracts.Security.NavAllowed
            Return New Architect.API.Core.Contracts.Security.NavAllowed With {.ParentCode = itemRow.StringValue("ParentCode"), .Code = itemRow.StringValue("Code"), .Type = itemRow.NumericValue("Type"), .MenuTitle = itemRow.StringValue("MenuTitle"), .Title = itemRow.StringValue("Title"), .Description = itemRow.StringValue("Description"), .URLPath = itemRow.StringValue("URLPath"), .SmallImage = itemRow.StringValue("SmallImage")}
        End Function

    End Class

End Namespace

