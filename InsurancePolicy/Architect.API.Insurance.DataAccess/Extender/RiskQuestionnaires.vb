Imports Architect.Common.Proxy

Namespace Architect.API.Insurance.DataAccess.Policy

    Partial Public NotInheritable Class RiskQuestionnaires

        ''' <summary>
        ''' Recupera una lista de registros en la tabla RiskQuestionnaires basado en el número de documento de un asegurado.
        ''' </summary>
        ''' <param name="documentNumber">Número de documento del asegurado</param>
        ''' <param name="questionIdBegin">Identificador de la pregunta inicial</param>
        ''' <param name="questionIdFinish">Identificador de la pregunta final</param>
        ''' <param name="companyId">Identificación de la compañía propietaria.</param>
        ''' <returns>Lista de instancias de RiskQuestionnaires</returns>
        Public Shared Function RetrieveByDocumentNumber(documentNumber As String, questionIdBegin As Integer, questionIdFinish As Integer, companyid As Integer) As List(Of Architect.API.Insurance.Contracts.Policy.RiskQuestionnaires)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.API.Insurance.Contracts.Policy.RiskQuestionnaires)

            documentNumber = "0000000000000000" + documentNumber
            documentNumber = documentNumber.Substring(documentNumber.Length - 10)
            With New DataManagerFactory("SELECT Id, PolicyId, Type, QuestionId, Confirmation, Diagnosis, Treatment, Doctor, When, RiskQuestionnaires.CompanyId, RiskQuestionnaires.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, RiskQuestionnaires.UpdateDate " &
                                          "FROM RiskQuestionnaires LEFT JOIN UserMember um ON um.UserId = RiskQuestionnaires.UpdateUserCode " &
                                         "WHERE RiskQuestionnaires.CompanyId=@:CompanyId " &
                                           "AND PolicyId in (SELECT PolicyId  FROM RiskRoles WHERE REPLACE(DocumentNumber,'-','')=@:DocumentNumber AND RiskRoles.CompanyId=RiskQuestionnaires.CompanyId) " &
                                           "AND TRUNC(RiskQuestionnaires.UpdateDate)=TRUNC(@:Today) " &
                                           "AND QuestionId BETWEEN @:questionIdBegin AND @:questionIdFinish " &
                                         "ORDER BY PolicyId DESC, QuestionId ASC " &
                                         "FETCH FIRST @:RowCount ROWS ONLY", "RiskQuestionnaires", "Research")
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyid)
                .AddParameter("DocumentNumber", DbType.AnsiString, 20, False, documentNumber)
                .AddParameter("Today", DbType.DateTime, 0, False, Today)
                .AddParameter("questionIdBegin", DbType.Decimal, 9, False, questionIdBegin)
                .AddParameter("questionIdFinish", DbType.Decimal, 9, False, questionIdFinish)
                .AddParameter("RowCount", DbType.Decimal, 9, False, questionIdFinish - questionIdBegin + 1)
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

