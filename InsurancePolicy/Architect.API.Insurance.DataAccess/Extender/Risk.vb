Imports Architect.Common.Proxy

Namespace Architect.API.Insurance.DataAccess.Policy

    Partial Public NotInheritable Class Risk


        Public Shared Function RetrieveLastIdByExecutiveUserCode(companyId As Integer, userId As Integer) As Integer
            Dim rows As Integer = 0

            With New DataManagerFactory("SELECT NVL(MAX(Id),0) " &
                                          "FROM Risk " &
                                         "WHERE CompanyId=@:CompanyId AND ExecutiveUserCode=@:UserId", "Risk", "Research")
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                .AddParameter("UserId", DbType.Decimal, 5, False, userId)
                rows = .QueryExecuteScalarToInteger
            End With
            Return rows
        End Function

        Public Shared Function RetrieveLastPolicyId(companyId As Integer) As Integer
            Dim rows As Integer = 0

            With New DataManagerFactory("SELECT NVL(MAX(Policyid),0) " &
                                          "FROM Risk " &
                                         "WHERE CompanyId=@:CompanyId", "Risk", "Research")
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                rows = .QueryExecuteScalarToInteger
            End With
            Return rows
        End Function

        Public Shared Function BuildFilter(filter As String, lineOfBusiness As Integer, product As Integer, status As String) As String
            Dim result As String = String.Empty

            'Permite filtrar por póliza, identificación, nombre, apellido
            'Email, telefono
            'Permite filtrar por certificado, identificación, número de cuenta
            If filter.IsNotEmpty Then
                If IsNumeric(filter) Then
                    result = " AND (P.POLICYID LIKE '%" & filter.ToUpper & "%' " &
                               "OR REPLACE(A.DOCUMENTNUMBER,'-','') LIKE '%" & filter.ToUpper & "%' " &
                               "OR A.PHONENUMBER LIKE '%" & filter.ToUpper & "%') "
                Else
                    result = " AND (UPPER(A.FIRSTNAME) LIKE '%" & filter.ToUpper & "%' " &
                               "OR UPPER(A.MIDDLENAME) LIKE '%" & filter.ToUpper & "%' " &
                               "OR UPPER(A.LASTNAME) LIKE '%" & filter.ToUpper & "%' " &
                               "OR UPPER(A.SECONDLASTNAME) LIKE '%" & filter.ToUpper & "%' " &
                               "OR A.DOCUMENTNUMBER LIKE '%" & filter.ToUpper & "%' " &
                               "OR UPPER(A.PRIMARYEMAILADDRESS) LIKE '%" & filter.ToUpper & "%') "
                End If

            End If

            If lineOfBusiness.IsNotEmpty Then
                result &= " AND P.LINEOFBUSINESSCODE=" & lineOfBusiness & " "
            End If
            If product.IsNotEmpty Then
                result &= " AND P.PRODUCTCODE=" & product & " "
            End If
            If status.IsNotEmpty Then
                result &= " AND P.STATUS IN (" & status & ") "
            End If

            Return result
        End Function

        ''' <summary>
        ''' Lista de pólizas existen según los criterio definidos en los filtros.
        ''' </summary>
        ''' <param name="companyId">Identificación de la compañia propietaria.</param>
        ''' <param name="filter">Permite filtrar por póliza o por la identificación, nombre, apellido, teléfono o correo electrónico del asegurado.</param>
        ''' <param name="lineOfBusiness">Opción para filtrar por ramo o linea de negocio.</param>
        ''' <param name="product">Opción para filtrar por producto vincaulado a un ramo.</param>
        ''' <param name="status">Opción para filtrar por multiples esta de las pólizas.</param>
        ''' <returns>Lista de pólizas según los criterio definidos en el filtro.</returns>
        Public Shared Function RetrieveView(companyId As Integer, filter As String, lineOfBusiness As Integer, product As Integer, status As String) As List(Of Contracts.Policy.PolicyView)
            Dim result As New List(Of Contracts.Policy.PolicyView)
            Dim selectDataTableItem As DataTable

            With New DataManagerFactory(My.Resources.Risk_RetrieveView.Replace("@FILTER@", BuildFilter(filter, lineOfBusiness, product, status)), "Risk", "Research")
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                selectDataTableItem = .QueryExecuteToTable(True)
            End With
            If Not IsNothing(selectDataTableItem) AndAlso selectDataTableItem.Rows.Count > 0 Then
                Dim newItem As Contracts.Policy.PolicyView
                For Each itemDataRow As DataRow In selectDataTableItem.Rows
                    newItem = New Contracts.Policy.PolicyView With {
                        .Id = itemDataRow.IntegerValue("ID"),
                        .IssueDate = itemDataRow.DateTimeValue("ISSUEDATE"),
                        .LineOfBusiness = itemDataRow.StringValue("LINEOFBUSINESS"),
                        .Product = itemDataRow.StringValue("PRODUCT"),
                        .PolicyId = itemDataRow.StringValue("POLICYID"),
                        .InsuredName = itemDataRow.StringValue("INSURED"),
                        .InsuredNumber = itemDataRow.StringValue("DOCUMENTNUMBER"),
                        .Module = itemDataRow.StringValue("MODULE"),
                        .EffectiveDate = itemDataRow.DateTimeValue("EFFECTIVEDATE"),
                        .EndingDate = itemDataRow.DateTimeValue("ENDINGDATE"),
                        .Status = itemDataRow.StringValue("STATUS"),
                        .StatusCode = itemDataRow.NumericValue("STATUSCODE"),
                        .Currency = itemDataRow.StringValue("CURRENCY"),
                        .CancellationDate = itemDataRow.DateTimeValue("CANCELLATIONDATE"),
                        .ReasonForStatus = itemDataRow.StringValue("REASONFORSTATUS"),
                        .InsuredAmount = itemDataRow.NumericValue("INSUREDAMOUNT"),
                        .AnnualPremium = itemDataRow.NumericValue("ANNUALPREMIUM")
                    }
                    result.Add(newItem)
                Next
            End If

            Return result
        End Function

        Public Shared Function RetrieveByKey(id As Integer, companyid As Integer) As Architect.API.Insurance.Contracts.Policy.Risk
            Dim rows As Data.DataTable = Nothing
            Dim result As Architect.API.Insurance.Contracts.Policy.Risk = Nothing
            With New DataManagerFactory("SELECT Id, OriginType, LineOfBusinessCode, ProductCode, PolicyId, Currency, ModuleCode, PaymentFrequency, IssueDate, EffectiveDate, EndingDate, InsuredAmountBase, InsuredAmountComplement, InsuredAmount, AnnualPremium, MonthlyPremium, Surcharge, Status, CancellationDate, ReasonForStatus, Risk.CompanyId, Risk.CustomData, Risk.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Risk.UpdateDate, CertificateId, Comments, Annotation, Risk.Reference, Risk.BranchOffice, ExecutiveUserCode " &
                                          "FROM Risk LEFT JOIN UserMember um ON um.UserId = Risk.UpdateUserCode " &
                                         "WHERE Id=@:Id AND Risk.CompanyId=@:CompanyId", "Risk", "Research")
                .AddParameter("Id", DbType.Decimal, 9, False, id)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyid)
                rows = .QueryExecuteToTable(True)
                If rows.IsNotEmpty AndAlso rows.Rows.Count <> 0 Then
                    result = DataRowMapper(rows.Rows(0))
                End If
            End With
            Return result
        End Function

        Public Shared Function RetrieveByDocumentNumber(companyid As Integer, lineOfBusinessCode As Integer, productCode As Integer, recordId As Integer, documentType As Integer, documentNumber As String) As Utilities.Contracts.LookUpValue
            Dim rows As Data.DataTable = Nothing
            Dim result As Utilities.Contracts.LookUpValue = Nothing

            With New DataManagerFactory("SELECT P.Status, LKS.Description StatusDesc " &
                                          "FROM RiskRoles JOIN Risk P ON P.Id=RiskRoles.PolicyId AND P.LineOfBusinessCode=@:LineOfBusinessCode AND P.ProductCode=@:ProductCode AND P.Status = 10 " &
                                          "LEFT JOIN LOOKUP LKS ON LKS.LOOKUPID = 2050 AND LKS.LANGUAGE=1 AND LKS.CODE = P.STATUS " &
                                         "WHERE P.CompanyId=@:CompanyId AND TYPE=2 AND DOCUMENTTYPE=@:DocumentType AND DOCUMENTNUMBER=@:DocumentNumber AND RiskRoles.PolicyId <> @:PolicyId ORDER BY P.ID DESC", "Risk", "Research")

                .AddParameter("LineOfBusinessCode", DbType.Decimal, 9, False, lineOfBusinessCode)
                .AddParameter("ProductCode", DbType.Decimal, 9, False, productCode)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyid)
                .AddParameter("DocumentType", DbType.Decimal, 8, False, documentType)
                .AddParameter("DocumentNumber", DbType.AnsiString, 20, False, documentNumber)
                .AddParameter("PolicyId", DbType.Decimal, 9, False, recordId)
                rows = .QueryExecuteToTable(True)
                If rows.IsNotEmpty AndAlso rows.Rows.Count > 0 Then
                    result = New Utilities.Contracts.LookUpValue With {.Code = rows.FirstRow.NumericValue("Status"), .Description = rows.FirstRow.StringValue("StatusDesc")}
                End If
            End With
            Return result
        End Function

        ''' <summary>
        ''' Actualiza el campo de referencia para un registro en la tabla Risk por medio de su clave primaria.
        ''' </summary>
        ''' <returns>Cantidad de registros actualizados.</returns>
        Public Shared Function UpdateReference(companyId As Integer, Id As Integer, reference As String) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("UPDATE Risk " &
                                           "SET Reference=@:Reference " &
                                         "WHERE Id=@:Id AND CompanyId=@:CompanyId", "Risk", "Research")
                .AddParameter("Reference", DbType.AnsiString, 36, False, reference)
                .AddParameter("Id", DbType.Decimal, 9, False, Id)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera una lista de registros en la tabla Risk.
        ''' </summary>
        ''' <param name="companyid"></param>
        ''' <param name="status"></param>
        ''' <returns>Lista de id</returns>
        Public Shared Function RetrieveByStatus(companyid As Integer, status As Integer) As List(Of Utilities.Contracts.LookUpValue)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Utilities.Contracts.LookUpValue)
            With New DataManagerFactory("SELECT Risk.Id, Risk.Reference " &
                                          "FROM Risk " &
                                          "JOIN RiskBayer ON RiskBayer.Id=Risk.Id AND NVL(RiskBayer.HasDigitalSignature,0)=0 " &
                                         "WHERE Risk.CompanyId=@:CompanyId AND Risk.Status=@:Status ", "Risk", "Research")
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyid)
                .AddParameter("Status", DbType.Decimal, 5, False, status)
                rows = .QueryExecuteToTable(True)
                If rows.IsNotEmpty AndAlso rows.Rows.Count <> 0 Then
                    For Each itemRow As DataRow In rows.Rows
                        result.Add(New Utilities.Contracts.LookUpValue() With {.Code = itemRow.NumericValue("Id").ToString(), .Description = itemRow.StringValue("Reference")})
                    Next
                End If
            End With
            Return result
        End Function

    End Class

End Namespace

