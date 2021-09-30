Imports Architect.Common.Proxy

Namespace Architect.API.Insurance.DataAccess.Policy

    Partial Public NotInheritable Class RuleLoans

        ''' <summary>
        ''' Recupera una lista de registros en la tabla RuleLoans.
        ''' </summary>
        ''' <param name="companyId">Identificación de la compañia propietaria.</param>
        ''' <param name="documentNumber">Documento o número de identificación.</param>
        ''' <returns>Lista de instancias de RuleLoans</returns>
        Public Shared Function RetrieveByDocumentNumber(companyId As Integer, documentNumber As String) As List(Of Architect.API.Insurance.Contracts.Policy.RuleLoans)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.API.Insurance.Contracts.Policy.RuleLoans)
            With New DataManagerFactory("SELECT LoanNumber, CompanyId, DocumentNumber, FullName, BirthDate, Gender, StartTerm, EndTerm, Duration, Amount, Balance " &
                                          "FROM RuleLoans " &
                                          "WHERE DocumentNumber=@:DocumentNumber AND CompanyId=@:CompanyId ORDER BY EndTerm", "RuleLoans", "Research")
                .AddParameter("DocumentNumber", DbType.AnsiString, 20, False, documentNumber)
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


        Public Shared Function Truncate() As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("TRUNCATE TABLE RuleLoans", "RuleLoans", "Research")
                rows = .CommandExecute()
            End With
            Return rows
        End Function

    End Class

End Namespace

