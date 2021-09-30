Imports Architect.Common.Proxy

Namespace Architect.API.Insurance.DataAccess.Policy

    ''' <summary>
    ''' 
    ''' </summary>
    Partial Public NotInheritable Class RiskRoles

        ''' <summary>
        ''' Crea un registro en la tabla RiskRoles.
        ''' </summary>
        ''' <param name="riskrolesItem">Instancia de RiskRoles</param>
        ''' <returns>Instancia de RiskRoles</returns>
        Public Shared Function Create(riskrolesItem As Architect.API.Insurance.Contracts.Policy.RiskRoles) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("INSERT INTO RiskRoles " &
                                              "(RoleId, PolicyId, Type, DocumentType, DocumentNumber, FirstName, MiddleName, LastName, SecondLastName, BirthDate, Gender, CivilStatus, Height, Weight, BloodPressureSystolic, BloodPressureDiastolic, Occupation, RetirementModality, RetirementCause, CountryOfNationality, CountryOfBirth, ClientType, Relationship, ParticipationRate, PrimaryEmailAddress, TypeOfAddress, Province, Canton, District, AddressDetail, PhoneType, PhoneNumber, CompanyId, CustomData, UpdateUserCode, UpdateDate, BankAccount, InclusionDate, ExclusionDate, AgeAtInclusion) " &
                                        "VALUES(@:RoleId, @:PolicyId, @:Type, @:DocumentType, @:DocumentNumber, @:FirstName, @:MiddleName, @:LastName, @:SecondLastName, @:BirthDate, @:Gender, @:CivilStatus, @:Height, @:Weight, @:BloodPressureSystolic, @:BloodPressureDiastolic, @:Occupation, @:RetirementModality, @:RetirementCause, @:CountryOfNationality, @:CountryOfBirth, @:ClientType, @:Relationship, @:ParticipationRate, @:PrimaryEmailAddress, @:TypeOfAddress, @:Province, @:Canton, @:District, @:AddressDetail, @:PhoneType, @:PhoneNumber, @:CompanyId, @:CustomData, @:UpdateUserCode, @:UpdateDate, @:BankAccount, @:InclusionDate, @:ExclusionDate, @:AgeAtInclusion)", "RiskRoles", "Research")
                .AddParameter("RoleId", DbType.Decimal, 9, riskrolesItem.RoleId.IsEmpty(), riskrolesItem.RoleId)
                .AddParameter("PolicyId", DbType.Decimal, 9, riskrolesItem.PolicyId.IsEmpty(), riskrolesItem.PolicyId)
                .AddParameter("Type", DbType.Decimal, 9, riskrolesItem.Type.IsEmpty(), riskrolesItem.Type)
                .AddParameter("DocumentType", DbType.Decimal, 8, riskrolesItem.DocumentType.IsEmpty(), riskrolesItem.DocumentType)
                .AddParameter("DocumentNumber", DbType.AnsiString, 20, riskrolesItem.DocumentNumber.IsEmpty(), riskrolesItem.DocumentNumber)
                .AddParameter("FirstName", DbType.AnsiString, 40, riskrolesItem.FirstName.IsEmpty(), riskrolesItem.FirstName)
                .AddParameter("MiddleName", DbType.AnsiString, 40, riskrolesItem.MiddleName.IsEmpty(), riskrolesItem.MiddleName)
                .AddParameter("LastName", DbType.AnsiString, 40, riskrolesItem.LastName.IsEmpty(), riskrolesItem.LastName)
                .AddParameter("SecondLastName", DbType.AnsiString, 40, riskrolesItem.SecondLastName.IsEmpty(), riskrolesItem.SecondLastName)
                .AddParameter("BirthDate", DbType.DateTime, 9, riskrolesItem.BirthDate.IsEmpty(), riskrolesItem.BirthDate)
                .AddParameter("Gender", DbType.Decimal, 5, riskrolesItem.Gender.IsEmpty(), riskrolesItem.Gender)
                .AddParameter("CivilStatus", DbType.Decimal, 5, riskrolesItem.CivilStatus.IsEmpty(), riskrolesItem.CivilStatus)
                .AddParameter("Height", DbType.Decimal, 5, riskrolesItem.Height.IsEmpty(), riskrolesItem.Height)
                .AddParameter("Weight", DbType.Decimal, 5, riskrolesItem.Weight.IsEmpty(), riskrolesItem.Weight)
                .AddParameter("BloodPressureSystolic", DbType.Decimal, 3, riskrolesItem.BloodPressureSystolic.IsEmpty(), riskrolesItem.BloodPressureSystolic)
                .AddParameter("BloodPressureDiastolic", DbType.Decimal, 3, riskrolesItem.BloodPressureDiastolic.IsEmpty(), riskrolesItem.BloodPressureDiastolic)
                .AddParameter("Occupation", DbType.AnsiString, 40, riskrolesItem.Occupation.IsEmpty(), riskrolesItem.Occupation)
                .AddParameter("RetirementModality", DbType.Decimal, 5, riskrolesItem.RetirementModality.IsEmpty(), riskrolesItem.RetirementModality)
                .AddParameter("RetirementCause", DbType.AnsiString, 40, riskrolesItem.RetirementCause.IsEmpty(), riskrolesItem.RetirementCause)
                .AddParameter("CountryOfNationality", DbType.Decimal, 5, riskrolesItem.CountryOfNationality.IsEmpty(), riskrolesItem.CountryOfNationality)
                .AddParameter("CountryOfBirth", DbType.Decimal, 5, riskrolesItem.CountryOfBirth.IsEmpty(), riskrolesItem.CountryOfBirth)
                .AddParameter("ClientType", DbType.Decimal, 9, riskrolesItem.ClientType.IsEmpty(), riskrolesItem.ClientType)
                .AddParameter("Relationship", DbType.Decimal, 5, riskrolesItem.Relationship.IsEmpty(), riskrolesItem.Relationship)
                .AddParameter("ParticipationRate", DbType.Decimal, 3, riskrolesItem.ParticipationRate.IsEmpty(), riskrolesItem.ParticipationRate)
                .AddParameter("PrimaryEmailAddress", DbType.AnsiString, 80, riskrolesItem.PrimaryEmailAddress.IsEmpty(), riskrolesItem.PrimaryEmailAddress)
                .AddParameter("TypeOfAddress", DbType.Decimal, 5, riskrolesItem.TypeOfAddress.IsEmpty(), riskrolesItem.TypeOfAddress)
                .AddParameter("Province", DbType.Decimal, 5, riskrolesItem.Province.IsEmpty(), riskrolesItem.Province)
                .AddParameter("Canton", DbType.Decimal, 5, riskrolesItem.Canton.IsEmpty(), riskrolesItem.Canton)
                .AddParameter("District", DbType.Decimal, 5, riskrolesItem.District.IsEmpty(), riskrolesItem.District)
                .AddParameter("AddressDetail", DbType.AnsiString, 120, riskrolesItem.AddressDetail.IsEmpty(), riskrolesItem.AddressDetail)
                .AddParameter("PhoneType", DbType.Decimal, 5, riskrolesItem.PhoneType.IsEmpty(), riskrolesItem.PhoneType)
                .AddParameter("PhoneNumber", DbType.AnsiString, 20, riskrolesItem.PhoneNumber.IsEmpty(), riskrolesItem.PhoneNumber)
                .AddParameter("CompanyId", DbType.Decimal, 5, riskrolesItem.CompanyId.IsEmpty(), riskrolesItem.CompanyId)
                .AddParameter("CustomData", DbType.AnsiString, 2000, riskrolesItem.CustomData.IsEmpty(), riskrolesItem.CustomData)
                .AddParameter("UpdateUserCode", DbType.Decimal, 9, riskrolesItem.UpdateUserCode.IsEmpty(), riskrolesItem.UpdateUserCode)
                .AddParameter("UpdateDate", DbType.DateTime, 0, riskrolesItem.UpdateDate.IsEmpty(), riskrolesItem.UpdateDate)
                .AddParameter("BankAccount", DbType.AnsiString, 22, riskrolesItem.BankAccount.IsEmpty(), riskrolesItem.BankAccount)
                .AddParameter("InclusionDate", DbType.DateTime, 9, riskrolesItem.InclusionDate.IsEmpty(), riskrolesItem.InclusionDate)
                .AddParameter("ExclusionDate", DbType.DateTime, 9, riskrolesItem.ExclusionDate.IsEmpty(), riskrolesItem.ExclusionDate)
                .AddParameter("AgeAtInclusion", DbType.Decimal, 3, riskrolesItem.AgeAtInclusion.IsEmpty(), riskrolesItem.AgeAtInclusion)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Verifica si existe un registro en la tabla RiskRoles por medio de su clave primaria.
        ''' </summary>
        ''' <returns>Verdadero si existe el registro, en caso contrario falso.</returns>
        Public Shared Function RetrieveLastKey() As Integer
            Dim rows As Integer = 0

            With New DataManagerFactory("SELECT NVL(MAX(RoleId),0) " &
                                          "FROM RiskRoles", "RiskRoles", "Research")
                rows = .QueryExecuteScalarToInteger
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Actualiza un registro en la tabla RiskRoles por medio de su clave primaria.
        ''' </summary>
        ''' <param name="riskrolesItem">Instancia de RiskRoles</param>
        ''' <returns>Cantidad de registros actualizados.</returns>
        Public Shared Function Update(riskrolesItem As Architect.API.Insurance.Contracts.Policy.RiskRoles) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("UPDATE RiskRoles " &
                                           "SET PolicyId=@:PolicyId, Type=@:Type, DocumentType=@:DocumentType, DocumentNumber=@:DocumentNumber, FirstName=@:FirstName, MiddleName=@:MiddleName, LastName=@:LastName, SecondLastName=@:SecondLastName, BirthDate=@:BirthDate, Gender=@:Gender, CivilStatus=@:CivilStatus, Height=@:Height, Weight=@:Weight, BloodPressureSystolic=@:BloodPressureSystolic, BloodPressureDiastolic=@:BloodPressureDiastolic, Occupation=@:Occupation, RetirementModality=@:RetirementModality, RetirementCause=@:RetirementCause, CountryOfNationality=@:CountryOfNationality, CountryOfBirth=@:CountryOfBirth, ClientType=@:ClientType, Relationship=@:Relationship, ParticipationRate=@:ParticipationRate, PrimaryEmailAddress=@:PrimaryEmailAddress, TypeOfAddress=@:TypeOfAddress, Province=@:Province, Canton=@:Canton, District=@:District, AddressDetail=@:AddressDetail, PhoneType=@:PhoneType, PhoneNumber=@:PhoneNumber, CompanyId=@:CompanyId, CustomData=@:CustomData, UpdateUserCode=@:UpdateUserCode, UpdateDate=@:UpdateDate, BankAccount=@:BankAccount, InclusionDate=@:InclusionDate, ExclusionDate=@:ExclusionDate, AgeAtInclusion=@:AgeAtInclusion " &
                                         "WHERE RoleId=@:RoleId", "RiskRoles", "Research")
                .AddParameter("PolicyId", DbType.Decimal, 9, riskrolesItem.PolicyId.IsEmpty(), riskrolesItem.PolicyId)
                .AddParameter("Type", DbType.Decimal, 9, riskrolesItem.Type.IsEmpty(), riskrolesItem.Type)
                .AddParameter("DocumentType", DbType.Decimal, 8, riskrolesItem.DocumentType.IsEmpty(), riskrolesItem.DocumentType)
                .AddParameter("DocumentNumber", DbType.AnsiString, 20, riskrolesItem.DocumentNumber.IsEmpty(), riskrolesItem.DocumentNumber)
                .AddParameter("FirstName", DbType.AnsiString, 40, riskrolesItem.FirstName.IsEmpty(), riskrolesItem.FirstName)
                .AddParameter("MiddleName", DbType.AnsiString, 40, riskrolesItem.MiddleName.IsEmpty(), riskrolesItem.MiddleName)
                .AddParameter("LastName", DbType.AnsiString, 40, riskrolesItem.LastName.IsEmpty(), riskrolesItem.LastName)
                .AddParameter("SecondLastName", DbType.AnsiString, 40, riskrolesItem.SecondLastName.IsEmpty(), riskrolesItem.SecondLastName)
                .AddParameter("BirthDate", DbType.DateTime, 9, riskrolesItem.BirthDate.IsEmpty(), riskrolesItem.BirthDate)
                .AddParameter("Gender", DbType.Decimal, 5, riskrolesItem.Gender.IsEmpty(), riskrolesItem.Gender)
                .AddParameter("CivilStatus", DbType.Decimal, 5, riskrolesItem.CivilStatus.IsEmpty(), riskrolesItem.CivilStatus)
                .AddParameter("Height", DbType.Decimal, 5, riskrolesItem.Height.IsEmpty(), riskrolesItem.Height)
                .AddParameter("Weight", DbType.Decimal, 5, riskrolesItem.Weight.IsEmpty(), riskrolesItem.Weight)
                .AddParameter("BloodPressureSystolic", DbType.Decimal, 3, riskrolesItem.BloodPressureSystolic.IsEmpty(), riskrolesItem.BloodPressureSystolic)
                .AddParameter("BloodPressureDiastolic", DbType.Decimal, 3, riskrolesItem.BloodPressureDiastolic.IsEmpty(), riskrolesItem.BloodPressureDiastolic)
                .AddParameter("Occupation", DbType.AnsiString, 40, riskrolesItem.Occupation.IsEmpty(), riskrolesItem.Occupation)
                .AddParameter("RetirementModality", DbType.Decimal, 5, riskrolesItem.RetirementModality.IsEmpty(), riskrolesItem.RetirementModality)
                .AddParameter("RetirementCause", DbType.AnsiString, 40, riskrolesItem.RetirementCause.IsEmpty(), riskrolesItem.RetirementCause)
                .AddParameter("CountryOfNationality", DbType.Decimal, 5, riskrolesItem.CountryOfNationality.IsEmpty(), riskrolesItem.CountryOfNationality)
                .AddParameter("CountryOfBirth", DbType.Decimal, 5, riskrolesItem.CountryOfBirth.IsEmpty(), riskrolesItem.CountryOfBirth)
                .AddParameter("ClientType", DbType.Decimal, 9, riskrolesItem.ClientType.IsEmpty(), riskrolesItem.ClientType)
                .AddParameter("Relationship", DbType.Decimal, 5, riskrolesItem.Relationship.IsEmpty(), riskrolesItem.Relationship)
                .AddParameter("ParticipationRate", DbType.Decimal, 3, riskrolesItem.ParticipationRate.IsEmpty(), riskrolesItem.ParticipationRate)
                .AddParameter("PrimaryEmailAddress", DbType.AnsiString, 80, riskrolesItem.PrimaryEmailAddress.IsEmpty(), riskrolesItem.PrimaryEmailAddress)
                .AddParameter("TypeOfAddress", DbType.Decimal, 5, riskrolesItem.TypeOfAddress.IsEmpty(), riskrolesItem.TypeOfAddress)
                .AddParameter("Province", DbType.Decimal, 5, riskrolesItem.Province.IsEmpty(), riskrolesItem.Province)
                .AddParameter("Canton", DbType.Decimal, 5, riskrolesItem.Canton.IsEmpty(), riskrolesItem.Canton)
                .AddParameter("District", DbType.Decimal, 5, riskrolesItem.District.IsEmpty(), riskrolesItem.District)
                .AddParameter("AddressDetail", DbType.AnsiString, 120, riskrolesItem.AddressDetail.IsEmpty(), riskrolesItem.AddressDetail)
                .AddParameter("PhoneType", DbType.Decimal, 5, riskrolesItem.PhoneType.IsEmpty(), riskrolesItem.PhoneType)
                .AddParameter("PhoneNumber", DbType.AnsiString, 20, riskrolesItem.PhoneNumber.IsEmpty(), riskrolesItem.PhoneNumber)
                .AddParameter("CompanyId", DbType.Decimal, 5, riskrolesItem.CompanyId.IsEmpty(), riskrolesItem.CompanyId)
                .AddParameter("CustomData", DbType.AnsiString, 2000, riskrolesItem.CustomData.IsEmpty(), riskrolesItem.CustomData)
                .AddParameter("UpdateUserCode", DbType.Decimal, 9, riskrolesItem.UpdateUserCode.IsEmpty(), riskrolesItem.UpdateUserCode)
                .AddParameter("UpdateDate", DbType.DateTime, 0, riskrolesItem.UpdateDate.IsEmpty(), riskrolesItem.UpdateDate)
                .AddParameter("BankAccount", DbType.AnsiString, 22, riskrolesItem.BankAccount.IsEmpty(), riskrolesItem.BankAccount)
                .AddParameter("InclusionDate", DbType.DateTime, 9, riskrolesItem.InclusionDate.IsEmpty(), riskrolesItem.InclusionDate)
                .AddParameter("ExclusionDate", DbType.DateTime, 9, riskrolesItem.ExclusionDate.IsEmpty(), riskrolesItem.ExclusionDate)
                .AddParameter("AgeAtInclusion", DbType.Decimal, 3, riskrolesItem.AgeAtInclusion.IsEmpty(), riskrolesItem.AgeAtInclusion)
                .AddParameter("RoleId", DbType.Decimal, 9, False, riskrolesItem.RoleId)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Elimina un registro en la tabla RiskRoles por medio de su clave primaria.
        ''' </summary>
        ''' <param name="roleid"></param>
        ''' <returns>Cantidad de registros eliminados.</returns>
        Public Shared Function Delete(roleid As Integer) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("DELETE FROM RiskRoles " &
                                         "WHERE RoleId=@:RoleId", "RiskRoles", "Research")
                .AddParameter("RoleId", DbType.Decimal, 9, False, roleid)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera una lista de registros en la tabla RiskRoles.
        ''' </summary>
        ''' <param name="policyid"></param>
        ''' <returns>Lista de instancias de RiskRoles</returns>
        Public Shared Function RetrieveByPolicyId(policyid As Integer) As List(Of Architect.API.Insurance.Contracts.Policy.RiskRoles)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.API.Insurance.Contracts.Policy.RiskRoles)
            With New DataManagerFactory("Select RoleId, PolicyId, Type, DocumentType, DocumentNumber, RiskRoles.FirstName, MiddleName, RiskRoles.LastName, SecondLastName, BirthDate, Gender, CivilStatus, Height, Weight, BloodPressureSystolic, BloodPressureDiastolic, Occupation, RetirementModality, RetirementCause, CountryOfNationality, CountryOfBirth, ClientType, Relationship, ParticipationRate, PrimaryEmailAddress, TypeOfAddress, Province, Canton, District, AddressDetail, PhoneType, PhoneNumber, RiskRoles.CompanyId, RiskRoles.CustomData, RiskRoles.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, RiskRoles.UpdateDate, BankAccount, InclusionDate, ExclusionDate, AgeAtInclusion " &
                                          "FROM RiskRoles LEFT JOIN UserMember um ON um.UserId = RiskRoles.UpdateUserCode " &
                                         "WHERE PolicyId=@:PolicyId", "RiskRoles", "Research")
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
        ''' Elimina un registro en la tabla RiskRoles por medio de su clave primaria.
        ''' </summary>
        ''' <param name="policyid"></param>
        ''' <returns>Cantidad de registros eliminados.</returns>
        Public Shared Function DeleteByPolicyId(policyid As Integer) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("DELETE FROM RiskRoles " &
                                         "WHERE PolicyId=@:PolicyId", "RiskRoles", "Research")
                .AddParameter("PolicyId", DbType.Decimal, 9, False, policyid)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera una lista de registros en la tabla RiskRoles.
        ''' </summary>
        ''' <param name="policyid"></param>
        ''' <param name="companyid"></param>
        ''' <returns>Lista de instancias de RiskRoles</returns>
        Public Shared Function RetrieveByPolicyIdCompanyId(policyid As Integer, companyid As Integer) As List(Of Architect.API.Insurance.Contracts.Policy.RiskRoles)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.API.Insurance.Contracts.Policy.RiskRoles)
            With New DataManagerFactory("Select RoleId, PolicyId, Type, DocumentType, DocumentNumber, RiskRoles.FirstName, MiddleName, RiskRoles.LastName, SecondLastName, RiskRoles.BirthDate, Gender, CivilStatus, Height, Weight, BloodPressureSystolic, BloodPressureDiastolic, Occupation, RetirementModality, RetirementCause, CountryOfNationality, CountryOfBirth, ClientType, Relationship, ParticipationRate, PrimaryEmailAddress, TypeOfAddress, Province, Canton, District, AddressDetail, PhoneType, RiskRoles.PhoneNumber, RiskRoles.CompanyId, RiskRoles.CustomData, RiskRoles.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, RiskRoles.UpdateDate, BankAccount, InclusionDate, ExclusionDate, AgeAtInclusion " &
                                          "FROM RiskRoles LEFT JOIN UserMember um ON um.UserId = RiskRoles.UpdateUserCode " &
                                         "WHERE PolicyId=@:PolicyId AND RiskRoles.CompanyId=@:CompanyId", "RiskRoles", "Research")
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
        ''' Elimina un registro en la tabla RiskRoles por medio de su clave primaria.
        ''' </summary>
        ''' <param name="policyid"></param>
        ''' <param name="companyid"></param>
        ''' <returns>Cantidad de registros eliminados.</returns>
        Public Shared Function DeleteByPolicyIdCompanyId(policyid As Integer, companyid As Integer) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("DELETE FROM RiskRoles " &
                                         "WHERE PolicyId=@:PolicyId AND CompanyId=@:CompanyId", "RiskRoles", "Research")
                .AddParameter("PolicyId", DbType.Decimal, 9, False, policyid)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyid)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

