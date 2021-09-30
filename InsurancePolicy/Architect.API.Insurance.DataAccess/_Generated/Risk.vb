Imports Architect.Common.Proxy

Namespace Architect.API.Insurance.DataAccess.Policy

    ''' <summary>
    ''' Pólizas registradas.
    ''' </summary>
    Partial Public NotInheritable Class Risk

        ''' <summary>
        ''' Crea un registro en la tabla Risk.
        ''' </summary>
        ''' <param name="riskItem">Instancia de Risk</param>
        ''' <returns>Cantidad de registros creados.</returns>
        Public Shared Function Create(riskItem As Architect.API.Insurance.Contracts.Policy.Risk) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("INSERT INTO Risk " &
                                              "(Id, CompanyId, OriginType, LineOfBusinessCode, ProductCode, PolicyId, Currency, ModuleCode, PaymentFrequency, IssueDate, EffectiveDate, EndingDate, InsuredAmountBase, InsuredAmountComplement, InsuredAmount, AnnualPremium, MonthlyPremium, Surcharge, Status, CancellationDate, ReasonForStatus, CertificateId, Comments, Annotation, Reference, BranchOffice, ExecutiveUserCode, CustomData, UpdateUserCode, UpdateDate) " &
                                        "VALUES(@:Id, @:CompanyId, @:OriginType, @:LineOfBusinessCode, @:ProductCode, @:PolicyId, @:Currency, @:ModuleCode, @:PaymentFrequency, @:IssueDate, @:EffectiveDate, @:EndingDate, @:InsuredAmountBase, @:InsuredAmountComplement, @:InsuredAmount, @:AnnualPremium, @:MonthlyPremium, @:Surcharge, @:Status, @:CancellationDate, @:ReasonForStatus, @:CertificateId, @:Comments, @:Annotation, @:Reference, @:BranchOffice, @:ExecutiveUserCode, @:CustomData, @:UpdateUserCode, @:UpdateDate)", "Risk", "Research")
                .AddParameter("Id", DbType.Decimal, 9, riskItem.Id.IsEmpty(), riskItem.Id)
                .AddParameter("CompanyId", DbType.Decimal, 5, riskItem.CompanyId.IsEmpty(), riskItem.CompanyId)
                .AddParameter("OriginType", DbType.Decimal, 5, riskItem.OriginType.IsEmpty(), riskItem.OriginType)
                .AddParameter("LineOfBusinessCode", DbType.Decimal, 9, riskItem.LineOfBusinessCode.IsEmpty(), riskItem.LineOfBusinessCode)
                .AddParameter("ProductCode", DbType.Decimal, 9, riskItem.ProductCode.IsEmpty(), riskItem.ProductCode)
                .AddParameter("PolicyId", DbType.Decimal, 9, False, riskItem.PolicyId)
                .AddParameter("Currency", DbType.Decimal, 5, riskItem.Currency.IsEmpty(), riskItem.Currency)
                .AddParameter("ModuleCode", DbType.Decimal, 5, riskItem.ModuleCode.IsEmpty(), riskItem.ModuleCode)
                .AddParameter("PaymentFrequency", DbType.Decimal, 5, riskItem.PaymentFrequency.IsEmpty(), riskItem.PaymentFrequency)
                .AddParameter("IssueDate", DbType.DateTime, 9, riskItem.IssueDate.IsEmpty(), riskItem.IssueDate)
                .AddParameter("EffectiveDate", DbType.DateTime, 9, riskItem.EffectiveDate.IsEmpty(), riskItem.EffectiveDate)
                .AddParameter("EndingDate", DbType.DateTime, 9, riskItem.EndingDate.IsEmpty(), riskItem.EndingDate)
                .AddParameter("InsuredAmountBase", DbType.Decimal, 18, riskItem.InsuredAmountBase.IsEmpty(), riskItem.InsuredAmountBase)
                .AddParameter("InsuredAmountComplement", DbType.Decimal, 18, riskItem.InsuredAmountComplement.IsEmpty(), riskItem.InsuredAmountComplement)
                .AddParameter("InsuredAmount", DbType.Decimal, 18, riskItem.InsuredAmount.IsEmpty(), riskItem.InsuredAmount)
                .AddParameter("AnnualPremium", DbType.Decimal, 18, riskItem.AnnualPremium.IsEmpty(), riskItem.AnnualPremium)
                .AddParameter("MonthlyPremium", DbType.Decimal, 18, riskItem.MonthlyPremium.IsEmpty(), riskItem.MonthlyPremium)
                .AddParameter("Surcharge", DbType.Decimal, 18, riskItem.Surcharge.IsEmpty(), riskItem.Surcharge)
                .AddParameter("Status", DbType.Decimal, 5, riskItem.Status.IsEmpty(), riskItem.Status)
                .AddParameter("CancellationDate", DbType.DateTime, 9, riskItem.CancellationDate.IsEmpty(), riskItem.CancellationDate)
                .AddParameter("ReasonForStatus", DbType.Decimal, 5, riskItem.ReasonForStatus.IsEmpty(), riskItem.ReasonForStatus)
                .AddParameter("CertificateId", DbType.Decimal, 9, riskItem.CertificateId.IsEmpty(), riskItem.CertificateId)
                .AddParameter("Comments", DbType.AnsiString, 350, riskItem.Comments.IsEmpty(), riskItem.Comments)
                .AddParameter("Annotation", DbType.AnsiString, 350, riskItem.Annotation.IsEmpty(), riskItem.Annotation)
                .AddParameter("Reference", DbType.AnsiString, 36, riskItem.Reference.IsEmpty(), riskItem.Reference)
                .AddParameter("BranchOffice", DbType.Decimal, 5, riskItem.BranchOffice.IsEmpty(), riskItem.BranchOffice)
                .AddParameter("ExecutiveUserCode", DbType.Decimal, 9, riskItem.ExecutiveUserCode.IsEmpty(), riskItem.ExecutiveUserCode)
                .AddParameter("CustomData", DbType.AnsiString, 2000, riskItem.CustomData.IsEmpty(), riskItem.CustomData)
                .AddParameter("UpdateUserCode", DbType.Decimal, 9, riskItem.UpdateUserCode.IsEmpty(), riskItem.UpdateUserCode)
                .AddParameter("UpdateDate", DbType.DateTime, 0, riskItem.UpdateDate.IsEmpty(), riskItem.UpdateDate)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera un registro en la tabla Risk por medio de su clave primaria.
        ''' </summary>
        ''' <param name="id">Identificación única de la póliza.</param>
        ''' <param name="companyId">Identificación de la compañia propietaria.</param>
        ''' <returns>Instancia de Risk</returns>
        Public Shared Function Retrieve(id As Integer, companyId As Integer) As Architect.API.Insurance.Contracts.Policy.Risk
            Dim rows As Data.DataTable = Nothing
            Dim result As Architect.API.Insurance.Contracts.Policy.Risk = Nothing
            With New DataManagerFactory("SELECT Id, Risk.CompanyId, OriginType, LineOfBusinessCode, ProductCode, PolicyId, Currency, ModuleCode, PaymentFrequency, IssueDate, EffectiveDate, EndingDate, InsuredAmountBase, InsuredAmountComplement, InsuredAmount, AnnualPremium, MonthlyPremium, Surcharge, Status, CancellationDate, ReasonForStatus, CertificateId, Comments, Annotation, Risk.Reference, Risk.BranchOffice, ExecutiveUserCode, Risk.CustomData, Risk.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Risk.UpdateDate " &
                                          "FROM Risk LEFT JOIN UserMember um ON um.UserId = Risk.UpdateUserCode " &
                                         "WHERE Risk.Id=@:Id AND Risk.CompanyId=@:CompanyId", "Risk", "Research")
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
        ''' Último valor asignado a clave unica de la tabla Risk.
        ''' </summary>
        ''' <returns>Último valor asignado.</returns>
        Public Shared Function RetrieveLastKey() As Integer
            Dim rows As Integer = 0

            With New DataManagerFactory("SELECT NVL(MAX(Id),0) " &
                                          "FROM Risk", "Risk", "Research")
                rows = .QueryExecuteScalarToInteger
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Actualiza un registro en la tabla Risk por medio de su clave primaria.
        ''' </summary>
        ''' <param name="riskItem">Instancia de Risk</param>
        ''' <returns>Cantidad de registros actualizados.</returns>
        Public Shared Function Update(riskItem As Architect.API.Insurance.Contracts.Policy.Risk) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("UPDATE Risk " &
                                           "SET CompanyId=@:CompanyId, OriginType=@:OriginType, LineOfBusinessCode=@:LineOfBusinessCode, ProductCode=@:ProductCode, PolicyId=@:PolicyId, Currency=@:Currency, ModuleCode=@:ModuleCode, PaymentFrequency=@:PaymentFrequency, IssueDate=@:IssueDate, EffectiveDate=@:EffectiveDate, EndingDate=@:EndingDate, InsuredAmountBase=@:InsuredAmountBase, InsuredAmountComplement=@:InsuredAmountComplement, InsuredAmount=@:InsuredAmount, AnnualPremium=@:AnnualPremium, MonthlyPremium=@:MonthlyPremium, Surcharge=@:Surcharge, Status=@:Status, CancellationDate=@:CancellationDate, ReasonForStatus=@:ReasonForStatus, CertificateId=@:CertificateId, Comments=@:Comments, Annotation=@:Annotation, Reference=@:Reference, BranchOffice=@:BranchOffice, ExecutiveUserCode=@:ExecutiveUserCode, CustomData=@:CustomData, UpdateUserCode=@:UpdateUserCode, UpdateDate=@:UpdateDate " &
                                         "WHERE Id=@:Id", "Risk", "Research")
                .AddParameter("CompanyId", DbType.Decimal, 5, riskItem.CompanyId.IsEmpty(), riskItem.CompanyId)
                .AddParameter("OriginType", DbType.Decimal, 5, riskItem.OriginType.IsEmpty(), riskItem.OriginType)
                .AddParameter("LineOfBusinessCode", DbType.Decimal, 9, riskItem.LineOfBusinessCode.IsEmpty(), riskItem.LineOfBusinessCode)
                .AddParameter("ProductCode", DbType.Decimal, 9, riskItem.ProductCode.IsEmpty(), riskItem.ProductCode)
                .AddParameter("PolicyId", DbType.Decimal, 9, False, riskItem.PolicyId)
                .AddParameter("Currency", DbType.Decimal, 5, riskItem.Currency.IsEmpty(), riskItem.Currency)
                .AddParameter("ModuleCode", DbType.Decimal, 5, riskItem.ModuleCode.IsEmpty(), riskItem.ModuleCode)
                .AddParameter("PaymentFrequency", DbType.Decimal, 5, riskItem.PaymentFrequency.IsEmpty(), riskItem.PaymentFrequency)
                .AddParameter("IssueDate", DbType.DateTime, 9, riskItem.IssueDate.IsEmpty(), riskItem.IssueDate)
                .AddParameter("EffectiveDate", DbType.DateTime, 9, riskItem.EffectiveDate.IsEmpty(), riskItem.EffectiveDate)
                .AddParameter("EndingDate", DbType.DateTime, 9, riskItem.EndingDate.IsEmpty(), riskItem.EndingDate)
                .AddParameter("InsuredAmountBase", DbType.Decimal, 18, riskItem.InsuredAmountBase.IsEmpty(), riskItem.InsuredAmountBase)
                .AddParameter("InsuredAmountComplement", DbType.Decimal, 18, riskItem.InsuredAmountComplement.IsEmpty(), riskItem.InsuredAmountComplement)
                .AddParameter("InsuredAmount", DbType.Decimal, 18, riskItem.InsuredAmount.IsEmpty(), riskItem.InsuredAmount)
                .AddParameter("AnnualPremium", DbType.Decimal, 18, riskItem.AnnualPremium.IsEmpty(), riskItem.AnnualPremium)
                .AddParameter("MonthlyPremium", DbType.Decimal, 18, riskItem.MonthlyPremium.IsEmpty(), riskItem.MonthlyPremium)
                .AddParameter("Surcharge", DbType.Decimal, 18, riskItem.Surcharge.IsEmpty(), riskItem.Surcharge)
                .AddParameter("Status", DbType.Decimal, 5, riskItem.Status.IsEmpty(), riskItem.Status)
                .AddParameter("CancellationDate", DbType.DateTime, 9, riskItem.CancellationDate.IsEmpty(), riskItem.CancellationDate)
                .AddParameter("ReasonForStatus", DbType.Decimal, 5, riskItem.ReasonForStatus.IsEmpty(), riskItem.ReasonForStatus)
                .AddParameter("CertificateId", DbType.Decimal, 9, riskItem.CertificateId.IsEmpty(), riskItem.CertificateId)
                .AddParameter("Comments", DbType.AnsiString, 350, riskItem.Comments.IsEmpty(), riskItem.Comments)
                .AddParameter("Annotation", DbType.AnsiString, 350, riskItem.Annotation.IsEmpty(), riskItem.Annotation)
                .AddParameter("Reference", DbType.AnsiString, 36, riskItem.Reference.IsEmpty(), riskItem.Reference)
                .AddParameter("BranchOffice", DbType.Decimal, 5, riskItem.BranchOffice.IsEmpty(), riskItem.BranchOffice)
                .AddParameter("ExecutiveUserCode", DbType.Decimal, 9, riskItem.ExecutiveUserCode.IsEmpty(), riskItem.ExecutiveUserCode)
                .AddParameter("CustomData", DbType.AnsiString, 2000, riskItem.CustomData.IsEmpty(), riskItem.CustomData)
                .AddParameter("UpdateUserCode", DbType.Decimal, 9, riskItem.UpdateUserCode.IsEmpty(), riskItem.UpdateUserCode)
                .AddParameter("UpdateDate", DbType.DateTime, 0, riskItem.UpdateDate.IsEmpty(), riskItem.UpdateDate)
                .AddParameter("Id", DbType.Decimal, 9, False, riskItem.Id)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Elimina un registro en la tabla Risk por medio de su clave primaria.
        ''' </summary>
        ''' <param name="id">Identificación única de la póliza.</param>
        ''' <param name="companyId">Identificación de la compañia propietaria.</param>
        ''' <returns>Cantidad de registros eliminados.</returns>
        Public Shared Function Delete(id As Integer, companyId As Integer) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("DELETE FROM Risk " &
                                         "WHERE Id=@:Id AND CompanyId=@:CompanyId", "Risk", "Research")
                .AddParameter("Id", DbType.Decimal, 9, False, id)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera una lista de registros en la tabla Risk.
        ''' </summary>
        ''' <param name="id"></param>
        ''' <param name="companyid"></param>
        ''' <returns>Lista de instancias de Risk</returns>
        Public Shared Function RetrieveByIdCompanyId(id As Integer, companyid As Integer) As List(Of Architect.API.Insurance.Contracts.Policy.Risk)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.API.Insurance.Contracts.Policy.Risk)
            With New DataManagerFactory("Select Id, Risk.CompanyId, OriginType, LineOfBusinessCode, ProductCode, PolicyId, Currency, ModuleCode, PaymentFrequency, IssueDate, EffectiveDate, EndingDate, InsuredAmountBase, InsuredAmountComplement, InsuredAmount, AnnualPremium, MonthlyPremium, Surcharge, Status, CancellationDate, ReasonForStatus, CertificateId, Comments, Annotation, Risk.Reference, Risk.BranchOffice, ExecutiveUserCode, Risk.CustomData, Risk.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Risk.UpdateDate " &
                                          "FROM Risk LEFT JOIN UserMember um ON um.UserId = Risk.UpdateUserCode " &
                                         "WHERE Id=@:Id AND Risk.CompanyId=@:CompanyId", "Risk", "Research")
                .AddParameter("Id", DbType.Decimal, 9, False, id)
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
        ''' Elimina un registro en la tabla Risk por medio de su clave primaria.
        ''' </summary>
        ''' <param name="id"></param>
        ''' <param name="companyid"></param>
        ''' <returns>Cantidad de registros eliminados.</returns>
        Public Shared Function DeleteByIdCompanyId(id As Integer, companyid As Integer) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("DELETE FROM Risk " &
                                         "WHERE Id=@:Id AND CompanyId=@:CompanyId", "Risk", "Research")
                .AddParameter("Id", DbType.Decimal, 9, False, id)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyid)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

#Region "Helper"

        ''' <summary>
        ''' Permite hacer el mapeo entre una fila de un datatable hacia una instancia de Risk.
        ''' </summary>
        ''' <returns>Instancia de Risk</returns>
        Private Shared Function DataRowMapper(itemRow As DataRow) As Architect.API.Insurance.Contracts.Policy.Risk
            Return New Architect.API.Insurance.Contracts.Policy.Risk With {.Id = itemRow.NumericValue("Id"), .CompanyId = itemRow.NumericValue("CompanyId"), .OriginType = itemRow.NumericValue("OriginType"), .LineOfBusinessCode = itemRow.NumericValue("LineOfBusinessCode"), .ProductCode = itemRow.NumericValue("ProductCode"), .PolicyId = itemRow.NumericValue("PolicyId"), .Currency = itemRow.NumericValue("Currency"), .ModuleCode = itemRow.NumericValue("ModuleCode"), .PaymentFrequency = itemRow.NumericValue("PaymentFrequency"), .IssueDate = itemRow.DateTimeValue("IssueDate"), .EffectiveDate = itemRow.DateTimeValue("EffectiveDate"), .EndingDate = itemRow.DateTimeValue("EndingDate"), .InsuredAmountBase = itemRow.NumericValue("InsuredAmountBase"), .InsuredAmountComplement = itemRow.NumericValue("InsuredAmountComplement"), .InsuredAmount = itemRow.NumericValue("InsuredAmount"), .AnnualPremium = itemRow.NumericValue("AnnualPremium"), .MonthlyPremium = itemRow.NumericValue("MonthlyPremium"), .Surcharge = itemRow.NumericValue("Surcharge"), .Status = itemRow.NumericValue("Status"), .CancellationDate = itemRow.DateTimeValue("CancellationDate"), .ReasonForStatus = itemRow.NumericValue("ReasonForStatus"), .CertificateId = itemRow.NumericValue("CertificateId"), .Comments = itemRow.StringValue("Comments"), .Annotation = itemRow.StringValue("Annotation"), .Reference = itemRow.StringValue("Reference"), .BranchOffice = itemRow.NumericValue("BranchOffice"), .ExecutiveUserCode = itemRow.NumericValue("ExecutiveUserCode"), .CustomData = itemRow.StringValue("CustomData"), .UpdateUserCode = itemRow.NumericValue("UpdateUserCode"), .UpdateUserName = itemRow.StringValue("UpdateUserName"), .UpdateDate = itemRow.DateTimeValue("UpdateDate")}
        End Function

#End Region

    End Class

End Namespace

