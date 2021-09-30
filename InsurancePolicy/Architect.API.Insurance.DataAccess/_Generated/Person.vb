Imports Architect.Common.Proxy

Namespace Architect.API.Insurance.DataAccess.Policy

    ''' <summary>
    ''' Personas
    ''' </summary>
    Partial Public NotInheritable Class Person

        ''' <summary>
        ''' Crea un registro en la tabla Person.
        ''' </summary>
        ''' <param name="personItem">Instancia de Person</param>
        ''' <returns>Cantidad de registros creados.</returns>
        Public Shared Function Create(personItem As Architect.API.Insurance.Contracts.Policy.Person) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("INSERT INTO Person " &
                                              "(Id, CompanyId, DocumentType, DocumentNumber, FirstName, MiddleName, LastName, SecondLastName, BirthDate, Gender, CivilStatus, Height, Weight, BloodPressureSystolic, BloodPressureDiastolic, Occupation, RetirementModality, RetirementCause, CountryOfNationality, CountryOfBirth, PrimaryEmailAddress, SecondaryEmailAddress, Province, Canton, District, AddressDetail, PhoneNumberMobile, PhoneNumberHome, PhoneNumberOffice, InclusionDate, Reference, CustomData, UpdateUserCode, UpdateDate) " &
                                        "VALUES(@:Id, @:CompanyId, @:DocumentType, @:DocumentNumber, @:FirstName, @:MiddleName, @:LastName, @:SecondLastName, @:BirthDate, @:Gender, @:CivilStatus, @:Height, @:Weight, @:BloodPressureSystolic, @:BloodPressureDiastolic, @:Occupation, @:RetirementModality, @:RetirementCause, @:CountryOfNationality, @:CountryOfBirth, @:PrimaryEmailAddress, @:SecondaryEmailAddress, @:Province, @:Canton, @:District, @:AddressDetail, @:PhoneNumberMobile, @:PhoneNumberHome, @:PhoneNumberOffice, @:InclusionDate, @:Reference, @:CustomData, @:UpdateUserCode, @:UpdateDate)", "Person", "Research")
                .AddParameter("Id", DbType.Decimal, 9, personItem.Id.IsEmpty(), personItem.Id)
                .AddParameter("CompanyId", DbType.Decimal, 5, personItem.CompanyId.IsEmpty(), personItem.CompanyId)
                .AddParameter("DocumentType", DbType.Decimal, 8, personItem.DocumentType.IsEmpty(), personItem.DocumentType)
                .AddParameter("DocumentNumber", DbType.AnsiString, 20, personItem.DocumentNumber.IsEmpty(), personItem.DocumentNumber)
                .AddParameter("FirstName", DbType.AnsiString, 40, personItem.FirstName.IsEmpty(), personItem.FirstName)
                .AddParameter("MiddleName", DbType.AnsiString, 40, personItem.MiddleName.IsEmpty(), personItem.MiddleName)
                .AddParameter("LastName", DbType.AnsiString, 40, personItem.LastName.IsEmpty(), personItem.LastName)
                .AddParameter("SecondLastName", DbType.AnsiString, 40, personItem.SecondLastName.IsEmpty(), personItem.SecondLastName)
                .AddParameter("BirthDate", DbType.DateTime, 9, personItem.BirthDate.IsEmpty(), personItem.BirthDate)
                .AddParameter("Gender", DbType.Decimal, 5, personItem.Gender.IsEmpty(), personItem.Gender)
                .AddParameter("CivilStatus", DbType.Decimal, 5, personItem.CivilStatus.IsEmpty(), personItem.CivilStatus)
                .AddParameter("Height", DbType.Decimal, 5, personItem.Height.IsEmpty(), personItem.Height)
                .AddParameter("Weight", DbType.Decimal, 5, personItem.Weight.IsEmpty(), personItem.Weight)
                .AddParameter("BloodPressureSystolic", DbType.Decimal, 3, personItem.BloodPressureSystolic.IsEmpty(), personItem.BloodPressureSystolic)
                .AddParameter("BloodPressureDiastolic", DbType.Decimal, 3, personItem.BloodPressureDiastolic.IsEmpty(), personItem.BloodPressureDiastolic)
                .AddParameter("Occupation", DbType.AnsiString, 40, personItem.Occupation.IsEmpty(), personItem.Occupation)
                .AddParameter("RetirementModality", DbType.Decimal, 5, personItem.RetirementModality.IsEmpty(), personItem.RetirementModality)
                .AddParameter("RetirementCause", DbType.AnsiString, 40, personItem.RetirementCause.IsEmpty(), personItem.RetirementCause)
                .AddParameter("CountryOfNationality", DbType.Decimal, 5, personItem.CountryOfNationality.IsEmpty(), personItem.CountryOfNationality)
                .AddParameter("CountryOfBirth", DbType.Decimal, 5, personItem.CountryOfBirth.IsEmpty(), personItem.CountryOfBirth)
                .AddParameter("PrimaryEmailAddress", DbType.AnsiString, 80, personItem.PrimaryEmailAddress.IsEmpty(), personItem.PrimaryEmailAddress)
                .AddParameter("SecondaryEmailAddress", DbType.AnsiString, 80, personItem.SecondaryEmailAddress.IsEmpty(), personItem.SecondaryEmailAddress)
                .AddParameter("Province", DbType.Decimal, 5, personItem.Province.IsEmpty(), personItem.Province)
                .AddParameter("Canton", DbType.Decimal, 5, personItem.Canton.IsEmpty(), personItem.Canton)
                .AddParameter("District", DbType.Decimal, 5, personItem.District.IsEmpty(), personItem.District)
                .AddParameter("AddressDetail", DbType.AnsiString, 200, personItem.AddressDetail.IsEmpty(), personItem.AddressDetail)
                .AddParameter("PhoneNumberMobile", DbType.AnsiString, 20, personItem.PhoneNumberMobile.IsEmpty(), personItem.PhoneNumberMobile)
                .AddParameter("PhoneNumberHome", DbType.AnsiString, 20, personItem.PhoneNumberHome.IsEmpty(), personItem.PhoneNumberHome)
                .AddParameter("PhoneNumberOffice", DbType.AnsiString, 20, personItem.PhoneNumberOffice.IsEmpty(), personItem.PhoneNumberOffice)
                .AddParameter("InclusionDate", DbType.DateTime, 9, personItem.InclusionDate.IsEmpty(), personItem.InclusionDate)
                .AddParameter("Reference", DbType.AnsiString, 36, personItem.Reference.IsEmpty(), personItem.Reference)
                .AddParameter("CustomData", DbType.AnsiString, 2000, personItem.CustomData.IsEmpty(), personItem.CustomData)
                .AddParameter("UpdateUserCode", DbType.Decimal, 9, personItem.UpdateUserCode.IsEmpty(), personItem.UpdateUserCode)
                .AddParameter("UpdateDate", DbType.DateTime, 0, personItem.UpdateDate.IsEmpty(), personItem.UpdateDate)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera un registro en la tabla Person por medio de su clave primaria.
        ''' </summary>
        ''' <param name="id">Identificación única del rol.</param>
        ''' <param name="companyId">Identificación de la compañia propietaria.</param>
        ''' <returns>Instancia de Person</returns>
        Public Shared Function Retrieve(id As Integer, companyId As Integer) As Architect.API.Insurance.Contracts.Policy.Person
            Dim rows As Data.DataTable = Nothing
            Dim result As Architect.API.Insurance.Contracts.Policy.Person = Nothing
            With New DataManagerFactory("SELECT Id, Person.CompanyId, DocumentType, DocumentNumber, Person.FirstName, MiddleName, Person.LastName, SecondLastName, Person.BirthDate, Gender, CivilStatus, Height, Weight, BloodPressureSystolic, BloodPressureDiastolic, Occupation, RetirementModality, RetirementCause, CountryOfNationality, CountryOfBirth, PrimaryEmailAddress, SecondaryEmailAddress, Province, Canton, District, AddressDetail, PhoneNumberMobile, PhoneNumberHome, PhoneNumberOffice, InclusionDate, Person.Reference, Person.CustomData, Person.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Person.UpdateDate " &
                                          "FROM Person LEFT JOIN UserMember um ON um.UserId = Person.UpdateUserCode " &
                                         "WHERE Person.Id=@:Id AND Person.CompanyId=@:CompanyId", "Person", "Research")
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
        ''' Recupera una lista de registros en la tabla Person.
        ''' </summary>
        ''' <param name="companyId">Identificación de la compañia propietaria.</param>
        ''' <param name="filter">Filtro personalizado.</param>
        ''' <returns>Lista de instancias de Person</returns>
        Public Shared Function RetrieveAll(companyId As Integer, filter As String) As List(Of Architect.API.Insurance.Contracts.Policy.Person)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.API.Insurance.Contracts.Policy.Person)
            With New DataManagerFactory("SELECT Id, Person.CompanyId, DocumentType, DocumentNumber, Person.FirstName, MiddleName, Person.LastName, SecondLastName, Person.BirthDate, Gender, CivilStatus, Height, Weight, BloodPressureSystolic, BloodPressureDiastolic, Occupation, RetirementModality, RetirementCause, CountryOfNationality, CountryOfBirth, PrimaryEmailAddress, SecondaryEmailAddress, Province, Canton, District, AddressDetail, PhoneNumberMobile, PhoneNumberHome, PhoneNumberOffice, InclusionDate, Person.Reference, Person.CustomData, Person.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Person.UpdateDate " &
                                          "FROM Person LEFT JOIN UserMember um ON um.UserId = Person.UpdateUserCode " &
                                         "WHERE Person.CompanyId=@:CompanyId", "Person", "Research")
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

        ''' <summary>
        ''' Último valor asignado a clave unica de la tabla Person.
        ''' </summary>
        ''' <returns>Último valor asignado.</returns>
        Public Shared Function RetrieveLastKey() As Integer
            Dim rows As Integer = 0

            With New DataManagerFactory("SELECT NVL(MAX(Id),0) " &
                                          "FROM Person", "Person", "Research")
                rows = .QueryExecuteScalarToInteger
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Actualiza un registro en la tabla Person por medio de su clave primaria.
        ''' </summary>
        ''' <param name="personItem">Instancia de Person</param>
        ''' <returns>Cantidad de registros actualizados.</returns>
        Public Shared Function Update(personItem As Architect.API.Insurance.Contracts.Policy.Person) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("UPDATE Person " &
                                           "SET CompanyId=@:CompanyId, DocumentType=@:DocumentType, DocumentNumber=@:DocumentNumber, FirstName=@:FirstName, MiddleName=@:MiddleName, LastName=@:LastName, SecondLastName=@:SecondLastName, BirthDate=@:BirthDate, Gender=@:Gender, CivilStatus=@:CivilStatus, Height=@:Height, Weight=@:Weight, BloodPressureSystolic=@:BloodPressureSystolic, BloodPressureDiastolic=@:BloodPressureDiastolic, Occupation=@:Occupation, RetirementModality=@:RetirementModality, RetirementCause=@:RetirementCause, CountryOfNationality=@:CountryOfNationality, CountryOfBirth=@:CountryOfBirth, PrimaryEmailAddress=@:PrimaryEmailAddress, SecondaryEmailAddress=@:SecondaryEmailAddress, Province=@:Province, Canton=@:Canton, District=@:District, AddressDetail=@:AddressDetail, PhoneNumberMobile=@:PhoneNumberMobile, PhoneNumberHome=@:PhoneNumberHome, PhoneNumberOffice=@:PhoneNumberOffice, InclusionDate=@:InclusionDate, Reference=@:Reference, CustomData=@:CustomData, UpdateUserCode=@:UpdateUserCode, UpdateDate=@:UpdateDate " &
                                         "WHERE Id=@:Id", "Person", "Research")
                .AddParameter("CompanyId", DbType.Decimal, 5, personItem.CompanyId.IsEmpty(), personItem.CompanyId)
                .AddParameter("DocumentType", DbType.Decimal, 8, personItem.DocumentType.IsEmpty(), personItem.DocumentType)
                .AddParameter("DocumentNumber", DbType.AnsiString, 20, personItem.DocumentNumber.IsEmpty(), personItem.DocumentNumber)
                .AddParameter("FirstName", DbType.AnsiString, 40, personItem.FirstName.IsEmpty(), personItem.FirstName)
                .AddParameter("MiddleName", DbType.AnsiString, 40, personItem.MiddleName.IsEmpty(), personItem.MiddleName)
                .AddParameter("LastName", DbType.AnsiString, 40, personItem.LastName.IsEmpty(), personItem.LastName)
                .AddParameter("SecondLastName", DbType.AnsiString, 40, personItem.SecondLastName.IsEmpty(), personItem.SecondLastName)
                .AddParameter("BirthDate", DbType.DateTime, 9, personItem.BirthDate.IsEmpty(), personItem.BirthDate)
                .AddParameter("Gender", DbType.Decimal, 5, personItem.Gender.IsEmpty(), personItem.Gender)
                .AddParameter("CivilStatus", DbType.Decimal, 5, personItem.CivilStatus.IsEmpty(), personItem.CivilStatus)
                .AddParameter("Height", DbType.Decimal, 5, personItem.Height.IsEmpty(), personItem.Height)
                .AddParameter("Weight", DbType.Decimal, 5, personItem.Weight.IsEmpty(), personItem.Weight)
                .AddParameter("BloodPressureSystolic", DbType.Decimal, 3, personItem.BloodPressureSystolic.IsEmpty(), personItem.BloodPressureSystolic)
                .AddParameter("BloodPressureDiastolic", DbType.Decimal, 3, personItem.BloodPressureDiastolic.IsEmpty(), personItem.BloodPressureDiastolic)
                .AddParameter("Occupation", DbType.AnsiString, 40, personItem.Occupation.IsEmpty(), personItem.Occupation)
                .AddParameter("RetirementModality", DbType.Decimal, 5, personItem.RetirementModality.IsEmpty(), personItem.RetirementModality)
                .AddParameter("RetirementCause", DbType.AnsiString, 40, personItem.RetirementCause.IsEmpty(), personItem.RetirementCause)
                .AddParameter("CountryOfNationality", DbType.Decimal, 5, personItem.CountryOfNationality.IsEmpty(), personItem.CountryOfNationality)
                .AddParameter("CountryOfBirth", DbType.Decimal, 5, personItem.CountryOfBirth.IsEmpty(), personItem.CountryOfBirth)
                .AddParameter("PrimaryEmailAddress", DbType.AnsiString, 80, personItem.PrimaryEmailAddress.IsEmpty(), personItem.PrimaryEmailAddress)
                .AddParameter("SecondaryEmailAddress", DbType.AnsiString, 80, personItem.SecondaryEmailAddress.IsEmpty(), personItem.SecondaryEmailAddress)
                .AddParameter("Province", DbType.Decimal, 5, personItem.Province.IsEmpty(), personItem.Province)
                .AddParameter("Canton", DbType.Decimal, 5, personItem.Canton.IsEmpty(), personItem.Canton)
                .AddParameter("District", DbType.Decimal, 5, personItem.District.IsEmpty(), personItem.District)
                .AddParameter("AddressDetail", DbType.AnsiString, 200, personItem.AddressDetail.IsEmpty(), personItem.AddressDetail)
                .AddParameter("PhoneNumberMobile", DbType.AnsiString, 20, personItem.PhoneNumberMobile.IsEmpty(), personItem.PhoneNumberMobile)
                .AddParameter("PhoneNumberHome", DbType.AnsiString, 20, personItem.PhoneNumberHome.IsEmpty(), personItem.PhoneNumberHome)
                .AddParameter("PhoneNumberOffice", DbType.AnsiString, 20, personItem.PhoneNumberOffice.IsEmpty(), personItem.PhoneNumberOffice)
                .AddParameter("InclusionDate", DbType.DateTime, 9, personItem.InclusionDate.IsEmpty(), personItem.InclusionDate)
                .AddParameter("Reference", DbType.AnsiString, 36, personItem.Reference.IsEmpty(), personItem.Reference)
                .AddParameter("CustomData", DbType.AnsiString, 2000, personItem.CustomData.IsEmpty(), personItem.CustomData)
                .AddParameter("UpdateUserCode", DbType.Decimal, 9, personItem.UpdateUserCode.IsEmpty(), personItem.UpdateUserCode)
                .AddParameter("UpdateDate", DbType.DateTime, 0, personItem.UpdateDate.IsEmpty(), personItem.UpdateDate)
                .AddParameter("Id", DbType.Decimal, 9, False, personItem.Id)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Elimina un registro en la tabla Person por medio de su clave primaria.
        ''' </summary>
        ''' <param name="id">Identificación única del rol.</param>
        ''' <param name="companyId">Identificación de la compañia propietaria.</param>
        ''' <returns>Cantidad de registros eliminados.</returns>
        Public Shared Function Delete(id As Integer, companyId As Integer) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("DELETE FROM Person " &
                                         "WHERE Id=@:Id AND CompanyId=@:CompanyId", "Person", "Research")
                .AddParameter("Id", DbType.Decimal, 9, False, id)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera la cantidad de registros existentes en la tabla Person por medio de su clave primaria.
        ''' </summary>
        ''' <param name="id"></param>
        ''' <param name="companyId">Identificación de la compañia propietaria.</param>
        ''' <returns>Cantidad de registros encontrados.</returns>
        Public Shared Function Count(id As Integer, companyId As Integer) As Integer
            Dim rows As Integer = 0

            With New DataManagerFactory("SELECT COUNT(Id) " &
                                          "FROM Person " &
                                         "WHERE Id=@:Id AND CompanyId=@:CompanyId", "Person", "Research")
                .AddParameter("Id", DbType.Decimal, 9, False, id)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                rows = .QueryExecuteScalarToInteger
            End With
            Return rows
        End Function

