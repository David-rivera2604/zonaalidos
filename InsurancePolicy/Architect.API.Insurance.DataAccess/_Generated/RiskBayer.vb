Imports Architect.Common.Proxy

Namespace Architect.API.Insurance.DataAccess.Policy

    ''' <summary>
    ''' RiskBayer
    ''' </summary>
    Partial Public NotInheritable Class RiskBayer

        ''' <summary>
        ''' Crea un registro en la tabla RiskBayer.
        ''' </summary>
        ''' <param name="riskbayerItem">Instancia de RiskBayer</param>
        ''' <returns>Cantidad de registros creados.</returns>
        Public Shared Function Create(riskbayerItem As Architect.API.Insurance.Contracts.Policy.RiskBayer) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("INSERT INTO RiskBayer " &
                                              "(Id, CompanyId, MainPolicyId, IssueDate, ContractorName, IsLife, IsHealth, SocialSecurity, DominantMember, DateEntryWork, MonthlySalary, Doctor, RefundBankCode, RefundBankAccount, RefundBankAccountType, RefundBankAccountCurrency, PaymentModeType, PaymentBankAccount, PaymentCardNumber, PaymentCardExpirationDate, PaymentHolder, PaymentBankCode, HasDigitalSignature, ContinuityDate, EmployeeNumber, UpdateUserCode, UpdateDate) " &
                                        "VALUES(@:Id, @:CompanyId, @:MainPolicyId, @:IssueDate, @:ContractorName, @:IsLife, @:IsHealth, @:SocialSecurity, @:DominantMember, @:DateEntryWork, @:MonthlySalary, @:Doctor, @:RefundBankCode, @:RefundBankAccount, @:RefundBankAccountType, @:RefundBankAccountCurrency, @:PaymentModeType, @:PaymentBankAccount, @:PaymentCardNumber, @:PaymentCardExpirationDate, @:PaymentHolder, @:PaymentBankCode, @:HasDigitalSignature, @:ContinuityDate, @:EmployeeNumber, @:UpdateUserCode, @:UpdateDate)", "RiskBayer", "Research")
                .AddParameter("Id", DbType.Decimal, 9, riskbayerItem.Id.IsEmpty(), riskbayerItem.Id)
                .AddParameter("CompanyId", DbType.Decimal, 5, riskbayerItem.CompanyId.IsEmpty(), riskbayerItem.CompanyId)
                .AddParameter("MainPolicyId", DbType.AnsiString, 20, False, riskbayerItem.MainPolicyId)
                .AddParameter("IssueDate", DbType.DateTime, 9, riskbayerItem.IssueDate.IsEmpty(), riskbayerItem.IssueDate)
                .AddParameter("ContractorName", DbType.AnsiString, 80, riskbayerItem.ContractorName.IsEmpty(), riskbayerItem.ContractorName)
                .AddParameter("IsLife", DbType.AnsiStringFixedLength, 2, riskbayerItem.IsLife.IsEmpty(), riskbayerItem.IsLife)
                .AddParameter("IsHealth", DbType.AnsiStringFixedLength, 2, riskbayerItem.IsHealth.IsEmpty(), riskbayerItem.IsHealth)
                .AddParameter("SocialSecurity", DbType.AnsiString, 20, riskbayerItem.SocialSecurity.IsEmpty(), riskbayerItem.SocialSecurity)
                .AddParameter("DominantMember", DbType.Decimal, 5, riskbayerItem.DominantMember.IsEmpty(), riskbayerItem.DominantMember)
                .AddParameter("DateEntryWork", DbType.DateTime, 9, riskbayerItem.DateEntryWork.IsEmpty(), riskbayerItem.DateEntryWork)
                .AddParameter("MonthlySalary", DbType.Decimal, 18, riskbayerItem.MonthlySalary.IsEmpty(), riskbayerItem.MonthlySalary)
                .AddParameter("Doctor", DbType.AnsiString, 120, riskbayerItem.Doctor.IsEmpty(), riskbayerItem.Doctor)
                .AddParameter("RefundBankCode", DbType.Decimal, 5, riskbayerItem.RefundBankCode.IsEmpty(), riskbayerItem.RefundBankCode)
                .AddParameter("RefundBankAccount", DbType.AnsiString, 22, riskbayerItem.RefundBankAccount.IsEmpty(), riskbayerItem.RefundBankAccount)
                .AddParameter("RefundBankAccountType", DbType.Decimal, 5, riskbayerItem.RefundBankAccountType.IsEmpty(), riskbayerItem.RefundBankAccountType)
                .AddParameter("RefundBankAccountCurrency", DbType.Decimal, 5, riskbayerItem.RefundBankAccountCurrency.IsEmpty(), riskbayerItem.RefundBankAccountCurrency)
                .AddParameter("PaymentModeType", DbType.Decimal, 5, riskbayerItem.PaymentModeType.IsEmpty(), riskbayerItem.PaymentModeType)
                .AddParameter("PaymentBankAccount", DbType.AnsiString, 22, riskbayerItem.PaymentBankAccount.IsEmpty(), riskbayerItem.PaymentBankAccount)
                .AddParameter("PaymentCardNumber", DbType.AnsiString, 22, riskbayerItem.PaymentCardNumber.IsEmpty(), riskbayerItem.PaymentCardNumber)
                .AddParameter("PaymentCardExpirationDate", DbType.DateTime, 9, riskbayerItem.PaymentCardExpirationDate.IsEmpty(), riskbayerItem.PaymentCardExpirationDate)
                .AddParameter("PaymentHolder", DbType.AnsiString, 60, riskbayerItem.PaymentHolder.IsEmpty(), riskbayerItem.PaymentHolder)
                .AddParameter("PaymentBankCode", DbType.Decimal, 5, riskbayerItem.PaymentBankCode.IsEmpty(), riskbayerItem.PaymentBankCode)
                .AddParameter("HasDigitalSignature", DbType.Decimal, 1, False, IIf(riskbayerItem.HasDigitalSignature, 1, 0))
                .AddParameter("ContinuityDate", DbType.DateTime, 9, riskbayerItem.ContinuityDate.IsEmpty(), riskbayerItem.ContinuityDate)
                .AddParameter("EmployeeNumber", DbType.AnsiString, 30, riskbayerItem.EmployeeNumber.IsEmpty(), riskbayerItem.EmployeeNumber)
                .AddParameter("UpdateUserCode", DbType.Decimal, 9, riskbayerItem.UpdateUserCode.IsEmpty(), riskbayerItem.UpdateUserCode)
                .AddParameter("UpdateDate", DbType.DateTime, 0, riskbayerItem.UpdateDate.IsEmpty(), riskbayerItem.UpdateDate)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera un registro en la tabla RiskBayer por medio de su clave primaria.
        ''' </summary>
        ''' <param name="id">Identificación única de la póliza.</param>
        ''' <param name="companyId">Identificación de la compañia propietaria.</param>
        ''' <returns>Instancia de RiskBayer</returns>
        Public Shared Function Retrieve(id As Integer, companyId As Integer) As Architect.API.Insurance.Contracts.Policy.RiskBayer
            Dim rows As Data.DataTable = Nothing
            Dim result As Architect.API.Insurance.Contracts.Policy.RiskBayer = Nothing
            With New DataManagerFactory("SELECT Id, RiskBayer.CompanyId, MainPolicyId, IssueDate, ContractorName, IsLife, IsHealth, SocialSecurity, DominantMember, DateEntryWork, MonthlySalary, Doctor, RefundBankCode, RefundBankAccount, RefundBankAccountType, RefundBankAccountCurrency, PaymentModeType, PaymentBankAccount, PaymentCardNumber, PaymentCardExpirationDate, PaymentHolder, PaymentBankCode, HasDigitalSignature, ContinuityDate, EmployeeNumber, RiskBayer.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, RiskBayer.UpdateDate " &
                                          "FROM RiskBayer LEFT JOIN UserMember um ON um.UserId = RiskBayer.UpdateUserCode " &
                                         "WHERE RiskBayer.Id=@:Id AND RiskBayer.CompanyId=@:CompanyId", "RiskBayer", "Research")
                .AddParameter("Id", DbType.Decimal, 9, False, id)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                rows = .QueryExecuteToTable(True)
                If rows.IsNotEmpty AndAlso rows.Rows.Count <> 0 Then
                    result = DataRowMapper(rows.Rows(0))
                End If
            End With
            Return result
        End Function

        ''' <summary>
        ''' Último valor asignado a clave unica de la tabla RiskBayer.
        ''' </summary>
        ''' <returns>Último valor asignado.</returns>
        Public Shared Function RetrieveLastKey() As Integer
            Dim rows As Integer = 0

            With New DataManagerFactory("SELECT NVL(MAX(Id),0) " &
                                          "FROM RiskBayer", "RiskBayer", "Research")
                rows = .QueryExecuteScalarToInteger
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Actualiza un registro en la tabla RiskBayer por medio de su clave primaria.
        ''' </summary>
        ''' <param name="riskbayerItem">Instancia de RiskBayer</param>
        ''' <returns>Cantidad de registros actualizados.</returns>
        Public Shared Function Update(riskbayerItem As Architect.API.Insurance.Contracts.Policy.RiskBayer) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("UPDATE RiskBayer " &
                                           "SET CompanyId=@:CompanyId, MainPolicyId=@:MainPolicyId, IssueDate=@:IssueDate, ContractorName=@:ContractorName, IsLife=@:IsLife, IsHealth=@:IsHealth, SocialSecurity=@:SocialSecurity, DominantMember=@:DominantMember, DateEntryWork=@:DateEntryWork, MonthlySalary=@:MonthlySalary, Doctor=@:Doctor, RefundBankCode=@:RefundBankCode, RefundBankAccount=@:RefundBankAccount, RefundBankAccountType=@:RefundBankAccountType, RefundBankAccountCurrency=@:RefundBankAccountCurrency, PaymentModeType=@:PaymentModeType, PaymentBankAccount=@:PaymentBankAccount, PaymentCardNumber=@:PaymentCardNumber, PaymentCardExpirationDate=@:PaymentCardExpirationDate, PaymentHolder=@:PaymentHolder, PaymentBankCode=@:PaymentBankCode, HasDigitalSignature=@:HasDigitalSignature, ContinuityDate=@:ContinuityDate, EmployeeNumber=@:EmployeeNumber, UpdateUserCode=@:UpdateUserCode, UpdateDate=@:UpdateDate " &
                                         "WHERE Id=@:Id", "RiskBayer", "Research")
                .AddParameter("CompanyId", DbType.Decimal, 5, riskbayerItem.CompanyId.IsEmpty(), riskbayerItem.CompanyId)
                .AddParameter("MainPolicyId", DbType.AnsiString, 20, False, riskbayerItem.MainPolicyId)
                .AddParameter("IssueDate", DbType.DateTime, 9, riskbayerItem.IssueDate.IsEmpty(), riskbayerItem.IssueDate)
                .AddParameter("ContractorName", DbType.AnsiString, 80, riskbayerItem.ContractorName.IsEmpty(), riskbayerItem.ContractorName)
                .AddParameter("IsLife", DbType.AnsiStringFixedLength, 2, riskbayerItem.IsLife.IsEmpty(), riskbayerItem.IsLife)
                .AddParameter("IsHealth", DbType.AnsiStringFixedLength, 2, riskbayerItem.IsHealth.IsEmpty(), riskbayerItem.IsHealth)
                .AddParameter("SocialSecurity", DbType.AnsiString, 20, riskbayerItem.SocialSecurity.IsEmpty(), riskbayerItem.SocialSecurity)
                .AddParameter("DominantMember", DbType.Decimal, 5, riskbayerItem.DominantMember.IsEmpty(), riskbayerItem.DominantMember)
                .AddParameter("DateEntryWork", DbType.DateTime, 9, riskbayerItem.DateEntryWork.IsEmpty(), riskbayerItem.DateEntryWork)
                .AddParameter("MonthlySalary", DbType.Decimal, 18, riskbayerItem.MonthlySalary.IsEmpty(), riskbayerItem.MonthlySalary)
                .AddParameter("Doctor", DbType.AnsiString, 120, riskbayerItem.Doctor.IsEmpty(), riskbayerItem.Doctor)
                .AddParameter("RefundBankCode", DbType.Decimal, 5, riskbayerItem.RefundBankCode.IsEmpty(), riskbayerItem.RefundBankCode)
                .AddParameter("RefundBankAccount", DbType.AnsiString, 22, riskbayerItem.RefundBankAccount.IsEmpty(), riskbayerItem.RefundBankAccount)
                .AddParameter("RefundBankAccountType", DbType.Decimal, 5, riskbayerItem.RefundBankAccountType.IsEmpty(), riskbayerItem.RefundBankAccountType)
                .AddParameter("RefundBankAccountCurrency", DbType.Decimal, 5, riskbayerItem.RefundBankAccountCurrency.IsEmpty(), riskbayerItem.RefundBankAccountCurrency)
                .AddParameter("PaymentModeType", DbType.Decimal, 5, riskbayerItem.PaymentModeType.IsEmpty(), riskbayerItem.PaymentModeType)
                .AddParameter("PaymentBankAccount", DbType.AnsiString, 22, riskbayerItem.PaymentBankAccount.IsEmpty(), riskbayerItem.PaymentBankAccount)
                .AddParameter("PaymentCardNumber", DbType.AnsiString, 22, riskbayerItem.PaymentCardNumber.IsEmpty(), riskbayerItem.PaymentCardNumber)
                .AddParameter("PaymentCardExpirationDate", DbType.DateTime, 9, riskbayerItem.PaymentCardExpirationDate.IsEmpty(), riskbayerItem.PaymentCardExpirationDate)
                .AddParameter("PaymentHolder", DbType.AnsiString, 60, riskbayerItem.PaymentHolder.IsEmpty(), riskbayerItem.PaymentHolder)
                .AddParameter("PaymentBankCode", DbType.Decimal, 5, riskbayerItem.PaymentBankCode.IsEmpty(), riskbayerItem.PaymentBankCode)
                .AddParameter("HasDigitalSignature", DbType.Decimal, 1, False, IIf(riskbayerItem.HasDigitalSignature, 1, 0))
                .AddParameter("ContinuityDate", DbType.DateTime, 9, riskbayerItem.ContinuityDate.IsEmpty(), riskbayerItem.ContinuityDate)
                .AddParameter("EmployeeNumber", DbType.AnsiString, 30, riskbayerItem.EmployeeNumber.IsEmpty(), riskbayerItem.EmployeeNumber)
                .AddParameter("UpdateUserCode", DbType.Decimal, 9, riskbayerItem.UpdateUserCode.IsEmpty(), riskbayerItem.UpdateUserCode)
                .AddParameter("UpdateDate", DbType.DateTime, 0, riskbayerItem.UpdateDate.IsEmpty(), riskbayerItem.UpdateDate)
                .AddParameter("Id", DbType.Decimal, 9, False, riskbayerItem.Id)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Elimina un registro en la tabla RiskBayer por medio de su clave primaria.
        ''' </summary>
        ''' <param name="id">Identificación única de la póliza.</param>
        ''' <param name="companyId">Identificación de la compañia propietaria.</param>
        ''' <returns>Cantidad de registros eliminados.</returns>
        Public Shared Function Delete(id As Integer, companyId As Integer) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("DELETE FROM RiskBayer " &
                                         "WHERE Id=@:Id AND CompanyId=@:CompanyId", "RiskBayer", "Research")
                .AddParameter("Id", DbType.Decimal, 9, False, id)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

#Region "Helper"

        ''' <summary>
        ''' Permite hacer el mapeo entre una fila de un datatable hacia una instancia de RiskBayer.
        ''' </summary>
        ''' <returns>Instancia de RiskBayer</returns>
        Private Shared Function DataRowMapper(itemRow As DataRow) As Architect.API.Insurance.Contracts.Policy.RiskBayer
            Return New Architect.API.Insurance.Contracts.Policy.RiskBayer With {.Id = itemRow.NumericValue("Id"), .CompanyId = itemRow.NumericValue("CompanyId"), .MainPolicyId = itemRow.StringValue("MainPolicyId"), .IssueDate = itemRow.DateTimeValue("IssueDate"), .ContractorName = itemRow.StringValue("ContractorName"), .IsLife = itemRow.StringValue("IsLife"), .IsHealth = itemRow.StringValue("IsHealth"), .SocialSecurity = itemRow.StringValue("SocialSecurity"), .DominantMember = itemRow.NumericValue("DominantMember"), .DateEntryWork = itemRow.DateTimeValue("DateEntryWork"), .MonthlySalary = itemRow.NumericValue("MonthlySalary"), .Doctor = itemRow.StringValue("Doctor"), .RefundBankCode = itemRow.NumericValue("RefundBankCode"), .RefundBankAccount = itemRow.StringValue("RefundBankAccount"), .RefundBankAccountType = itemRow.NumericValue("RefundBankAccountType"), .RefundBankAccountCurrency = itemRow.NumericValue("RefundBankAccountCurrency"), .PaymentModeType = itemRow.NumericValue("PaymentModeType"), .PaymentBankAccount = itemRow.StringValue("PaymentBankAccount"), .PaymentCardNumber = itemRow.StringValue("PaymentCardNumber"), .PaymentCardExpirationDate = itemRow.DateTimeValue("PaymentCardExpirationDate"), .PaymentHolder = itemRow.StringValue("PaymentHolder"), .PaymentBankCode = itemRow.NumericValue("PaymentBankCode"), .HasDigitalSignature = (itemRow.NumericValue("HasDigitalSignature") = 1), .ContinuityDate = itemRow.DateTimeValue("ContinuityDate"), .EmployeeNumber = itemRow.StringValue("EmployeeNumber"), .UpdateUserCode = itemRow.NumericValue("UpdateUserCode"), .UpdateUserName = itemRow.StringValue("UpdateUserName"), .UpdateDate = itemRow.DateTimeValue("UpdateDate")}
        End Function

#End Region

    End Class

End Namespace