#Region "Helper"

        ''' <summary>
        ''' Permite hacer el mapeo entre una fila de un datatable hacia una instancia de RiskRoles.
        ''' </summary>
        ''' <returns>Instancia de RiskRoles</returns>
        Private Shared Function DataRowMapper(itemRow As DataRow) As Architect.API.Insurance.Contracts.Policy.RiskRoles
            Return New Architect.API.Insurance.Contracts.Policy.RiskRoles With {.RoleId = itemRow.NumericValue("RoleId"), .PolicyId = itemRow.NumericValue("PolicyId"), .Type = itemRow.NumericValue("Type"), .DocumentType = itemRow.NumericValue("DocumentType"), .DocumentNumber = itemRow.StringValue("DocumentNumber"), .FirstName = itemRow.StringValue("FirstName"), .MiddleName = itemRow.StringValue("MiddleName"), .LastName = itemRow.StringValue("LastName"), .SecondLastName = itemRow.StringValue("SecondLastName"), .BirthDate = itemRow.DateTimeValue("BirthDate"), .Gender = itemRow.NumericValue("Gender"), .CivilStatus = itemRow.NumericValue("CivilStatus"), .Height = itemRow.NumericValue("Height"), .Weight = itemRow.NumericValue("Weight"), .BloodPressureSystolic = itemRow.NumericValue("BloodPressureSystolic"), .BloodPressureDiastolic = itemRow.NumericValue("BloodPressureDiastolic"), .Occupation = itemRow.StringValue("Occupation"), .RetirementModality = itemRow.NumericValue("RetirementModality"), .RetirementCause = itemRow.StringValue("RetirementCause"), .CountryOfNationality = itemRow.NumericValue("CountryOfNationality"), .CountryOfBirth = itemRow.NumericValue("CountryOfBirth"), .ClientType = itemRow.NumericValue("ClientType"), .Relationship = itemRow.NumericValue("Relationship"), .ParticipationRate = itemRow.NumericValue("ParticipationRate"), .PrimaryEmailAddress = itemRow.StringValue("PrimaryEmailAddress"), .TypeOfAddress = itemRow.NumericValue("TypeOfAddress"), .Province = itemRow.NumericValue("Province"), .Canton = itemRow.NumericValue("Canton"), .District = itemRow.NumericValue("District"), .AddressDetail = itemRow.StringValue("AddressDetail"), .PhoneType = itemRow.NumericValue("PhoneType"), .PhoneNumber = itemRow.StringValue("PhoneNumber"), .CompanyId = itemRow.NumericValue("CompanyId"), .CustomData = itemRow.StringValue("CustomData"), .UpdateUserCode = itemRow.NumericValue("UpdateUserCode"), .UpdateUserName = itemRow.StringValue("UpdateUserName"), .UpdateDate = itemRow.DateTimeValue("UpdateDate"), .BankAccount = itemRow.StringValue("BankAccount"), .InclusionDate = itemRow.DateTimeValue("InclusionDate"), .ExclusionDate = itemRow.DateTimeValue("ExclusionDate"), .AgeAtInclusion = itemRow.NumericValue("AgeAtInclusion")}
        End Function

#End Region

    End Class

End Namespace

