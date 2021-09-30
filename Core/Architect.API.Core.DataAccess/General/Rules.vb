Imports Architect.Common.Proxy

Namespace Architect.API.Core.DataAccess.General

    Partial Public NotInheritable Class Rules

        ''' <summary>
        ''' Recupera una lista de registros en la tabla Rules.
        ''' </summary>
        ''' <param name="companyId"></param>
        ''' <param name="entityType"></param>
        ''' <param name="action"></param>
        ''' <returns>Lista de instancias de Rules</returns>
        Public Shared Function RetrieveByEntityAction(companyId As Integer, entityType As Integer, action As String) As List(Of Architect.API.Core.Contracts.General.Rules)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.API.Core.Contracts.General.Rules)
            With New DataManagerFactory("SELECT Id, Rules.CompanyId, EntityType, Action, Sequence, Description, Statement, Rules.RecordStatus, Rules.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Rules.UpdateDate " &
                                          "FROM Rules LEFT JOIN UserMember um ON um.UserId = Rules.UpdateUserCode " &
                                         "WHERE Rules.CompanyId=@:CompanyId AND EntityType=@:EntityType AND Action=@:action AND Rules.RecordStatus=1 ORDER BY Sequence", "Rules", "Research")
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                .AddParameter("EntityType", DbType.Decimal, 5, False, entityType)
                .AddParameter("Action", DbType.AnsiString, 30, False, action)
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
        ''' Recupera la cantidad de registros existentes en la tabla Rules por medio de su clave primaria.
        ''' </summary>
        ''' <param name="companyId"></param>
        ''' <param name="entityType"></param>
        ''' <param name="action"></param>
        ''' <returns>Cantidad de registros encontrados.</returns>
        Public Shared Function Count(companyId As Integer, entityType As Integer, action As String) As Integer
            Dim rows As Integer = 0

            With New DataManagerFactory("SELECT COUNT(Id) " &
                                          "FROM Rules " &
                                         "WHERE CompanyId=@:CompanyId AND EntityType=@:EntityType AND Action=@:action", "Rules", "Research")
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                .AddParameter("EntityType", DbType.Decimal, 5, False, entityType)
                .AddParameter("Action", DbType.AnsiString, 30, False, action)
                rows = .QueryExecuteScalarToInteger
            End With
            Return rows
        End Function

    End Class

End Namespace

