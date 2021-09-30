Imports Architect.Common.Proxy

Namespace Architect.API.Insurance.DataAccess.Policy

    ''' <summary>
    ''' 
    ''' </summary>
    Partial Public NotInheritable Class RiskQuestionnaires

        ''' <summary>
        ''' Crea un registro en la tabla RiskQuestionnaires.
        ''' </summary>
        ''' <param name="riskquestionnairesItem">Instancia de RiskQuestionnaires</param>
        ''' <returns>Instancia de RiskQuestionnaires</returns>
        Public Shared Function Create(riskquestionnairesItem As Architect.API.Insurance.Contracts.Policy.RiskQuestionnaires) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("INSERT INTO RiskQuestionnaires " &
                                              "(Id, PolicyId, Type, QuestionId, Confirmation, Diagnosis, Treatment, Doctor, When, CompanyId, UpdateUserCode, UpdateDate) " &
                                        "VALUES(@:Id, @:PolicyId, @:Type, @:QuestionId, @:Confirmation, @:Diagnosis, @:Treatment, @:Doctor, @:When, @:CompanyId, @:UpdateUserCode, @:UpdateDate)", "RiskQuestionnaires", "Research")
                .AddParameter("Id", DbType.Decimal, 9, riskquestionnairesItem.Id.IsEmpty(), riskquestionnairesItem.Id)
                .AddParameter("PolicyId", DbType.Decimal, 9, riskquestionnairesItem.PolicyId.IsEmpty(), riskquestionnairesItem.PolicyId)
                .AddParameter("Type", DbType.Decimal, 9, riskquestionnairesItem.Type.IsEmpty(), riskquestionnairesItem.Type)
                .AddParameter("QuestionId", DbType.Decimal, 9, riskquestionnairesItem.QuestionId.IsEmpty(), riskquestionnairesItem.QuestionId)
                .AddParameter("Confirmation", DbType.Decimal, 1, False, riskquestionnairesItem.Confirmation)
                .AddParameter("Diagnosis", DbType.AnsiString, 200, riskquestionnairesItem.Diagnosis.IsEmpty(), riskquestionnairesItem.Diagnosis)
                .AddParameter("Treatment", DbType.AnsiString, 200, riskquestionnairesItem.Treatment.IsEmpty(), riskquestionnairesItem.Treatment)
                .AddParameter("Doctor", DbType.AnsiString, 120, riskquestionnairesItem.Doctor.IsEmpty(), riskquestionnairesItem.Doctor)
                .AddParameter("When", DbType.DateTime, 9, riskquestionnairesItem.When.IsEmpty(), riskquestionnairesItem.When)
                .AddParameter("CompanyId", DbType.Decimal, 5, riskquestionnairesItem.CompanyId.IsEmpty(), riskquestionnairesItem.CompanyId)
                .AddParameter("UpdateUserCode", DbType.Decimal, 9, riskquestionnairesItem.UpdateUserCode.IsEmpty(), riskquestionnairesItem.UpdateUserCode)
                .AddParameter("UpdateDate", DbType.DateTime, 0, riskquestionnairesItem.UpdateDate.IsEmpty(), riskquestionnairesItem.UpdateDate)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Verifica si existe un registro en la tabla RiskQuestionnaires por medio de su clave primaria.
        ''' </summary>
        ''' <returns>Verdadero si existe el registro, en caso contrario falso.</returns>
        Public Shared Function RetrieveLastKey() As Integer
            Dim rows As Integer = 0

            With New DataManagerFactory("SELECT NVL(MAX(Id),0) " &
                                          "FROM RiskQuestionnaires", "RiskQuestionnaires", "Research")
                rows = .QueryExecuteScalarToInteger
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Actualiza un registro en la tabla RiskQuestionnaires por medio de su clave primaria.
        ''' </summary>
        ''' <param name="riskquestionnairesItem">Instancia de RiskQuestionnaires</param>
        ''' <returns>Cantidad de registros actualizados.</returns>
        Public Shared Function Update(riskquestionnairesItem As Architect.API.Insurance.Contracts.Policy.RiskQuestionnaires) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("UPDATE RiskQuestionnaires " &
                                           "SET PolicyId=@:PolicyId, Type=@:Type, QuestionId=@:QuestionId, Confirmation=@:Confirmation, Diagnosis=@:Diagnosis, Treatment=@:Treatment, Doctor=@:Doctor, When=@:When, CompanyId=@:CompanyId, UpdateUserCode=@:UpdateUserCode, UpdateDate=@:UpdateDate " &
                                         "WHERE Id=@:Id", "RiskQuestionnaires", "Research")
                .AddParameter("PolicyId", DbType.Decimal, 9, riskquestionnairesItem.PolicyId.IsEmpty(), riskquestionnairesItem.PolicyId)
                .AddParameter("Type", DbType.Decimal, 9, riskquestionnairesItem.Type.IsEmpty(), riskquestionnairesItem.Type)
                .AddParameter("QuestionId", DbType.Decimal, 9, riskquestionnairesItem.QuestionId.IsEmpty(), riskquestionnairesItem.QuestionId)
                .AddParameter("Confirmation", DbType.Decimal, 1, False, riskquestionnairesItem.Confirmation)
                .AddParameter("Diagnosis", DbType.AnsiString, 200, riskquestionnairesItem.Diagnosis.IsEmpty(), riskquestionnairesItem.Diagnosis)
                .AddParameter("Treatment", DbType.AnsiString, 200, riskquestionnairesItem.Treatment.IsEmpty(), riskquestionnairesItem.Treatment)
                .AddParameter("Doctor", DbType.AnsiString, 120, riskquestionnairesItem.Doctor.IsEmpty(), riskquestionnairesItem.Doctor)
                .AddParameter("When", DbType.DateTime, 9, riskquestionnairesItem.When.IsEmpty(), riskquestionnairesItem.When)
                .AddParameter("CompanyId", DbType.Decimal, 5, riskquestionnairesItem.CompanyId.IsEmpty(), riskquestionnairesItem.CompanyId)
                .AddParameter("UpdateUserCode", DbType.Decimal, 9, riskquestionnairesItem.UpdateUserCode.IsEmpty(), riskquestionnairesItem.UpdateUserCode)
                .AddParameter("UpdateDate", DbType.DateTime, 0, riskquestionnairesItem.UpdateDate.IsEmpty(), riskquestionnairesItem.UpdateDate)
                .AddParameter("Id", DbType.Decimal, 9, False, riskquestionnairesItem.Id)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera una lista de registros en la tabla RiskQuestionnaires.
        ''' </summary>
        ''' <param name="policyid"></param>
        ''' <returns>Lista de instancias de RiskQuestionnaires</returns>
        Public Shared Function RetrieveByPolicyId(policyid As Integer) As List(Of Architect.API.Insurance.Contracts.Policy.RiskQuestionnaires)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.API.Insurance.Contracts.Policy.RiskQuestionnaires)
            With New DataManagerFactory("Select Id, PolicyId, Type, QuestionId, Confirmation, Diagnosis, Treatment, Doctor, When, RiskQuestionnaires.CompanyId, RiskQuestionnaires.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, RiskQuestionnaires.UpdateDate " &
                                          "FROM RiskQuestionnaires LEFT JOIN UserMember um ON um.UserId = RiskQuestionnaires.UpdateUserCode " &
                                         "WHERE PolicyId=@:PolicyId", "RiskQuestionnaires", "Research")
                .AddParameter("PolicyId", DbType.Decimal, 9, False, policyid)
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
        ''' Elimina un registro en la tabla RiskQuestionnaires por medio de su clave primaria.
        ''' </summary>
        ''' <param name="policyid"></param>
        ''' <returns>Cantidad de registros eliminados.</returns>
        Public Shared Function DeleteByPolicyId(policyid As Integer) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("DELETE FROM RiskQuestionnaires " &
                                         "WHERE PolicyId=@:PolicyId", "RiskQuestionnaires", "Research")
                .AddParameter("PolicyId", DbType.Decimal, 9, False, policyid)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera una lista de registros en la tabla RiskQuestionnaires.
        ''' </summary>
        ''' <param name="policyid"></param>
        ''' <param name="companyid"></param>
        ''' <returns>Lista de instancias de RiskQuestionnaires</returns>
        Public Shared Function RetrieveByPolicyIdCompanyId(policyid As Integer, companyid As Integer) As List(Of Architect.API.Insurance.Contracts.Policy.RiskQuestionnaires)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.API.Insurance.Contracts.Policy.RiskQuestionnaires)
            With New DataManagerFactory("Select Id, PolicyId, Type, QuestionId, Confirmation, Diagnosis, Treatment, Doctor, When, RiskQuestionnaires.CompanyId, RiskQuestionnaires.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, RiskQuestionnaires.UpdateDate " &
                                          "FROM RiskQuestionnaires LEFT JOIN UserMember um ON um.UserId = RiskQuestionnaires.UpdateUserCode " &
                                         "WHERE PolicyId=@:PolicyId AND RiskQuestionnaires.CompanyId=@:CompanyId", "RiskQuestionnaires", "Research")
                .AddParameter("PolicyId", DbType.Decimal, 9, False, policyid)
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
        ''' Elimina un registro en la tabla RiskQuestionnaires por medio de su clave primaria.
        ''' </summary>
        ''' <param name="policyid"></param>
        ''' <param name="companyid"></param>
        ''' <returns>Cantidad de registros eliminados.</returns>
        Public Shared Function DeleteByPolicyIdCompanyId(policyid As Integer, companyid As Integer) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("DELETE FROM RiskQuestionnaires " &
                                         "WHERE PolicyId=@:PolicyId AND CompanyId=@:CompanyId", "RiskQuestionnaires", "Research")
                .AddParameter("PolicyId", DbType.Decimal, 9, False, policyid)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyid)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

#Region "Helper"

        ''' <summary>
        ''' Permite hacer el mapeo entre una fila de un datatable hacia una instancia de RiskQuestionnaires.
        ''' </summary>
        ''' <returns>Instancia de RiskQuestionnaires</returns>
        Private Shared Function DataRowMapper(itemRow As DataRow) As Architect.API.Insurance.Contracts.Policy.RiskQuestionnaires
            Return New Architect.API.Insurance.Contracts.Policy.RiskQuestionnaires With {.Id = itemRow.NumericValue("Id"), .PolicyId = itemRow.NumericValue("PolicyId"), .Type = itemRow.NumericValue("Type"), .QuestionId = itemRow.NumericValue("QuestionId"), .Confirmation = itemRow.NumericValue("Confirmation"), .Diagnosis = itemRow.StringValue("Diagnosis"), .Treatment = itemRow.StringValue("Treatment"), .Doctor = itemRow.StringValue("Doctor"), .When = itemRow.DateTimeValue("When"), .CompanyId = itemRow.NumericValue("CompanyId"), .UpdateUserCode = itemRow.NumericValue("UpdateUserCode"), .UpdateUserName = itemRow.StringValue("UpdateUserName"), .UpdateDate = itemRow.DateTimeValue("UpdateDate")}
        End Function

#End Region

    End Class

End Namespace