#Region "Helper"

        ''' <summary>
        ''' Permite hacer el mapeo entre una fila de un datatable hacia una instancia de Person.
        ''' </summary>
        ''' <returns>Instancia de Person</returns>
        Private Shared Function DataRowMapper(itemRow As DataRow) As Architect.API.Insurance.Contracts.Policy.Person
            Return New Architect.API.Insurance.Contracts.Policy.Person With {.Id = itemRow.NumericValue("Id"), .CompanyId = itemRow.NumericValue("CompanyId"), .DocumentType = itemRow.NumericValue("DocumentType"), .DocumentNumber = itemRow.StringValue("DocumentNumber"), .FirstName = itemRow.StringValue("FirstName"), .MiddleName = itemRow.StringValue("MiddleName"), .LastName = itemRow.StringValue("LastName"), .SecondLastName = itemRow.StringValue("SecondLastName"), .BirthDate = itemRow.DateTimeValue("BirthDate"), .Gender = itemRow.NumericValue("Gender"), .CivilStatus = itemRow.NumericValue("CivilStatus"), .Height = itemRow.NumericValue("Height"), .Weight = itemRow.NumericValue("Weight"), .BloodPressureSystolic = itemRow.NumericValue("BloodPressureSystolic"), .BloodPressureDiastolic = itemRow.NumericValue("BloodPressureDiastolic"), .Occupation = itemRow.StringValue("Occupation"), .RetirementModality = itemRow.NumericValue("RetirementModality"), .RetirementCause = itemRow.StringValue("RetirementCause"), .CountryOfNationality = itemRow.NumericValue("CountryOfNationality"), .CountryOfBirth = itemRow.NumericValue("CountryOfBirth"), .PrimaryEmailAddress = itemRow.StringValue("PrimaryEmailAddress"), .SecondaryEmailAddress = itemRow.StringValue("SecondaryEmailAddress"), .Province = itemRow.NumericValue("Province"), .Canton = itemRow.NumericValue("Canton"), .District = itemRow.NumericValue("District"), .AddressDetail = itemRow.StringValue("AddressDetail"), .PhoneNumberMobile = itemRow.StringValue("PhoneNumberMobile"), .PhoneNumberHome = itemRow.StringValue("PhoneNumberHome"), .PhoneNumberOffice = itemRow.StringValue("PhoneNumberOffice"), .InclusionDate = itemRow.DateTimeValue("InclusionDate"), .Reference = itemRow.StringValue("Reference"), .CustomData = itemRow.StringValue("CustomData"), .UpdateUserCode = itemRow.NumericValue("UpdateUserCode"), .UpdateUserName = itemRow.StringValue("UpdateUserName"), .UpdateDate = itemRow.DateTimeValue("UpdateDate")}
        End Function

#End Region

    End Class

End Namespace

